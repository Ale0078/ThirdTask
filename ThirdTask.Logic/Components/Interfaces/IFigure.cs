using System;

namespace ThirdTask.Logic.Components.Interfaces
{
    public interface IFigure : IComparable<IFigure>
    {
        string Name { get; init; }
        double Suaqre { get; }
    }
}
