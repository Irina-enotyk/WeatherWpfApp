namespace WeatherWpfApp.Models
{
    public static class InputValidator
    {
        public static void CheckLogin(string login)
        {
            if(login == null || login == string.Empty)
            {
                throw new Exception("Логин не может быть пустым");
            }

            foreach (var symbol in login)
            {
                if (IsNumber(symbol))
                {
                    throw new Exception("Логин не должен содержать цифры!");
                }
                if (!IsCapitalLetter(symbol) && !IsLowercaseLetter(symbol))
                {
                    throw new Exception("Для логина используйте только латинские буквы!");
                }
            }
        }

        public static void CheckPassword(string password)
        {
            if (password == null || password == string.Empty)
            {
                throw new Exception("Пароль не может быть пустым");
            }

            var requaredSymbolCount = 5;

            if (password.Length < requaredSymbolCount)
            {
                throw new Exception("Пароль должен состоять минимум из 5 символов!");
            }

            var capitalLetterCount = 0;
            var lowercaseLetterCount = 0;
            var numberCount = 0;

            foreach (var symbol in password)
            {
                if (IsCapitalLetter(symbol))
                {
                    capitalLetterCount++;
                }
                else if (IsLowercaseLetter(symbol))
                {
                    lowercaseLetterCount++;
                }
                else if (IsNumber(symbol))
                {
                    numberCount++;
                }
                else
                {
                    throw new Exception("Пароль должен содержать только латинские буквы и цифры!");
                }
            }

            if (capitalLetterCount == 0 || lowercaseLetterCount == 0 || numberCount == 0)
            {
                throw new Exception("Пароль должен содержать минимум " +
                    "\n 1 Заглавную латинскую букву, " +
                    "\n 1 прописную латинскую букву, " +
                    "\n и 1 цифру!");
            }
        }

        private static bool IsCapitalLetter(char symbol)
        {
            return symbol >= 'A' && symbol <= 'Z';
        }

        private static bool IsLowercaseLetter(char symbol)
        {
            return symbol >= 'a' && symbol <= 'z';
        }

        private static bool IsNumber(char symbol)
        {
            return symbol >= '0' && symbol <= '9';
        }
    }
}
