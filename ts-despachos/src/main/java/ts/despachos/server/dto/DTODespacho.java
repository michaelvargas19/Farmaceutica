/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ts.despachos.server.dto;

/**
 *
 * @author Usuario
 */
public class DTODespacho {
    private long idDespacho;
    private String nombre;
    private String fechaInicio;
    private String fechaFin;
    private String idProveedor;
    private String nombreProveedor;
    private String idEstado;
    private String municipioOrigen;
    private String municipioDestino;
    
    public DTODespacho(){
    
    }

    /**
     * @return the idDespacho
     */
    public long getIdDespacho() {
        return idDespacho;
    }

    /**
     * @param idDespacho the idDespacho to set
     */
    public void setIdDespacho(long idDespacho) {
        this.idDespacho = idDespacho;
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
     * @return the fechaInicio
     */
    public String getFechaInicio() {
        return fechaInicio;
    }

    /**
     * @param fechaInicio the fechaInicio to set
     */
    public void setFechaInicio(String fechaInicio) {
        this.fechaInicio = fechaInicio;
    }

    /**
     * @return the fechaFin
     */
    public String getFechaFin() {
        return fechaFin;
    }

    /**
     * @param fechaFin the fechaFin to set
     */
    public void setFechaFin(String fechaFin) {
        this.fechaFin = fechaFin;
    }

    /**
     * @return the idProveedor
     */
    public String getIdProveedor() {
        return idProveedor;
    }

    /**
     * @param idProveedor the idProveedor to set
     */
    public void setIdProveedor(String idProveedor) {
        this.idProveedor = idProveedor;
    }

    /**
     * @return the nombreProveedor
     */
    public String getNombreProveedor() {
        return nombreProveedor;
    }

    /**
     * @param nombreProveedor the nombreProveedor to set
     */
    public void setNombreProveedor(String nombreProveedor) {
        this.nombreProveedor = nombreProveedor;
    }

    /**
     * @return the idEstado
     */
    public String getIdEstado() {
        return idEstado;
    }

    /**
     * @param idEstado the idEstado to set
     */
    public void setIdEstado(String idEstado) {
        this.idEstado = idEstado;
    }

    /**
     * @return the municipioOrigen
     */
    public String getMunicipioOrigen() {
        return municipioOrigen;
    }

    /**
     * @param municipioOrigen the municipioOrigen to set
     */
    public void setMunicipioOrigen(String municipioOrigen) {
        this.municipioOrigen = municipioOrigen;
    }

    /**
     * @return the municipioDestino
     */
    public String getMunicipioDestino() {
        return municipioDestino;
    }

    /**
     * @param municipioDestino the municipioDestino to set
     */
    public void setMunicipioDestino(String municipioDestino) {
        this.municipioDestino = municipioDestino;
    }
    
    
}
