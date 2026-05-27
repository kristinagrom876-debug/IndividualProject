using System;
using MusicPlayer.Services;

namespace MusicPlayer.States {
  class StoppedState : IPlayerState {
    private string stateName = "STOPPED";

    public void Play(MusicPlayer player) {
      Console.WriteLine("Starting playback...");
      player.SetState(new PlayingState());
    }

    public void Pause(MusicPlayer player) {
      Console.WriteLine("Cannot pause - player is stopped. Press Play first!");
    }

    public void Stop(MusicPlayer player) {
      Console.WriteLine("Already stopped!");
    }

    public void Next(MusicPlayer player) {
      Console.WriteLine("Switching to next track...");
      player.NextTrack();
    }

    public void Previous(MusicPlayer player) {
      Console.WriteLine("Switching to previous track...");
      player.PreviousTrack();
    }

    public string GetStateName() {
      return stateName;
    }
  }
}