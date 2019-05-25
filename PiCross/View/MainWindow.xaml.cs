using ViewModel;
using System.Windows;
using PiCross;
using System.Windows.Media;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows.Input;

namespace View
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            songs = new List<string>
            {
                "../../../../music/minecraft.mp3",
                "../../../../music/pokemon.mp3",
                "../../../../music/hamburger.mp3",
                "../../../../music/halo.mp3",
                "../../../../music/bruh.mp3",
                "../../../../music/avengers.mp3",
                "../../../../music/crab.mp3",
                "../../../../music/tutorial2010.mp3"
            };
            mediaPlayer = new MediaPlayer();
            mediaPlayer.MediaEnded += OnMediaEnded;
            var songsRandomized = songs.OrderBy(a => random.Next());
            mediaPlayer.Open(new Uri((songsRandomized.ElementAt(0)).ToString(), UriKind.Relative));
            mediaPlayer.Play();
        }

        private void OnMediaEnded(object sender, EventArgs e)
        {
            var songsRandomized = songs.OrderBy(a => random.Next());
            mediaPlayer.Open(new Uri((songsRandomized.ElementAt(0)).ToString(), UriKind.Relative));
            mediaPlayer.Play();
        }

        public void Music()
        {
            if (toggleMusic)
            {
                mediaPlayer.Pause();
                toggleMusic = false;
            }
            else
            {
                mediaPlayer.Play();
                toggleMusic = true;
            }
            
        }

        public void NextSong()
        {
            var songsRandomized = songs.OrderBy(a => random.Next());
            mediaPlayer.Open(new Uri((songsRandomized.ElementAt(0)).ToString(), UriKind.Relative));
            mediaPlayer.Play();
        }

        private MediaPlayer mediaPlayer;
        private List<string> songs;
        private static Random random = new Random();
        private bool toggleMusic = true;

    }
}