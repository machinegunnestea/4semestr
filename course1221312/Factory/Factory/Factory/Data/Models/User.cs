using System.Collections.Generic;

namespace Factory.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Level { get; set; }

        public string Access => Accesses[Level];

        public static readonly Dictionary<int, string> Accesses = new()
        {
            [1] = "Администратор",
            [2] = "Менеджер",
            [3] = "Пользователь"
        };
    }
}
