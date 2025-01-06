using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Szyfr_Cezara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string CaesarEncrypt(string input, int key)
        {
            string alphabetLower = "aπbcÊdeÍfghijkl≥mnÒoÛpqrsútuvwxyzüø";
            string alphabetUpper = "A•BC∆DE FGHIJKL£MN—O”PQRSåTUVWXYZèØ";

            return ShiftText(input, key, alphabetLower, alphabetUpper);
        }
        private string CaesarDecrypt(string input, int key)
        {
            string alphabetLower = "aπbcÊdeÍfghijkl≥mnÒoÛpqrsútuvwxyzüø";
            string alphabetUpper = "A•BC∆DE FGHIJKL£MN—O”PQRSåTUVWXYZèØ";

            return ShiftText(input, -key, alphabetLower, alphabetUpper);
        }
        private string ShiftText(string input, int key, string alphabetLower, string alphabetUpper)
        {
            char[] buffer = input.ToCharArray();
            int alphabetLength = alphabetLower.Length; 

            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                if (alphabetLower.Contains(letter))
                {
                    int index = alphabetLower.IndexOf(letter);
                    int newIndex = (index + key) % alphabetLength;

                    if (newIndex < 0)
                        newIndex += alphabetLength;

                    buffer[i] = alphabetLower[newIndex];
                }
                else if (alphabetUpper.Contains(letter))
                {
                    int index = alphabetUpper.IndexOf(letter);
                    int newIndex = (index + key) % alphabetLength;

                    if (newIndex < 0)
                        newIndex += alphabetLength;

                    buffer[i] = alphabetUpper[newIndex];
                }
            }

            return new string(buffer);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            int key = (int)numKey.Value;
            txtOutput.Text = CaesarEncrypt(input, key);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;  
            int key = (int)numKey.Value;  
            txtOutput.Text = CaesarDecrypt(input, key);  
        }

    }
}
