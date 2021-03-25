namespace AMS.Core.ViewModel
{
    public class FileViewModel : IBaseViewModel
    {
        public int Id { get; set; }

        public string FilePath { get; set; }

        public int TransactionId { get; set; }
    }
}