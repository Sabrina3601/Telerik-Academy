using System;

namespace BombermanGame
{
    [Serializable()]
    public struct Bomb
    {
        public Position position;
        public char body;
        public ConsoleColor background;
        public ConsoleColor foreground;
        public int delay;
        public bool enemyBomb;// true - enemy bombs; false - bomberman bombs;
        public int power;
        public Bomb(Position bombPos, bool enemy = false, int myPower = 5, int myDelay = 30, char myBody = '@', ConsoleColor fore = ConsoleColor.Red, ConsoleColor back = ConsoleColor.Yellow)
        {
            this.position.col = bombPos.col;
            this.position.row = bombPos.row;
            this.body = myBody;
            this.background = back;
            this.foreground = fore;
            this.delay = myDelay;
            this.enemyBomb = enemy;
            this.power = myPower;
        }
    }
}