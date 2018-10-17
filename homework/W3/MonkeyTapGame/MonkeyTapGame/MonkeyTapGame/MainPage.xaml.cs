﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonkeyTapGame
{
    class MonkeyTapWithSoundPage : MonkeyTapGame.MainPage
    {
        const int errorDuration = 500;

        // Diminished 7th in 1st inversion: C, Eb, F#, A
        double[] frequencies = { 523.25, 622.25, 739.99, 880 };

        protected override void FlashBoxView(int index)
        {
            SoundPlayer.PlaySound(frequencies[index], flashDuration);
            base.FlashBoxView(index);
        }

        protected override void EndGame()
        {
            SoundPlayer.PlaySound(65.4, errorDuration);
            base.EndGame();
        }
    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        const int sequenceTime = 750;       //in ms
        protected const int flashDuration = 250;

        const double offLuminosity = 0.4;
        const double onLuminosity = 0.75;

        BoxView[] boxViews;
        Color[] colors = { Color.Red, Color.Blue, Color.Yellow, Color.Green };
        List<int> sequence = new List<int>();
        int sequenceIndex;
        bool awaitingTaps;
        bool gameEnded;
        Random random = new Random();

        public MainPage()
        {
            InitializeComponent();
            boxViews = new BoxView[] { boxview0, boxview1, boxview2, boxview3 };
            InitializeBoxView();
        }

        protected virtual void InitializeBoxView()
        {
            for (int index = 0; index < 4; index++)
            {
                boxViews[index].Color = colors[index].WithLuminosity(offLuminosity);
            }
        }

        protected void OnStartGameButtonClicked(object sender, EventArgs args)
        {
            gameEnded = false;
            startGameButton.IsVisible = false;
            InitializeBoxView();
            sequence.Clear();
            StartSequence();
        }

        void StartSequence()
        {
            sequence.Add(random.Next(4));
            sequenceIndex = 0;
            Device.StartTimer(TimeSpan.FromMilliseconds(sequenceTime), OnTimerTick);
        }

        bool OnTimerTick()
        {
            if (gameEnded)
                return false;
            FlashBoxView(sequence[sequenceIndex]);
            sequenceIndex++;
            awaitingTaps = sequenceIndex == sequence.Count;
            sequenceIndex = awaitingTaps ? 0 : sequenceIndex;
            return !awaitingTaps;
        }

        protected virtual void FlashBoxView(int index)
        {
            boxViews[index].Color = colors[index].WithLuminosity(onLuminosity);
            Device.StartTimer(TimeSpan.FromMilliseconds(flashDuration), () =>
            {
                if (gameEnded)
                    return false;
                boxViews[index].Color = colors[index].WithLuminosity(offLuminosity);
                return false;
            });
        }

        protected void OnBoxViewTapped(object sender, EventArgs args)
        {
            if (gameEnded)
                return;

            if (!awaitingTaps)
            {
                EndGame();
                return;
            }

            BoxView tappedBoxView = (BoxView)sender;
            int index = Array.IndexOf(boxViews, tappedBoxView);

            if (index != sequence[sequenceIndex])
            {
                EndGame();
                return;
            }

            FlashBoxView(index);

            sequenceIndex++;
            awaitingTaps = sequenceIndex < sequence.Count;

            if (!awaitingTaps)
                StartSequence();
        }

        protected virtual void EndGame()
        {
            gameEnded = true;

            for (int index = 0; index < 4; index++)
            {
                boxViews[index].Color = Color.Gray;
            }

            startGameButton.Text = "Try again?";
            startGameButton.IsVisible = true;
        }
    }
}