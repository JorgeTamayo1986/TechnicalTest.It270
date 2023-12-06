using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalTest.Models
{
    /// <summary>
    /// Clase para gestionar los animales
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        [Key]
        public string Name { get; set; }
        /// <summary>
        /// Fecha de Nacimiento
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// Género
        /// </summary>
        public string? Gender { get; set; }
        /// <summary>
        /// Precio
        /// </summary>
        public decimal  Price { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public bool State { get; set; }
        public int RaceId { get; set; }
        /// <summary>
        /// Raza
        /// </summary>
        [ForeignKey("RaceId")]
        public virtual Race Race { get; set; }

    }
}
