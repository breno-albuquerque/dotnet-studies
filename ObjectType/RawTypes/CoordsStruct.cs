namespace ObjectType.RawTypes
{
    public struct CoordsStruct
    {
        public int X { get; set; }

        public int Y { get; set; }

        public CoordsStruct(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
