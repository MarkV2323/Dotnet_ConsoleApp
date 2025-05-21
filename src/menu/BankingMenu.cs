class BankingMenu(string userInput = "0", bool isHeadless = false)
  : Menu(
    @"
============================================================
        Please select an option from the list below.

  1) Check balance
  2) Depoist
  3) Withdraw
  0) Exit
============================================================",
    @"
=>  ",
    userInput, isHeadless)
{

  required public ConfigManager BankingConfigMan
  { get; set; }
  public override int ExecMenu()
  {
    bool inMenu = true;
    DepoistMenu depoistMenu = new("0", isHeadless: isHeadless)
    {
      DepoistConfigMan = BankingConfigMan
    };
    WithdrawMenu withdrawMenu = new("0", isHeadless: isHeadless)
    {
      WithdrawConfigMan = BankingConfigMan
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
          inMenu = false;
          break;
        case 1:
          Console.WriteLine("");
          Console.WriteLine("Your balance is " + BankingConfigMan.ConfigObj.BankBalance);
          break;
        case 2:
          depoistMenu.ExecMenu();
          break;
        case 3:
          withdrawMenu.ExecMenu();
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