using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestBed4.Phonemes;

namespace TestBed4
{
    public class Phonemes
    {
        public class Phoneme
        {
            public string IPASymbol { get; }
            public string PlaceOfArticulation { get; }
            public string MannerOfArticulation { get; }
            public string EnglishTranslation { get; }
            public bool IsVowel { get; }

            public Phoneme(string ipaSymbol, string placeOfArticulation, string mannerOfArticulation, string englishTranslation, bool isVowel)
            {
                IPASymbol = ipaSymbol;
                PlaceOfArticulation = placeOfArticulation;
                MannerOfArticulation = mannerOfArticulation;
                EnglishTranslation = englishTranslation;
                IsVowel = isVowel;
            }
        }

        public Dictionary<string, Phoneme> CphonDict = new Dictionary<string, Phoneme>
        {
            {"b", new Phoneme("b", "Bilabial", "Stop", "b", false)},
            {"c", new Phoneme("c", "Alveolar/Palatal", "Fricative/Affricate", "c", false)},
            {"d", new Phoneme("d", "Alveolar", "Stop", "d", false)},
            {"f", new Phoneme("f", "Labiodental", "Fricative", "f", false)},
            {"g", new Phoneme("g", "Velar/Palatal", "Stop/Affricate", "g", false)},
            {"h", new Phoneme("h", "Glottal", "Fricative", "h", false)},
            {"j", new Phoneme("j", "Palatal", "Approximant", "j", false)},
            {"k", new Phoneme("k", "Velar", "Stop", "k", false)},
            {"l", new Phoneme("l", "Alveolar", "Lateral", "l", false)},
            {"m", new Phoneme("m", "Bilabial", "Nasal", "m", false)},
            {"n", new Phoneme("n", "Alveolar", "Nasal", "n", false)},
            {"p", new Phoneme("p", "Bilabial", "Stop", "p", false)},
            {"q", new Phoneme("q", "Velar", "Stop", "q", false)},
            {"r", new Phoneme("r", "Alveolar", "Approximant", "r", false)},
            {"s", new Phoneme("s", "Alveolar", "Fricative", "s", false)},
            {"t", new Phoneme("t", "Alveolar", "Stop", "t", false)},
            {"v", new Phoneme("v", "Labiodental", "Fricative", "v", false)},
            {"w", new Phoneme("w", "Labial-Velar", "Approximant", "w", false)},
            {"x", new Phoneme("x", "Variable", "Fricative", "x", false)},
            {"y", new Phoneme("y", "Palatal", "Approximant/Vowel", "y", false)},
            {"z", new Phoneme("z", "Alveolar", "Fricative", "z", false)}
        };

        public Dictionary<string, Phoneme> VphonDict = new Dictionary<string, Phoneme>
        {
            {"a", new Phoneme("a", "Open", "Low", "a", true)},
            {"e", new Phoneme("e", "Close-Mid", "High", "e", true)},
            {"i", new Phoneme("i", "Close", "High", "i", true)},
            {"o", new Phoneme("o", "Close-Mid", "High", "o", true)},
            {"u", new Phoneme("u", "Close", "High", "u", true)}
        };
    }
}
