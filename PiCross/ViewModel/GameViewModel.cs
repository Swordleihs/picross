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

        public GameViewModel(Puzzle puzzle)
        {
            var facade = new PiCrossFacade();
            this.playablePuzzle = facade.CreatePlayablePuzzle(puzzle);

            this.Grid = this.playablePuzzle.Grid.Map(square => new SquareViewModel(square)).Copy();
            this.RowConstraints = this.playablePuzzle.RowConstraints.Map(row => new RowViewModel(row)).Copy();
            this.ColumnConstraints = this.playablePuzzle.ColumnConstraints.Map(column => new ColumnViewModel(column)).Copy();
            this.IsSatisfied = this.playablePuzzle.IsSolved;
        }

        public object Grid { get; }

        public object RowConstraints { get; }
        public object ColumnConstraints { get; }

        public Cell<bool> IsSatisfied { get; }


        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class RowViewModel
    {
        private IPlayablePuzzleConstraints row;

        public RowViewModel(IPlayablePuzzleConstraints row)
        {
            this.row = row;
            this.IsSatisfied = row.IsSatisfied;
        }

        public object Values => row.Values;

        Cell<bool> IsSatisfied { get; }
    }

    public class ColumnViewModel
    {
        private IPlayablePuzzleConstraints column;

        public ColumnViewModel(IPlayablePuzzleConstraints column)
        {
            this.column = column;
            this.IsSatisfied = column.IsSatisfied;
        }

        public object Values => column.Values;

        Cell<bool> IsSatisfied { get; }
    }
}