namespace MySQLStore.Models
{
    public class StagedTransactionModel
    {
        public byte[] Key { get; set; }

        public byte[] Value { get; set; }

        public byte[] Prefix { get; set; }
    }
}
