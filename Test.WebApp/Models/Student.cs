using Test.WebApp.Models.Base;

namespace Test.WebApp.Models
{
    public class Student: AuditableEntity
    {
        public string Name {  get; set; }
        public string Email {  get; set; }
        public string Phone {  get; set; }
        public string Image {  get; set; }
        public string RegistrationId {  get; set; }
    }
}
