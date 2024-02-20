using AutoMapper;
using Test.WebApp.DatabaseContext;
using Test.WebApp.Models;
using Test.WebApp.Service;
using Test.WebApp.ViewModel;

namespace Test.WebApp.RepositoryService;

public class StudentRepository:RepositoryService<Student,StudentVm>, IStudentRepository
{
    public StudentRepository(StudentDbContext dbContext, IMapper mapper ):base(dbContext, mapper)
    {
        
    }
}
