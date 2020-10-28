/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.es.proveedores.persistencia;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.List;
import javeriana.es.proveedores.dto.DTOCatalogo;
import javeriana.es.proveedores.dto.DTOResultado;
import javeriana.es.proveedores.dto.DTOServicio;

/**
 *
 * @author Usuario
 */
public class TransaccionCatalogo {
    Connection conn;    
    String result;     
    
    public TransaccionCatalogo(){
        
    }
    
    public DTOResultado ejecutar(DTOCatalogo catalogo) throws Exception{
        DTOResultado result = new DTOResultado();
        String message = null;
        try{
            //validar transaccion
            
            conn = Conexion.getInstance().getConex();
            conn.setAutoCommit(false);
            
            //validar provedor
            //validar ciudades
            
            long idCatalogo = insertCatalogo(catalogo);
            
            if(insertServicios(idCatalogo, catalogo.getServicios()) == true ){
                result.setCodigo("200");
                result.setMensaje("Catalogo guardado con exito.");
                conn.commit();
            }else{
                result.setCodigo("000");
                result.setMensaje("No se guardo el catalogo.");
                conn.rollback();
            }           
        } catch(Exception ex){            
            message = "Rollback: " + ex.getMessage();
            conn.rollback();
        } finally {      
            if (conn != null) {
                try { conn.close(); } catch (SQLException e) { message = e.getMessage(); }
                conn = null;
            }
        }
        if(message != null){
            throw new Exception(message);
        }
        return result;
    }    
    
    private long insertCatalogo(DTOCatalogo catalogo) throws Exception{        
        long result = 0;  
        String message = null;       
        Statement stmt = null;
        try{           
            
            String sql = "INSERT INTO \"Catalogos\" (\"IdUsuario\", \"Nombre\", \"FechaCreacion\") "
                    + "VALUES (" +catalogo.getIdUsuario() + ", '" + catalogo.getNombre() + "', now())";
            
            stmt = conn.createStatement();
            
            stmt.executeUpdate(sql, Statement.RETURN_GENERATED_KEYS);
            ResultSet rs = stmt.getGeneratedKeys();
            if(rs.next()){
                result = rs.getLong(1);
            }
            
            rs.close();
            rs = null;
            
            stmt.close();
            stmt = null;            
        }catch(Exception ex){       
            message = "Error creando la transaccion: " + ex.getMessage();
        } finally {            
            if (stmt != null) {
                try { stmt.close(); } catch (SQLException e) { message = e.getMessage(); }
                stmt = null;
            }
        }
        if(message != null){
            throw new Exception(message);
        }
        return result;
    
    }
    
    private boolean insertServicios(long idCatalogo, List<DTOServicio> servicios) throws Exception{
        boolean result = false;  
        String message = null;
        PreparedStatement prStmt = null;
       
        try{
            String sql = "INSERT INTO \"Servicios\" (\"IdCatalogo\", \"Nombre\", \"Descripcion\", \"IdCiudadOrigen\", \"IdMunicipioOrigen\", \"IdMunicipioDestino\", \"Precio\") "
                    + "VALUES (?, ?, ?, ?, ?, ?, ?)"; 
            
            prStmt = conn.prepareStatement(sql); 
            for (DTOServicio servicio : servicios) {                
                prStmt.setLong(1, idCatalogo);            
                prStmt.setString(2, servicio.getNombre());
                prStmt.setString(3, servicio.getDescripcion());  
                
                prStmt.setLong(4, Long.parseLong(servicio.getIdCiudadOrigen()));
                prStmt.setLong(5, Long.parseLong(servicio.getIdCiudadOrigen()));
                prStmt.setLong(6, Long.parseLong(servicio.getIdCiudadDestino()));
                prStmt.setDouble(7, servicio.getPrecio());
                prStmt.execute();
                if(prStmt.getUpdateCount() > 0 ){
                    result = true;
                }else{
                    result = false;
                }  
            }
            
        }catch(Exception ex){      
            message = "Error guardando servicios: " + ex.getMessage();
        } finally {            
            if (prStmt != null) {
                try { prStmt.close(); } catch (SQLException e) { message = e.getMessage(); }
                prStmt = null;
            }
        }
        if(message != null){
            result = false;
            throw new Exception(message);
        }
        return result;
    }
    
    
}
