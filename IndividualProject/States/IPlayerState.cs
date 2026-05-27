using MusicPlayer.Services;

namespace MusicPlayer.States {
  interface IPlayerState {
    void Play(MusicPlayer player);
    void Pause(MusicPlayer player);
    void Stop(MusicPlayer player);
    void Next(MusicPlayer player);
    void Previous(MusicPlayer player);
    string GetStateName();
  }
}