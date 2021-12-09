using Base.DATA.Interfaces;
using Base.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamGM.DATA.Context;

namespace Base.DATA.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DesafioAtosContext _context;

        public ClienteRepository(DesafioAtosContext context)
        {
            _context = context;
        }

        public Cliente AdicionarCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public Cliente AtualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente ExibeClientes()
        {
            throw new NotImplementedException();
        }

        public Cliente PequisarClientePorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Cliente PesquisarClientePorId(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente RemoveRCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
