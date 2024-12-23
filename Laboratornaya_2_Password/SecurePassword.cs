using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laboratornaya_2_Password
{
    public class SecurePassword : Password
    {
        // Личная информация пользователя
        private string firstName;
        private string lastName;
        private string birthDate; // В формате "ddmmyy"
        private string nickname;

        public SecurePassword(string password, string firstName, string lastName, string birthDate, string nickname)
            : base(password)
        {
            this.firstName = firstName.ToLower();
            this.lastName = lastName.ToLower();
            this.birthDate = birthDate;
            this.nickname = nickname.ToLower();
        }

        // Метод анализа надежности пароля
        public bool AnalyzeStrength()
        {
            bool isStrong = true;

            // Проверка длины
            if (password.Length <= 12)
            {
                MessageBox.Show("Пароль должен содержать более 12 символов.");
                isStrong = false;
            }

            // Проверка наличия строчных, прописных букв, цифр и символов
            if (!password.Any(char.IsLower))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну строчную букву.");
                isStrong = false;
            }
            if (!password.Any(char.IsUpper))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну прописную букву.");
                isStrong = false;
            }
            if (!password.Any(char.IsDigit))
            {
                MessageBox.Show("Пароль должен содержать хотя бы одну цифру.");
                isStrong = false;
            }
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Пароль должен содержать хотя бы один символ.");
                isStrong = false;
            }

            // Проверка на последовательности более двух символов на клавиатуре
            if (HasKeyboardSequentialChars(password))
            {
                MessageBox.Show("Пароль не должен содержать последовательности более двух символов на клавиатуре.");
                isStrong = false;
            }

            // Проверка на наличие личной информации
            if (ContainsPersonalInfo(password.ToLower()))
            {
                MessageBox.Show("Пароль не должен содержать вашу личную информацию.");
                isStrong = false;
            }

            return isStrong;
        }

        // Метод проверки последовательностей на клавиатуре
        private bool HasKeyboardSequentialChars(string pwd)
        {
            // Простейший подход: проверка последовательностей из цифр и букв
            // Более сложные проверки можно реализовать, используя раскладку клавиатуры

            // Проверка последовательности цифр
            for (int i = 0; i < pwd.Length - 2; i++)
            {
                if (char.IsDigit(pwd[i]) && char.IsDigit(pwd[i + 1]) && char.IsDigit(pwd[i + 2]))
                {
                    int first = pwd[i] - '0';
                    int second = pwd[i + 1] - '0';
                    int third = pwd[i + 2] - '0';
                    if (second == first + 1 && third == second + 1)
                        return true;
                }
            }

            // Проверка последовательности букв
            for (int i = 0; i < pwd.Length - 2; i++)
            {
                if (char.IsLetter(pwd[i]) && char.IsLetter(pwd[i + 1]) && char.IsLetter(pwd[i + 2]))
                {
                    int first = char.ToLower(pwd[i]) - 'a';
                    int second = char.ToLower(pwd[i + 1]) - 'a';
                    int third = char.ToLower(pwd[i + 2]) - 'a';
                    if (second == first + 1 && third == second + 1)
                        return true;
                }
            }

            return false;
        }

        // Метод проверки наличия личной информации в пароле
        private bool ContainsPersonalInfo(string pwd)
        {
            if (pwd.Contains(firstName) || pwd.Contains(lastName) || pwd.Contains(nickname))
                return true;

            // Проверка последних двух цифр даты рождения
            if (birthDate.Length >= 2)
            {
                string lastTwo = birthDate.Substring(birthDate.Length - 2);
                if (pwd.Contains(lastTwo))
                    return true;
            }

            return false;
        }
    }
}
