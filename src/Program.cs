using System;

class Program
{

  static bool isProgram = true;

  static ConfigManager configManager = new("resource/config.json");

  static MainMenu? mainMenu;

  static void InitMenus()
  {
    mainMenu = new("0", isHeadless: false)
    {
      ConfigMan = configManager
    };
  }

  static void Main(string[] args)
  {
    // Read Config
    configManager.ReadConfig();

    // Init Menus
    InitMenus();

    // Main Program Loop
    while (isProgram)
    {
      if (mainMenu == null)
      {
        isProgram = false;
        continue;
      }

      if (mainMenu.ExecMenu() == 0)
      {
        isProgram = false;
      }
    }
  }
}