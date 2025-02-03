namespace Model
{
    public class Resource
    {
        private ResourceType _resourceType;

        private int _value;

        public int Value { get { return _value; } set { _value = value; } }
        public Resource(ResourceType resourceType, int value)
        {
            _resourceType = resourceType;
            _value = value;
        }

        public Resource(ResourceType resourceType)
        {
            _resourceType = resourceType;
            _value = 0;
        }

        public string toString()
        {
            switch (_resourceType)
            {
                case ResourceType.Gold:
                    return "Gold";
                case ResourceType.Wood:
                    return "Wood";
                case ResourceType.Stone:
                    return "Stone";
                case ResourceType.Steel:
                    return "Steel";
                case ResourceType.Sword:
                    return "Sword";
                case ResourceType.TradeGoods:
                    return "Trade Goods";
                default:
                    return "Unknow";
            }
        }
        public string getImagePath()
        {
            switch (_resourceType)
            {
                case ResourceType.Gold:
                    return "money.png";
                case ResourceType.Wood:
                    return "wood.png";
                case ResourceType.Stone:
                    return "stone.png";
                case ResourceType.Steel:
                    return "steel.png";
                case ResourceType.Sword:
                    return "sword.png";
                case ResourceType.TradeGoods:
                    return "tradegoods.png";
                default:
                    return "unknow.png";
            }
        }
    }
}
