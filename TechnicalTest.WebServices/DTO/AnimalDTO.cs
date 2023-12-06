using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.WebServices.DTO
{
    public class AnimalDTO
    {
        /// <summary>
        /// Nombre
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Fecha de Nacimiento
        /// </summary>
        public string? BirthDate { get; set; }
        /// <summary>
        /// Género
        /// </summary>
        public string? Gender { get; set; }
        /// <summary>
        /// Precio
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// Id Raza
        /// </summary>
        public int RaceId { get; set; }
    }
}
