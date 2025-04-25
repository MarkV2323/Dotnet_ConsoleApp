using System.Drawing;

class ConfigMenu(string userInput = "0", bool isHeadless = false)
  : Menu(
    @"
============================================================
        Please select an option from the list below.

  1) Background - RED
  2) Background - GREEN
  3) Background - BLACK
  4) Foreground - RED
  5) Foreground - GREEN
  6) Foreground - BLACK
  0) Exit
============================================================",
    @"
=>  ",
    userInput, isHeadless)
{

  public override int ExecMenu()
  {
    bool inMenu = true;
    while (inMenu)
    {
      // Display Menu Text
      Console.WriteLine(menuText);

      // Display Prompt Text
      Console.Write(menuPrompt);

      // Gather user input
      int choice = GetInput();

      switch (choice)
      {
        case 0:
          inMenu = false;
          break;
        case 1:
          Console.BackgroundColor = ConsoleColor.Red;
          break;
        case 2:
          Console.BackgroundColor = ConsoleColor.Green;
          break;
        case 3:
          Console.BackgroundColor = ConsoleColor.Black;
          break;
        case 4:
          Console.ForegroundColor = ConsoleColor.Red;
          break;
        case 5:
          Console.ForegroundColor = ConsoleColor.Green;
          break;
        case 6:
          Console.ForegroundColor = ConsoleColor.Black;
          break;
        default:
          Console.Clear();
          Console.WriteLine("Please enter a valid option... ");
          break;
      }
    }

    return 0;
  }
}