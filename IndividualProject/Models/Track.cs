namespace MusicPlayer.Models {
  public class Track {
    private const int SecondsInOneMinute = 60;

    public string Title { get; set; }

    public string Artist { get; set; }

    public int DurationSeconds { get; set; }

    public string GetDurationString() {
      int minutes;
      int seconds;

      minutes = DurationSeconds / SecondsInOneMinute;
      seconds = DurationSeconds % SecondsInOneMinute;

      return $"{minutes}:{seconds:D2}";
    }
  }
}