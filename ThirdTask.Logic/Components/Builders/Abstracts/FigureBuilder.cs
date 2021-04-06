using System.Collections.Generic;

using ThirdTask.Logic.Components.Interfaces;

namespace ThirdTask.Logic.Components.Builders.Abstracts
{
    public abstract class FigureBuilder
    {
        public List<double> Sides { get; protected set; }

        public FigureBuilder(params double[] sides) =>
            Sides.AddRange(sides);

        public abstract IFigure Create();
    }
}
