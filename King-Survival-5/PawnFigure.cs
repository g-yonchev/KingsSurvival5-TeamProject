using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King
{
    public class PawnFigure : Figure, IFigure
    {
        public PawnFigure(Position position)
            : base(position)
        {
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
