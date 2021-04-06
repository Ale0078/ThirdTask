using ThirdTask.Logic.Components.Builders.Abstracts;

namespace ThirdTask.Logic.UserInterface.Abstracts
{
    public abstract class Controller
    {
        public View ViewToDisplay { get; }
        public FigureBuilder FigureCreater { get; protected set; }

        public Controller(View viewToDisplay, FigureBuilder figureCreater) 
        {
            ViewToDisplay = viewToDisplay;
            FigureCreater = figureCreater;
        }

        public abstract void Display();
        public abstract void AddFigure();
        public abstract void SetNewFigureBuilder(FigureBuilder builder);
        public abstract void SetNewParameters(string figureName, params double[] figureSides);
        public abstract void SortFigures();
    }
}
