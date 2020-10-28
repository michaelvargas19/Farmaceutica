/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.es.proveedores.dto;

import java.util.List;

/**
 *
 * @author Usuario
 */
public class DTOCatalogo {
    private String idCatalogo;
    private String idUsuario;
    private String nombre;
    private List<DTOServicio> servicios;
    
    public DTOCatalogo(){
    
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
     * @return the servicios
     */
    public List<DTOServicio> getServicios() {
        return servicios;
    }

    /**
     * @param servicios the servicios to set
     */
    public void setServicios(List<DTOServicio> servicios) {
        this.servicios = servicios;
    }
    
    
    
}
