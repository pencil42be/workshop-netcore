namespace Pencil42.PakjesDienst.Db
{
    public class PakjesQueueSettings
    {
        public const string SectionName = "pakjes-queue";

        public string Address { get; set; }
        public string QueueName { get; set; }
    }
}