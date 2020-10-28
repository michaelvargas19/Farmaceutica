/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.es.proveedores.negocio;

import java.util.logging.Level;
import java.util.logging.Logger;
import javeriana.es.proveedores.dto.DTOCatalogo;
import javeriana.es.proveedores.dto.DTOOferta;
import javeriana.es.proveedores.dto.DTOResultado;
import javeriana.es.proveedores.persistencia.TransaccionCatalogo;
import javeriana.es.proveedores.persistencia.TransaccionOferta;

/**
 *
 * @author Usuario
 */
public class NegocioProveedor {
    
    public NegocioProveedor(){
    
    }
    
    public DTOResultado notificarCatalogo(DTOCatalogo parameters) {
        TransaccionCatalogo tx = new TransaccionCatalogo();
        DTOResultado resultado = new DTOResultado();
        try {
            resultado = tx.ejecutar(parameters);
        } catch (Exception ex) {
            resultado.setCodigo("000");
            resultado.setMensaje(ex.getMessage());
            Logger.getLogger(NegocioProveedor.class.getName()).log(Level.SEVERE, null, ex);
        }
        return resultado;
    }

    public DTOResultado notificarOferta(DTOOferta parameters) {
        TransaccionOferta tx = new TransaccionOferta();
        DTOResultado resultado = new DTOResultado();
        try {
            resultado = tx.ejecutar(parameters);
        } catch (Exception ex) {
            resultado.setCodigo("000");
            resultado.setMensaje(ex.getMessage());
            Logger.getLogger(NegocioProveedor.class.getName()).log(Level.SEVERE, null, ex);
        }
        return resultado;
    }
}
