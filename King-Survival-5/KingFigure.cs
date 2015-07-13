using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King
{
    public class KingFigure : Figure, IFigure
    {
        public KingFigure(Position position)
            : base(position)
        {
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
