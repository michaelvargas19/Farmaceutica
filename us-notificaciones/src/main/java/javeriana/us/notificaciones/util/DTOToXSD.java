/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.us.notificaciones.util;

import javeriana.us.notificaciones.dto.DTOResultado;
import usnotificaciones.javeriana.service.v1_0_0.notificaciones.EnviarNotificacionResponse;

/**
 *
 * @author Usuario
 */
public class DTOToXSD {
    public static EnviarNotificacionResponse resultadoDTOToEnviarNotificacionResponse(DTOResultado xsd){
        EnviarNotificacionResponse dto = new EnviarNotificacionResponse();
        if(xsd != null){
            dto.setCodigo(xsd.getCodigo());
            dto.setMensaje(xsd.getMensaje());
        }
        return dto;
    }
}
