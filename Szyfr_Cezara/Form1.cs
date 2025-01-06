using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Szyfr_Cezara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Funkcja do szyfrowania
        private string CaesarEncrypt(string input, int key)
        {
            string alphabetLower = "aπbcÊdeÍfghijkl≥mnÒoÛpqrsútuvwxyzüø";
            string alphabetUpper = "A•BC∆DE FGHIJKL£MN—O”PQRSåTUVWXYZèØ";

            return ShiftText(input, key, alphabetLower, alphabetUpper);
        }

        // Funkcja do deszyfrowania
        private string CaesarDecrypt(string input, int key)
        {
            string alphabetLower = "aπbcÊdeÍfghijkl≥mnÒoÛpqrsútuvwxyzüø";
            string alphabetUpper = "A•BC∆DE FGHIJKL£MN—O”PQRSåTUVWXYZèØ";

            return ShiftText(input, -key, alphabetLower, alphabetUpper);
        }

        // Uniwersalna funkcja przesuwania znakÛw w alfabecie
        private string ShiftText(string input, int key, string alphabetLower, string alphabetUpper)
        {
            char[] buffer = input.ToCharArray();
            int alphabetLength = alphabetLower.Length; // D≥ugoúÊ polskiego alfabetu

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                // Sprawdzamy, czy to litera (ma≥a)
                if (alphabetLower.Contains(letter))
                {
                    int index = alphabetLower.IndexOf(letter);
                    int newIndex = (index + key) % alphabetLength;

                    // Obs≥uga ujemnych indeksÛw
                    if (newIndex < 0)
                        newIndex += alphabetLength;

                    buffer[i] = alphabetLower[newIndex];
                }
                // Sprawdzamy, czy to litera (wielka)
                else if (alphabetUpper.Contains(letter))
                {
                    int index = alphabetUpper.IndexOf(letter);
                    int newIndex = (index + key) % alphabetLength;

                    // Obs≥uga ujemnych indeksÛw
                    if (newIndex < 0)
                        newIndex += alphabetLength;

                    buffer[i] = alphabetUpper[newIndex];
                }
            }

            return new string(buffer);
        }

        // Obs≥uga przycisku szyfrowania
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            int key = (int)numKey.Value;
            txtOutput.Text = CaesarEncrypt(input, key);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;  // Pobieramy tekst z pola wejúciowego
            int key = (int)numKey.Value;   // Pobieramy wartoúÊ klucza z NumericUpDown
            txtOutput.Text = CaesarDecrypt(input, key);  // Wywo≥ujemy funkcjÍ odszyfrowania i wyúwietlamy wynik w txtOutput
        }

    }
}
