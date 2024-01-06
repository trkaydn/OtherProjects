//GBAKFramework 3.0.0
namespace GBAK
{
    public class Error
    {
        public Error()
        {
            Status = false;
            Description = "";
        }
        public bool Status { get; set; }
        public string Description { get; set; }
        public void SETNotNullable(string value)
        {
            Description = "The \"" + value + "\" field can not be null.";
        }
    }
}



