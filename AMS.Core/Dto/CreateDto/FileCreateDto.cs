namespace AMS.Core.Dto.CreateDto
{
    public class FileCreateDto
    {
        public string File { get; set; }

        public string FileExtension { get; set; }

        public int TransactionId { get; set; }
        
    }
}