class DepoistMenu(string userInput = "0", bool isHeadless = false)
  : Menu(
    @"
How much would you like to add: ",
    @"
=>  ",
    userInput, isHeadless)
{

  required public ConfigManager DepoistConfigMan
  { get; set; }
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

      if (choice >= 0)
      {
        inMenu = false;
        DepoistConfigMan.ConfigObj.BankBalance += choice;
        Console.WriteLine("Your new balance is " + DepoistConfigMan.ConfigObj.BankBalance);
      }
      else
      {
        Console.Clear();
        Console.WriteLine("You cannot add negative money...");
      }
    }

    return 0;
  }
}