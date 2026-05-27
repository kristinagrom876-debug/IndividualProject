using System.Collections.Generic;
using MusicPlayer.Models;
using MusicPlayer.States;

namespace MusicPlayer.Services {
  class Player {
    private const int secondsInOneMinute = 60;
    private IPlayerState currentState;
    private List<Track> playlist;
    private int currentTrackIndex;

    public Player() {
      currentState = new StoppedState();
      currentTrackIndex = 0;
      LoadDefaultPlaylist();
    }

    public void SetState(IPlayerState newState) {
      currentState = newState;
    }

    public string Play() {
      string message;
      message = currentState.Play(this);
      return message;
    }

    public string Pause() {
      string message;
      message = currentState.Pause(this);
      return message;
    }

    public string Stop() {
      string message;
      message = currentState.Stop(this);
      return message;
    }

    public string Next() {
      string message;
      message = currentState.Next(this);
      return message;
    }

    public string Previous() {
      string message;
      message = currentState.Previous(this);
      return message;
    }

    public void NextTrack() {
      int playlistSize;
      bool hasNextTrack;

      playlistSize = playlist.Count;
      hasNextTrack = currentTrackIndex + 1 < playlistSize;

      if (hasNextTrack) {
        currentTrackIndex = currentTrackIndex + 1;
      } else {
        currentTrackIndex = 0;
      }
    }

    public void PreviousTrack() {
      int playlistSize;
      bool hasPreviousTrack;

      playlistSize = playlist.Count;
      hasPreviousTrack = currentTrackIndex - 1 >= 0;

      if (hasPreviousTrack) {
        currentTrackIndex = currentTrackIndex - 1;
      } else {
        currentTrackIndex = playlistSize - 1;
      }
    }

    public Track GetCurrentTrack() {
      Track currentTrack;
      currentTrack = playlist[currentTrackIndex];
      return currentTrack;
    }

    public string GetCurrentTrackInfo() {
      Track current;
      int minutes;
      int seconds;
      string trackInfo;

      current = GetCurrentTrack();
      minutes = current.DurationSeconds / secondsInOneMinute;
      seconds = current.DurationSeconds % secondsInOneMinute;
      trackInfo = $"{current.Title} - {current.Artist} [{minutes}:{seconds:D2}]";
      return trackInfo;
    }

    public string GetPlaylistString() {
      string result;
      result = "\n=== PLAYLIST ===\n";

      for (int trackIndex = 0; trackIndex < playlist.Count; trackIndex++) {
        Track singleTrack;
        int minutes;
        int seconds;
        string currentMarker;

        singleTrack = playlist[trackIndex];
        minutes = singleTrack.DurationSeconds / secondsInOneMinute;
        seconds = singleTrack.DurationSeconds % secondsInOneMinute;
        currentMarker = "";

        if (trackIndex == currentTrackIndex) {
          currentMarker = " ▶";
        }

        result = result + $"{trackIndex + 1}. {singleTrack.Title} - {singleTrack.Artist} [{minutes}:{seconds:D2}]{currentMarker}\n";
      }

      return result;
    }

    public string GetStatusString() {
      Track current;
      int minutes;
      int seconds;
      string result;

      current = GetCurrentTrack();
      minutes = current.DurationSeconds / secondsInOneMinute;
      seconds = current.DurationSeconds % secondsInOneMinute;

      result = "\n=== PLAYER STATUS ===\n";
      result = result + $"State: {currentState.GetStateName()}\n";
      result = result + $"Current track: {current.Title}\n";
      result = result + $"Artist: {current.Artist}\n";
      result = result + $"Duration: {minutes}:{seconds:D2}\n";
      result = result + $"Track number: {currentTrackIndex + 1} of {playlist.Count}";

      return result;
    }

    private void LoadDefaultPlaylist() {
      playlist = new List<Track>();

      Track firstTrack;
      firstTrack = new Track();
      firstTrack.Title = "Bohemian Rhapsody";
      firstTrack.Artist = "Queen";
      firstTrack.DurationSeconds = 355;
      playlist.Add(firstTrack);

      Track secondTrack;
      secondTrack = new Track();
      secondTrack.Title = "Imagine";
      secondTrack.Artist = "John Lennon";
      secondTrack.DurationSeconds = 183;
      playlist.Add(secondTrack);

      Track thirdTrack;
      thirdTrack = new Track();
      thirdTrack.Title = "Billie Jean";
      thirdTrack.Artist = "Michael Jackson";
      thirdTrack.DurationSeconds = 294;
      playlist.Add(thirdTrack);

      Track fourthTrack;
      fourthTrack = new Track();
      fourthTrack.Title = "Like a Rolling Stone";
      fourthTrack.Artist = "Bob Dylan";
      fourthTrack.DurationSeconds = 366;
      playlist.Add(fourthTrack);
    }
  }
}