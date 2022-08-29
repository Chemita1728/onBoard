using System.ComponentModel.DataAnnotations;

namespace onBoard.Models
{
    public class Hour
    {
        public string UserName { get; set; }
        public TimeSpan HourPressed { get; set; }
    }
}
