using System.ComponentModel.DataAnnotations;

namespace onBoard.Models
{
    public abstract class Hour
    {
        public int HourID { get; set; }
        public string UserName { get; set; }
        public TimeSpan HourPressed { get; set; }
        public User User { get; set; }
    }
}
