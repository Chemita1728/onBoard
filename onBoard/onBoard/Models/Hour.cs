using System.ComponentModel.DataAnnotations;

namespace onBoard.Models
{
    public class Hour
    {
        public int HourID { get; set; }
        public string UserName { get; set; }
        public TimeSpan HourPressed { get; set; }
        public User User { get; set; }
    }
}
