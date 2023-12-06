using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalTest.Models
{
    /// <summary>
    /// Entidad para gestionar las razas de los bovinos
    /// </summary>
    public class Race
    {
        /// <summary>
        /// Id númerico
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public bool State { get; set; }

        public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}
