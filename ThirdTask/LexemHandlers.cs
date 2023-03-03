using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThirdTask
{
    public class SearchFactory
    {
        public IReader LexemReader { get; set; }
        public SearchFactory(IReader lexemReader)
        {
            LexemReader = lexemReader;
        }
        public ISearcher GetLexemSearcher(string lexem)
        {
            return new LexemSearcher(lexem, LexemReader.Indexes); 
        }
    }
    public interface ISearcher
    {
        (string, int)[] GetFileNameAndCount();
        List<int> GetIndexes(int index);
    }
    public class LexemSearcher: ISearcher
    {
        private List<KeyValuePair<string, LexemeInformation>> _staticInform;
        public LexemSearcher(string lexem, InvertionIndex indexes)
        {
            _staticInform = indexes.GetLexemInform(lexem).GetStaticInform();
        }
        public (string, int)[] GetFileNameAndCount()
        {
            var result = _staticInform.Select(item => (item.Key, item.Value.LexemCountInFile)).ToArray();
            return result;
        }
        public List<int> GetIndexes(int index)
        {
            return _staticInform[index].Value.LexemPositions;
        }
    }
    public interface IReader
    {
        void Read();
        InvertionIndex Indexes { get; set; }
    }
    public class LexemReader: IReader
    {
        public InvertionIndex Indexes { get; set; }
        private char[] _separators;
        private string _path;
        public LexemReader(char[] separators, string path)
        {
            _separators = separators;
            _path = path;
            Indexes = new InvertionIndex();
        }

        public void Read()
        {
            var dir = new DirectoryInfo(_path);
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                using (var sr = new StreamReader(file.FullName))
                {
                    var lexems = sr.ReadToEnd().Split(_separators, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < lexems.Length; i++)
                    {
                        Indexes.AddLexemIndexInFile(lexems[i], file.Name, i);
                    }
                }
            }
        }
    }
}
