using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Game
    {
        Player player;
        Room[,] world;
        Random random = new Random();

        public void Play()
        {
            CreatePlayer();
            CreateWorld();

            do
            {
                Console.Clear();
                DisplayWorld();
                DisplayStats();
                AskForMovement();

            } while (player.Health > 0);

            GameOver();
        }

        private void DisplayStats()
        {
            Console.WriteLine();
            Console.WriteLine(player.Name);
            Console.Write($"Health: {player.Health} ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("♥");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            int i = 0;
            Console.WriteLine("Backpack: item (weight)");

            foreach (var item in player.Backpack)
            {
                i++;
                Console.Write($"{i}: {item.Name} ({item.Weight}) ");
            }
            Console.WriteLine();

        }

        private void AskForMovement()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            int newX = player.X;
            int newY = player.Y;
            bool isValidMove = true;

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                case ConsoleKey.Enter: GameOver(); break;
                default: isValidMove = false; break;
            }

            if (isValidMove &&
                newX >= 0 && newX < world.GetLength(0) &&
                newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;

                player.Health--;

                CheckForEncounter();
            }

        }

        private void CheckForEncounter()
        {
            if (world[player.X, player.Y].Monster != null)
            {
                Console.WriteLine($"You have encounter a {world[player.X, player.Y].Monster.Name}. The monster says: \"{ world[player.X, player.Y].Monster.CatchPhrase}\"");
                Console.ReadKey();
            }
            else if (world[player.X, player.Y].Item != null)
            {
                player.Backpack.Add(world[player.X, player.Y].Item);
                world[player.X, player.Y].Item = null;
            }
        }

        private void Water()
        {
            if (random.Next(10) == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write('~');
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write('≈');
            }
        }

        private void Tree(int position = 0)
        {
            Random random = new Random(position);
            if (random.Next(5) == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("♣");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("▲");
            }
        }

        private void TopBorder()
        {
            int t = 1337;
            for (int i = 0; i < world.GetLength(0) + 10; i++)
            {
                Tree(t++);
            }
            Console.WriteLine();

            Tree(t++);
            for (int j = 0; j < world.GetLength(0) + 8; j++)
            {
                Water();
            }
            Tree(t++);
            Console.WriteLine();

            Tree(t++);
            for (int j = 0; j < world.GetLength(0) + 8; j++)
            {
                Water();
            }
            Tree(t++);
            Console.WriteLine();


            Tree(t++);
            Water();
            Water();
            for (int i = 0; i < world.GetLength(0) + 4; i++)
            {
                Tree(t++);
            }
            Water();
            Water();
            Tree(t++);
            Console.WriteLine();

            Tree(t++);
            Water();
            Water();
            Tree(t++);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("╔");
            for (int j = 0; j < world.GetLength(0); j++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            Tree(t++);
            Water();
            Water();
            Tree(t++);
            Console.WriteLine();
        }

        private void BottomBorder()
        {
            int t = 9923149;
            Tree(t++);
            Water();
            Water();
            Tree(t++);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("╚");

            for (int j = 0; j < world.GetLength(0); j++)

            {
                Console.Write("═");
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("╝");
            Tree(t++);
            Water();
            Water();
            Tree(t++);
            Console.WriteLine();

            Tree(t++);
            Water();
            Water();
            for (int i = 0; i < world.GetLength(0) + 4; i++)
            {
                Tree(t++);
            }
            Water();
            Water();
            Tree(t++);
            Console.WriteLine();

            Tree(t++);
            for (int j = 0; j < world.GetLength(0) + 8; j++)
            {
                Water();
            }
            Tree(t++);
            Console.WriteLine();

            Tree(t++);
            for (int j = 0; j < world.GetLength(0) + 8; j++)
            {
                Water();
            }
            Tree(t++);
            Console.WriteLine();

            for (int i = 0; i < world.GetLength(0) + 10; i++)
            {
                Tree(t++);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void LeftBorder(int index)
        {
            int t = 1234 + index*127;
            if (index == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("====");
                Console.Write("╪");
            }
            else
            {
                Tree(t++);
                Water();
                Water();
                Tree(t++);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("║");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void RightBorder(int index)
        {
            int t = 65481 + index * 1023;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("║");
            Tree(t++);
            Water();
            Water();
            Tree(t++);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        private void DisplayWorld()
        {
            Console.OutputEncoding = Encoding.UTF8;

            TopBorder();

            for (int y = 0; y < world.GetLength(1); y++)
            {
                LeftBorder(y);

                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];

                    if (player.X == x && player.Y == y)
                    { Console.Write(player.Icon); }
                    else if (room.Monster != null)
                    { Console.Write(world[x, y].Monster.Icon); }
                    else if (room.Item != null)
                    { Console.Write(world[x, y].Item.Icon); }
                    else
                    { Console.Write("."); }
                }
                RightBorder(y);
            }
            BottomBorder();
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over...");
            Console.ReadKey();
            Play();

        }

        private void CreateWorld()
        {
            world = new Room[30, 10];

            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = new Room();

                    if (player.X != x || player.Y != y)
                    {
                        int randomNumberMonster = random.Next(0, 100);

                        if (randomNumberMonster < 5)
                        { world[x, y].Monster = new Monster("Grimsnare", 30, "Bu!", 5, '*'); }
                        else if (randomNumberMonster < 10)
                        { world[x, y].Monster = new Monster("Primitive Phantom Beast", 15, "Prepare to die!", 3, '*'); }

                        int randomNumberItem = random.Next(0, 100);

                        if (randomNumberMonster < 15)
                        { world[x, y].Item = new Food("Apple", 1, 1); }
                        else if (randomNumberMonster < 20)
                        { world[x, y].Item = new Food("HealthPotion", 2, 2); }
                        else if (randomNumberMonster < 25)
                        { world[x, y].Item = new Weapon("Axe", 3, 4); }
                        else if (randomNumberMonster < 25)
                        { world[x, y].Item = new Weapon("Sword", 2, 2); }

                    }

                }
            }
        }

        private void CreatePlayer()
        {
            Console.Write("Skriv in namnet på din hjälte: ");
            string playerName = Console.ReadLine();

            player = new Player(playerName, 30, 0, 0, 0);
        }



    }
}
