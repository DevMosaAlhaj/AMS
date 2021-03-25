namespace AMS.Core.Dto.UpdateDto
{
    public class ClientUpdateDto
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Mediator { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int? IdentityNo { get; set; }
    }
}