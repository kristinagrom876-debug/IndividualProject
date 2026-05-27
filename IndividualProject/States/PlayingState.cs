using MusicPlayer.Services;

namespace MusicPlayer.States {
  class PlayingState : IPlayerState {
    private string stateName = "PLAYING";

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