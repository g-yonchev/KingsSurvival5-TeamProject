namespace King.Models.Factories
{
    using Contracts;
    using global::Models;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class KingFactory : FigureFactory
    {
        public override IFigure CreateFigure(global::Models.Position position)
        {
            return new KingFigure(position);
        }
    }
}
