using Base.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.DATA.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> InsertClienteAsync(Cliente cliente);
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteIdAsync(int id);
        Task<Cliente> GetClienteNomeAsync(string nome);
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
        Task<Cliente> DeleteClienteAsync(int id);
    }
}
