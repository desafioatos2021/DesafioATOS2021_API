﻿using Base.DATA.Interfaces;
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

        public Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
