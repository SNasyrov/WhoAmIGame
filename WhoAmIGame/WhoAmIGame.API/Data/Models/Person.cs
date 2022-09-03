#nullable disable

namespace WhoAmIGame.Data.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }
    }
}
