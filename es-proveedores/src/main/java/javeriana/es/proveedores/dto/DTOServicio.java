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
public class DTOServicio {
    private String idServicio;
    private String idCatalogo;
    private String nombre;
    private String descripcion;
    private String idCiudadOrigen;
    private String idCiudadDestino;
    private double precio;
    
    public DTOServicio(){
    
    }

    /**
     * @return the idServicio
     */
    public String getIdServicio() {
        return idServicio;
    }

    /**
     * @param idServicio the idServicio to set
     */
    public void setIdServicio(String idServicio) {
        this.idServicio = idServicio;
    }

    /**
     * @return the idCatalogo
     */
    public String getIdCatalogo() {
        return idCatalogo;
    }

    /**
     * @param idCatalogo the idCatalogo to set
     */
    public void setIdCatalogo(String idCatalogo) {
        this.idCatalogo = idCatalogo;
    }

    /**
     * @return the nombre
     */
    public String getNombre() {
        return nombre;
    }

    /**
     * @param nombre the nombre to set
     */
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    /**
     * @return the descripcion
     */
    public String getDescripcion() {
        return descripcion;
    }

    /**
     * @param descripcion the descripcion to set
     */
    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    /**
     * @return the idCiudadOrigen
     */
    public String getIdCiudadOrigen() {
        return idCiudadOrigen;
    }

    /**
     * @param idCiudadOrigen the idCiudadOrigen to set
     */
    public void setIdCiudadOrigen(String idCiudadOrigen) {
        this.idCiudadOrigen = idCiudadOrigen;
    }

    /**
     * @return the idCiudadDestino
     */
    public String getIdCiudadDestino() {
        return idCiudadDestino;
    }

    /**
     * @param idCiudadDestino the idCiudadDestino to set
     */
    public void setIdCiudadDestino(String idCiudadDestino) {
        this.idCiudadDestino = idCiudadDestino;
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
    
    
}
