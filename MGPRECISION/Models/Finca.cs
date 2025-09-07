using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MGPRECISION.Models
{
    public class Finca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public String? Nombre { get; set; }
        public bool Estado { get; set; }

        public ICollection<Lote> Lotes { get; set; }
    }
}
