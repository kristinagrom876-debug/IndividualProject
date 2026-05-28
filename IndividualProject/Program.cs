using System;
using MusicPlayer.Services;

namespace MusicPlayer {
  public class Program {
    private static string commandPlay;
    private static string commandPause;
    private static string commandStop;
    private static string commandNext;
    private static string commandPrevious;
    private static string commandShowPlaylist;
    private static string commandShowStatus;
    private static string commandExit;

    public static void Main() {
      Player player;
      bool isRunning;
      string choice;
      string result;

      commandPlay = "1";
      commandPause = "2";
      commandStop = "3";
      commandNext = "4";
      commandPrevious = "5";
      commandShowPlaylist = "6";
      commandShowStatus = "7";
      commandExit = "0";

      player = new Player();
      isRunning = true;

      Console.WriteLine("=== MUSIC PLAYER ===");
      Console.WriteLine("State pattern - Playing/Paused/Stopped");

      while (isRunning) {
        Console.WriteLine("\n=== COMMANDS ===");
        Console.WriteLine("1. Play");
        Console.WriteLine("2. Pause");
        Console.WriteLine("3. Stop");
        Console.WriteLine("4. Next track");
        Console.WriteLine("5. Previous track");
        Console.WriteLine("6. Show playlist");
        Console.WriteLine("7. Show status");
        Console.WriteLine("0. Exit");

        Console.Write("\nYour choice: ");

        choice = Console.ReadLine();

        if (choice == commandPlay) {
          result = player.Play();
          Console.WriteLine(result);
          Console.WriteLine($"Now playing: {player.GetCurrentTrackInfo()}");
        } else if (choice == commandPause) {
          result = player.Pause();
          Console.WriteLine(result);
        } else if (choice == commandStop) {
          result = player.Stop();
          Console.WriteLine(result);
        } else if (choice == commandNext) {
          result = player.Next();
          Console.WriteLine(result);
          Console.WriteLine($"Now playing: {player.GetCurrentTrackInfo()}");
        } else if (choice == commandPrevious) {
          result = player.Previous();
          Console.WriteLine(result);
          Console.WriteLine($"Now playing: {player.GetCurrentTrackInfo()}");
        } else if (choice == commandShowPlaylist) {
          Console.WriteLine(player.GetPlaylistString());
        } else if (choice == commandShowStatus) {
          Console.WriteLine(player.GetStatusString());
        } else if (choice == commandExit) {
          isRunning = false;
          Console.WriteLine("Goodbye!");
        } else {
          Console.WriteLine("Unknown command!");
        }
      }
    }
  }
}