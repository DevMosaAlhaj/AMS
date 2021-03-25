namespace AMS.Core.Dto.CreateDto
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; }

        public int? IdentityNo { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string JobName { get; set; }
    }
}