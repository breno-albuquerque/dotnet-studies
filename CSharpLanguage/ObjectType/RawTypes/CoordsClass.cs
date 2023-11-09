namespace ObjectType.RawTypes
{
    public class CoordsClass
    {
        public int X { get; set; }

        public int Y { get; set; }

        public CoordsClass(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
