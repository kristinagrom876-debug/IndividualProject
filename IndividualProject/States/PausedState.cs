using MusicPlayer.Services;

namespace MusicPlayer.States {
  class PausedState : IPlayerState {
    public string stateName = "PAUSED";

    public string Play(Player player) {
      player.SetState(new PlayingState());
      return "Resuming playback...";
    }

    public string Pause(Player player) {
      return "Already paused!";
    }

    public string Stop(Player player) {
      player.SetState(new StoppedState());
      return "Stopping playback...";
    }

    public string Next(Player player) {
      player.NextTrack();
      player.SetState(new PlayingState());
      return "Skipping to next track...";
    }

    public string Previous(Player player) {
      player.PreviousTrack();
      player.SetState(new PlayingState());
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