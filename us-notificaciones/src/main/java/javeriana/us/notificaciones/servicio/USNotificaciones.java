/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.us.notificaciones.servicio;

import javax.jws.WebService;
import javeriana.us.notificaciones.negocio.NegocioNotificacion;
import javeriana.us.notificaciones.util.DTOToXSD;
import javeriana.us.notificaciones.util.XSDToDTO;
import usnotificaciones.javeriana.service.v1_0_0.notificaciones.EnviarNotificacionResponse;

/**
 *
 * @author Usuario
 */
@WebService(serviceName = "USNotificacionesService", portName = "USNotificacionesPort", endpointInterface = "usnotificaciones.javeriana.service.v1_0_0.notificaciones.USNotificacionesPortType", targetNamespace = "http://javeriana.usnotificaciones/service/v1.0.0/notificaciones", wsdlLocation = "WEB-INF/wsdl/USNotificaciones.wsdl")
public class USNotificaciones {

    public usnotificaciones.javeriana.service.v1_0_0.notificaciones.EnviarNotificacionResponse enviarNotificacion(usnotificaciones.javeriana.service.v1_0_0.notificaciones.CabeceraIntegracion cabecera, usnotificaciones.javeriana.service.v1_0_0.notificaciones.EnviarNotificacionRequest parameters) {
        NegocioNotificacion negocio = new NegocioNotificacion(); 
        EnviarNotificacionResponse result = DTOToXSD.resultadoDTOToEnviarNotificacionResponse(
                negocio.notificar(XSDToDTO.notificacionToDTONotificacion(parameters.getNotificacion())));        
        return result;
    }
    
}
