﻿using Microsoft.EntityFrameworkCore;
using SEGES.Backend.Helpers;
using SEGES.Backend.Repositories.Interfaces;
using SEGES.Backend.UnitsOfWork.Implementations;
using SEGES.Shared;
using SEGES.Shared.Entities;
using SEGES.Shared.Responses;
using SEGES.Shared.DTOs;
using static SEGES.Backend.Repositories.Implementations.CitiesRepository;

namespace SEGES.Backend.Repositories.Implementations
{
    
        public class CitiesRepository : GenericRepository<City>, ICitiesRepository
        {
            private readonly DataContext _context;

            public CitiesRepository(DataContext context) : base(context)
            {
                _context = context;
            }

            public async Task<IEnumerable<City>> GetComboAsync(int stateId)
            {
                return await _context.Cities
                    .Where(c => c.StateId == stateId)
                    .OrderBy(c => c.Name)
                    .ToListAsync();
            }

            public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination)
            {
                var queryable = _context.Cities
                    .Where(x => x.State!.StateId == pagination.Id)
                    .AsQueryable();


                return new ActionResponse<IEnumerable<City>>
                {
                    WasSuccess = true,
                    Result = await queryable
                        .OrderBy(x => x.Name)
                        .Paginate(pagination)
                        .ToListAsync()
                };
            }

            public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination)
            {
                var queryable = _context.Cities
                    .Where(x => x.State!.StateId == pagination.Id)
                    .AsQueryable();



                double count = await queryable.CountAsync();
                int totalPages = (int)Math.Ceiling(count / pagination.RecordsNumber);
                return new ActionResponse<int>
                {
                    WasSuccess = true,
                    Result = totalPages
                };
            }
        }
    
}