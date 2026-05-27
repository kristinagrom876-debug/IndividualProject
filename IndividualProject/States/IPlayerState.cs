using MusicPlayer.Services;

namespace MusicPlayer.States {
  public interface IPlayerState {
    string Play(Player player);

    string Pause(Player player);

    string Stop(Player player);

    string Next(Player player);

    string Previous(Player player);

    string GetStateName();
  }
}