using Base.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.BUSINESS.Interfaces
{
    public interface IClienteBusiness
    {
        Task<Cliente> AdicionarCliente(Cliente cliente);

        Task<Cliente> ExcluirCliente(int id);
        Task<Cliente> UpdateCliente(Cliente cliente);
        Task<Cliente> ListarClientes();
        Task<Cliente> ConsultarClientePorNome(string nome);
        Task<Cliente> ConsultarClientePorId(int id);
    }
}
