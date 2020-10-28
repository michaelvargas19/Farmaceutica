/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ts.despachos.server.notificaciones;

import ts.despachos.server.integracion.proxyNotificaciones.EnviarNotificacionRequest;
import ts.despachos.server.integracion.proxyNotificaciones.IntegracionNotificaciones;
import ts.despachos.server.integracion.proxyNotificaciones.Notificacion;

/**
 *
 * @author Usuario
 */
public class TareaNotificaciones {
    
    public TareaNotificaciones(){
    
    }
    
    public void ejecutar(){
        IntegracionNotificaciones integracion = new IntegracionNotificaciones();
        
        EnviarNotificacionRequest request = new EnviarNotificacionRequest();
        Notificacion notifica = new Notificacion();
        notifica.setDestino("+573016075810");
        notifica.setIdTipoNotificacion("1");
        notifica.setMensajeCorto("Notificando Despacho creado 123456");
        
        
        request.setNotificacion(notifica);
                
        integracion.notificar(request);
    }
}
