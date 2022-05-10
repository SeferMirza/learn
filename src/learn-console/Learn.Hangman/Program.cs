using Learn.Hangman;
using Learn.Hangman.Consoles;
using Learn.Hangman.MenuOptions;

var mainMenuOptionsList = new MenuOptionFactory().FillMainMenuOptions(new SystemConsole(), new GameRunner(new GameFactory().CreateDefault(), new SystemConsole()));

var menuRunner = new MenuRunner(new MainMenu(mainMenuOptionsList), new SystemConsole());

menuRunner.Run();
