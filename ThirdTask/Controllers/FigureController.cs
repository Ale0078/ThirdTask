using System.Collections.Generic;
using NLog;

using ThirdTask.Messages;
using ThirdTask.Logic.UserInterface.Abstracts;
using ThirdTask.Logic.Components.Builders.Abstracts;

namespace ThirdTask.Controllers
{
    public class FigureController : Controller
    {
        private ILogger _logger;

        public FigureController(View viewToDisplay, FigureBuilder figureCreater) :
            base(viewToDisplay, figureCreater)
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public override void AddFigure()
        {
            ViewToDisplay.FigureContainer.AddFigure(FigureCreater.Create());

            _logger.Info(LoggerMessage.ADD_FIGURE);
        }

        public override void Display()
        {
            ViewToDisplay.Display();

            _logger.Info(LoggerMessage.DISPLAY);
        }

        public override void SetNewFigureBuilder(FigureBuilder builder)
        {
            FigureCreater = builder;

            _logger.Info(LoggerMessage.SET_NEW_FIGURE_BUILDER);
        }

        public override void SetNewParameters(string figureName, params double[] figureSides)
        {
            FigureCreater.Name = figureName;
            FigureCreater.Sides = new List<double>(figureSides);

            _logger.Info(LoggerMessage.SET_NEW_PARAMETRS);
        }

        public override void SortFigures()
        {
            ViewToDisplay.FigureContainer.Figures.Sort();

            _logger.Info(LoggerMessage.SORT_FIGURES);
        }
    }
}
