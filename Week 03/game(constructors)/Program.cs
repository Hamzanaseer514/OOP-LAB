using EZInput;
using game_constructors_.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game_constructors_
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] print = new char[41, 145];
            char[,] heli =
              {
                  { ' ', ' ', ' ', '-', '-', '-', '-', '-', '|', '-', '-', '-', '-', '-'},
                  { '*', '>', '=', '=', '=', '=', '=', '[', '_', ']', 'L', ')', ' ', ' '},
                  { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ',', ' ', ',', ' ', ' ', ' ', ' '},
                };
            loadMaze(print);

            coordinate player = new coordinate();
            coordinate enemy2 = new coordinate();
            player.x = 10;
            player.y = 10;
            enemy2.x = 137;
            enemy2.y = 15;
            enemy2.health = 200;
            player.BulletX = new List<int>();
            player.BulletY = new List<int>();
            enemy2.BulletX = new List<int>();
            enemy2.BulletY = new List<int>();
            string direction2 = "left";
            string direction = "up";
            bool gameRunning = true;
            char e1 = '|';
            char e2 = '|';
            int timer = 0;
            int score = 0;
            while (true)
            {
                MainMenu();
                int option = menu();
                if (option == 1)
                {
                    maze(print);
                    PrintHeli(player, heli);
                    Printenemy2(e1, e2, enemy2);
                    while (gameRunning)
                    {
                        if (Keyboard.IsKeyPressed(Key.UpArrow))
                        {
                            if (print[player.y - 1, player.x + 1] == ' ' && print[player.y - 1, player.x + 5] == ' ' && print[player.y - 1, player.x + 8] == ' ' && print[player.y - 1, player.x + 11] == ' ' && print[player.y - 1, player.x + 13] == ' ')
                            {
                                goUp(player, heli);

                            }
                        }
                        if (Keyboard.IsKeyPressed(Key.DownArrow))
                        {
                            if (print[player.y + 3, player.x + 1] == ' ' && print[player.y + 3, player.x + 5] == ' ' && print[player.y + 3, player.x + 7] == ' ' && print[player.y + 3, player.x + 9] == ' ' && print[player.y + 3, player.x + 11] == ' ' && print[player.y + 3, player.x + 13] == ' ')
                            {
                                goDown(player, heli);
                            }

                        }
                        if (Keyboard.IsKeyPressed(Key.RightArrow))
                        {
                            if (print[player.y, player.x + 14] == ' ' && print[player.y + 1, player.x + 14] == ' ' && print[player.y + 2, player.x + 14] == ' ')
                            {
                                goRight(player, heli);
                            }
                        }
                        if (Keyboard.IsKeyPressed(Key.LeftArrow))
                        {
                            if (print[player.y, player.x - 1] == ' ' && print[player.y + 1, player.x - 1] == ' ' && print[player.y + 2, player.x - 1] == ' ')
                            {
                                goLeft(player, heli);
                            }
                        }

                        if (Keyboard.IsKeyPressed(Key.Space))
                        {
                            CreateBullet(player);
                        }
                        if (timer % 5 == 0)
                        {

                            Moveenemy2(ref direction, ref direction2, e1, e2, enemy2, print);
                        }
                        if (timer % 50 == 0)
                        {
                            enemy2Bullet(enemy2);

                        }
                        Moveenemy2Bullet(enemy2, print);
                        MoveBullets(print, player, enemy2);
                        for (int i = 0; i < player.BulletX.Count; i++)
                        {
                            DetectionEnemy(enemy2, player.BulletX[i], player.BulletY[i], ref score);
                        }
                        printScore(score);
                        timer++;
                        Thread.Sleep(10);
                    }
                    Console.ReadLine();
                }

                if (option == 2)
                {
                    Instructions();
                    Console.ReadLine();
                }
                if (option > 3 || option < 1)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("\t\t\t\t Please Enter the valid option");
                    Console.ReadLine();
                }
                if (option == 3)
                {
                    break;
                }

            }
        }

        static int menu()
        {
            int option;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t 1. Start ");
            Console.WriteLine("\t\t\t\t 2. Instructions ");
            Console.WriteLine("\t\t\t\t 3. Exists ");
            Console.WriteLine("");
            Console.Write("\t\t\t\t  Enter the option : ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("  /$$   /$$ /$$$$$$$$ /$$       /$$$$$$       /$$   /$$  /$$$$$$  /$$    /$$  /$$$$$$   /$$$$$$  ");
            Console.WriteLine(" | $$  | $$| $$_____/| $$      |_  $$_/      | $$  | $$ /$$__  $$| $$   | $$ /$$__  $$ /$$__  $$ ");
            Console.WriteLine(" | $$  | $$| $$      | $$        | $$        | $$  | $$| $$  \\ $$| $$   | $$| $$  \\ $$| $$  \\__/ ");
            Console.WriteLine(" | $$$$$$$$| $$$$$   | $$        | $$        | $$$$$$$$| $$$$$$$$|  $$ / $$/| $$  | $$| $$       ");
            Console.WriteLine(" | $$__  $$| $$__/   | $$        | $$        | $$__  $$| $$__  $$ \\  $$ $$/ | $$  | $$| $$       ");
            Console.WriteLine(" | $$  | $$| $$      | $$        | $$        | $$  | $$| $$  | $$  \\  $$$/  | $$  | $$| $$    $$ ");
            Console.WriteLine(" | $$  | $$| $$$$$$$$| $$$$$$$$ /$$$$$$      | $$  | $$| $$  | $$   \\  $/   |  $$$$$$/|  $$$$$$/ ");
            Console.WriteLine(" |__/  |__/|________/|________/|______/      |__/  |__/|__/  |__/    \\_/     \\______/  \\______/  ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("______________Loading     ");
            Console.Write("*" + "*" + "*" + "*");
            Thread.Sleep(500);
            Console.Write("*" + "*" + "*" + "*");
            Thread.Sleep(500);
            Console.Write("*" + "*" + "*" + "*");
            Thread.Sleep(500);
            Console.Write("*" + "*" + "*" + "*");
            Thread.Sleep(500);

        }

        static void Instructions()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t........WELCOME! THESE ARE THE INSTRUCTIONS OF GAME HELI HAVOC.......... ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1. Upper Arrow key used to move the helicopter upward.");
            Console.WriteLine("");
            Console.WriteLine("2. Down Arrow key is used to move the helicopter downward.");
            Console.WriteLine("");
            Console.WriteLine("3. Left Arrow key is used to move the helicopter left side.");
            Console.WriteLine("");
            Console.WriteLine("4. Right Arrow key is used to move the helicopter right side.");
            Console.WriteLine("");
            Console.WriteLine("5. Space key is used to fire the enemies.");
            Console.WriteLine("");
            Console.WriteLine("6. When you hit by enemy fire your health will decreases by 1");
            Console.WriteLine("");
            Console.WriteLine("7. when your bullet hits the enemy, his health decreases and when it health reaches to zero. then enemy killed.");

        }
        static void maze(char[,] print)
        {
            Console.Clear();
            for (int i = 0; i < 41; i++)
            {
                for (int j = 0; j < 145; j++)
                {
                    Console.Write(print[i, j]);
                }
                Console.WriteLine("");
            }
        }

        static void PrintHeli(coordinate player, char[,] heli)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 14; j++)
                {

                    Console.SetCursorPosition(player.x + j, player.y + i);
                    Console.Write(heli[i, j]);
                }
            }
        }

        static void RemoveHeli(coordinate player)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    Console.SetCursorPosition(player.x + j, player.y + i);
                    Console.Write(" ");
                }
            }
        }

        static void goUp(coordinate player, char[,] heli)
        {

            RemoveHeli(player);
            player.y = player.y - 1;
            Console.SetCursorPosition(player.x, player.y);
            PrintHeli(player, heli);

        }

        static void goDown(coordinate player, char[,] heli)
        {

            RemoveHeli(player);
            player.y = player.y + 1;
            Console.SetCursorPosition(player.x, player.y);
            PrintHeli(player, heli);

        }

        static void goRight(coordinate player, char[,] heli)
        {

            RemoveHeli(player);
            player.x = player.x + 1;
            Console.SetCursorPosition(player.x, player.y);
            PrintHeli(player, heli);

        }
        static void goLeft(coordinate player, char[,] heli)
        {

            RemoveHeli(player);
            player.x = player.x - 1;
            Console.SetCursorPosition(player.x, player.y);
            PrintHeli(player, heli);

        }

        static void Printenemy2(char e1, char e2, coordinate enemy2)
        {
            char[,] enemy1 =
                {
                 { ' ', ' ', '/', '|', ' ', ' '},
                 { 'C', e1, e1, e1, e1, e2},
                 { ' ', ' ', '|', '/', ' ', ' '},
                };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.SetCursorPosition(enemy2.x + j, enemy2.y + i);
                    Console.Write(enemy1[i, j]);
                }
            }
        }
        static void Removeenemy2(coordinate enemy2)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.SetCursorPosition(enemy2.x + j, enemy2.y + i);
                    Console.Write(" ");
                }
            }
        }

        static void Moveenemy2(ref string direction, ref string direction2, char e1, char e2, coordinate enemy2, char[,] print)
        {
            if (direction2 == "left")
            {

                if (enemy2.x > 110)
                {
                    Removeenemy2(enemy2);
                    print[enemy2.y, enemy2.x - 1] = ' ';
                    print[enemy2.y + 1, enemy2.x - 1] = ' ';
                    print[enemy2.y + 2, enemy2.x - 1] = ' ';
                    enemy2.x = enemy2.x - 1;
                    Console.SetCursorPosition(enemy2.x, enemy2.y);
                    Printenemy2(e1, e2, enemy2);
                    print[enemy2.y, enemy2.x - 1] = '1';
                    print[enemy2.y + 1, enemy2.x - 1] = '1';
                    print[enemy2.y + 2, enemy2.x - 1] = '1';
                }
                else
                {
                    direction2 = "right";
                }

            }
            if (direction2 == "right")
            {

                if (enemy2.x < 135)
                {
                    Removeenemy2(enemy2);
                    print[enemy2.y, enemy2.x - 1] = ' ';
                    print[enemy2.y + 1, enemy2.x - 1] = ' ';
                    print[enemy2.y + 2, enemy2.x - 1] = ' ';
                    enemy2.x = enemy2.x + 1;
                    Console.SetCursorPosition(enemy2.x, enemy2.y);
                    Printenemy2(e1, e2, enemy2);
                    print[enemy2.y, enemy2.x - 1] = '1';
                    print[enemy2.y + 1, enemy2.x - 1] = '1';
                    print[enemy2.y + 2, enemy2.x - 1] = '1';
                }
                else
                {
                    direction2 = "left";
                }

                // Sleep(100);

            }

            if (direction == "up")
            {

                if (enemy2.y > 21)
                {
                    // gotoxy(enemy1X,enemy1Y);k8
                    Removeenemy2(enemy2);
                    print[enemy2.y, enemy2.x - 1] = ' ';
                    print[enemy2.y + 1, enemy2.x - 1] = ' ';
                    print[enemy2.y + 2, enemy2.x - 1] = ' ';
                    enemy2.y = enemy2.y - 1;
                    Console.SetCursorPosition(enemy2.x, enemy2.y);
                    Printenemy2(e1, e2, enemy2);
                    print[enemy2.y, enemy2.x - 1] = '1';
                    print[enemy2.y + 1, enemy2.x - 1] = '1';
                    print[enemy2.y + 2, enemy2.x - 1] = '1';
                }
                else
                {
                    direction = "down";
                }

            }
            if (direction == "down")
            {


                if (enemy2.y < 35)
                {
                    Removeenemy2(enemy2);
                    print[enemy2.y, enemy2.x - 1] = ' ';
                    print[enemy2.y + 1, enemy2.x - 1] = ' ';
                    print[enemy2.y + 2, enemy2.x - 1] = ' ';
                    enemy2.y = enemy2.y + 1;
                    Console.SetCursorPosition(enemy2.x, enemy2.y);
                    Printenemy2(e1, e2, enemy2);
                    print[enemy2.y, enemy2.x - 1] = '1';
                    print[enemy2.y + 1, enemy2.x - 1] = '1';
                    print[enemy2.y + 2, enemy2.x - 1] = '1';
                }
                else
                {
                    direction = "up";
                }

            }
        }

        static void DetectionEnemy(coordinate enemy2, int x, int y, ref int score)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (enemy2.x + i == x && enemy2.y + j == y)
                    {
                        enemy2.health--;
                        score++;
                        Console.SetCursorPosition(148, 8);
                        Console.WriteLine("Enemy2Health : " + enemy2.health);
                        if (enemy2.health == 0)
                        {
                            Removeenemy2(enemy2);
                        }
                    }
                }
            }


        }

        static void CreateBullet(coordinate player)
        {
            player.BulletX.Add(player.x + 13);
            player.BulletY.Add(player.y + 1);
            Console.SetCursorPosition(player.x + 13, player.y + 1);
            Console.Write(".");
        }

        static void MoveBullets(char[,] print, coordinate player, coordinate enemy2)
        {
            for (int i = 0; i < player.BulletX.Count; i++)
            {
                if (print[player.BulletY[i] + 2, player.BulletX[i]] == ' ')
                {
                    Console.SetCursorPosition(player.BulletX[i], player.BulletY[i]);
                    Console.WriteLine(" ");
                    player.BulletX[i]++;
                    Console.SetCursorPosition(player.BulletX[i], player.BulletY[i]);
                    Console.Write(".");
                }

                else
                {

                    Console.SetCursorPosition(player.BulletX[i], player.BulletY[i]);
                    Console.WriteLine(" ");
                    player.BulletX.RemoveAt(i);
                    player.BulletY.RemoveAt(i);

                }
            }
        }

        static void enemy2Bullet(coordinate enemy2)
        {
            enemy2.BulletX.Add(enemy2.x - 1);
            enemy2.BulletY.Add(enemy2.y + 1);
            Console.SetCursorPosition(enemy2.x - 1, enemy2.y + 1);
            Console.Write("<");
        }

        static void Moveenemy2Bullet(coordinate enemy2, char[,] print)
        {
            for (int i = 0; i < enemy2.BulletX.Count; i++)
            {
                if (print[enemy2.BulletY[i] - 2, enemy2.BulletX[i]] == ' ')
                {
                    Console.SetCursorPosition(enemy2.BulletX[i], enemy2.BulletY[i]);
                    Console.WriteLine(" ");
                    enemy2.BulletX[i]--;
                    Console.SetCursorPosition(enemy2.BulletX[i], enemy2.BulletY[i]);
                    Console.Write("<");
                }
                else
                {
                    Console.SetCursorPosition(enemy2.BulletX[i], enemy2.BulletY[i]);
                    Console.WriteLine(" ");

                    enemy2.BulletX.RemoveAt(i);
                    enemy2.BulletY.RemoveAt(i);

                }
            }
        }

        static void StoreMaze(char[,] print)
        {
            StreamWriter myFile = new StreamWriter("D:\\2nd semester OOP\\OOP PD\\Week 01\\Game\\maze.txt");

            for (int i = 0; i < 41; i++)
            {
                for (int j = 0; j < 145; j++)
                {
                    myFile.Write(print[i, j]);
                }
                myFile.WriteLine("");

            }
            myFile.Close();
        }

        static void loadMaze(char[,] print)
        {
            string path = "D:\\2nd semester OOP\\OOP PD\\Week 01\\Game\\maze.txt";
            string record;
            int row = 0;
            StreamReader myFile = new StreamReader(path);
            while ((record = myFile.ReadLine()) != null)
            {
                for (int i = 0; i < 145; i++)
                {
                    print[row, i] = record[i];

                }
                row++;
            }
            myFile.Close();
        }

        static void printScore(int score)
        {
            Console.SetCursorPosition(10, 41);
            Console.Write("Score : " + score);
        }

    }
}

