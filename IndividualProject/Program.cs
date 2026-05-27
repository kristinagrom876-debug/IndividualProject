using System;
using MusicPlayer.Services;

namespace MusicPlayer {
  class Program {
    private string commandPlay = "1";
    private string commandPause = "2";
    private string commandStop = "3";
    private string commandNext = "4";
    private string commandPrevious = "5";
    private string commandShowPlaylist = "6";
    private string commandShowStatus = "7";
    private string commandExit = "0";

    static void Main(string[] args) {
      MusicPlayer player = new MusicPlayer();

      Console.WriteLine("=== MUSIC PLAYER ===");
      Console.WriteLine("State pattern - Playing/Paused/Stopped");

      bool isRunning = true;

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
        string choice = Console.ReadLine();

        string result = "";

        if (choice == commandPlay) {
          result = player.Play();
          Console.WriteLine(result);
        } else if (choice == commandPause) {
          result = player.Pause();
          Console.WriteLine(result);
        } else if (choice == commandStop) {
          result = player.Stop();
          Console.WriteLine(result);
        } else if (choice == commandNext) {
          result = player.Next();
          Console.WriteLine(result);
        } else if (choice == commandPrevious) {
          result = player.Previous();
          Console.WriteLine(result);
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