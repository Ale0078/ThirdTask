using System;

namespace ThirdTask.Logic.Components.Interfaces
{
    public interface IFigure : IComparable<IFigure>
    {
        double Suaqre { get; }
    }
}
