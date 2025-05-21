using System.Security.Cryptography.X509Certificates;

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
  4) Config
  5) Save
  0) Exit
============================================================",
    @"
=>  ",
    userInput, isHeadless)
{

  required public ConfigManager MainConfigMan
  { get; set; }

  public override int ExecMenu()
  {
    bool inMenu = true;
    ConfigMenu? configMenu = new("0", isHeadless: isHeadless);
    BankingMenu bankingMenu = new("0", isHeadless: isHeadless)
    {
      BankingConfigMan = MainConfigMan
    };


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
          bankingMenu.ExecMenu();
          break;
        case 2:
          inMenu = false;
          break;
        case 3:
          inMenu = false;
          break;
        case 4:
          configMenu.ExecMenu();
          break;
        case 5:
          SaveConfig(MainConfigMan);
          break;
        default:
          Console.Clear();
          Console.WriteLine("Please enter a valid option... ");
          break;
      }
    }

    return 0;
  }

  public static void SaveConfig(ConfigManager cm)
  {
    cm.ConfigObj.BackgroundColor = Console.BackgroundColor;
    cm.ConfigObj.ForegroundColor = Console.ForegroundColor;
    cm.WriteConfig();
    Console.WriteLine("Wrote configuration to " + cm.ConfigPath);
  }
}