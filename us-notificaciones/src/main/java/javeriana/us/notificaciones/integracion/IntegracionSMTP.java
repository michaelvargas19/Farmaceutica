/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.us.notificaciones.integracion;

import java.util.Properties;
import java.util.ResourceBundle;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import javeriana.us.notificaciones.dto.DTONotificacion;
import javeriana.us.notificaciones.dto.DTOResultado;

/**
 *
 * @author Usuario
 */
public class IntegracionSMTP {
    public static final String FROM = "ortiz-mf@javeriana.edu.co";
    public static final String USER = "ortiz-mf@javeriana.edu.co";
    public static final String PASSWORD = "mauroD83";
    public static final String HOST = "smtp.office365.com";
    public static final String PORT = "587";
    
    
    public DTOResultado enviarNotifiacion(DTONotificacion notificacion){
        DTOResultado resultado = new DTOResultado();
        
        // Recipient's email ID needs to be mentioned.
        String to = notificacion.getDestino();
        // Get system properties
        Properties properties = System.getProperties();

        // Setup mail server
        properties.setProperty("mail.smtp.host", HOST);
        properties.setProperty("mail.smtp.auth", "true");
        properties.setProperty("mail.smtp.starttls.enable", "true");
        properties.setProperty("mail.smtp.port", PORT);

        // Get the default Session object.
        Session session = Session.getInstance(properties,
            new javax.mail.Authenticator() {
            protected PasswordAuthentication getPasswordAuthentication() {
            return new PasswordAuthentication(USER, PASSWORD);
            }
            });

        try {
           // Create a default MimeMessage object.
           MimeMessage message = new MimeMessage(session);

           // Set From: header field of the header.
           message.setFrom(new InternetAddress(FROM));

           // Set To: header field of the header.
           message.addRecipient(Message.RecipientType.TO, new InternetAddress(to));

           // Set Subject: header field
           message.setSubject(notificacion.getAsunto());

           // Now set the actual message
           message.setText(notificacion.getMensaje());

           // Send message
           Transport.send(message);
           
           resultado.setCodigo("200");
           resultado.setMensaje("Correo enviado con exito");
           System.out.println("Mensaje enviado satisfactoriamente....");
        } catch (MessagingException mex) {
            resultado.setCodigo("000");
            resultado.setMensaje("No fue posible enviar el correo: " + mex.getMessage());
        }
        
        return resultado;
    }
    
}
