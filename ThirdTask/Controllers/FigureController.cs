using System.Collections.Generic;
using NLog;

using ThirdTask.Logic.UserInterface.Abstracts;
using ThirdTask.Logic.Components.Builders.Abstracts;

namespace ThirdTask.Controllers
{
    public class FigureController : Controller
    {
        private ILogger _logger;

        public FigureController(View viewtoDisplay, FigureBuilder figureCreater) :
            base(viewtoDisplay, figureCreater)
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public override void AddFigure()
        {
            ViewToDisplay.FigureContainer.AddFigure(FigureCreater.Create());

            _logger.Info("New figure was created and added to model");
        }

        public override void Display()
        {
            ViewToDisplay.Display();

            _logger.Info("All figures were inputted into console");
        }

        public override void SetNewFigureBuilder(FigureBuilder builder)
        {
            FigureCreater = builder;

            _logger.Info("New FigureBuilder was setted to create new type of figure");
        }

        public override void SetNewParameters(string figureName, params double[] figureSides)
        {
            FigureCreater.Name = figureName;
            FigureCreater.Sides = new List<double>(figureSides);

            _logger.Info("New parametrs were setted to FigureBuilder");
        }

        public override void SortFigures()
        {
            ViewToDisplay.FigureContainer.Figures.Sort();

            _logger.Info("All figures were sorted");
        }
    }
}
