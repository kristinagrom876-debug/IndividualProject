using MusicPlayer.Services;

namespace MusicPlayer.States {
  class PlayingState : IPlayerState {
    private string stateName = "PLAYING";

    public string Play(MusicPlayer player) {
      return "Already playing!";
    }

    public string Pause(MusicPlayer player) {
      player.SetState(new PausedState());
      return "Pausing playback...";
    }

    public string Stop(MusicPlayer player) {
      player.SetState(new StoppedState());
      return "Stopping playback...";
    }

    public string Next(MusicPlayer player) {
      player.NextTrack();
      return "Skipping to next track...";
    }

    public string Previous(MusicPlayer player) {
      player.PreviousTrack();
      return "Going to previous track...";
    }

    public string GetStateName() {
      return stateName;
    }
  }
}