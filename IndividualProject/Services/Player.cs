using System.Collections.Generic;
using MusicPlayer.Models;
using MusicPlayer.States;

namespace MusicPlayer.Services {
  public class Player {
    private readonly int secondsInOneMinute = 60;
    private readonly int firstTrackIndex = 0;
    private readonly int defaultTrackIndex = 0;
    private readonly int startTrackNumber = 1;

    private readonly int runawayDurationSeconds = 245;
    private readonly int singForTheMomentDurationSeconds = 317;
    private readonly int letMeLoveYouDurationSeconds = 205;
    private readonly int homeDurationSeconds = 195;
    private readonly int zooDurationSeconds = 210;
    private readonly int imEtoNadoDurationSeconds = 180;
    private readonly int tonuDurationSeconds = 200;

    private IPlayerState currentState;
    private List<Track> playlist;
    private int currentTrackIndex;

    public Player() {
      currentState = new StoppedState();
      currentTrackIndex = defaultTrackIndex;
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
      hasNextTrack = ++currentTrackIndex < playlistSize;

      if (hasNextTrack) {
        currentTrackIndex = ++currentTrackIndex;
      } else {
        currentTrackIndex = firstTrackIndex;
      }
    }

    public void PreviousTrack() {
      int playlistSize;
      bool hasPreviousTrack;
      int newTrackIndex;

      playlistSize = playlist.Count;
      newTrackIndex = --currentTrackIndex;
      hasPreviousTrack = newTrackIndex >= firstTrackIndex;

      if (hasPreviousTrack) {
        currentTrackIndex = newTrackIndex;
      } else {
        currentTrackIndex = --playlistSize;
      }
    }

    public Track GetCurrentTrack() {
      Track currentTrack;

      if (currentTrackIndex < firstTrackIndex || currentTrackIndex >= playlist.Count) {
        currentTrackIndex = defaultTrackIndex;
      }

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

      for (int trackIndex = firstTrackIndex; trackIndex < playlist.Count; trackIndex++) {
        Track singleTrack;
        int minutes;
        int seconds;
        string currentMarker;

        singleTrack = playlist[trackIndex];
        minutes = singleTrack.DurationSeconds / secondsInOneMinute;
        seconds = singleTrack.DurationSeconds % secondsInOneMinute;
        currentMarker = string.Empty;

        if (trackIndex == currentTrackIndex) {
          currentMarker = " ▶";
        }

        result += $"{trackIndex + startTrackNumber}. {singleTrack.Title} - {singleTrack.Artist} [{minutes}:{seconds:D2}]{currentMarker}\n";
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
      result += $"State: {currentState.GetStateName()}\n";
      result += $"Current track: {current.Title}\n";
      result += $"Artist: {current.Artist}\n";
      result += $"Duration: {minutes}:{seconds:D2}\n";
      result += $"Track number: {currentTrackIndex + startTrackNumber} of {playlist.Count}";

      return result;
    }

    private void LoadDefaultPlaylist() {
      playlist = new List<Track>();

      Track firstTrack;
      firstTrack = new Track {
        Title = "Runaway",
        Artist = "Aurora",
        DurationSeconds = runawayDurationSeconds
      };
      playlist.Add(firstTrack);

      Track secondTrack;
      secondTrack = new Track {
        Title = "Sing For The Moment",
        Artist = "Eminem",
        DurationSeconds = singForTheMomentDurationSeconds
      };
      playlist.Add(secondTrack);

      Track thirdTrack;
      thirdTrack = new Track {
        Title = "Let Me Love You",
        Artist = "DJ Snake, Sean Paul, Justin Bieber",
        DurationSeconds = letMeLoveYouDurationSeconds
      };
      playlist.Add(thirdTrack);

      Track fourthTrack;
      fourthTrack = new Track {
        Title = "Home",
        Artist = "Machine Gun Kelly, X Ambassadors, Bebe Rexha",
        DurationSeconds = homeDurationSeconds
      };
      playlist.Add(fourthTrack);

      Track fifthTrack;
      fifthTrack = new Track {
        Title = "ZOO (from Zootopia 2)",
        Artist = "Shakira",
        DurationSeconds = zooDurationSeconds
      };
      playlist.Add(fifthTrack);

      Track sixthTrack;
      sixthTrack = new Track {
        Title = "Им это надо",
        Artist = "MAYOT",
        DurationSeconds = imEtoNadoDurationSeconds
      };
      playlist.Add(sixthTrack);

      Track seventhTrack;
      seventhTrack = new Track {
        Title = "Тону",
        Artist = "HOLLYFLAME",
        DurationSeconds = tonuDurationSeconds
      };
      playlist.Add(seventhTrack);
    }
  }
}