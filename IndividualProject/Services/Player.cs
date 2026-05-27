using System.Collections.Generic;
using MusicPlayer.Models;
using MusicPlayer.States;

namespace MusicPlayer.Services {
  public class Player {
    private const int SecondsInOneMinute = 60;
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

#pragma warning disable IDE0045 // Преобразовать в условное выражение
      if (hasNextTrack) {
        currentTrackIndex = ++currentTrackIndex;
      } else {
#pragma warning restore IDE0045 // Преобразовать в условное выражение
        currentTrackIndex = 0;
      }
    }

    public void PreviousTrack() {
      int playlistSize;
      bool hasPreviousTrack;
      int newTrackIndex;

      playlistSize = playlist.Count;
      newTrackIndex = --currentTrackIndex;
      hasPreviousTrack = newTrackIndex >= 0;

#pragma warning disable IDE0045 // Преобразовать в условное выражение
      if (hasPreviousTrack) {
        currentTrackIndex = newTrackIndex;
      } else {
#pragma warning restore IDE0045 // Преобразовать в условное выражение
        currentTrackIndex = --playlistSize;
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
      minutes = current.DurationSeconds / SecondsInOneMinute;
      seconds = current.DurationSeconds % SecondsInOneMinute;
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
        minutes = singleTrack.DurationSeconds / SecondsInOneMinute;
        seconds = singleTrack.DurationSeconds % SecondsInOneMinute;
        currentMarker = string.Empty;

        if (trackIndex == currentTrackIndex) {
          currentMarker = " ▶";
        }

        result += $"{trackIndex + 1}. {singleTrack.Title} - {singleTrack.Artist} [{minutes}:{seconds:D2}]{currentMarker}\n";
      }

      return result;
    }

    public string GetStatusString() {
      Track current;
      int minutes;
      int seconds;
      string result;

      current = GetCurrentTrack();
      minutes = current.DurationSeconds / SecondsInOneMinute;
      seconds = current.DurationSeconds % SecondsInOneMinute;

      result = "\n=== PLAYER STATUS ===\n";
      result += $"State: {currentState.GetStateName()}\n";
      result += $"Current track: {current.Title}\n";
      result += $"Artist: {current.Artist}\n";
      result += $"Duration: {minutes}:{seconds:D2}\n";
      result += $"Track number: {currentTrackIndex + 1} of {playlist.Count}";

      return result;
    }

    private void LoadDefaultPlaylist() {
      playlist = new List<Track>();

      Track firstTrack;
      firstTrack = new Track {
        Title = "Bohemian Rhapsody",
        Artist = "Queen",
        DurationSeconds = 355
      };
      playlist.Add(firstTrack);

      Track secondTrack;
      secondTrack = new Track {
        Title = "Imagine",
        Artist = "John Lennon",
        DurationSeconds = 183
      };
      playlist.Add(secondTrack);

      Track thirdTrack;
      thirdTrack = new Track {
        Title = "Billie Jean",
        Artist = "Michael Jackson",
        DurationSeconds = 294
      };
      playlist.Add(thirdTrack);

      Track fourthTrack;
      fourthTrack = new Track {
        Title = "Like a Rolling Stone",
        Artist = "Bob Dylan",
        DurationSeconds = 366
      };
      playlist.Add(fourthTrack);
    }
  }
}