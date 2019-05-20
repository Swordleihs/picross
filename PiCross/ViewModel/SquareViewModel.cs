using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class SquareViewModel : INotifyPropertyChanged
    {
        private readonly IPlayablePuzzleSquare square;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SquareLeftClick { get; }
        public ICommand SquareRightClick { get; }

        public SquareViewModel(IPlayablePuzzleSquare square)
        {
            this.square = square;
            this.SquareLeftClick = new SquareLeftClickCommand(this);
            this.SquareRightClick = new SquareRightClickCommand(this);
        }

        public object Contents
        {
            get
            {
                return square.Contents;
            }
        }

        private class SquareLeftClickCommand : ICommand
        {
            private SquareViewModel _viewModel;

            public SquareLeftClickCommand(SquareViewModel vm)
            {
                _viewModel = vm;

            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                if (_viewModel.square.Contents.Value == Square.FILLED)
                {
                    _viewModel.square.Contents.Value = Square.EMPTY;
                }
                else if(_viewModel.square.Contents.Value == Square.EMPTY) {
                    _viewModel.square.Contents.Value = Square.FILLED;
                }
                else
                {
                    _viewModel.square.Contents.Value = Square.FILLED;
                }

            }
        }
        private class SquareRightClickCommand : ICommand
        {
            private SquareViewModel _viewModel;

            public SquareRightClickCommand(SquareViewModel vm)
            {
                _viewModel = vm;

            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                _viewModel.square.Contents.Value = Square.UNKNOWN;
            }
        }
    }   
}
