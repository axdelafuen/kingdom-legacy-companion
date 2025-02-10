using System.ComponentModel;

namespace Model
{
    public class Game : INotifyPropertyChanged
    {
        private static int _uniqueId = 0;
        private int _id;
        private string _name;
        private Resource _gold;
        private Resource _wood;
        private Resource _stone;
        private Resource _steel;
        private Resource _sword;
        private Resource _tradegoods;
        private bool _isEnded;
        private int _score;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Game(string? name)
        {
            _id = _uniqueId;
            _uniqueId++;
            _name = name ?? "Kingdom#"+_id;
            _gold = new Resource(ResourceType.Gold);
            _wood = new Resource(ResourceType.Wood);
            _stone = new Resource(ResourceType.Stone);
            _steel = new Resource(ResourceType.Steel);
            _sword = new Resource(ResourceType.Sword);
            _tradegoods = new Resource(ResourceType.TradeGoods);
            _isEnded = false;
            _score = -1;
        }

        public int Id 
        { 
            get { return _id; }
            set { _id = value;  }
        }
        public static int UniqueId
        {
            get { return _uniqueId; }
            set { _uniqueId = value; }
        }
        public string Name 
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        public int Gold 
        {
            get { return _gold.Value; }
            set { _gold.Value = value; OnPropertyChanged(nameof(Gold)); }
        }
        public int Wood 
        {
            get { return _wood.Value; }
            set { _wood.Value = value; OnPropertyChanged(nameof(Wood)); }
        }
        public int Stone 
        { 
            get { return _stone.Value; }
            set { _stone.Value = value; OnPropertyChanged(nameof(Stone)); }
        }
        public int Steel 
        {
            get { return _steel.Value; }
            set { _steel.Value = value; OnPropertyChanged(nameof(Steel)); }
        }
        public int Sword
        {
            get { return _sword.Value; }
            set { _sword.Value = value; OnPropertyChanged(nameof(Sword)); }
        }
        public int TradeGoods
        {
            get { return _tradegoods.Value; }
            set { _tradegoods.Value = value; OnPropertyChanged(nameof(TradeGoods)); }
        }

        public bool IsEnded
        {
            get { return _isEnded; }
            set { _isEnded = value; OnPropertyChanged(nameof(IsEnded));}
        }

        public int Score
        {
            get { if (_isEnded) return _score; else return -1; }
            set { if (_isEnded) _score = value; OnPropertyChanged(nameof(Score));}
        }

        public static void RestoreUniqueId(int value)
        {
            _uniqueId = value;
        }
        
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
