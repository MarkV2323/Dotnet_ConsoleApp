class WithdrawMenu(string userInput = "0", bool isHeadless = false)
  : Menu(
    @"
How much would you like to remove: ",
    @"
=>  ",
    userInput, isHeadless)
{

  required public ConfigManager WithdrawConfigMan
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

      if (choice < 0)
      {
        Console.Clear();
        Console.WriteLine("You cannot remove negative money...");
        continue;
      }

      int money = WithdrawConfigMan.ConfigObj.BankBalance - choice;
      if (money < 0)
      {
        Console.Clear();
        Console.WriteLine("You cannot remove more money then your bank balance has...");
        continue;
      }

      inMenu = false;
      WithdrawConfigMan.ConfigObj.BankBalance = money;
      Console.WriteLine("Your new balance is " + WithdrawConfigMan.ConfigObj.BankBalance);
    }

    return 0;
  }
}