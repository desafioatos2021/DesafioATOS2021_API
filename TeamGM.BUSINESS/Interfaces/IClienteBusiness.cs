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

        Task<Cliente> UpdateCliente(Cliente cliente);
    }
}
