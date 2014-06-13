using System;

namespace BombermanGame
{
    [Serializable()]
    public enum direction { up, down, left, right };
    [Serializable()]
    public struct Gad
    {
        public Position position;
        public char body;
        public ConsoleColor background;
        public ConsoleColor foreground;
        public int lifes;
        public int speed;
        public direction dir;
        public int moveCount;

        public Gad(Position myPos, int life = 1)
        {
            this.position.col = myPos.col;
            this.position.row = myPos.row;
            this.lifes = life;
            this.body = 'G';
            this.speed = 3;
            this.dir = direction.up;
            this.moveCount = 0;
            this.background = ConsoleColor.Magenta;
            this.foreground = ConsoleColor.White;
        }
    }
}