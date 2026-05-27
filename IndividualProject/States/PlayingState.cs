using MusicPlayer.Services;

namespace MusicPlayer.States {
  public class PlayingState : IPlayerState {
    private readonly string stateName;

    public PlayingState() {
      stateName = "PLAYING";
    }

    public string Play(Player player) {
      return "Already playing!";
    }

    public string Pause(Player player) {
      player.SetState(new PausedState());
      return "Pausing playback...";
    }

    public string Stop(Player player) {
      player.SetState(new StoppedState());
      return "Stopping playback...";
    }

    public string Next(Player player) {
      player.NextTrack();
      return "Skipping to next track...";
    }

    public string Previous(Player player) {
      player.PreviousTrack();
      return "Going to previous track...";
    }

    public string GetStateName() {
      return stateName;
    }
  }
}