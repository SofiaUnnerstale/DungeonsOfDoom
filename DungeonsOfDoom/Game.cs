using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utils;

namespace DungeonsOfDoom
{
    class Game
    {
        Player player;
        Room[,] world;
     

        public void Play()
        {
            TextUtils.AnimateText("Welcome to the Dungeons of doom...", 70);
            Console.WriteLine();
            Thread.Sleep(1000);
            CreatePlayer();
            GetStory();
            CreateWorld();
            
            do
            {
                Console.Clear();
                DisplayWorld();
                DisplayStats();
                AskForMovement();

            } while (player.Health > 0 || Monster.MonsterCount > 0);

            GameOver();
        }

        private void GetStory()
        {
            string story = System.IO.File.ReadAllText(@"C: \Users\Administrator\Source\Repos\DungeonsOfDoom\DungeonsOfDoom\DungeonsOfDoom.txt");
            TextUtils.AnimateText(story, 50);
        }

        private void DisplayStats()
        {
            DisplayPlayer();
            Monster monsterInRoom = world[player.X, player.Y].Monster;
            if (monsterInRoom != null)
            {
                DisplayMonster(monsterInRoom);
            }
            
        }

        private void DisplayMonster(Monster monsterInRoom)
        {
            Console.WriteLine();
            Console.WriteLine(monsterInRoom.Name);
            Console.Write($"Health: {monsterInRoom.Health} ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("♥");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write($"Strength: {monsterInRoom.Strength} ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("♦");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();


        }

        private void DisplayPlayer()
        {
            Console.WriteLine();
            Console.WriteLine(player.Name);
            Console.Write($"Health: {player.Health} ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("♥");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write($"Strength: {player.Strength} ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("♦");
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

                CheckForEncounter();
            }

        }

        private void CheckForEncounter()
        {
            bool isNotValid = true;
            Monster monsterInRoom = world[player.X, player.Y].Monster;
            if (monsterInRoom != null)
            {
                isNotValid = EncounterMonster(isNotValid, monsterInRoom);

            }


            else if (world[player.X, player.Y].Item != null)
            {
                EncounterItem();

            }
        }

        private void EncounterItem()
        {
            world[player.X, player.Y].Item.PickUpItem(player);
            Console.WriteLine($"You have picked up {world[player.X, player.Y].Item.Name}");
            world[player.X, player.Y].Item = null;
            Thread.Sleep(500);

           


        }

        

        private bool EncounterMonster(bool isNotValid, Monster monsterInRoom)
        {
            Console.WriteLine($"You have encounter a {monsterInRoom.Name}. The monster says: \"{ monsterInRoom.CatchPhrase}\"");
            do
            {

                Console.WriteLine("Do you want to engage Y/N");

                try
                {
                    string choice = Console.ReadLine();
                    switch (choice.ToUpper())
                    {
                        case "Y":
                            int result = player.Attack(monsterInRoom);
                            Console.WriteLine($"{monsterInRoom.Name} was hurt by {result}!");
                            Thread.Sleep(1000);

                            if (monsterInRoom.Health > 0)
                            {
                                result = monsterInRoom.Attack(player);

                                if (result>0)
                                {
                                Console.WriteLine($"{player.Name} was hurt by {result}!");
                                Thread.Sleep(700);

                                }
                                else
                                {
                                    GameOver();

                                }
                            }
                            else
                            {
                                player.Backpack.Add(world[player.X, player.Y].Monster);
                                world[player.X, player.Y].Monster = null;
                                Console.WriteLine($"Congrats you have slayed the {monsterInRoom.Name}!");
                                Thread.Sleep(700);


                            }

                            isNotValid = false; break;

                        case "N": isNotValid = false; break;

                        default: break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            } while (isNotValid);
            return isNotValid;
        }

        private void Water()
        {
            if (RandomUtils.RandomGenerator(10))
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
            int t = 1234 + index * 127;
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
            if (Monster.MonsterCount<=0)
            {
                Console.WriteLine("Congrats! You have sent all the monsters back to the underworld where they belong!");
                Console.ReadKey();
             
            }
            else
            {
                Console.WriteLine("Game over...");
                Console.ReadKey();
            }

            Console.Write("Do you want to play again? Y/N ");
            string temp = Console.ReadLine();
            switch (temp)
            {
                case "Y": Play(); break;

                default:
                    break;
            }
            

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
                        

                        if (RandomUtils.RandomGenerator(2))
                        { world[x, y].Monster = new Grimsnare(); }
                        else if (RandomUtils.RandomGenerator(2))
                        { world[x, y].Monster = new PrimitivePhantomBeast(); }

                       

                        if (RandomUtils.RandomGenerator(1))
                        { world[x, y].Item = new Food("Apple", 1, 1); }
                        else if (RandomUtils.RandomGenerator(1))
                        { world[x, y].Item = new Food("HealthPotion", 2, 2); }
                        else if (RandomUtils.RandomGenerator(1))
                        { world[x, y].Item = new Weapon("Axe", 3, 4); }
                        else if (RandomUtils.RandomGenerator(1))
                        { world[x, y].Item = new Weapon("Sword", 2, 2); }

                    }

                }
            }
        }

        private void CreatePlayer()
        {
            Console.Write("Skriv in namnet på din hjälte: ");
            string playerName = Console.ReadLine();

            player = new Player(playerName, 30, 5, 0, 0);
        }



    }
}
