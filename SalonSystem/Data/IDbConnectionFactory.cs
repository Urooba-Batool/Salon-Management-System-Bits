using System.Data;

namespace SalonSystem.Data
{
    public interface IDbConnectionFactory
    {
        //anyone implementing Idbconnectionfactory must have a method that creates the db connection
        IDbConnection CreateConnection();
    }
}
