/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.us.notificaciones.negocio;

import javeriana.us.notificaciones.dto.DTONotificacion;
import javeriana.us.notificaciones.dto.DTOResultado;
import javeriana.us.notificaciones.integracion.IntegracionSMS;
import javeriana.us.notificaciones.integracion.IntegracionSMTP;

/**
 *
 * @author Usuario
 */
public class NegocioNotificacion {
    public static String SMS = "1";
    public static String SMTP = "2";
    
    public NegocioNotificacion(){
    
    }
    
    public DTOResultado notificar(DTONotificacion notificacion){
        DTOResultado resultado = new DTOResultado();
        if(SMS.equals(notificacion.getIdTipoNotificacion()) == true){
            IntegracionSMS integracion = new IntegracionSMS();
            resultado = integracion.enviarNotificacion(notificacion);            
        }else if(SMTP.equals(notificacion.getIdTipoNotificacion()) == true){
            IntegracionSMTP integracion = new IntegracionSMTP();
            resultado = integracion.enviarNotifiacion(notificacion);
        }        
        return resultado;
    }
    
}
