using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1.Contracts.V1;
using Web1.Contracts.V1.Requests;
using Web1.Contracts.V1.Requests.Querries;
using Web1.Contracts.V1.Responses;
using Web1.Domain;
using Web1.Services;

namespace Web1.Controllers.V1
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmnetService _service;
        private readonly IMapper _map;
        public DepartmentController(IDepartmnetService departmnetService, IMapper mapper)
        {
            _service = departmnetService;
            _map = mapper;

        }
        [HttpGet(ApiRoutes.Department.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuerry paginationQuerry)
        {
           
            var paginationResonse = await _service.GetPagination_Async(paginationQuerry);
            if (paginationResonse == null)
            {
               return BadRequest();
            }
            return Ok(_map.Map<PagePagination<DepartmentDTO>>(paginationResonse));


        }
        [HttpGet(ApiRoutes.Department.Get)]
        public async Task<IActionResult> GetOne([FromRoute] int departmentId)
        {
            var rs = await _service.GetOne_Async(departmentId);
            if (rs == null)
            {
                NoContent();
            }
            
            return Ok(_map.Map<DepartmentDTO>(rs));
        }
        [HttpPost(ApiRoutes.Department.Create)]
        public async Task<IActionResult> Create([FromBody] DepartmentRequest departmentRequest)
        {
            var dep = _map.Map<Department>(departmentRequest);
            await _service.Create_Async(dep);
            return CreatedAtAction(nameof(GetOne), new
            {
                departmentId = dep.DepartmentId
            }, _map.Map<DepartmentDTO>(dep));
        }
       
    }
}
