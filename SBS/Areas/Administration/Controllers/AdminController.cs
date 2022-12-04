using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SBS.Areas.Administration.Constants.AdministrationConstants;

namespace SBS.Areas.Administration.Controllers
{
    /// <summary>
    /// Base admin data
    /// </summary>
    [Area(AreaName)]
    [Route("Administration/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]
    public class AdminController : Controller
    {
    }
}
