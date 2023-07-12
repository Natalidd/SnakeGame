using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class GameStateJson
    {
        public GameStateJson()
        {

        }
        public Cell Apple { get; set; }
        public List<Cell> Snake { get; set; }
        public int Score { get; set; }
        public Directions Direction { get; set; }
    }
}
