namespace Labb_2
{
    public class LevelData
    {
        private List<LevelElement> elements;

        public List<LevelElement> Elements
        {
            get { return elements; }
        }

        public LevelData()
        {
            elements = new List<LevelElement>();
        }

        public void Load(string filename)
        {
            elements.Clear();

            string[] lines = File.ReadAllLines(filename);

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    char character = lines[y][x];

                    if (character == '#')
                    {
                        elements.Add(new Wall(x, y));
                    }
                    else if (character == 'R')
                    {
                        elements.Add(new Rat(x, y));
                    }
                    else if (character == 'S')
                    {
                        elements.Add(new Snake(x, y));
                    }
                }
            }
        }

        public LevelElement GetElementAt(int x, int y)
        {
            foreach (LevelElement element in elements)
            {
                if (element.X == x && element.Y == y)
                {
                    return element;
                }
            }

            return null;
        }

        public void Draw()
        {
            foreach (LevelElement element in elements)
            {
                element.Draw();
            }
        }
    }
}
