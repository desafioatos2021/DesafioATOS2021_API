using Base.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DATA.Interfaces
{
    public interface IClienteRepository
    {
        Cliente AdicionarCliente(Cliente cliente);
        Cliente ExibeClientes();
        Cliente PesquisarClientePorId(int id);
        Cliente PequisarClientePorNome(string nome);
        Cliente AtualizarCliente(Cliente cliente);
        Cliente RemoveRCliente(Cliente cliente);
    }
}
