﻿using PiCross;
using System.Collections.Generic;
using System.Linq;

namespace ViewModel
{
    public class SelectViewModel
    {
        private readonly IGameData gameData;

        public SelectViewModel()
        {
            var facade = new PiCrossFacade();
            gameData = facade.CreateDummyGameData();
            Puzzles = gameData.PuzzleLibrary.Entries;
            ChosenPuzzle = Puzzles.ElementAt(0);
        }

        public IPuzzleLibraryEntry ChosenPuzzle
        {
            get;
            set;
        }
        public IEnumerable<IPuzzleLibraryEntry> Puzzles
        {
            get;
        }
    }
}
