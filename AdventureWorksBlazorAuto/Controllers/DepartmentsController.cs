using AdventureWorksBlazorAuto.Models;
using AdventureWorksBlazorAuto.Services;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace AdventureWorksBlazorAuto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController(DepartmentsService departmentService) : ControllerBase
    {
        // GET: api/GetDepartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            var deps = await departmentService.GetDepartments();
            return Ok(deps);
        }

        // GET: api/GetDepartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(short id)
        {
            return await departmentService.GetDepartment(id);
        }
        
        // POST: api/GetDepartments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> SaveDepartment(Department department)
        {
            var departmentSaved = await departmentService.Save(department);
            return Ok(departmentSaved);
        }

    }
}
