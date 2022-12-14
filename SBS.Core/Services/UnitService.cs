using Microsoft.EntityFrameworkCore;
using SBS.Core.Contract;
using SBS.Core.Models;
using SBS.Infrastructure.Data.Common;
using SBS.Infrastructure.Data.Models;
using SBS.Tools;

namespace SBS.Core.Services
{
    /// <summary>
    /// Service for Units
    /// </summary>
    public class UnitService : IUnitService
    {
        private readonly ISbsRepository repo;

        /// <summary>
        /// Init service
        /// </summary>
        /// <param name="repo"></param>
        public UnitService(ISbsRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Add Unit in repository
        /// </summary>
        /// <param name="unitViewModel"></param>
        /// <returns></returns>
        public async Task Add(UnitViewModel unitViewModel)
        {
            Sanitizer.Sanitize(unitViewModel);
            var unit = new Unit()
            {
                Id = unitViewModel.Id,
                Name = unitViewModel.Name,
                Description = unitViewModel.Description,
            };

            await repo.AddAsync(unit);
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Delete Unit from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            var unit = await repo.All<Unit>()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (unit != null)
            {
                unit.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets unit from repository by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UnitViewModel> Get(Guid id)
        {
            UnitViewModel model = new UnitViewModel();
            var unit = await repo.GetByIdAsync<Unit>(id);


            if (unit != null)
            {
                model = new UnitViewModel()
                {
                    Id = unit.Id,
                    Name = unit.Name,
                    Description = unit.Description ?? String.Empty,
                    IsActive = unit.IsActive,
                };
            }
            return model;
        }

        /// <summary>
        /// Get list of all units sorted and paginated
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="sortHelper"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<UnitViewModel>> GetAll(UnitFilterViewModel filter, SortHelper sortHelper, int pageIndex = 1, int pageSize = 5)
        {
            IQueryable<Unit> units =  repo.AllReadonly<Unit>()
                .Where(u => u.IsActive);

            if(!string.IsNullOrEmpty(filter.Name))
            {
                units = units.Where(u => u.Name.Contains(filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.Description))
            {
                units = units.Where(u => u.Description.Contains(filter.Description));
            }

            List<UnitViewModel> unitViewModels = await units
                .Select(u => new UnitViewModel()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Description = u.Description ?? "",
                    IsActive = u.IsActive,
                }).ToListAsync();

            sortHelper.ApplySort<UnitViewModel>(ref unitViewModels);

            unitViewModels = unitViewModels.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            //PaginatedList<UnitViewModel> retUnits = new PaginatedList<UnitViewModel>(unitViewModels, pageIndex, pageSize);

            return unitViewModels;
        }

        /// <summary>
        /// Get list of all units
        /// </summary>
        /// <returns></returns>
        public async Task<List<UnitViewModel>> GetAll()
        {
            return await repo.AllReadonly<Unit>()
                .Where(u => u.IsActive)
                .Select(u => new UnitViewModel()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Description = u.Description ?? "",
                    IsActive = u.IsActive,
                })
                .ToListAsync();

        }

        /// <summary>
        /// Get count of filtered units
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public int GetCount(UnitFilterViewModel filter)
        {
            IQueryable<Unit> units = repo.AllReadonly<Unit>()
                .Where(u => u.IsActive);

            if (!string.IsNullOrEmpty(filter.Name))
            {
                units = units.Where(u => u.Name.Contains(filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.Description))
            {
                units = units.Where(u => u.Description.Contains(filter.Description));
            }
            return units.Count();
        }

        /// <summary>
        /// Updates an Unit
        /// </summary>
        /// <param name="unitViewModel"></param>
        /// <returns></returns>
        public async Task Update(UnitViewModel unitViewModel)
        {
            Sanitizer.Sanitize(unitViewModel);
            var unit = await repo.GetByIdAsync<Unit>(unitViewModel.Id);
            if (unit != null)
            {
                unit.Name = unitViewModel.Name;
                unit.Description = unitViewModel.Description;
                unit.IsActive = unitViewModel.IsActive;

                await repo.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Checks is unit exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExists(string name)
        {
            return repo.All<Unit>().Where(n => n.Name.ToLower() == name.ToLower()).Count() > 0;
        }
        /// <summary>
        /// Checks is unit exists
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsExists(string name, Guid id)
        {
            return repo.All<Unit>().Where(n => n.Name.ToLower() == name.ToLower() && n.Id != id).Count() > 0;
        }
    }
}
