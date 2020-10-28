/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.es.proveedores.util;

import esproveedores.javeriana.service.v1_0_0.b2b.NotificarCatalogoResponse;
import esproveedores.javeriana.service.v1_0_0.b2b.NotificarOfertaResponse;
import javeriana.es.proveedores.dto.DTOResultado;



/**
 *
 * @author Usuario
 */
public class DTOToXSD {
    
    public static NotificarCatalogoResponse resultadoDTOToNotificarCatalogo(DTOResultado dto){
        NotificarCatalogoResponse xsd = new NotificarCatalogoResponse();
        if(dto != null){
            xsd.setCodigo(dto.getCodigo());
            xsd.setMensaje(dto.getMensaje());
        }
        return xsd;
    }
    
    public static NotificarOfertaResponse resultadoDTOToNotificarOferta(DTOResultado dto){
        NotificarOfertaResponse xsd = new NotificarOfertaResponse();
        if(dto != null){
            xsd.setCodigo(dto.getCodigo());
            xsd.setMensaje(dto.getMensaje());
        }
        return xsd;
    }
}
