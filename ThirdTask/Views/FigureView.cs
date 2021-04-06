using static System.Console;

using ThirdTask.Logic.UserInterface.Abstracts;

namespace ThirdTask.Views
{
    public class FigureView : View
    {
        public FigureView(Model figureViewModel) : base(figureViewModel) 
        {
        }

        public override void Display()
        {
            foreach (var item in FigureContainer.Figures) 
            {
                WriteLine(item);
            }
        }
    }
}
