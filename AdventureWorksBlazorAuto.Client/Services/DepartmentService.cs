using Shared;
using System.Net.Http.Json;

namespace AdventureWorksBlazorAuto.Client.Services;

public class DepartmentService(HttpClient httpClient)
{
    public async Task<List<DepartmentDto>?> GetDepartments()
    {
       return await httpClient
            .GetFromJsonAsync<List<DepartmentDto>>("api/Departments");
    }

    public async Task<DepartmentDto?> GetDepartment(int id)
    {
        return await httpClient
            .GetFromJsonAsync<DepartmentDto>($"api/Departments/{id}");
    }
}
