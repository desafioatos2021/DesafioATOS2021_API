using Base.BUSINESS.Interfaces;
using Base.DATA.Interfaces;
using Base.DOMAIN.Models;
using System;
using System.Collections.Generic;
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

        public async Task<Cliente> ConsultarClientePorId(int id)
        {
            var clienteConsultado = await _clienteRepository.GetClienteIdAsync(id);
            return clienteConsultado;
        }

        public Task<Cliente> ConsultarClientePorNome(string nome)
        {
            var clienteConsultado = _clienteRepository.GetClienteNomeAsync(nome);
            return clienteConsultado;
        }

        public Task<Cliente> ExcluirCliente(int id)
        {
            var clienteExluido = _clienteRepository.DeleteClienteAsync(id);
            return clienteExluido;
        }

        public async Task<IEnumerable<Cliente>> ListarClientes()
        {
            var clientes = await _clienteRepository.GetClientesAsync();
            return clientes;
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente) =>
            await _clienteRepository.UpdateClienteAsync(cliente);
        
    }
}
