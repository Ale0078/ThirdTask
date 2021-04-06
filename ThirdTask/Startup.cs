using System;
using NLog;
using static System.Console;

using ThirdTask.Controllers;
using ThirdTask.Models;
using ThirdTask.Views;
using ThirdTask.Validators;
using ThirdTask.Logic.Components.Builders;
using ThirdTask.Logic.UserInterface.Abstracts;
using LibToTasks.Validation;

namespace ThirdTask
{
    public class Startup
    {
        private const double MIN_SIZE_OF_SIDE = 1.0;
        private const double MAX_SIZE_OF_SIDE = 300.0;

        private ILogger _loggre;

        public Validator ValidatorToSide { get; set; }
        public Transformator TransformatorToSide { get; set; }
        public TriangleValidator ValidatorToTriangle { get; set; }

        public Startup() 
        {
            _loggre = LogManager.GetCurrentClassLogger();

            ValidatorToSide = new Validator();
            TransformatorToSide = new Transformator();
            ValidatorToTriangle = new TriangleValidator();
        }

        public void Start(string[] mainArguments) 
        {
            try
            {
                Controller figureController = GetController(
                    triangleName: mainArguments[0],
                    triangleSides: IsTriangle(ConvertAllStringsInDouble(mainArguments[1..])));

                figureController.AddFigure();

                bool flage = true;

                while(flage)
                {
                    string[] triangleParametrs = ParseReadLine();

                    figureController.SetNewParameters(
                        figureName: triangleParametrs[0],
                        figureSides: IsTriangle(ConvertAllStringsInDouble(triangleParametrs[1..])));

                    figureController.AddFigure();

                    SetBooleanFlage(out flage);
                }

                figureController.SortFigures();

                figureController.Display();

                _loggre.Info("Program was finalized correct");
            }
            catch(FormatException ex)
            {
                WriteLine("You has to enter all parametrs to triangle like thet: [name], [side1], [side2], [side3]");

                _loggre.Error("Program was finalized with exception: {0}, with mesage: {1}", ex.GetType(), ex.Message);
            }
        }

        private double[] IsTriangle(double[] sides) 
        {   
            if (!ValidatorToTriangle.IsTriangle(sides))
            {
                throw new FormatException("You need enter a string like thet: [name], [side1], [side2], [side3]");
            }

            return sides;
        }

        private string[] ParseReadLine() 
        {
            WriteLine("Enter all parametrs to triangle like thet: [name], [side1], [side2], [side3]");

            string[] parsedString = ReadLine().Split(", ");

            if (parsedString.Length < 3) 
            {
                throw new FormatException("You need enter a string like thet: [name], [side1], [side2], [side3]");
            }

            return parsedString;
        }

        private Controller GetController(string triangleName, params double[] triangleSides)
        {
            return new FigureController(
                viewToDisplay: new FigureView(
                    figureViewModel: new FigureViewModel()),
                figureCreater: new TriangelBuilder(triangleName, triangleSides));
        }

        private void SetBooleanFlage(out bool flage)
        {
            WriteLine("Do you want to continue ('y' or 'yes' to continue) ?");

            flage = (ReadLine().ToUpper()) switch
            {
                "Y" or "YES" => true,
                _ => false,
            };
        }

        private double[] ConvertAllStringsInDouble(params string[] sides) 
        {
            double[] sidesLikedouble = new double[sides.Length];

            for (int i = 0; i < sides.Length; i++)
            {
                sidesLikedouble[i] = GetCheckedDoubleFromString(sides[i]);

                if (sidesLikedouble[i] < 2.0 || sidesLikedouble[i] > 300.0) 
                {
                    throw new FormatException("Side must be less than 300 and more than 2");
                }
            }

            return sidesLikedouble;
        }

        private double GetCheckedDoubleFromString(string doubleValue)
        {
            double envelopWidthHeight = ConvertStringToDouble(doubleValue);

            if (ValidatorToSide.CheckValue(CheckDouble, envelopWidthHeight, false))
            {
                return envelopWidthHeight;
            }

            return default;
        }

        private double ConvertStringToDouble(string doubleValue)
        {
            return TransformatorToSide.ConfirmConversion<double, string>(doubleValue);
        }

        private bool CheckDouble(double doubleToCheck)
        {
            if (doubleToCheck > MAX_SIZE_OF_SIDE || doubleToCheck < MIN_SIZE_OF_SIDE)
            {
                return false;
            }

            return true;
        }
    }
}
