using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestBed4.Phoneme;

namespace TestBed4
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

        public override string ToString()
        {
            return $"{IPASymbol} - {PlaceOfArticulation} - {MannerOfArticulation} - {EnglishTranslation} - {(IsVowel ? "Vowel" : "Consonant")}";
        }
    }
}
