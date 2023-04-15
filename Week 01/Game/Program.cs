using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;

namespace Game__C_sharp_
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
            
            int[] bulletX = new int[200];
            int[] bulletY = new int[200];
            int[] enemy2BulletX = new int[200];
            int[] enemy2BulletY = new int[200];
            int index = 0;
            int index2 = 0;
            int heliX = 10;
            int heliY = 10;
            int enemy2X = 137;
            int enemy2Y = 15;
            string direction2 = "left";
            string direction = "up";
            bool gameRunning = true;
            char e1 = '|';
            char e2 = '|';
            int timer = 0;
            while (true)
            {
                MainMenu();
               int option =  menu();
                if (option == 1)
                {
                    maze(print);
                    PrintHeli(heliX, heliY, heli);
                    PrintEnemy2(e1, e2, enemy2X, enemy2Y);

                    while (gameRunning)
                    {
                        if (Keyboard.IsKeyPressed(Key.UpArrow))
                        {
                            if (print[heliY-1, heliX + 1] == ' ' && print[heliY - 1, heliX + 5] == ' ' && print[heliY - 1, heliX + 8] == ' ' && print[heliY - 1, heliX + 11] == ' ' && print[heliY - 1, heliX + 13] == ' ')
                            {
                                goUp(ref heliX, ref heliY, heli);

                            }
                        }
                        if (Keyboard.IsKeyPressed(Key.DownArrow))
                        {
                            if (print[heliY + 3, heliX + 1] == ' ' && print[heliY + 3, heliX + 5] == ' ' && print[heliY + 3, heliX + 7] == ' ' && print[heliY + 3, heliX + 9] == ' ' && print[heliY + 3, heliX + 11] == ' ' && print[heliY + 3, heliX + 13] == ' ')
                            {
                                goDown(ref heliX, ref heliY, heli);
                            }

                        }
                        if (Keyboard.IsKeyPressed(Key.RightArrow))
                        {
                            if (print[heliY, heliX + 14] == ' ' && print[heliY+1, heliX + 14] == ' '&& print[heliY+2, heliX + 14] == ' ')
                            {
                                goRight(ref heliX, ref heliY, heli);
                            }
                        }
                        if (Keyboard.IsKeyPressed(Key.LeftArrow))
                        {
                            if (print[heliY, heliX - 1] == ' ' && print[heliY + 1, heliX - 1] == ' ' && print[heliY + 2, heliX - 1] == ' ')
                            {
                                goLeft(ref heliX, ref heliY, heli);
                            }
                        }

                        if (Keyboard.IsKeyPressed(Key.Space))
                        {
                            CreateBullet(ref index, heliX, heliY, bulletX, bulletY);
                        }
                        if (timer % 5 == 0)
                        {

                            MoveEnemy2(ref direction, ref direction2, e1, e2, ref enemy2X, ref enemy2Y);
                        }
                        if (timer % 50 == 0)
                        {
                            Enemy2Bullet(ref index2, enemy2X, enemy2Y, enemy2BulletX, enemy2BulletY);

                        }
                        MoveEnemy2Bullet(ref index2, enemy2BulletX, enemy2BulletY, print);
                        MoveBullets(ref index, bulletX, bulletY, print);
                        timer++;
                        Thread.Sleep(20);
                    }
                    Console.ReadLine();
                }

                if(option == 2)
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
                if(option == 3)
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
            Console.WriteLine("  /$$   /$$ /$$$$$$$$ /$$       /$$$$$$       /$$   /$$  /$$$$$$  /$$    /$$  /$$$$$$   /$$$$$$  "     );
            Console.WriteLine(" | $$  | $$| $$_____/| $$      |_  $$_/      | $$  | $$ /$$__  $$| $$   | $$ /$$__  $$ /$$__  $$ "     );
            Console.WriteLine(" | $$  | $$| $$      | $$        | $$        | $$  | $$| $$  \\ $$| $$   | $$| $$  \\ $$| $$  \\__/ "  );
            Console.WriteLine(" | $$$$$$$$| $$$$$   | $$        | $$        | $$$$$$$$| $$$$$$$$|  $$ / $$/| $$  | $$| $$       "     );
            Console.WriteLine(" | $$__  $$| $$__/   | $$        | $$        | $$__  $$| $$__  $$ \\  $$ $$/ | $$  | $$| $$       "    );
            Console.WriteLine(" | $$  | $$| $$      | $$        | $$        | $$  | $$| $$  | $$  \\  $$$/  | $$  | $$| $$    $$ "    );
            Console.WriteLine(" | $$  | $$| $$$$$$$$| $$$$$$$$ /$$$$$$      | $$  | $$| $$  | $$   \\  $/   |  $$$$$$/|  $$$$$$/ "    );
            Console.WriteLine(" |__/  |__/|________/|________/|______/      |__/  |__/|__/  |__/    \\_/     \\______/  \\______/  "  );
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

        static void PrintHeli(int heliX, int heliY, char[,] heli)
        {
          

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 14; j++)
                {

                    Console.SetCursorPosition(heliX + j, heliY + i);
                    Console.Write(heli[i,j]);
                }
            }
        } 
        
        static void RemoveHeli(int heliX, int heliY)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    Console.SetCursorPosition(heliX + j, heliY + i);
                    Console.Write(" ");
                }
            }
        }

       static void goUp( ref int heliX, ref int heliY,char[,] heli)
        {
          
                RemoveHeli(heliX, heliY);
                heliY = heliY - 1;
                Console.SetCursorPosition(heliX, heliY);
                PrintHeli(heliX, heliY,heli);
           
        }
        
        static void goDown( ref int heliX, ref int heliY, char[,] heli)
        {
          
                RemoveHeli(heliX, heliY);
                heliY = heliY + 1;
                Console.SetCursorPosition(heliX, heliY);
                PrintHeli(heliX, heliY,heli);
           
        }

        static void goRight(ref int heliX, ref int heliY, char[,] heli)
        {

            RemoveHeli(heliX, heliY);
            heliX = heliX + 1;
            Console.SetCursorPosition(heliX, heliY);
            PrintHeli(heliX, heliY,heli);

        }
        static void goLeft(ref int heliX, ref int heliY, char[,] heli)
        {

            RemoveHeli(heliX, heliY);
            heliX = heliX - 1;
            Console.SetCursorPosition(heliX, heliY);
            PrintHeli(heliX, heliY,heli);

        }

       static void PrintEnemy2(char e1, char e2, int enemy2X, int enemy2Y)
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
                    Console.SetCursorPosition(enemy2X + j, enemy2Y + i);
                    Console.Write(enemy1[i, j]);
                }
            }
        }
        static void RemoveEnemy2(char e1, char e2, int enemy2X, int enemy2Y)
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
                    Console.SetCursorPosition(enemy2X + j, enemy2Y + i);
                    Console.Write(" ");
                }
            }
        }

        static void MoveEnemy2(ref string direction,ref string direction2, char e1, char e2,ref int enemy2X, ref int enemy2Y)
        {
            if (direction2 == "left")
            {
                
                    if (enemy2X > 110)
                    {
                        RemoveEnemy2(e1, e2, enemy2X, enemy2Y);
                        enemy2X = enemy2X - 1;
                        Console.SetCursorPosition(enemy2X, enemy2Y);
                        PrintEnemy2(e1, e2, enemy2X, enemy2Y);
                    }
                    else
                    {
                        direction2 = "right";
                    }
                
            }
            if (direction2 == "right")
            {
               
                    if (enemy2X < 135)
                    {
                        RemoveEnemy2(e1, e2, enemy2X, enemy2Y);
                        enemy2X = enemy2X + 1;
                        Console.SetCursorPosition(enemy2X, enemy2Y);
                        PrintEnemy2(e1, e2, enemy2X, enemy2Y);
                    }
                    else
                    {
                        direction2 = "left";
                    }

                    // Sleep(100);
                
            }

            if (direction == "up")
            {

                if (enemy2Y > 21)
                {
                    // gotoxy(enemy1X,enemy1Y);k8
                    RemoveEnemy2(e1, e2, enemy2X, enemy2Y);
                    enemy2Y = enemy2Y - 1;
                    Console.SetCursorPosition(enemy2X, enemy2Y);
                    PrintEnemy2(e1, e2, enemy2X, enemy2Y);
                }
                else
                {
                    direction = "down";
                }
                
            }
            if (direction == "down")
            {

               
                    if (enemy2Y < 35)
                    {
                    RemoveEnemy2(e1, e2, enemy2X, enemy2Y);
                    enemy2Y = enemy2Y + 1;
                    Console.SetCursorPosition(enemy2X, enemy2Y);
                    PrintEnemy2(e1, e2, enemy2X, enemy2Y);
                }
                    else
                    {
                        direction = "up";
                    }
                
            }
        }

        static void CreateBullet(ref int index, int heliX, int heliY, int[] bulletX, int [] bulletY)
        {
            bulletX[index] = heliX + 13;
            bulletY[index] = heliY + 1;
            Console.SetCursorPosition(bulletX[index], bulletY[index]);
            Console.Write(".");
            index++;
        }

        static void MoveBullets(ref int index, int[] bulletX, int[] bulletY, char[,] print)
        {
            for (int i = 0; i < index; i++)
            {
                if (print[bulletY[i] + 2, bulletX[i]] == ' ')
                {
                    Console.SetCursorPosition(bulletX[i], bulletY[i]);
                    Console.WriteLine(" ");
                    bulletX[i]++;
                    Console.SetCursorPosition(bulletX[i], bulletY[i]);
                    Console.Write(".");
                }
     
                else
                {
                    Console.SetCursorPosition(bulletX[i], bulletY[i]);
                    Console.WriteLine("#");
                    for (int j = 0; j < index - 1; j++)
                    {
                        bulletX[j] = bulletX[j + 1];
                        bulletY[j] = bulletY[j + 1];
                    }
                    index--;
                }
            }
        }

        static void Enemy2Bullet(ref int index2,int enemy2X, int enemy2Y, int[] enemy2BulletX, int[] enemy2BulletY)
        {
            enemy2BulletX[index2] = enemy2X - 1;
            enemy2BulletY[index2] = enemy2Y + 1;
            Console.SetCursorPosition(enemy2BulletX[index2], enemy2BulletY[index2]);
            Console.Write("<");
            index2++;
        }

        static void MoveEnemy2Bullet(ref int index2,int[] enemy2BulletX, int[] enemy2BulletY, char[,] print)
        {
            for (int i = 0; i < index2; i++)
            {
                if (print[enemy2BulletY[i] - 2, enemy2BulletX[i]] == ' ')
                {
                    Console.SetCursorPosition(enemy2BulletX[i], enemy2BulletY[i]);
                    Console.WriteLine(" ");
                    enemy2BulletX[i]--;
                    Console.SetCursorPosition(enemy2BulletX[i], enemy2BulletY[i]);
                    Console.Write("<");
                }
                else
                {
                    Console.SetCursorPosition(enemy2BulletX[i], enemy2BulletY[i]);
                    Console.WriteLine("#");
                    for (int j = 0; j < index2 - 1; j++)
                    {
                        enemy2BulletX[j] = enemy2BulletX[j + 1];
                        enemy2BulletY[j] = enemy2BulletY[j + 1];
                    }
                    index2--;
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
                for (int i = 0; i < 145;i++)
                {
                    print[row, i] = record[i];

                }
                row++;
            }
            myFile.Close();
        }

       
        


    }
}