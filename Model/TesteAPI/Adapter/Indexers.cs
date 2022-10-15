namespace Adapter
{
    public class Indexers
    {
        private string[] _words;

        public enum CellStatus
        {
            Empty,
            X,
            O
        }
        private const int _rowCount = 3;
        private const int _colCount = 3;
        private CellStatus[,] _patch = new CellStatus[3, 3];
        public CellStatus this[int row, int col]
        {
            get
            {
                if (row >= _rowCount || row < 0)
                    throw new ArgumentOutOfRangeException(nameof(row));
                if (col >= _colCount || col < 0)
                    throw new ArgumentOutOfRangeException(nameof(col));
                return _patch[row, col];
            }
            set
            {
                if (row >= _rowCount || row < 0)
                    throw new ArgumentOutOfRangeException(nameof(row));
                if (col >= _colCount || col < 0)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if (!Enum.IsDefined(value))
                    return;
                if (value == CellStatus.Empty)
                    return;
                if (_patch[row, col] != CellStatus.Empty)
                    return;
                _patch[row, col] = value;
            }
        }
        public Indexers(string sentence)
        {
            if (sentence is null)
                throw new ArgumentNullException(nameof(sentence));

            _words = sentence.Split(' ');
        }

        private static (int, int) Convert(int cellNumber)
        {
            if (cellNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(cellNumber));

            return ((cellNumber - 1) / _rowCount, (cellNumber - 1) % _colCount);
        }

        public CellStatus this[int cellNumber]
        {
            get
            {
                var result = Convert(cellNumber);
                return this[result.Item1, result.Item2];
            }
            set
            {
                var result = Convert(cellNumber);
                this[result.Item1, result.Item2] = value;
            }
        }
        //public string this[int word]
        //{
        //    get => _words[word];
        //    set => _words[word] = value;
        //}
        public interface IIndexerInterface
        {
            string this[int index] { get; }
        }

        public class IndexerClass : IIndexerInterface
        {
            public string this[int index]
            {
                get => "Hello from class.";
            }
        }
        //public string this[int id]
        //{
        //    get
        //    {
        //        if(id<= 0 || id >= _words.Length -1)
        //            throw new ArgumentNullException(nameof(id));
        //        return _words[id];
        //    }

        //    set
        //    {
        //        if (id <= 0 || id >= _words.Length - 1)
        //            throw new ArgumentNullException(nameof(id));

        //        if (value is null
        //            || value.Trim().Length.Equals(0)
        //            || value.Split().Length > 1)
        //            return;
        //        _words[id] = value;
        //    }
        //}
    }
}
