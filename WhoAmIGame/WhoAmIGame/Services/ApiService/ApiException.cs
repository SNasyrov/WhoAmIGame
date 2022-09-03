using Newtonsoft.Json;
using System;
using System.Net;

namespace WhoAmIGame.Services.ApiService
{
    /// <summary>
    /// Исключение HTTP API клиента
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// HTTP код ответа
        /// </summary>
        public HttpStatusCode? StatusCode { get; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public override string Message { get; }

        /// <summary>
        /// Тело ответа
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="statusCode">HTTP код ответа</param>
        /// <param name="content">Тело ответа</param>
        public ApiException(HttpStatusCode statusCode, string content)
        {
            StatusCode = statusCode;
            Content = content;

            if (StatusCode == HttpStatusCode.NotFound)
                Message = $"Не удалось получить ответ от сервера: {StatusCode}({StatusCode:D}). Возможно неправильно указана ссылка";
            else
                Message = $"Не удалось получить ответ от сервера: {StatusCode}({StatusCode:D})";
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="content">Контент</param>
        /// <param name="innerException">Внутреннее исключение</param>
        public ApiException(string message, string content, Exception innerException) : base(message, innerException)
        {
            Content = content;
        }

        /// <summary>
        /// Разбирает тело ответа с ошибкой
        /// </summary>
        /// <typeparam name="TResult">Тип результата</typeparam>
        /// <returns></returns>
        public TResult ParseContent<TResult>() => JsonConvert.DeserializeObject<TResult>(Content);

        /// <summary>
        /// Пытается разобрать тело ответа с ошибкой
        /// </summary>
        /// <typeparam name="TResult">Тип результата</typeparam>
        /// <param name="result">Результат</param>
        /// <returns></returns>
        public bool TryParseContent<TResult>(out TResult result)
        {
            try
            {
                result = ParseContent<TResult>();
                return true;
            }
            catch (JsonSerializationException)
            {
                result = default;
                return false;
            }
        }
    }
}
