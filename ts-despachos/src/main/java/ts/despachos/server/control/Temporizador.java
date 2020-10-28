/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ts.despachos.server.control;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Component;
import ts.despachos.server.notificaciones.TareaNotificaciones;

/**
 *
 * @author developer
 */
@Component
public class Temporizador {
    protected final Logger log = LoggerFactory.getLogger(this.getClass());    
    
    @Scheduled(cron = "20/20 * * * * ?")
    public void tareaProgramada() {
        log.info("ejecución de la tareaProgramada...");
        
        log.info("Inicio notificacion de proveedores...");
        TareaNotificaciones tarea = new TareaNotificaciones();
        tarea.ejecutar();
        log.info("ejecuto notificaciones...");
    }
}
