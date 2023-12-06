namespace TechnicalTest.WebServices.Common
{
    public class RequestResponse<T>
    {
        /// <summary>
        /// Mensaje 
        /// </summary>
        public string? Message { get; set; }
        /// <summary>
        /// Estado 
        /// </summary>
        public bool IsSuccessful { get; set; }
        /// <summary>
        /// Estado de error
        /// </summary>
        public bool IsError { get; set; }
        /// <summary>
        /// Mensaje de error
        /// </summary>
        public string? ErrorMessage { get; set; }
        /// <summary>
        /// Resultado
        /// </summary>
        public T? Result { get; set; }

        /// <summary>
        /// Crea un resultado de petición con error
        /// </summary>
        /// <param name="error">Mensaje del error ocurrido</param>
        /// <returns> Resultado de la petición</returns>
        public RequestResponse<T> CreateError(string error)
        {
            IsSuccessful = false;
            IsError = true;
            ErrorMessage = error ?? string.Empty;
            return this;
        }

        /// <summary>
        ///  Crea un resultado de petición exitoso
        /// </summary>
        /// <param name="result"> Objeto resultado</param>
        /// <returns>Resultado de la petición</returns>
        public RequestResponse<T> CreateSuccessful(T result)
        {
            IsSuccessful = true;
            IsError = false;
            Result = result;
            return this;
        }

        /// <summary>
        ///  Crea un resultado de petición exitoso
        /// </summary>
        /// <param name="result"> Objeto resultado</param>
        /// <param name="message"> Mensaje del resultado</param>
        /// <returns>Resultado de la petición</returns>
        public RequestResponse<T> CreateSuccessful(T result, string message)
        {
            IsSuccessful = true;
            Message = message ?? string.Empty;
            IsError = false;
            Result = result;
            return this;
        }

        /// <summary>
        ///  Crea un resultado de petición fracasado
        /// </summary>
        /// <param name="result">Mensajes de validación que no permitieron que el resultado fuera exitoso</param>
        /// <returns>Resultado de la petición</returns>
        public RequestResponse<T> CreateUnsuccessful(string messages)
        {
            IsSuccessful = false;
            IsError = false;
            Message = messages ?? string.Empty;
            return this;
        }
    }
}
