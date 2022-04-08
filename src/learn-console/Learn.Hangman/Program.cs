using Learn.Hangman;
using Learn.Hangman.Consoles;
using Learn.Hangman.Lists;

var menus = new MenuList();
var menu = new MainMenu(menus.GetMainMenu());
var menuRunner = new MenuRunner(menu, new SystemConsole());

menuRunner.Run();
