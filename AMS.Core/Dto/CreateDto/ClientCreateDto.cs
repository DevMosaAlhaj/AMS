using System.Diagnostics.CodeAnalysis;

namespace AMS.Core.Dto.CreateDto
{
    public class ClientCreateDto
    {
        [NotNull]
        public string Name { get; set; }

        public string Mediator { get; set; }

        [NotNull]
        public string Address { get; set; }

        [NotNull]
        public string PhoneNumber { get; set; }

        public int IdentityNo { get; set; }
    }
}