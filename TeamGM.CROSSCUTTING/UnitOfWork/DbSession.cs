using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Connection = new OracleConnection(_configuration.GetConnectionString("TeamGmDbConnection"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
