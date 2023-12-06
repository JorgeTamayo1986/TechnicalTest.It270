namespace TechnicalTest.WebServices.DTO
{
    public class PageResponseDTO<T>
    {
        public List<T> Response { get; set; } = new();
        /// <summary>
        /// Solicitud de paginación
        /// </summary>
        public int Pages { get; set; }
        /// <summary>
        /// La página actual que se solicitó por lo que Results vendrán los resultados de la página actual
        /// </summary>
        public int CurrentPage { get; set; }
    }
}
