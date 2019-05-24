using PiCross;
using System;
using System.Windows.Input;
using ViewModel;

namespace View
{
    public abstract class Screen
    {
        public readonly ScreenController screenController;
        public Screen(ScreenController sC)
        {
            this.screenController = sC;
        }

        public void SwitchScreen(Screen screen)
        {
            this.screenController.CurrentScreen = screen;
        }

        public void CloseWindow()
        {

        }
    }

    public class HomeScreen : Screen
    {
        public ICommand Start
        {
            get;
        }
        public ICommand Close
        {
            get;
        }
        public HomeViewModel ViewModel
        {
            get;
        }
        public HomeScreen(ScreenController sC) : base(sC)
        {
            ViewModel = new HomeViewModel();
            Close = new ExecuteCommand(() => System.Windows.Application.Current.Shutdown());
            Start = new ExecuteCommand(() => SwitchScreen(new SelectScreen(sC)));
        }
    }

    public class SelectScreen : Screen
    {
        public ICommand Go
        {
            get;
        }
        public ICommand BackHome
        {
            get;
        }
        public SelectViewModel ViewModel
        {
            get;
        }
        public SelectScreen(ScreenController sC) : base(sC)
        {
            ViewModel = new SelectViewModel();
            Go = new ExecuteCommand(() => SwitchScreen(new GameScreen(sC, ViewModel.ChosenPuzzle.Puzzle)));
            BackHome = new ExecuteCommand(() => SwitchScreen(new HomeScreen(sC)));
        }
    }

    public class GameScreen : Screen
    {
        public ICommand Back
        {
        get;
        }
        public GameViewModel ViewModel
        {
        get;
        }
        public GameScreen(ScreenController sC, Puzzle puzzle) : base(sC)
        {
            ViewModel = new GameViewModel(puzzle);
            Back = new ExecuteCommand(() => SwitchScreen(new SelectScreen(sC)));
        }
    }
}
