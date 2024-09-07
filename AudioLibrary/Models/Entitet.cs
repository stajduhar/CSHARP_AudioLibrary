using System.ComponentModel.DataAnnotations;

namespace AudioLibrary.Models
{
    public abstract class Entitet
    {
        [Key]
        public int id { get; set; }
    }
}
