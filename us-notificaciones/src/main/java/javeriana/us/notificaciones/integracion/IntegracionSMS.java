/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.us.notificaciones.integracion;

import com.twilio.Twilio;
import com.twilio.rest.api.v2010.account.Message;
import com.twilio.type.PhoneNumber;
import javeriana.us.notificaciones.dto.DTONotificacion;
import javeriana.us.notificaciones.dto.DTOResultado;

/**
 *
 * @author Usuario
 */
public class IntegracionSMS {
    public static final String ACCOUNT_SID = "ACa3a7da2be93b87f07da61f38621e6c1e";
    public static final String AUTH_TOKEN = "265c809dab3bce59cd3f99e09d7d9adb";
    public static final String PHONE_NUMBER = "+14152369391";
    
    
    
    public IntegracionSMS(){
    
    }
    
    public DTOResultado enviarNotificacion(DTONotificacion notificacion){
        DTOResultado resultado = new DTOResultado();
        Twilio.init(ACCOUNT_SID, AUTH_TOKEN);
        Message message = Message.creator(new PhoneNumber(notificacion.getDestino()),
            new PhoneNumber(PHONE_NUMBER), 
            notificacion.getMensajeCorto()).create();
        if(message.getSid() != null){
            resultado.setCodigo("200");
            resultado.setMensaje("SMS Enviado: " + message.getSid());
        }else{
            resultado.setCodigo("000");
            resultado.setMensaje("SMS No Enviado: " + message.getErrorMessage());
        }
        return resultado;        
    }
}
