using AMS.Core.Enum;

namespace AMS.Core.Dto.UpdateDto
{
    public class UserUpdateDto
    {

        public string Id { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public int ForEmpId { get; set; }

        public UserType? UserType { get; set; }
    }
}