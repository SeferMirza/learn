using Learn.Hangman;
using Learn.Hangman.Consoles;

var menu = new MenuFactory().CreateDefaultMainMenu();
var menuRunner = new MenuRunner(menu, new SystemConsole());

menuRunner.Run();
