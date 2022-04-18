using ConsoleGame;

string path = "../../../map.txt";
var eventLoop = new EventLoop();
var game = new Game(path);
game.StartConsole();

eventLoop.LeftHandler += game.OnLeft;
eventLoop.LeftHandler += game.UpdatePosition;

eventLoop.RightHandler += game.OnRight;
eventLoop.RightHandler += game.UpdatePosition;

eventLoop.DownHandler += game.OnDown;
eventLoop.DownHandler += game.UpdatePosition;

eventLoop.UpHandler += game.OnUp;
eventLoop.UpHandler += game.UpdatePosition;

eventLoop.EscHandler += game.OnEsc;

eventLoop.Run();
