namespace Labb_2
{
    public abstract class LevelElement
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected char Symbol { get; set; }

        public LevelElement(int x, int y, char symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }
    }
}