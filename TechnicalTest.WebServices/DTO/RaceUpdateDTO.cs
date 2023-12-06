namespace TechnicalTest.WebServices.DTO
{
    public class RaceUpdateDTO
    {
        public int Id { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public bool State { get; set; }
    }
}
