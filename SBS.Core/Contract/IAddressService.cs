using SBS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Contract
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressViewModel>> GetAll();

        Task Add(AddressViewModel addressViewModel);

        Task Delete(Guid id);

        Task<AddressViewModel> Get(Guid id);

        Task Update(AddressViewModel addressViewModel);
    }
}
