using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King
{
    public abstract class Figure : IFigure
    {
        protected Figure(Position position)
        {
            this.Position = position;
        }

        public Position Position { get; private set; }

        public abstract void Move();
    }
}
