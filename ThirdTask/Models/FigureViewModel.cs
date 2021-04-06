using ThirdTask.Logic.Components.Interfaces;
using ThirdTask.Logic.UserInterface.Abstracts;

namespace ThirdTask.Models
{
    public class FigureViewModel : Model
    {
        public FigureViewModel() : base() 
        {
        }

        public override void AddFigure(IFigure figure) =>
            Figures.Add(figure);
    }
}
