/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.es.proveedores.util;

import esproveedores.javeriana.service.v1_0_0.b2b.NotificarCatalogoRequest;
import esproveedores.javeriana.service.v1_0_0.b2b.NotificarOfertaRequest;
import esproveedores.javeriana.service.v1_0_0.b2b.Servicio;
import java.util.ArrayList;
import java.util.List;
import javeriana.es.proveedores.dto.DTOCatalogo;
import javeriana.es.proveedores.dto.DTOOferta;
import javeriana.es.proveedores.dto.DTOServicio;


/**
 *
 * @author Usuario
 */
public class XSDToDTO {
    
    public static DTOCatalogo notificarCatalogoToDTOCatalogo(NotificarCatalogoRequest xsd){
        DTOCatalogo dto = new DTOCatalogo();
        if(xsd != null){
            dto.setIdCatalogo(xsd.getCatalogo().getIdCatalogo());
            dto.setIdUsuario(xsd.getCatalogo().getIdUsuario());
            dto.setNombre(xsd.getCatalogo().getNombre());            
            if(xsd.getCatalogo().getServicios() != null){ 
                List<DTOServicio> list = new ArrayList<>();
                for (Servicio servicio : xsd.getCatalogo().getServicios()) {
                    list.add(servicioToDTOServicio(servicio));
                }
                dto.setServicios(list);
            }
        }
        return dto;
    }
    
    private static DTOServicio servicioToDTOServicio(Servicio xsd){
        DTOServicio dto = new DTOServicio();
        if(xsd != null){
            dto.setDescripcion(xsd.getDescripcion());
            dto.setIdCatalogo(xsd.getIdCatalogo());
            dto.setIdCiudadDestino(xsd.getIdCiudadDestino());
            dto.setIdCiudadOrigen(xsd.getIdCiudadOrigen());
            dto.setIdServicio(xsd.getIdServicio());
            dto.setNombre(xsd.getNombre());
            dto.setPrecio(xsd.getPrecio());
        }
        return dto;
    }
    
    public static DTOOferta notificarOfertaToDTOOferta(NotificarOfertaRequest xsd){
        DTOOferta dto = new DTOOferta();
        if(xsd != null){
            dto.setIdDespacho(xsd.getOferta().getIdDespacho());
            dto.setIdOferta(xsd.getOferta().getIdOferta());
            dto.setIdUsuario(xsd.getOferta().getIdUsuario());
            dto.setPrecio(xsd.getOferta().getPrecio());
        }
        return dto;
    }
    
    
}
