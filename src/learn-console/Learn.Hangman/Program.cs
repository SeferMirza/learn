using Learn.Hangman;
using Learn.Hangman.Consoles;

var game = new GameFactory().CreateDefault();
var console = new SystemConsole();
var runner = new GameRunner(game, console);

runner.Run();
