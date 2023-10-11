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
        public Form1()
        {
            InitializeComponent();
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
            string output = "";
            
            List<string> list = new List<string>() { "Stop", "Stop/Affricate" };
            List<bool> list2 = new List<bool>();

            foreach (bool isvowl in syllable.SyllableTypeDict.ElementAt(randomIndex).Value)
            {
                if (isvowl == true)
                {
                    randomIndex = random.Next(phonemes.VphonDict.Count);
                    string randomKey = phonemes.VphonDict.Keys.ElementAt(randomIndex);
                    output = output + phonemes.VphonDict[randomKey].EnglishTranslation;
                }
                else
                {
                    if (output.Length == 0)
                    {
                        randomIndex = random.Next(phonemes.CphonDict.Count);
                        string randomKey = phonemes.CphonDict.Keys.ElementAt(randomIndex);
                        output = output + phonemes.CphonDict[randomKey].EnglishTranslation;
                    }
                    else
                    {
                        bool nostop = true;
                        string lastChar = output[output.Length - 1].ToString();

                        //Bypass 1
                        if (lastChar == "q")
                        {
                        }
                        else if (stopCons.Contains(lastChar))
                        {
                            while (nostop)
                            {
                                randomIndex = random.Next(phonemes.CphonDict.Count);
                                string randomKey = phonemes.CphonDict.Keys.ElementAt(randomIndex);
                                string mannerOfArticulation = phonemes.CphonDict[randomKey].MannerOfArticulation;
                                if (stoppair[lastChar].Contains(phonemes.CphonDict[randomKey].EnglishTranslation))
                                {
                                    output = output + phonemes.CphonDict[randomKey].EnglishTranslation;
                                    nostop = false; // Set nostop to false to exit the loop
                                }
                            }
                        }
                        else if (consonantsSimp2.Contains(lastChar))
                        {
                            while (nostop)
                            {
                                randomIndex = random.Next(phonemes.CphonDict.Count);
                                string randomKey = phonemes.CphonDict.Keys.ElementAt(randomIndex);
                                string mannerOfArticulation = phonemes.CphonDict[randomKey].MannerOfArticulation;


                                // Check if the manner of articulation is not in the list of stop types
                                if (!list.Contains(mannerOfArticulation))
                                {
                                    output = output + phonemes.CphonDict[randomKey].EnglishTranslation;
                                    nostop = false; // Set nostop to false to exit the loop
                                }
                            }
                        }
                        else
                        {
                            randomIndex = random.Next(phonemes.CphonDict.Count);
                            string randomKey = phonemes.CphonDict.Keys.ElementAt(randomIndex);
                            output = output + phonemes.CphonDict[randomKey].EnglishTranslation;
                        }
                        
                    }
                }
            }

            richTextBox1.AppendText(output + "\n");
        }

    }
}