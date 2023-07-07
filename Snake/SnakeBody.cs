using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakeBody
    {
        public List<Cell> Body;
        public SnakeBody()
        {
            Body = new List<Cell>()
            {
                new Cell(3, 3),
                new Cell(3, 4),
                new Cell(3, 5),
                new Cell(3, 6),
                new Cell(3, 7),
                new Cell(3, 8)

            };
        }

    }
}
