namespace Bot.Data.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int SourceUserId { get; set; }
        public int TargetUserId { get; set; }
        public int WarningMessage { get; set; }
        public int ReportedMessage { get; set; }

    }
}
