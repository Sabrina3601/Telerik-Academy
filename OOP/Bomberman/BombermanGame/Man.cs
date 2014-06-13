using System;

namespace BombermanGame
{
    [Serializable()]
    public struct Man
    {
        public Position position;
        public char body;
        public ConsoleColor background;
        public ConsoleColor foreground;
        public int lifes;
        public Man(Position myPos, int life = 3, ConsoleColor fore = ConsoleColor.Red, ConsoleColor back = ConsoleColor.Gray)
        {
            this.position.col = myPos.col;
            this.position.row = myPos.row;
            this.body = (char)(0x263B);// Try (char)0x263B depending on the console font//ok
            this.background = back;
            this.foreground = fore;
            this.lifes = life;
        }
    }
}