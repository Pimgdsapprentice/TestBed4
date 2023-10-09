using System;
using static TestBed4.Phoneme;

namespace TestBed4
{
    public partial class Form1 : Form
    {

        static Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int randomValue = random.Next(1, 16);
            string selectedSyllable = "";

            if (randomValue == 1)
            {
                // Select a random phenome
                selectedSyllable = SelectRandomPhenome();
            }
            else
            {
                // Select a random syllable
                selectedSyllable = SelectRandomSyllable();
            }

            MessageBox.Show($"Random Value: {randomValue}\nSelected Syllable: {selectedSyllable}");
        }

        /*
         * int syllableCount = random.Next(1, 4); // You can adjust the syllable count as needed

            for (int i = 0; i < syllableCount; i++)
            {
                string phoneme = GetRandomPhoneme();
                richTextBox1.AppendText("\n" + phoneme);

            }
        */

        static string GetRandomPhoneme()
        {
            int randomIndex = random.Next(Phoneme.isolatedWordDictionary.Count);
            return Phoneme.isolatedWordDictionary.Values.ElementAt(randomIndex).EnglishTranslation;
        }

        private string SelectRandomSyllable()
        {
            // Replace this with your logic to select a random syllable
            int randomIndex = random.Next(syllables.Count);
            return syllables[randomIndex];
        }

    }
}