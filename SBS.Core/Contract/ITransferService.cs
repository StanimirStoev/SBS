using SBS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Core.Contract
{
    public interface ITransferService
    {
        Task<IEnumerable<TransferViewModel>> GetAll();
    }
}
