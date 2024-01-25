using System.ComponentModel.DataAnnotations;

namespace Blazor.Frontend.Bootstrap.Classes
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
        public DateTime Time { get; set; } = DateTime.Now;
        public bool AutoDismiss { get; set; } = false;
        public double DisplayTime { get; set; } = 3;
        public bool IsVisible { get; set; } = true;
        public override string ToString()
        {
            return $"{Type}: {Text} - {Time}";
        }
    }
}
