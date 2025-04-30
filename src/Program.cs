using System;

class Program
{

  static bool isProgram = true;

  static ConfigManager configManager = new("resource/config.json");

  static MainMenu? mainMenu;

  static void initMenus()
  {
    mainMenu = new("0", isHeadless: false);
  }

  static void Main(string[] args)
  {
    // Read Config
    configManager.readConfig();

    // Init Menus
    initMenus();

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