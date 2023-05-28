using ShipTask.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ship = new List<Ship>();
            int option = 0;
            while (option != 5)
            {
                option = menu();
                if (option == 1)
                {
                    AddShip(ship);
                }
                if (option == 2)
                {   
                    view(ship);
                }
                if (option == 3)
                {
                    viewsingquad(ship);
                }
                if(option == 4)
                {
                    changePosition(ship);
                }
                if(option > 5 || option < 1)
                {
                    Console.WriteLine("Enter the correct option ");
                    Console.ReadKey();
                }
            }
        }

        static int menu()
        {
            Console.Clear();
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");
            int option;
            Console.WriteLine("Enter the option : ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static void AddShip(List<Ship> ship)
        {
            Ship s = new Ship();
            Console.Write("Enter the Ship number : ");
            s.ships_number = Console.ReadLine();
            Console.WriteLine("Enter the ship Latitude : ");
            Console.Write("Enter the Latitude degree : ");
            s.latitude.degree = int.Parse(Console.ReadLine());
            Console.Write("Enter the Latitude minutes : ");
            s.latitude.minutes = float.Parse(Console.ReadLine());
            Console.Write("Enter the Latitude direction : ");
            s.latitude.direction = char.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Enter the ship longitude : ");
            Console.Write("Enter the longitude degree : ");
            s.longitude.degree = int.Parse(Console.ReadLine());
            Console.Write("Enter the longitude minutes : ");
            s.longitude.minutes = float.Parse(Console.ReadLine());
            Console.Write("Enter the longitude direction : ");
            s.longitude.direction = char.Parse(Console.ReadLine());
            ship.Add(s);
        }
        static void view(List<Ship> ship)
        {
            string number;
            Console.Write("Enter the ship number : ");
            number = Console.ReadLine();
            for (int i = 0; i < ship.Count; i++)
            {
                if (number == ship[i].ships_number)
                {
                    Console.Write(ship[i].latitude.degree + "\u00b0" + ship[i].latitude.minutes + "'" + ship[i].latitude.direction + " and ");
                    Console.Write(ship[i].longitude.degree + "\u00b0" + ship[i].longitude.minutes + "'" + ship[i].longitude.direction);
                    Console.ReadKey();
                }
            }

        }

        static void viewsingquad(List<Ship> ship)
        {
            int degree1;
            int degree2;
            float minutes1;
            float minutes2;
            char dir1;
            char dir2;
            bool flag = false;
            Console.WriteLine("Enter the ship Latitude : ");
            Console.Write("Enter the Latitude degree : ");
            degree1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the Latitude minutes : ");
            minutes1 = float.Parse(Console.ReadLine());
            Console.Write("Enter the Latitude direction : ");
            dir1 = char.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Enter the ship longitude : ");
            Console.Write("Enter the longitude degree : ");
            degree2 = int.Parse(Console.ReadLine());
            Console.Write("Enter the longitude minutes : ");
            minutes2 = float.Parse(Console.ReadLine());
            Console.Write("Enter the longitude direction : ");
            dir2 = char.Parse(Console.ReadLine());
            for(int i = 0;i < ship.Count;i++)
            {
                if(ship[i].latitude.degree == degree1 && ship[i].latitude.minutes == minutes1 && ship[i].latitude.direction == dir1 && ship[i].longitude.direction == dir2 && ship[i].longitude.minutes == minutes2 && ship[i].longitude.degree == degree2)
                {
                    flag = true;
                    Console.WriteLine("Ship Number : " + ship[i].ships_number);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    flag = false;
                }
            }
            if(flag == false)
            {
                Console.WriteLine("No Ship");
                Console.ReadKey();
            }

        }

        static void changePosition(List<Ship> ship)
        {
            string number;
            Console.WriteLine("Enter the ship number : ");
            number = Console.ReadLine();
            bool flag = false;
            for (int i = 0; i < ship.Count; i++)
            {
                if (number == ship[i].ships_number)
                {
                    flag = true;
                    Console.WriteLine("Enter the ship new Latitude : ");
                    Console.Write("Enter the new Latitude degree : ");
                    ship[i].latitude.degree = int.Parse(Console.ReadLine());
                    Console.Write("Enter the new Latitude minutes : ");
                    ship[i].latitude.minutes = float.Parse(Console.ReadLine());
                    Console.Write("Enter the new Latitude direction : ");
                    ship[i].latitude.direction = char.Parse(Console.ReadLine());
                    Console.WriteLine("");
                    Console.WriteLine("Enter the new ship longitude : ");
                    Console.Write("Enter the new longitude degree : ");
                    ship[i].longitude.degree = int.Parse(Console.ReadLine());
                    Console.Write("Enter the new longitude minutes : ");
                    ship[i].longitude.minutes = float.Parse(Console.ReadLine());
                    Console.Write("Enter the new longitude direction : ");
                    ship[i].longitude.direction = char.Parse(Console.ReadLine());
                    Console.ReadKey();
                    break;
                }
                else
                {
                    flag = false;
                }
            }
            if(flag == false)
            {
                Console.WriteLine("No Ship Found");
                Console.ReadKey();
            }
        }
    }

}
