
package ts.despachos.server.integracion.proxyNotificaciones;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the ts.despachos.server.integracion.proxyNotificaciones package. 
 * <p>An ObjectFactory allows you to programatically 
 * construct new instances of the Java representation 
 * for XML content. The Java representation of XML 
 * content can consist of schema derived interfaces 
 * and classes representing the binding of schema 
 * type definitions, element declarations and model 
 * groups.  Factory methods for each of these are 
 * provided in this class.
 * 
 */
@XmlRegistry
public class ObjectFactory {

    private final static QName _Cabecera_QNAME = new QName("http://javeriana.usnotificaciones/service/v1.0.0/notificaciones", "cabecera");
    private final static QName _EnviarNotificacionResponse_QNAME = new QName("http://javeriana.usnotificaciones/service/v1.0.0/notificaciones", "enviarNotificacionResponse");
    private final static QName _EnviarNotificacionRequest_QNAME = new QName("http://javeriana.usnotificaciones/service/v1.0.0/notificaciones", "enviarNotificacionRequest");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: ts.despachos.server.integracion.proxyNotificaciones
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link EnviarNotificacionRequest }
     * 
     */
    public EnviarNotificacionRequest createEnviarNotificacionRequest() {
        return new EnviarNotificacionRequest();
    }

    /**
     * Create an instance of {@link CabeceraIntegracion }
     * 
     */
    public CabeceraIntegracion createCabeceraIntegracion() {
        return new CabeceraIntegracion();
    }

    /**
     * Create an instance of {@link EnviarNotificacionResponse }
     * 
     */
    public EnviarNotificacionResponse createEnviarNotificacionResponse() {
        return new EnviarNotificacionResponse();
    }

    /**
     * Create an instance of {@link Resultado }
     * 
     */
    public Resultado createResultado() {
        return new Resultado();
    }

    /**
     * Create an instance of {@link Notificacion }
     * 
     */
    public Notificacion createNotificacion() {
        return new Notificacion();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link CabeceraIntegracion }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://javeriana.usnotificaciones/service/v1.0.0/notificaciones", name = "cabecera")
    public JAXBElement<CabeceraIntegracion> createCabecera(CabeceraIntegracion value) {
        return new JAXBElement<CabeceraIntegracion>(_Cabecera_QNAME, CabeceraIntegracion.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link EnviarNotificacionResponse }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://javeriana.usnotificaciones/service/v1.0.0/notificaciones", name = "enviarNotificacionResponse")
    public JAXBElement<EnviarNotificacionResponse> createEnviarNotificacionResponse(EnviarNotificacionResponse value) {
        return new JAXBElement<EnviarNotificacionResponse>(_EnviarNotificacionResponse_QNAME, EnviarNotificacionResponse.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link EnviarNotificacionRequest }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://javeriana.usnotificaciones/service/v1.0.0/notificaciones", name = "enviarNotificacionRequest")
    public JAXBElement<EnviarNotificacionRequest> createEnviarNotificacionRequest(EnviarNotificacionRequest value) {
        return new JAXBElement<EnviarNotificacionRequest>(_EnviarNotificacionRequest_QNAME, EnviarNotificacionRequest.class, null, value);
    }

}
