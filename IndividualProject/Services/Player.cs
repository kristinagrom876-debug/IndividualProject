using System.Collections.Generic;
using MusicPlayer.Models;
using MusicPlayer.States;

namespace MusicPlayer.Services {
  public class Player {
    private readonly int secondsInOneMinute;
    private readonly int firstTrackIndex;
    private readonly int defaultTrackIndex;
    private readonly int startTrackNumber;

    private readonly int runawayDurationSeconds;
    private readonly int singForTheMomentDurationSeconds;
    private readonly int letMeLoveYouDurationSeconds;
    private readonly int homeDurationSeconds;
    private readonly int zooDurationSeconds;
    private readonly int imEtoNadoDurationSeconds;
    private readonly int tonuDurationSeconds;

    private IPlayerState currentState;
    private List<Track> playlist;
    private int currentTrackIndex;

    public Player() {
      secondsInOneMinute = 60;
      firstTrackIndex = 0;
      defaultTrackIndex = 0;
      startTrackNumber = 1;

      runawayDurationSeconds = 245;
      singForTheMomentDurationSeconds = 317;
      letMeLoveYouDurationSeconds = 205;
      homeDurationSeconds = 195;
      zooDurationSeconds = 210;
      imEtoNadoDurationSeconds = 180;
      tonuDurationSeconds = 200;

      currentState = new StoppedState();
      currentTrackIndex = defaultTrackIndex;
      LoadDefaultPlaylist();
    }

    public void SetState(IPlayerState newState) {
      currentState = newState;
    }

    public string Play() {
      return currentState.Play(this);
    }

    public string Pause() {
      return currentState.Pause(this);
    }

    public string Stop() {
      return currentState.Stop(this);
    }

    public string Next() {
      return currentState.Next(this);
    }

    public string Previous() {
      return currentState.Previous(this);
    }

    public void NextTrack() {
      int playlistSize;
      bool hasNextTrack;

      playlistSize = playlist.Count;
      hasNextTrack = ++currentTrackIndex < playlistSize;

      if (hasNextTrack) {
        ++currentTrackIndex;
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
        --currentTrackIndex;
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