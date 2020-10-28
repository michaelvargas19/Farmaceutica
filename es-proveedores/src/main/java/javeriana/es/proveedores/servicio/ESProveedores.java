/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.es.proveedores.servicio;

import esproveedores.javeriana.service.v1_0_0.b2b.NotificarCatalogoResponse;
import esproveedores.javeriana.service.v1_0_0.b2b.NotificarOfertaResponse;
import javax.jws.WebService;
import javeriana.es.proveedores.negocio.NegocioProveedor;
import javeriana.es.proveedores.util.DTOToXSD;
import javeriana.es.proveedores.util.XSDToDTO;

/**
 *
 * @author Usuario
 */
@WebService(serviceName = "ESProveedoresService", portName = "ESProveedoresPort", endpointInterface = "esproveedores.javeriana.service.v1_0_0.b2b.ESProveedoresPortType", targetNamespace = "http://javeriana.esproveedores/service/v1.0.0/b2b", wsdlLocation = "WEB-INF/wsdl/ESProveedores.wsdl")
public class ESProveedores {

     public esproveedores.javeriana.service.v1_0_0.b2b.NotificarCatalogoResponse notificarCatalogo(esproveedores.javeriana.service.v1_0_0.b2b.CabeceraIntegracion cabecera, esproveedores.javeriana.service.v1_0_0.b2b.NotificarCatalogoRequest parameters) {
        NegocioProveedor negocio = new NegocioProveedor(); 
        NotificarCatalogoResponse result = DTOToXSD.resultadoDTOToNotificarCatalogo(negocio.notificarCatalogo(
                XSDToDTO.notificarCatalogoToDTOCatalogo(parameters)));
        return result;        
    }

    public esproveedores.javeriana.service.v1_0_0.b2b.NotificarOfertaResponse notificarOferta(esproveedores.javeriana.service.v1_0_0.b2b.CabeceraIntegracion cabecera, esproveedores.javeriana.service.v1_0_0.b2b.NotificarOfertaRequest parameters) {
        NegocioProveedor negocio = new NegocioProveedor(); 
        NotificarOfertaResponse result = DTOToXSD.resultadoDTOToNotificarOferta(negocio.notificarOferta(
                XSDToDTO.notificarOfertaToDTOOferta(parameters)));
        return result;        
        
    }
    
}
