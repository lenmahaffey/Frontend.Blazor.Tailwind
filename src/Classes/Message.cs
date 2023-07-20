using System.ComponentModel.DataAnnotations;

namespace Blazor.Frontend.Classes
{
    public class Message : EventArgs
    {
        public Message()
        {
            
        }

        public Message(Message m)
        {
            Title = m.Title;
            Text = m.Text;
            Time = m.Time;  
            Type = m.Type;
            AutoDismiss = m.AutoDismiss;
        }

        [Required]
        [StringLength(25, ErrorMessage ="Message title must be shorter than 25 chars")]
        public string Title { get; set; } = "Error!";

        [Required]
        [StringLength(250, ErrorMessage = "Message text must be shorter than 250 chars")]
        public string Text { get; set; } = "An unhandled exception has occured";
        
        [Required]
        public MessageType Type { get; set; } = MessageType.Error;
        public DateTime Time { get; set; } = DateTime.Now;
        public bool AutoDismiss { get; set; } = true;
        public bool IsDismissed { get; set; } = false;
        public bool HasDisplayed { get; set; } = false;
        public bool IsVisible { get; set; } = true;
        
    }
}
