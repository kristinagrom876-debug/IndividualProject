using System;
using MusicPlayer.Services;

namespace MusicPlayer {
  class Program {
    private const string commandPlay = "1";
    private const string commandPause = "2";
    private const string commandStop = "3";
    private const string commandNext = "4";
    private const string commandPrevious = "5";
    private const string commandShowPlaylist = "6";
    private const string commandShowStatus = "7";
    private const string commandExit = "0";

    static void Main(string[] args) {
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
        result = "";

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