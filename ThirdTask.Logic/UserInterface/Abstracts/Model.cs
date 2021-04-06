using System.Collections.Generic;

using ThirdTask.Logic.Components.Interfaces;

namespace ThirdTask.Logic.UserInterface.Abstracts
{
    public abstract class Model
    {
        public List<IFigure> Figures { get; }

        public Model() =>
            Figures = new List<IFigure>();

        public abstract void AddFigure(IFigure figure);
    }
}
