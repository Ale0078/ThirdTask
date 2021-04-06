using System;
using System.Text;

using ThirdTask.Logic.Components.Interfaces;

namespace ThirdTask.Logic.Components
{
    public class Triangle : IFigure
    {
        public double FirstSide { get; init; }
        public double SecondSide { get; init; }
        public double ThirdSide { get; init; }
        public string Name { get; init; }

        public double SemiPerimeter =>
            (FirstSide + SecondSide + ThirdSide) / 2.0;

        public double Suaqre =>
            Math.Sqrt(SemiPerimeter * (SemiPerimeter - FirstSide) * (SemiPerimeter - SecondSide) * (SemiPerimeter - ThirdSide));

        public Triangle(double firstSide, double secondSide, double thirdSide, string name) 
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
            Name = name;
        }

        public int CompareTo(IFigure figure) =>
            figure.Suaqre.CompareTo(Suaqre);

        public override string ToString() 
        {
            StringBuilder builder = new();

            builder.Append("[Triangle ");
            builder.Append(Name);
            builder.Append("]: ");
            builder.Append(Suaqre);
            builder.Append(" cm");

            return builder.ToString();
        }
    }
}
