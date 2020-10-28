/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ts.despachos.server.integracion.proxyNotificaciones;

/**
 *
 * @author Usuario
 */
public class IntegracionNotificaciones {
    
    
    public void notificar(EnviarNotificacionRequest notificacion){
        USNotificacionesService service = new USNotificacionesService();
        USNotificacionesPortType port = service.getUSNotificacionesPort();
        port.enviarNotificacion(new CabeceraIntegracion(), notificacion);
    }
    
}
