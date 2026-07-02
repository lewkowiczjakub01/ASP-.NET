using AntColonySimulation.Ants;
using AntColonySimulation.World.Items;

namespace AntColonySimulation.World
{
    public class Map
    {
        private int width;
        private int height;
        private char[,] grid;
        private List<Item> mapItems = new List<Item>();

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new char[height, width];
            ClearMap();
        }

        public void AddItem(Item item)
        {
            mapItems.Add(item);
        }

        public void RemoveItem(Item item)
        {
            mapItems.Remove(item);
        }

        public void ClearMap()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    grid[i, j] = '.';
                }
            }

            int centerX = width / 2;
            int centerY = height / 2;
            grid[centerY, centerX] = 'C';
            grid[centerY, centerX - 1] = 'C';
            grid[centerY - 1, centerX] = 'C';
            grid[centerY - 1, centerX - 1] = 'C';
        }

        public bool IsEmpty(int x, int y)
        {
            return grid[y, x] == '.' && mapItems.All(item => item.x != x || item.y != y);
        }

        public void UpdateMap(IEnumerable<Ant> ants)
        {
            ClearMap();
            foreach (var item in mapItems)
            {
                if (item.x >= 0 && item.x < width && item.y >= 0 && item.y < height)
                {
                    grid[item.y, item.x] = item.GetSymbol();
                }
            }

            foreach (var ant in ants)
            {
                if (!ant.IsInColony && ant.X >= 0 && ant.X < width && ant.Y >= 0 && ant.Y < height)
                {
                    grid[ant.Y, ant.X] = ant.GetMapSymbol();
                }
            }
        }

        public void DisplayMap()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public Item GetItemAt(int X, int Y)
        {
            return mapItems.FirstOrDefault(obj => obj.x == X && obj.y == Y);
        }
    }
}
