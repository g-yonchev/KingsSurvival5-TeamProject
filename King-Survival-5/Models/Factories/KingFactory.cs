using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King.Models.Factories
{
    public class KingFactory : FigureFactory
    {
        public override IFigure CreateFigure(Position position)
        {
            return new KingFigure(position);
        }
    }
}
