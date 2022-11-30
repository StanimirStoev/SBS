using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SBS.Areas.Administration.Contants.AdministrationConstants;

namespace SBS.Areas.Administration.Controllers
{
    [Area(AreaName)]
    [Route("Administration/[controller]/[Action]/{id?}")]
    //[Authorize(Roles = AdminRoleName)]
    public class AdminController : Controller
    {
    }
}
