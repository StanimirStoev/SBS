using SBS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Contract
{
    public interface IDeliveryService
    {
        Task<IEnumerable<DeliveryViewModel>> GetAll();

        Task Add(DeliveryViewModel viewModel);

        Task Delete(Guid id);

        Task<DeliveryViewModel> Get(Guid id);

        Task<DeliveryDetailViewModel> GetPartide(Guid id);

        Task Update(DeliveryViewModel viewModel);

        Task Confirm(DeliveryViewModel viewModel);
    }
}
