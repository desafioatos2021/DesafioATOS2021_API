using Base.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DATA.Interfaces
{
    public interface IItemVendaRepository
    {
        Task<IEnumerable<ItemVenda>> RegistrarItensVenda(IEnumerable<ItemVenda> produtos);

        Task<IEnumerable<ItemVenda>> AtualizarItensVenda(IEnumerable<ItemVenda> produtos);

        Task<IEnumerable<ItemVenda>> ExcluirItensVenda(IEnumerable<ItemVenda> produtos);

        Task ItensParaRemover(int id);


    }
}
