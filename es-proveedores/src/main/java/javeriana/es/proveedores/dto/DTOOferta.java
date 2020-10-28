/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.es.proveedores.dto;

/**
 *
 * @author Usuario
 */
public class DTOOferta {
    private String idOferta;
    private String idUsuario;    
    private double precio;
    private String idDespacho;
    
    public DTOOferta(){
    
    }

    /**
     * @return the idOferta
     */
    public String getIdOferta() {
        return idOferta;
    }

    /**
     * @param idOferta the idOferta to set
     */
    public void setIdOferta(String idOferta) {
        this.idOferta = idOferta;
    }

    /**
     * @return the idUsuario
     */
    public String getIdUsuario() {
        return idUsuario;
    }

    /**
     * @param idUsuario the idUsuario to set
     */
    public void setIdUsuario(String idUsuario) {
        this.idUsuario = idUsuario;
    }

    /**
     * @return the precio
     */
    public double getPrecio() {
        return precio;
    }

    /**
     * @param precio the precio to set
     */
    public void setPrecio(double precio) {
        this.precio = precio;
    }

    /**
     * @return the idDespacho
     */
    public String getIdDespacho() {
        return idDespacho;
    }

    /**
     * @param idDespacho the idDespacho to set
     */
    public void setIdDespacho(String idDespacho) {
        this.idDespacho = idDespacho;
    }
    
    
}
