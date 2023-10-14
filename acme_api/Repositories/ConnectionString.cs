namespace acme_api.Repositories;

public abstract class ConnectionString{
    private const string DATABASE_NAME = "db_afiliados_Acme.db3";
    protected readonly string connectionString = $"Data Source = {Environment.CurrentDirectory + $"/Data/{DATABASE_NAME}"}";
}