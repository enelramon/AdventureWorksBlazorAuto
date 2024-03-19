using AdventureWorksBlazorAuto.DAL;
using AdventureWorksBlazorAuto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace AdventureWorksBlazorAuto.Services;

public class DepartmentsService(AdventureWorks2019Context context)
{
    public async Task<IEnumerable<DepartmentDto>> GetDepartments()
    {
        return await context.Departments
            .Select(d => new DepartmentDto()
            {
                DepartmentId = d.DepartmentId,
                Name = d.Name
            }).ToListAsync();
    }

    public async Task<Department?> GetDepartment(short id)
    {
        return await context.Departments.FindAsync(id);
    }

    public async Task<Department> Save(Department department)
    {
        context.Departments.Add(department);
        await context.SaveChangesAsync();
        return department;
    }
}

