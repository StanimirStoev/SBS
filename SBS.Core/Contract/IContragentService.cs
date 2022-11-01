using SBS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Contract
{
    public interface IContragentService
    {
        Task<IEnumerable<ContragentViewModel>> GetAll();

        Task Add(ContragentViewModel contragentViewModel);

        Task Delete(Guid id);

        Task<ContragentViewModel> Get(Guid id);

        Task Update(ContragentViewModel contragentViewModel);
    }
}
