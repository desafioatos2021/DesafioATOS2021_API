using Base.BUSINESS.Interfaces;
using Base.DATA.Interfaces;
using Base.DOMAIN.Models;
using System;
using System.Threading.Tasks;

namespace Base.BUSINESS.Business
{
    public class ClienteBusiness : IClienteBusiness
    {

        private readonly IClienteRepository _clienteRepository;
                
        public ClienteBusiness(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<Cliente> AdicionarCliente(Cliente cliente)
        {
            var clienteRetorno = _clienteRepository.InsertClienteAsync(cliente);
            return clienteRetorno;
        }

        public Task<Cliente> ExcluirCliente(int id)
        {
            var clienteExcluido = _clienteRepository.DeleteClienteAsync(id);
            return clienteExcluido;
        }
        
        public async Task<Cliente> UpdateCliente(Cliente cliente) =>
            await _clienteRepository.UpdateClienteAsync(cliente);
        
    }
}
