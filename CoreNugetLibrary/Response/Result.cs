namespace SG.Kernel.Response
{
    public class Result
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public Severity Severity { get; set; }
    }

    public enum Severity
    {
        Lower = 1,
        High = 2
    }
}