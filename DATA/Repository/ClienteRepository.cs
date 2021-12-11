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
        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            await _context.Cliente.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
        public Task<Cliente> DeleteClienteAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetClienteIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetClienteNomeAsync(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var clienteAtualizado = _context.Cliente.FirstOrDefault(c => c.IdCliente == cliente.IdCliente);
            
            if (clienteAtualizado == null)
                return null;
            else
            {
                _context.Update(clienteAtualizado);
                await _context.SaveChangesAsync();
                return clienteAtualizado;
            }
        }
    }
}
