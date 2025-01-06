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
using System.Windows.Media.Animation;
using System.Diagnostics;

namespace VigenereCipherApp
{
    public partial class MainWindow : Window
    {
        // Polski alfabet
        private const string Alphabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void HighlightOutput()
        {
            Storyboard highlight = (Storyboard)FindResource("HighlightAnimation");
            highlight.Begin();
        }
        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string input = FilterInput(InputTextBox.Text.ToLower());
            string key = FilterInput(KeyTextBox.Text.ToLower());

            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Klucz musi zawierać tylko znaki z polskiego alfabetu", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string fullKey = GenerateFullKey(input, key);

            try
            {
                string result = EncryptVigenere(input, fullKey);
                OutputTextBox.Text = result;
                HighlightOutput();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas szyfrowania: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string input = FilterInput(InputTextBox.Text.ToLower());
            string key = FilterInput(KeyTextBox.Text.ToLower());

            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Należy wypełnić pola tekstowe", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string fullKey = GenerateFullKey(input, key);

            try
            {
                string result = DecryptVigenere(input, fullKey);
                OutputTextBox.Text = result;
                HighlightOutput();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas odszyfrowywania: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Clear();
            KeyTextBox.Clear();
            OutputTextBox.Clear();
        }
        private string GenerateFullKey(string input, string key)
        {
            StringBuilder fullKey = new();
            int keyIndex = 0;

            foreach (char c in input)
            {
                if (Alphabet.Contains(c))
                {
                    fullKey.Append(key[keyIndex]);
                    keyIndex = (keyIndex + 1) % key.Length;
                }
            }

            return fullKey.ToString();
        }
        private string EncryptVigenere(string input, string fullKey)
        {
            StringBuilder encryptedText = new();

            for (int i = 0; i < input.Length; i++)
            {
                int inputIndex = Alphabet.IndexOf(input[i]);
                int keyIndex = Alphabet.IndexOf(fullKey[i]);

                if (inputIndex == -1 || keyIndex == -1)
                {
                    encryptedText.Append(input[i]);
                    continue;
                }

                int encryptedIndex = (inputIndex + keyIndex) % Alphabet.Length;
                encryptedText.Append(Alphabet[encryptedIndex]);
            }

            return encryptedText.ToString();
        }
        private string DecryptVigenere(string input, string fullKey)
        {
            StringBuilder decryptedText = new();

            for (int i = 0; i < input.Length; i++)
            {
                int inputIndex = Alphabet.IndexOf(input[i]);
                int keyIndex = Alphabet.IndexOf(fullKey[i]);

                if (inputIndex == -1 || keyIndex == -1)
                {
                    decryptedText.Append(input[i]);
                    continue;
                }

                int decryptedIndex = (inputIndex - keyIndex + Alphabet.Length) % Alphabet.Length;
                decryptedText.Append(Alphabet[decryptedIndex]);
            }

            return decryptedText.ToString();
        }
        // Input filter (polish alphabet)
        private string FilterInput(string input)
        {
            StringBuilder filteredInput = new();

            foreach (char c in input)
            {
                if (Alphabet.Contains(c))
                {
                    filteredInput.Append(c);
                }
            }

            return filteredInput.ToString();
        }
    }
}

