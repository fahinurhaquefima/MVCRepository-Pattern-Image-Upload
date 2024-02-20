using AutoMapper;
using Test.WebApp.Models;
using Test.WebApp.Models.Base;

namespace Test.WebApp.ViewModel;
[AutoMap(typeof(Student),ReverseMap =true)]
public class StudentVm:BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Image { get; set; }
    public string RegistrationId { get; set; }
}
