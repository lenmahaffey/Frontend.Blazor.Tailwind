using System.ComponentModel.DataAnnotations;

namespace Frontend.Blazor.Tailwind.Classes
{
    public class Message
    {

        [Required]
        [StringLength(25, ErrorMessage = "Message title must be shorter than 25 chars")]
        public string Title { get; set; } = "Error!";

        [Required]
        [StringLength(250, ErrorMessage = "Message text must be shorter than 250 chars")]
        public string Text { get; set; } = "An unhandled exception has occured";

        [Required]
        public MessageType Type { get; set; } = MessageType.Error;

        [Range(1, 10, ErrorMessage = "Invalid")]
        [RegularExpression(@"^\d*\.?\d{1,2}$", ErrorMessage = "Too Long")]
        public double DisplayTime { get; set; } = 3;
        public DateTime Time { get; set; } = DateTime.Now;
        public bool AutoDismiss { get; set; } = true;
        public bool IsVisible { get; set; } = true;
    }
}
