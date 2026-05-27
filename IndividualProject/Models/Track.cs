namespace MusicPlayer.Models {
  class Track {

    private const int secondsInOneMinute = 60;

    public string Title { get; set; }
    public string Artist { get; set; }
    public int DurationSeconds { get; set; }

    public string GetDurationString() {
      int minutes;
      int seconds;

      minutes = DurationSeconds / secondsInOneMinute;
      seconds = DurationSeconds % secondsInOneMinute;

      return $"{minutes}:{seconds:D2}";
    }
  }
}