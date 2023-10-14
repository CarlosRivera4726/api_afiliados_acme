using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;
using acme_api.Models;

namespace acme_api.Repositories;

public class EmpleadoRepository : ConnectionString, IRepository<Empleado>
{
    private IDbConnection connection;
    

    public EmpleadoRepository()
    {
        connection = new SqliteConnection(connectionString);
    }
    public async Task<IEnumerable<Empleado>> Get()
    {
        try{
            var sql = "SELECT id, nombres, apellidos, identificacion, telefono, correo FROM empleados";
        
            var empleados = await connection.QueryAsync<Empleado>(sql);

            return empleados;
        } catch(Exception ex){
            Console.WriteLine("Get all empleados Error: " + ex.Message);
            return new Empleado[1];
        }

     }
    public async Task<Empleado> Get(int id)
    {
        try{
            var sql = "SELECT * FROM empleados WHERE empleados.id = @Id";
        
            var empleado = await connection.QuerySingleAsync<Empleado>(sql, new{Id = id});
            
            return empleado;
            

        } catch(Exception ex){
            Console.WriteLine("Get By Id Error: " + ex.Message);
            return new Empleado {};
        }
    }

    public async Task<Empleado> Create(Empleado value)
    {
        var result = 0;
        try {
            var sql = "INSERT INTO empleados (nombres, apellidos, identificacion, telefono, correo) VALUES (@nombres, @apellidos, @identificacion, @telefono, @correo)";

            result = await connection.ExecuteAsync(sql, value);
            Console.WriteLine("result: " + result);
            return value;

        } catch(Exception ex){
            Console.WriteLine("Create Error: " + ex.Message);
            return new Empleado {};
        }
    }

    public async Task<string> Delete(int id)
    {
       try{
        var sql = "DELETE FROM empleados WHERE id = @Id";
        var result = await connection.ExecuteAsync(sql, new { Id = id });
        Console.WriteLine(result);
        if(result > 0){
            return "Empleado has been deleted";
        }
        return "Empleado not found";
       } catch(Exception ex){
        Console.WriteLine("Delete Error: " + ex.Message);
        return "Empleado not found";
       }
    }

    public async Task<Empleado> Update(Empleado value)
    {
        try{
            var sql = @"
            UPDATE empleados 
            SET nombres=IFNULL(@nombres, nombres),
                apellidos=IFNULL(@apellidos, apellidos), 
                identificacion=IFNULL(@identificacion, identificacion),
                telefono=IFNULL(@telefono, telefono),
                correo=IFNULL(@correo, correo) 
                WHERE id = @Id";
            await connection.ExecuteAsync(sql, new { 
                    nombres=value.nombres,
                    apellidos=value.apellidos,
                    identificacion=value.identificacion,
                    telefono=value.telefono,
                    correo=value.correo,
                    Id=value.id,
                });
        

        return value;
        } catch(Exception ex){
            Console.WriteLine("Update Error: " + ex.Message);
            return new Empleado{};
        }
    }
}