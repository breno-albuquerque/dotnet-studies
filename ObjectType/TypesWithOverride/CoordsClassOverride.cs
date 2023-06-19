namespace ObjectType.TypesWithOverride
{
    public class CoordsClassOverride
    {
        public int X { get; set; }

        public int Y { get; set; }

        public CoordsClassOverride(int x, int y)
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
            if (obj is CoordsClassOverride coordsClass)
            {
                return (coordsClass.X == X && coordsClass.Y == Y);
            }

            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
