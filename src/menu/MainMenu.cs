class MainMenu(string userInput = "0", bool isHeadless = false)
  : Menu(
    @"
============================================================
        Welcome to the Console Application Program!
        Please select where to navigate to from the
        options listed below.
  
  1) Banking   Application
  2) Vechicle  Application
  3) Inventory Application
  4) Options
  5) Save
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
          Console.WriteLine("Thank you for using our application, please come again!");
          inMenu = false;
          break;
        case 1:
          inMenu = false;
          break;
        case 2:
          inMenu = false;
          break;
        case 3:
          inMenu = false;
          break;
        case 4:
          inMenu = false;
          break;
        case 5:
          inMenu = false;
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