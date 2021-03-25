namespace AMS.Data.DbEntity
{
    public class FileDbEntity : BaseDbEntity
    {
        public string FilePath { get; set; }


        public int TransactionId { get; set; }

        public TransactionDbEntity Transaction { get; set; }

        
    }
}