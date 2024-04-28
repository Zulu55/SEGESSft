﻿using SEGES.Shared.Entities;
using SEGES.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using SEGES.Shared.DTOs;


namespace SEGES.Backend.UnitsOfWork.Interfaces
{
    public class ICitiesUnitOfWork
    {
        Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}
