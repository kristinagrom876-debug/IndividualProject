using System;
using MusicPlayer.Services;

namespace MusicPlayer {
  public class Program {
    private const string CommandPlay = "1";
    private const string CommandPause = "2";
    private const string CommandStop = "3";
    private const string CommandNext = "4";
    private const string CommandPrevious = "5";
    private const string CommandShowPlaylist = "6";
    private const string CommandShowStatus = "7";
    private const string CommandExit = "0";

    public static void Main(string[] args) {
      Player player;

      player = new Player();

      Console.WriteLine("=== MUSIC PLAYER ===");
      Console.WriteLine("State pattern - Playing/Paused/Stopped");

      bool isRunning;

      isRunning = true;

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

        string choice;

        choice = Console.ReadLine();

        string result;
        if (choice == CommandPlay) {
          result = player.Play();

          Console.WriteLine(result);
          Console.WriteLine($"Now playing: {player.GetCurrentTrackInfo()}");
        } else if (choice == CommandPause) {
          result = player.Pause();

          Console.WriteLine(result);
        } else if (choice == CommandStop) {
          result = player.Stop();

          Console.WriteLine(result);
        } else if (choice == CommandNext) {
          result = player.Next();

          Console.WriteLine(result);
          Console.WriteLine($"Now playing: {player.GetCurrentTrackInfo()}");
        } else if (choice == CommandPrevious) {
          result = player.Previous();

          Console.WriteLine(result);
          Console.WriteLine($"Now playing: {player.GetCurrentTrackInfo()}");
        } else if (choice == CommandShowPlaylist) {
          Console.WriteLine(player.GetPlaylistString());
        } else if (choice == CommandShowStatus) {
          Console.WriteLine(player.GetStatusString());
        } else if (choice == CommandExit) {
          isRunning = false;

          Console.WriteLine("Goodbye!");
        } else {
          Console.WriteLine("Unknown command!");
        }
      }
    }
#pragma warning restore IDE0060 // Удалите неиспользуемый параметр
  }
}