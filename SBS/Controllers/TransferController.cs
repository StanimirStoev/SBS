using Microsoft.AspNetCore.Mvc;
using SBS.Core.Contract;

namespace SBS.Controllers
{
    public class TransferController : Controller
    {
        private readonly ITransferService service;

        public TransferController(ITransferService service)
        {
            this.service = service;
        }

        // GET: ContragentController
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var transfers = await service.GetAll();
            ViewData["Title"] = "Transfers";

            return View(transfers);
        }
    }
}
