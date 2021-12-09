using Base.BUSINESS.Interfaces;
using Base.DATA.Interfaces;
using Base.DOMAIN.Models;
using System;


namespace Base.BUSINESS.Business
{
    public class ClienteBusiness : IClienteBusiness
    {

        private readonly IClienteRepository _clienteRepository;
                
        public ClienteBusiness(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente AdicionarCliente(Cliente cliente)
        {
            var clienteRetorno = _clienteRepository.AdicionarCliente(cliente);
            return clienteRetorno;
        }

        
    }
}
