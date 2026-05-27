using MusicPlayer.Services;

namespace MusicPlayer.States {
  class PausedState : IPlayerState {
    private string stateName = "PAUSED";

    public string Play(MusicPlayer player) {
      player.SetState(new PlayingState());
      return "Resuming playback...";
    }

    public string Pause(MusicPlayer player) {
      return "Already paused!";
    }

    public string Stop(MusicPlayer player) {
      player.SetState(new StoppedState());
      return "Stopping playback...";
    }

    public string Next(MusicPlayer player) {
      player.NextTrack();
      player.SetState(new PlayingState());
      return "Skipping to next track...";
    }

    public string Previous(MusicPlayer player) {
      player.PreviousTrack();
      player.SetState(new PlayingState());
      return "Going to previous track...";
    }

    public string GetStateName() {
      return stateName;
    }
  }
}