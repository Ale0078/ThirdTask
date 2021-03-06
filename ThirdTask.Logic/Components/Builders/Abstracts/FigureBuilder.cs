using System.Collections.Generic;

using ThirdTask.Logic.Components.Interfaces;

namespace ThirdTask.Logic.Components.Builders.Abstracts
{
    public abstract class FigureBuilder
    {
        public List<double> Sides { get; set; }
        public string Name { get; set; }

        public FigureBuilder(string name, params double[] sides)
        {
            Sides = new List<double>();

            Sides.AddRange(sides);
            Name = name;
        }

        public abstract IFigure Create();
    }
}
