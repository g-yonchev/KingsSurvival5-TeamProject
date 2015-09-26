using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King.Models.Factories
{
    public abstract class FigureFactory
    {
        public abstract IFigure CreateFigure(Position position);
    }
}
