using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Factory.Data.Models
{
    public static class Validator
    {
        private static bool IsRussian(this string str)
        {
            return Regex.IsMatch(str, @"\p{IsCyrillic}");
        }

        private static bool CheckLength(this string str, int leftBorder = 3, int rightBorder = 100)
        {
            return (str.Length >= 3) && (str.Length <= 100);
        }

        public static User Auth(DataLayer data, string login, string password)
        {
            return data.Users.GetAll().FirstOrDefault(x => (x.Login == login) && (x.Password == password));
        }

        public static bool CompareDate(DateTime first, DateTime second)
        {
            return (first.Day == second.Day) && (first.Month == second.Month) && (first.Year == second.Year);
        }

        public static string Valid(ProductProduction material, Product product)
        {
            if ((material.Count <= 0) || (material.Count >= 100000))
            {
                return "Неверное количество";
            }
            if ((material.Date <= DateTime.Now.AddYears(-50)) || (material.Date >= DateTime.Now.AddYears(50)))
            {
                return "Неверная дата";
            }
            if (product.Plans.Any(x => CompareDate(x.Date, material.Date)))
            {
                return "На этот день уже назначен результат";
            }
            return null;
        }

        public static string Valid(ProductPlan material, Product product)
        {
            if ((material.Count <= 0) || (material.Count >= 100000))
            {
                return "Неверное количество";
            }
            if ((material.Date <= DateTime.Now.AddYears(-50)) || (material.Date >= DateTime.Now.AddYears(50)))
            {
                return "Неверная дата";
            }
            if (product.Plans.Any(x => CompareDate(x.Date, material.Date)))
            {
                return "На этот день уже назначен план";
            }
            return null;
        }

        public static string Valid(Norm material)
        {
            if (material.Raw == null)
            {
                return "Не выбрано сырьё";
            }
            if (material.Quantity is < 0.01 or > 10000)
            {
                return "Неверное количество";
            }
            return null;
        }

        public static string Valid(ProductMaterial material)
        {
            if (material.Material == null)
            {
                return "Не выбран материал";
            }
            if (material.Quantity is < 0.01 or > 10000)
            {
                return "Неверное количество";
            }
            return null;
        }

        public static string Valid(Product raw)
        {
            if (!raw.Name.CheckLength())
            {
                return "Неверный формат наименования";
            }
            if (!raw.Name.IsRussian())
            {
                return "Название должно быть на кириллице";
            }
            return null;
        }

        public static string Valid(Material raw)
        {
            if (!raw.Name.CheckLength())
            {
                return "Неверный формат наименования";
            }
            if (!raw.Name.IsRussian())
            {
                return "Название должно быть на кириллице";
            }
            return null;
        }

        public static string Valid(Raw raw)
        {
            if (!raw.Name.CheckLength())
            {
                return "Неверный формат наименования";
            }
            if (!raw.Name.IsRussian())
            {
                return "Название должно быть на кириллице";
            }
            return null;
        }

        public static string Valid(User user, IRepository<User> data, bool ignoreLogin = false)
        {
            if (!ignoreLogin)
            {
                if (data.GetAll().Any(x => x.Login == user.Login))
                {
                    return "Уже существует пользователь с таким логином";
                }
            }
            if (user.Login.Contains(' '))
            {
                return "В строке логин не может быть пробелов";
            }
            if (!user.Login.CheckLength())
            {
                return "Строка логин некорректна";
            }
            if (!user.Password.CheckLength())
            {
                return "Строка пароль неккоректна";
            }
            return null;
        }
    }
}
