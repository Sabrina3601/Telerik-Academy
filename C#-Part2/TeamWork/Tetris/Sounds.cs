using System;
using System.IO;
using System.Threading;
using System.Media;

namespace Tetris
{
    public static class Sounds
    {
        public enum SoundEffects { Move, Rotate, ClearLine, Drop, LevelUp, GameOver }
        static int[,] musicSheet;
        const string path = @"..\..\sound\";
        public static Thread musicThread;
        static bool musicOn = false;

        public static bool MusicOn
        {
            get
            {
                return musicOn;
            }
            set
            {
                if (value && !musicOn)
                {
                    StartMusic();
                    musicOn = true;
                }

                if (!value && musicOn)
                {
                    StopMusic();
                    musicOn = false;
                }
            }
        }

        static Sounds() // A static constructor to load the game music when the method class is first used
        {
            if (File.Exists(path + "music.mus"))
            {
                StreamReader musicFile = new StreamReader(path + "music.mus");
                musicThread = new Thread(new ThreadStart(PlayMusic));
                LoadMusicFromFile(musicFile);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        public static void SFX(SoundEffects sfx)
        {
            switch (sfx)
            {
                case SoundEffects.Move:
                    PlaySoundFromFile(path + "move.wav");
                    break;
                case SoundEffects.Rotate:
                    PlaySoundFromFile(path + "rotate.wav");
                    break;
                case SoundEffects.LevelUp:
                    PlaySoundFromFile(path + "levelup.wav");
                    break;
                case SoundEffects.ClearLine:
                    PlaySoundFromFile(path + "clearline.wav");
                    break;
                case SoundEffects.Drop:
                    PlaySoundFromFile(path + "drop.wav");
                    break;
                case SoundEffects.GameOver:
                    PlaySoundFromFile(path + "gameover.wav");
                    break;
            } 
        }

        private static void PlaySoundFromFile(string filePath)
        {
            using (SoundPlayer player = new SoundPlayer(filePath))
            {
                player.Stop();
                player.Play();
            }
        }

        internal static void StopMusic()
        {
            musicThread.Abort();
            musicThread = new Thread(new ThreadStart(PlayMusic));
        }

        internal static void StartMusic()
        {
            musicThread.Start();
        }

        static void LoadMusicFromFile(StreamReader loadMusic)
        {
            int lines = int.Parse(loadMusic.ReadLine());
            musicSheet = new int[lines, 2];
            for (int i = 0; i < lines; i++)
            {
                string[] musicLine = loadMusic.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                musicSheet[i, 0] = int.Parse(musicLine[0]);
                musicSheet[i, 1] = int.Parse(musicLine[1]);
            }
        }

        internal static void PlayMusic()
        {
            while (true)
            {
                for (int line = 0; line < musicSheet.GetLength(0); line++)
                {
                    if (musicSheet[line, 1] != 0)
                    {
                        Console.Beep(musicSheet[line, 0], musicSheet[line, 1]);
                    }
                    else
                    {
                        Thread.Sleep(musicSheet[line, 0]);
                    }
                }
            }
        }
    }
}
