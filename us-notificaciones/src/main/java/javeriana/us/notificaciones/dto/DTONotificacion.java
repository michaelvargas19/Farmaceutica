/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.us.notificaciones.dto;

/**
 *
 * @author Usuario
 */
public class DTONotificacion {
    private String idTipoNotificacion;
    private String destino;
    private String asunto;
    private String mensaje;
    private String mensajeCorto;
    
    public DTONotificacion(){
    
    }

    /**
     * @return the idTipoNotificacion
     */
    public String getIdTipoNotificacion() {
        return idTipoNotificacion;
    }

    /**
     * @param idTipoNotificacion the idTipoNotificacion to set
     */
    public void setIdTipoNotificacion(String idTipoNotificacion) {
        this.idTipoNotificacion = idTipoNotificacion;
    }

    /**
     * @return the destino
     */
    public String getDestino() {
        return destino;
    }

    /**
     * @param destino the destino to set
     */
    public void setDestino(String destino) {
        this.destino = destino;
    }

    /**
     * @return the asunto
     */
    public String getAsunto() {
        return asunto;
    }

    /**
     * @param asunto the asunto to set
     */
    public void setAsunto(String asunto) {
        this.asunto = asunto;
    }

    /**
     * @return the mensaje
     */
    public String getMensaje() {
        return mensaje;
    }

    /**
     * @param mensaje the mensaje to set
     */
    public void setMensaje(String mensaje) {
        this.mensaje = mensaje;
    }

    /**
     * @return the mensajeCorto
     */
    public String getMensajeCorto() {
        return mensajeCorto;
    }

    /**
     * @param mensajeCorto the mensajeCorto to set
     */
    public void setMensajeCorto(String mensajeCorto) {
        this.mensajeCorto = mensajeCorto;
    }
    
    
}
