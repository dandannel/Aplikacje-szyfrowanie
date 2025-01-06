using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System;
using System.Linq;

namespace Szyfr_Polibiusza
{
    public partial class MainWindow : Window
    {
        private char[,] polibiuszTable;
        private readonly string alphabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";

        public MainWindow()
        {
            InitializeComponent();
            GenerateRandomPolibiusTable();
        }

        private void GenerateRandomPolibiusTable()
        {
            Random rng = new Random();
            char[] availableChars = alphabet.ToCharArray();
            availableChars = availableChars.OrderBy(c => rng.Next()).ToArray();

            polibiuszTable = new char[7, 5];
            int index = 0;

            for (int row = 0; row < 7; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (index < availableChars.Length)
                    {
                        polibiuszTable[row, col] = availableChars[index++];
                    }
                }
            }

            var emptyCells = new System.Collections.Generic.List<(int, int)>();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    emptyCells.Add((i, j));
                }
            }

            emptyCells = emptyCells.OrderBy(_ => rng.Next()).Take(3).ToList();
            foreach (var (row, col) in emptyCells)
            {
                polibiuszTable[row, col] = ' ';
            }
        }

        private string Encrypt(string input)
        {
            StringBuilder encrypted = new StringBuilder();

            input = input.ToLower();  // Konwersja całego wejścia na małe litery

            foreach (char c in input)
            {
                if (!alphabet.Contains(c)) continue;

                for (int row = 0; row < 7; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        if (polibiuszTable[row, col] == c)
                        {
                            encrypted.Append($"{row + 1}{col + 1}");
                            break;
                        }
                    }
                }
            }

            return encrypted.ToString();
        }

        private long CalculateY(long x, int a, int b)
        {
            return a * x - b;
        }

        private long EncodeTextToNumber(string input)
        {
            StringBuilder number = new StringBuilder();

            input = input.ToLower();  // Konwersja całego wejścia na małe litery

            foreach (char c in input)
            {
                if (!alphabet.Contains(c)) continue;

                for (int row = 0; row < 7; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        if (polibiuszTable[row, col] == c)
                        {
                            number.Append($"{row + 1}{col + 1}");
                            break;
                        }
                    }
                }
            }

            return long.Parse(number.ToString());
        }

        private string DecodeNumberToText(long encodedNumber)
        {
            string encodedStr = encodedNumber.ToString();
            StringBuilder decoded = new StringBuilder();

            for (int i = 0; i < encodedStr.Length; i += 2)
            {
                int row = int.Parse(encodedStr[i].ToString()) - 1;
                int col = int.Parse(encodedStr[i + 1].ToString()) - 1;

                decoded.Append(polibiuszTable[row, col]);
            }

            return decoded.ToString();
        }

        private long DecryptY(long y, int a, int b)
        {
            if (a == 0)
            {
                MessageBox.Show("Klucz A nie może być zerem!");
                return 0;
            }

            return (y + b) / a;
        }

        private void EncryptAndCalculateY_Click(object sender, RoutedEventArgs e)
        {
            string input = txtInput.Text.ToLower();  // Konwersja na małe litery

            string encryptedText = Encrypt(input);

            if (long.TryParse(txtA.Text, out long a) &&
                long.TryParse(txtB.Text, out long b))
            {
                if (a == 0)
                {
                    MessageBox.Show("Klucz A nie może być zerem!");
                    return;
                }

                long x = EncodeTextToNumber(input);
                long y = CalculateY(x, (int)a, (int)b);

                txtOutput.Text = y.ToString();
            }
            else
            {
                MessageBox.Show("Wprowadź poprawne wartości kluczy A i B.");
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string encryptedInput = txtDecryptInput.Text;

            if (long.TryParse(txtDecryptA.Text, out long a) &&
                long.TryParse(txtDecryptB.Text, out long b))
            {
                if (a == 0)
                {
                    MessageBox.Show("Klucz A nie może być zerem!");
                    return;
                }

                long y = long.Parse(encryptedInput);
                long x = DecryptY(y, (int)a, (int)b);
                string decryptedText = DecodeNumberToText(x);

                txtDecryptOutput.Text = decryptedText;
            }
            else
            {
                MessageBox.Show("Wprowadź poprawne wartości kluczy A i B.");
            }
        }
    }
}



