using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private readonly IPlayablePuzzle playablePuzzle;
        public ICommand RowLeftClick { get; }

        public GameViewModel(Puzzle puzzle)
        {
            var facade = new PiCrossFacade();
            this.playablePuzzle = facade.CreatePlayablePuzzle(puzzle);

            this.Grid = this.playablePuzzle.Grid.Map(square => new SquareViewModel(square)).Copy();
            this.RowConstraints = this.playablePuzzle.RowConstraints.Map(row => new RowViewModel(row)).Copy();
            this.ColumnConstraints = this.playablePuzzle.ColumnConstraints.Map(column => new ColumnViewModel(column)).Copy();
            IsSolved = playablePuzzle.IsSolved;
        }

        public object Grid { get; }
        public object RowConstraints { get; }
        public object ColumnConstraints { get; }
        public Cell<bool> IsSolved { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    internal class RowViewModel
    {
        private IPlayablePuzzleConstraints row;

        public RowViewModel(IPlayablePuzzleConstraints row)
        {
            this.row = row;
            this.Satisfied = row.IsSatisfied;
        }

        public object Values => row.Values;

        public Cell<bool> Satisfied { get; }
    }

    internal class ColumnViewModel
    {
        private IPlayablePuzzleConstraints column;

        public ColumnViewModel(IPlayablePuzzleConstraints column)
        {
            this.column = column;
            this.Satisfied = column.IsSatisfied;
        }

        public object Values => column.Values;

        public Cell<bool> Satisfied { get; }
    }

    internal class SquareViewModel : INotifyPropertyChanged
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
                if (_viewModel.square.Contents.Value == Square.UNKNOWN)
                {
                    _viewModel.square.Contents.Value = Square.FILLED;
                }
                else if (_viewModel.square.Contents.Value == Square.EMPTY)
                {
                    _viewModel.square.Contents.Value = Square.FILLED;
                }
                else
                {
                    _viewModel.square.Contents.Value = Square.UNKNOWN;
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
                if (_viewModel.square.Contents.Value == Square.UNKNOWN)
                {
                    _viewModel.square.Contents.Value = Square.EMPTY;
                }
                else if (_viewModel.square.Contents.Value == Square.FILLED)
                {
                    _viewModel.square.Contents.Value = Square.EMPTY;
                }
                else
                {
                    _viewModel.square.Contents.Value = Square.UNKNOWN;
                }

            }
        }
    }
}