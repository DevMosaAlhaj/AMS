namespace AMS.Core.Dto.UpdateDto
{
    public class EmployeeUpdateDto
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int? IdentityNo { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string JobName { get; set; }
    }
}