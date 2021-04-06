using System;

using ThirdTask.Logic.Components.Interfaces;

namespace ThirdTask.Logic.Components
{
    public class Triangle : IFigure
    {
        public double FirstSide { get; init; }
        public double SecondSide { get; init; }
        public double ThirdSide { get; set; }

        public double SemiPerimeter =>
            (FirstSide + SecondSide + ThirdSide) / 2.0;

        public double Suaqre =>
            Math.Sqrt(SemiPerimeter * (SemiPerimeter - FirstSide) * (SemiPerimeter - SecondSide) * (SemiPerimeter - ThirdSide));

        public Triangle(double firstSide, double secondSide, double thirdSide) 
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

        public int CompareTo(IFigure figure) =>
            SemiPerimeter.CompareTo(figure.Suaqre);
    }
}
