/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.us.notificaciones.util;

import javeriana.us.notificaciones.dto.DTONotificacion;
import usnotificaciones.javeriana.service.v1_0_0.notificaciones.Notificacion;

/**
 *
 * @author Usuario
 */
public class XSDToDTO {
    
    public static DTONotificacion notificacionToDTONotificacion(Notificacion xsd){
        DTONotificacion dto = new DTONotificacion();
        if(xsd != null){
            dto.setAsunto(xsd.getAsunto());
            dto.setDestino(xsd.getDestino());
            dto.setIdTipoNotificacion(xsd.getIdTipoNotificacion());
            dto.setMensaje(xsd.getMensaje());
            dto.setMensajeCorto(xsd.getMensajeCorto());
        }
        return dto;
    }
    
    
}
