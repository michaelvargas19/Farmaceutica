/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.es.proveedores.persistencia;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import javeriana.es.proveedores.dto.DTOOferta;
import javeriana.es.proveedores.dto.DTOResultado;

/**
 *
 * @author Usuario
 */
public class TransaccionOferta {
    Connection conn;    
    String result;     
    
    public TransaccionOferta(){
        
    }
    
    public DTOResultado ejecutar(DTOOferta oferta) throws Exception{
        DTOResultado result = new DTOResultado();
        String message = null;
        try{
            //validar transaccion
            
            conn = Conexion.getInstance().getConex();
            conn.setAutoCommit(false);
            
            //cuantas ofertas puede enviar
            //validar estado y vigencia del despacho
            
            long idOferta=  insertOferta(oferta);
            
            if(idOferta > 0 == true){
                result.setCodigo("200");
                result.setMensaje("Oferta guardada con exito: " + idOferta);
                conn.commit();
            }else{
                result.setCodigo("000");
                result.setMensaje("No se guardo la oferta");
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
    
    private long insertOferta(DTOOferta oferta) throws Exception{        
        long result = 0;  
        String message = null;       
        Statement stmt = null;
        try{           
            
            String sql = "INSERT INTO \"Ofertas\" (\"IdUsuario\", \"FechaPostulacion\", \"Precio\", \"IdEstado\", \"IdDespacho\") "
                    + "VALUES (" +oferta.getIdUsuario() + ", now(), " + oferta.getPrecio()+ ", 1 , " + oferta.getIdDespacho() + ")";
            
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
    
    
}
