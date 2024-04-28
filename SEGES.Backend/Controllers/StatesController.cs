﻿using Microsoft.AspNetCore.Mvc;
using SEGES.Shared.Entities;
using SEGES.Shared.DTOs;
using SEGES.Backend.UnitsOfWork.Interfaces;

namespace SEGES.Backend.Controllers
{
    public class StatesController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class StatesController : GenericController<State>
        {
            private readonly IStateUnitOfWork _statesUnitOfWork;

            public StatesController(IGenericUnitOfWork<State> unitOfWork, IStateUnitOfWork statesUnitOfWork) : base(unitOfWork)
            {
                _statesUnitOfWork = statesUnitOfWork;
            }

            [HttpGet("full")]
            public override async Task<IActionResult> GetAsync()
            {
                var response = await _statesUnitOfWork.GetAsync();
                if (response.WasSuccess)
                {
                    return Ok(response.Result);
                }
                return BadRequest();
            }

            [HttpGet]
            public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
            {
                var response = await _statesUnitOfWork.GetAsync(pagination);
                if (response.WasSuccess)
                {
                    return Ok(response.Result);
                }
                return BadRequest();
            }

            [HttpGet("totalPages")]
            public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
            {
                var action = await _statesUnitOfWork.GetTotalPagesAsync(pagination);
                if (action.WasSuccess)
                {
                    return Ok(action.Result);
                }
                return BadRequest();
            }

            [HttpGet("{id}")]
            public override async Task<IActionResult> GetAsync(int id)
            {
                var response = await _statesUnitOfWork.GetAsync(id);
                if (response.WasSuccess)
                {
                    return Ok(response.Result);
                }
                return NotFound(response.Message);
            }
        }
    }
}
