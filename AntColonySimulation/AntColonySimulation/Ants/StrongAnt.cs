using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntColonySimulation.Ants
{
    public class StrongAnt : Ant
    {
        private Ant ant;
        private static Random random = new Random();

        public StrongAnt(Ant ant)
        {
            this.ant = ant;
            this.Strength = ant.Strength + 5;
            this.Memory = ant.Memory;
            this.Health = ant.Health;
            this.X = ant.X;
            this.Y = ant.Y;
            this.IsInColony = ant.IsInColony;
            this.Age = ant.Age;
        }

        public override void Move(int width, int height)
        {
            if ( width == -1 )
            {
                X = width / 2;
                Y = height / 2;
            }
            else
            {
                int moveX = random.Next(-1, 2);
                int moveY = random.Next(-1, 2);

                int newX = X + moveX;
                int newY = Y + moveY;

                if (newX >= 0 && newX < width)
                {
                    X = newX;
                }

                if (newY >= 0 && newY < height)
                {
                    Y = newY;
                }
            }
            IsInColony = (X == width / 2 && Y == height / 2) ||
                         (X == width / 2 - 1 && Y == height / 2) ||
                         (X == width / 2 && Y == height / 2 - 1) ||
                         (X == width / 2 - 1 && Y == height / 2 - 1);

            Age++;
        }

        public override char GetMapSymbol()
        {
            return 'S';
        }

        public override string ToString()
        {
            return $"StrongAnt(Type={GetType().Name}, Strength={Strength}, Memory={Memory}, Health={Health}, Position=({X}, {Y}), InColony={IsInColony}, Age={Age})";
        }
    }
}
