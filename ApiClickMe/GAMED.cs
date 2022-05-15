using Microsoft.EntityFrameworkCore;

namespace ApiClickMe
{
    public class GAMED
    {
        public int Id { get; set; }
        public int ClickNumber { get; set; }
        public int Time { get; set; } 
        public int GameId { get; set; }
    }
}
