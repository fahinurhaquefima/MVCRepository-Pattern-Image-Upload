using Test.WebApp.Models;
using Test.WebApp.Service;
using Test.WebApp.ViewModel;

namespace Test.WebApp.RepositoryService;

public interface IStudentRepository:IRepositoryService<Student,StudentVm>
{
}
