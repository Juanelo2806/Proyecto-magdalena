using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MGPRECISION.Models
{
    public class Lote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public Decimal Area { get; set; }
        public int Sector { get; set; }
        
        public bool Estado { get; set; }
       
        public int FincaId { get; set; }

       
        public Finca Finca { get; set; }
    }
}
