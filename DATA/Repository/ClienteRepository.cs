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
        public async Task<Cliente> DeleteClienteAsync(int id)
        {
            var clienteConsultado = await _context.Cliente.FindAsync(id);
            if (clienteConsultado == null)
            {
                return null;
            }
            var clienteRemovido = _context.Cliente.Remove(clienteConsultado);
            await _context.SaveChangesAsync();
            return clienteRemovido.Entity;
        }

        public async Task<Cliente> GetClienteIdAsync(int id)
        {
            var clienteColsultado = _context.Cliente.Where(c => c.IdCliente == id).FirstOrDefault();
            if (clienteColsultado == null) return null;
            await _context.SaveChangesAsync();
            return clienteColsultado;
        }

        public async Task<Cliente> GetClienteNomeAsync(string nome)
        {
            var clienteConsultado = _context.Cliente.Where(c => c.Nome == nome).FirstOrDefault();
            if (clienteConsultado == null)
            {
                return null;
            }
            await _context.SaveChangesAsync();
            return clienteConsultado;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            var clientes = _context.Cliente.ToList();
            return clientes;
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
