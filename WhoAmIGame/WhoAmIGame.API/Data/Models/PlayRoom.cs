#nullable disable

namespace WhoAmIGame.Data.Models
{
    /// <summary>
    /// Лобби
    /// </summary>
    public class PlayRoom
    {
        /// <summary>
        /// Идентификатор лобби
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название лобби
        /// </summary>
        public string LobbyName { get; set; }

        /// <summary>
        /// Количество игроков в лобби
        /// </summary>
        public int NumberOfPlayers { get; set; }
    }
}
