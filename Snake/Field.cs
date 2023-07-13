using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Field
    {
        public char[,] FieldArea;
        public int Dimention;
        public Field(int dimention)
        {
            Dimention = dimention;
            FieldArea = new char[dimention, dimention];
        }
    }
}////
