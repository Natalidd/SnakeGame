using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Cell
    {
        public Cell()
        {

        }
        public int X { get; set; }
        public int Y { get; set; }
        public char DisplayCharacter { get; set; }


        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            DisplayCharacter = 's';
        }

        public Cell(Cell other)
        {
            X = other.X;
            Y = other.Y;
            DisplayCharacter = other.DisplayCharacter;
        }
    }

}
