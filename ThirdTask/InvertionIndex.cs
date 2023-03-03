using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTask
{
    public class InvertionIndex
    {
        private SortedDictionary<string, StaticInformation> _lexemsInformation { get; set; }
        public InvertionIndex()
        {
            _lexemsInformation = new SortedDictionary<string, StaticInformation>();
        }
        public void AddLexemIndexInFile(string lexem, string fileName, int index)
        {
            if (!_lexemsInformation.ContainsKey(lexem))
            {
                _lexemsInformation[lexem] = new StaticInformation();
            }
            _lexemsInformation[lexem].AddLexemIndex(fileName, index);
        }
        public StaticInformation GetLexemInform(string lexem) => _lexemsInformation[lexem];
    }
    public class StaticInformation
    {
        private Dictionary<string, LexemeInformation> _staticInform;
        public StaticInformation()
        {
            _staticInform = new Dictionary<string, LexemeInformation>();
        }
        public void AddLexemIndex(string fileName, int index)
        {
            if (!_staticInform.ContainsKey(fileName))
            {
                _staticInform[fileName] = new LexemeInformation();
            }
            _staticInform[fileName].AddPosition(index);
        }
        public List<KeyValuePair<string, LexemeInformation>> GetStaticInform() => _staticInform.OrderByDescending(item => item.Value.LexemCountInFile).ToList();
    }
    public class LexemeInformation
    {
        public int LexemCountInFile => LexemPositions.Count;
        public List<int> LexemPositions { get; set; }
        public LexemeInformation()
        {
            LexemPositions = new List<int>();
        }
        public void AddPosition(int index)
        {
            LexemPositions.Add(index);
        }
    }
}
