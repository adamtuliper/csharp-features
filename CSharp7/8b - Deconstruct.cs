namespace csharp_features.CSharp7
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        //OR
        //public Point(int x, int y) => (X, Y) = (x, y);
        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }

        //OR
        //public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
        public void Deconstruct(out int x, out int y, out int q)
        {
            x = X;
            y = Y;
            q = 5;
        }
    }

}
