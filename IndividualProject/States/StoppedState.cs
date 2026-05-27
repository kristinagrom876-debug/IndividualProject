using MusicPlayer.Services;

namespace MusicPlayer.States {
  public class StoppedState : IPlayerState {
    private readonly string stateName;

    public StoppedState() {
      stateName = "STOPPED";
    }

    public string Play(Player player) {
      player.SetState(new PlayingState());
      return "Starting playback...";
    }

    public string Pause(Player player) {
      return "Cannot pause - player is stopped. Press Play first!";
    }

    public string Stop(Player player) {
      return "Already stopped!";
    }

    public string Next(Player player) {
      player.NextTrack();
      return "Switching to next track...";
    }

    public string Previous(Player player) {
      player.PreviousTrack();
      return "Switching to previous track...";
    }

    public string GetStateName() {
      return stateName;
    }
  }
}