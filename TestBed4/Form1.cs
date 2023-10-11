using System;
using System.Collections.Generic;
using System.Linq;
using static TestBed4.Phonemes;

namespace TestBed4
{
    public partial class Form1 : Form
    {

        static Random random = new Random();
        Syllable syllable = new Syllable();
        Phonemes phonemes = new Phonemes();

        Dictionary<string, Phoneme> loadedConsonantDict = new Dictionary<string, Phoneme>();
        Dictionary<string, Phoneme> loadedVowelDict = new Dictionary<string, Phoneme>();
        public Form1()
        {
            InitializeComponent();
            loadedConsonantDict = phonemes.CphonDict;
            loadedVowelDict = phonemes.VphonDict;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                met1();
            }

        }

        //List of stop consonants and what they can be paired with
        public Dictionary<string, List<string>> stoppair = new Dictionary<string, List<string>>
        {
            { "b", new List<string> { "b", "l", "r", "y" } },
            { "d", new List<string> { "d", "r", "y" } },
            { "g", new List<string> { "g", "l", "n", "r" } },
            { "k", new List<string> { "l", "n", "r" } },
            { "p", new List<string> { "h", "l", "p", "r", "y" } },
            { "t", new List<string> { "h", "r", "t", "y" } }
        };

        List<string> consonantsSimp = new List<string>
        {
            "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z"
        };

        List<string> consonantsSimp2 = new List<string>
        {
            "c", "f", "h", "j", "l", "m", "n", "r", "s", "v", "w", "x", "y", "z"
        };
        List<string> stopCons = new List<string>
        {
            "b", "d", "g", "k", "p", "q", "t"
        };



        public bool stopstart(string output, string nextchar)
        {
            string lastChar = output[output.Length - 1].ToString();
            if (stoppair[lastChar].Contains(nextchar) == true)
            {
                return true;
            }
            return false;
        }



        private void met1()
        {
            int randomIndex = random.Next(syllable.SyllableTypeDict.Count);
            string output = GenerateSyllable(syllable.SyllableTypeDict.ElementAt(randomIndex));

            richTextBox1.AppendText(output + "\n");
        }

        private string GenerateSyllable(KeyValuePair<string, List<bool>> syllableType)
        {
            string output = "";
            foreach (bool isVowel in syllableType.Value)
            {
                if (isVowel)
                {
                    output += GenerateVowel();
                }
                else
                {
                    string lastChar = output.Length > 0 ? output[output.Length - 1].ToString() : "";
                    output += GenerateConsonant(lastChar);
                }
            }
            return output;
        }

        private string GenerateVowel()
        {
            int randomIndex = random.Next(phonemes.VphonDict.Count);
            string randomKey = phonemes.VphonDict.Keys.ElementAt(randomIndex);
            return phonemes.VphonDict[randomKey].EnglishTranslation;
        }

        private string GenerateConsonant(string lastChar)
        {
            if (lastChar == "q")
            {
                return "";
            }

            string[] consonantsSimp2 = new string[] { "b", "c", "d", "f", "h", "j", "l", "m", "n", "r", "s", "v", "w", "x", "y", "z" };
            if (lastChar == "" || stopCons.Contains(lastChar))
            {
                return GenerateConsonantByMannerOfArticulation("Stop", consonantsSimp2);
            }

            if (consonantsSimp2.Contains(lastChar))
            {
                return GenerateConsonantByMannerOfArticulation("Stop/Affricate", consonantsSimp2);
            }

            return GenerateRandomConsonant();
        }

        private string GenerateConsonantByMannerOfArticulation(string mannerOfArticulation, string[] consonantsSimp2)
        {
            string output = "";
            bool nostop = true;
            while (nostop)
            {
                int randomIndex = random.Next(phonemes.CphonDict.Count);
                string randomKey = phonemes.CphonDict.Keys.ElementAt(randomIndex);
                string articulation = phonemes.CphonDict[randomKey].MannerOfArticulation;
                if (articulation != mannerOfArticulation)
                {
                    output += phonemes.CphonDict[randomKey].EnglishTranslation;
                    nostop = false;
                }
            }
            return output;
        }

        private string GenerateRandomConsonant()
        {
            int randomIndex = random.Next(phonemes.CphonDict.Count);
            string randomKey = phonemes.CphonDict.Keys.ElementAt(randomIndex);
            return phonemes.CphonDict[randomKey].EnglishTranslation;
        }


    }
}