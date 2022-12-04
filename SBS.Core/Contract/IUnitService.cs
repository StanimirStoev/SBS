using SBS.Core.Models;
using SBS.Tools;

namespace SBS.Core.Contract
{
    /// <summary>
    /// Service for Units
    /// </summary>
    public interface IUnitService
    {
        /// <summary>
        /// Get count of filtered units
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        int GetCount(UnitFilterViewModel filter);

        /// <summary>
        /// Get list of all units sorted and paginated
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="sortHelper"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<UnitViewModel>> GetAll(UnitFilterViewModel filter, SortHelper sortHelper, int pageIndex = 1, int pageSize = 5);

        /// <summary>
        /// Get list of all units
        /// </summary>
        /// <returns></returns>
        Task<List<UnitViewModel>> GetAll();

        /// <summary>
        /// Add Unit in repository
        /// </summary>
        /// <param name="unitViewModel"></param>
        /// <returns></returns>
        Task Add(UnitViewModel unitViewModel);

        /// <summary>
        /// Delete Unit from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);

        /// <summary>
        /// Gets unit from repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UnitViewModel> Get(Guid id);

        /// <summary>
        /// Updates an Unit
        /// </summary>
        /// <param name="unitViewModel"></param>
        /// <returns></returns>
        Task Update(UnitViewModel unitViewModel);

        /// <summary>
        /// Checks is unit exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExists(string name);

        /// <summary>
        /// Checks is unit exists
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsExists(string name, Guid id);
    }
}
