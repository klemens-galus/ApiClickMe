using System.ComponentModel.DataAnnotations;

namespace ApiClickMe
{
    public class GAMEH
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Pseudo { get; set; } 
        public int BestTime { get; set; }
        public int MoyTime { get; set; }

    }
}
