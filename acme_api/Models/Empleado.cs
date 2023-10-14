namespace acme_api.Models;
public class Empleado {
    // no se le deja valores default porque si se hace el patch se usa ese valor default
    public int id {get; set;}
    public string ?nombres {get; set;} 
    public string ?apellidos {get; set;} 
    public string ?identificacion {get; set;}
    public string ?telefono {get; set;}
    public string ?correo {get; set;}

    public Afiliado ?Afiliado { get; set;}

    public Empleado(string nombres, string apellidos, string identificacion, string telefono, string correo)
    {
        this.nombres = nombres;
        this.apellidos = apellidos;
        this.identificacion = identificacion;
        this.telefono = telefono;
        this.correo = correo;
    }
    public Empleado(){
        
    }
}