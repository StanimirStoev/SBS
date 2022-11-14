using SBS.Core.Models;
using SBS.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Contract
{
    public interface IPartidesInStoresService
    {
        Task<IEnumerable<PartidesInStoreViewModel>> GetAll();
    }
}
