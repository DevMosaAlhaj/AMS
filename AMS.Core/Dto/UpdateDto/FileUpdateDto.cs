namespace AMS.Core.Dto.UpdateDto
{
    public class FileUpdateDto
    {
        
        public int Id { get; set; }
        
        public string File { get; set; }

        public string FileExtension { get; set; }

        public int? TransactionId { get; set; }
        
    }
}