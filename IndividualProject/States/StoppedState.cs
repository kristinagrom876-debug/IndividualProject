using MusicPlayer.Services;

namespace MusicPlayer.States {
  class StoppedState : IPlayerState {
    private string stateName = "STOPPED";

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

    string IPlayerState.Play(Player player) {
      throw new System.NotImplementedException();
    }

    string IPlayerState.Pause(Player player) {
      throw new System.NotImplementedException();
    }

    string IPlayerState.Stop(Player player) {
      throw new System.NotImplementedException();
    }

    string IPlayerState.Next(Player player) {
      throw new System.NotImplementedException();
    }

    string IPlayerState.Previous(Player player) {
      throw new System.NotImplementedException();
    }
  }
}