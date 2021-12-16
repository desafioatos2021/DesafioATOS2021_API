using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
using System.Web;
using System.Configuration;

namespace TeamGM.CROSSCUTTING.UnitOfWork
{
    public sealed class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        private readonly IConfiguration _configuration;
        

        public DbSession(IConfiguration configuration)
        {
            _configuration = configuration;
            Connection = new OracleConnection(_configuration.GetConnectionString("DesafioAtosConnection"));
            Connection.Open();

            //Connection = new SqlConnection(_configuration.GetConnectionString("SQL_SERVER_Connection"));
            //Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
