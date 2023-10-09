using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBed4
{
    public class Syllable
    {
        public Dictionary<string, List<bool>> SyllableTypeDict = new Dictionary<string, List<bool>>
        {
            { "CV", new List<bool> { false, true } },
            { "VC", new List<bool> { true, false } },
            { "CVC", new List<bool> { false, true, false } },
            { "CCV", new List<bool> { false, false, true } },
            { "CVV", new List<bool> { false, true, true } },
            { "VCV", new List<bool> { true, false, true } },
            { "CVCV", new List<bool> { false, true, false, true } },
            { "CCVC", new List<bool> { false, false, true, false } },
            { "CCVCC", new List<bool> { false, false, true, true, true } }
        };
    }
}
