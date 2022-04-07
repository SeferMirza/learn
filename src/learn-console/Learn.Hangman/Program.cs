using Learn.Hangman;
using Learn.Hangman.Consoles;
using Learn.Hangman.Models;

var menus = new Menus();
var menu = new MainMenu(menus.MainMenu);
var menuRunner = new MenuRunner(menu, new SystemConsole());

menuRunner.Run();
