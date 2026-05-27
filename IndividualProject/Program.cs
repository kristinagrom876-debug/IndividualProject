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

        if (choice == commandExit) {
          isRunning = false;
          Console.WriteLine("Goodbye!");
        } else {
          Console.WriteLine("Command executed");
        }
      }
    }
  }
}