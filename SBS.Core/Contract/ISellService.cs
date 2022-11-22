using SBS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Contract
{
    public interface ISellService
    {
        Task<IEnumerable<SellViewModel>> GetAll();

        Task Add(SellViewModel viewModel);

        Task Delete(Guid id);

        Task<SellViewModel> Get(Guid id);

        Task Update(SellViewModel viewModel);
    }
}
