

namespace ThirdTask.Logic.UserInterface.Abstracts
{
    public abstract class View
    {
        public Model FigureContainer { get; }

        public View(Model figureContainer) =>
            FigureContainer = figureContainer;

        public abstract void Display();
    }
}
