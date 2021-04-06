using ThirdTask.Logic.Components;
using ThirdTask.Logic.Components.Interfaces;
using ThirdTask.Logic.Components.Builders.Abstracts;

namespace ThirdTask.Logic.Components.Builders
{
    public class TriangelBuilder : FigureBuilder
    {
        public TriangelBuilder(params double[] sides) : base(sides) 
        {
        }

        public override IFigure Create()
        {
            return new Triangle(
                firstSide: Sides[0],
                secondSide: Sides[1],
                thirdSide: Sides[2]);
        }
    }
}
