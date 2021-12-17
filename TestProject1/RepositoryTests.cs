
using Base.DOMAIN.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Threading.Tasks;
using TeamGM.DATA.Context;

namespace BaseAPI.Data.Tests
{
    [TestClass]
    public class RepositoryTests
    {

        

        

        [TestMethod]
        public void Test_Insert_Cliente()
        {
            Cliente clienteAtual = new Cliente() { IdCliente = 0, IdEndereco = 3, Nome = "Leonardo" };

            Assert.IsTrue(!string.IsNullOrEmpty(clienteAtual.Nome) && clienteAtual.IdEndereco != 0);

        }

        


    }
}
