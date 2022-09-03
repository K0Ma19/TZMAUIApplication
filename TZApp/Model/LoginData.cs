using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZApp.Model
{
    /// <summary>
    /// Данные для авторизации
    /// </summary>
    public class LoginData
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public bool HasConditions { get; set; }
        public string Conditions { get; set; }

    }
}
