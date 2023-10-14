namespace acme_api.Models;
public class Afiliado {
    public int id {get; set;} = 0;
    public string estado {get; set;} = "";
    public string fechaRetiro {get; set;}= "";
    public string fechaIngreso {get; set;}="";
    
    public ICollection <Empleado> ?Empleados {get;set;}

}