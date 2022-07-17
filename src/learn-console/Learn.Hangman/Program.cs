using Learn.Hangman;
using Learn.Hangman.Consoles;
using Learn.Hangman.MenuOptions;

var console = new SystemConsole();
List<IMenuOption> options = new();
options.Add(new Play(new GameRunner(new GameFactory().CreateDefault(), console)));
options.Add(new Exit(console));

var menuRunner = new MenuRunner(new MainMenu(options), console);

menuRunner.Run();
