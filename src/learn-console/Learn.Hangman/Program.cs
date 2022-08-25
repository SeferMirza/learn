using Learn.Hangman;
using Learn.Hangman.Consoles;
using Learn.Hangman.MenuOptions;

var console = new SystemConsole();
List<IMenuOption> mainMenuOptions = new();
mainMenuOptions.Add(new Play(new GameRunner(new GameFactory(), console)));
mainMenuOptions.Add(new Exit(console));

List<IMenuOption> endMenuOptions = new();
endMenuOptions.Add(new Main());
endMenuOptions.Add(new Exit(console));

var menuRunner = new MenuRunner(new MainMenu(mainMenuOptions), new EndMenu(endMenuOptions), console);

menuRunner.Run();
