
package ts.despachos.server.integracion.proxyNotificaciones;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Clase Java para enviarNotificacionRequest complex type.
 * 
 * <p>El siguiente fragmento de esquema especifica el contenido que se espera que haya en esta clase.
 * 
 * <pre>
 * &lt;complexType name="enviarNotificacionRequest">
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="notificacion" type="{http://javeriana.usnotificaciones/service/v1.0.0/notificaciones}notificacion"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "enviarNotificacionRequest", propOrder = {
    "notificacion"
})
public class EnviarNotificacionRequest {

    @XmlElement(required = true, nillable = true)
    protected Notificacion notificacion;

    /**
     * Obtiene el valor de la propiedad notificacion.
     * 
     * @return
     *     possible object is
     *     {@link Notificacion }
     *     
     */
    public Notificacion getNotificacion() {
        return notificacion;
    }

    /**
     * Define el valor de la propiedad notificacion.
     * 
     * @param value
     *     allowed object is
     *     {@link Notificacion }
     *     
     */
    public void setNotificacion(Notificacion value) {
        this.notificacion = value;
    }

}
