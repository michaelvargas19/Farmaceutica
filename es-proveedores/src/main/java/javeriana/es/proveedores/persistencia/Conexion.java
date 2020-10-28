/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javeriana.es.proveedores.persistencia;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import javax.sql.DataSource;

/**
 *
 * @author Usuario
 */
public class Conexion {
    private Connection conex=null;
    //private String file;
    private String user;
    private String password;
    private String driver;
    private String url;
    private static Conexion absDDconnect;
    private DataSource ds;
    private String datasource;
    
    
    
    private Conexion() throws Exception {
        String messageError= "";
        try {
           // this.file = file;
//            user = ResourceBundle.getBundle(file).getString(Constantes.USER_DB);
//            password = ResourceBundle.getBundle(file).getString(Constantes.PASS_DB);
//            driver = ResourceBundle.getBundle(file).getString(Constantes.DRIVER_DB);
//            url = ResourceBundle.getBundle(file).getString(Constantes.URL_DB);
            user = "postgres";
            password = "postgres";
            driver = "org.postgresql.Driver";
            url = "jdbc:postgresql://localhost:5432/DB_DESPACHOS";
            Class.forName(driver);
//                datasource = ResourceBundle.getBundle(file).getString(Constantes.DATASOURCE_DB);
//                InitialContext ic = new InitialContext();
//                ds = (DataSource) ic.lookup(datasource);
            
            
            //System.out.println(url);
//            conex = DriverManager.getConnection(url, user, password);
//            System.out.println("Se creo la satisfactoriamente la conexion.");
        } catch (Exception ex) {
            messageError = "No se logro cargar el nombre de datasource: " + ex.getMessage();
            //Logger.getLogger(DBConnection.class.getName()).log(Level.SEVERE, null, ex);
        } 
        if(!messageError.equals("")){
            throw new Exception(messageError);         
        }
    }
    
    
    
    public static Conexion getInstance() throws Exception {
        if(absDDconnect == null ){
            absDDconnect = new Conexion();
        }  
        return absDDconnect;
    }


    
    public synchronized Connection getConex() throws Exception {
        String message = null;
        Connection conn = null;
        try {
            conn = DriverManager.getConnection(url, user, password);  
            //conn = ds.getConnection();
        } catch (SQLException ex){
            message = "Se presento un error al intentar establecer comunicación con base de datos: " + ex.getMessage();
        }
        if(message != null){
            throw new Exception(message);
        }
        return conn;
    }

    public void setConex(Connection conex) {
        this.conex = conex;
    }

    public String getUser() {
        return user;
    }

    public void setUser(String user) {
        this.user = user;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getDriver() {
        return driver;
    }

    public void setDriver(String driver) {
        this.driver = driver;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public DataSource getDs() {
        return ds;
    }

    public void setDs(DataSource ds) {
        this.ds = ds;
    }
}
