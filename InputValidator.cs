namespace WeatherWpfApp
{
    public static class InputValidator
    {
        public static void CheckLogin(string login)
        {
            foreach (var symbol in login)
            {
                if (symbol >= '0' && symbol <= '9')
                {
                    throw new Exception("Логин не должен содержать цифры!");
                }
                if (!(symbol >= 'A' && symbol <= 'z'))
                {
                    throw new Exception("Для логина используйте только латинские буквы!");
                }
            }
        }

        public static void CheckPassword(string password)
        {
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
                if (symbol >= 'A' && symbol <= 'Z')
                {
                    capitalLetterCount++;
                }
                else if (symbol >= 'a' && symbol <= 'z')
                {
                    lowercaseLetterCount++;
                }
                else if (symbol >= '0' && symbol <= '9')
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
    }
}
