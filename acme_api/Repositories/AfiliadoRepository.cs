using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;
using acme_api.Models;

namespace acme_api.Repositories;

public class AfiliadoRepository : ConnectionString, IRepository<Afiliado> 
{
    private IDbConnection connection;

    public AfiliadoRepository(){
        connection = new SqliteConnection(connectionString);
    }
    public async Task<IEnumerable<Afiliado>> Get()
    {
        var sql = "SELECT * FROM afiliados";
        var afiliados = await connection.QueryAsync<Afiliado>(sql);
        return afiliados;
    }

    public async Task<Afiliado> Get(int id)
    {
        var sql = "SELECT * FROM afiliados WHERE id=@Id";
        var afiliado = await connection.QuerySingleAsync<Afiliado>(sql, new {Id = id});
        afiliado.estado = afiliado.estado == "1" ? "Activo" : "Inactivo";
        return afiliado;
    }

    public Task<Afiliado> Create(Afiliado value)
    {
        throw new NotImplementedException();
    }

    public Task<string> Delete(int id)
    {
        throw new NotImplementedException();
    }


    public Task<Afiliado> Update(Afiliado value)
    {
        throw new NotImplementedException();
    }
}