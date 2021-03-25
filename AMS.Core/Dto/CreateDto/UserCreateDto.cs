using AMS.Core.Enum;

namespace AMS.Core.Dto.CreateDto
{
    public class UserCreateDto
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int ForEmpId { get; set; }

        public UserType UserType { get; set; }
    }
}