using System;

namespace traffic
{
    class Program
    {
        class car
        {
            private protected string location, destination, id;
            private protected int waiting_time, priority;
            public car(string l) : this(l, "none") { }
            public car(string l, string d) : this(l, d, 0) { }
            public car(string l, string d, int t) : this (l, d, t, "undefined") { }
            public car(string l, string d, int t, string i)
            {
                if ((l != "south" & l != "north" & l != "east" & l != "west") || (d != "south" & d != "north" & d != "east" & d != "west"))
                {
                    Console.WriteLine("Error! You must use only East, West, South or North for car's location and destination");
                }
                else if (t < 0)
                {
                    Console.WriteLine("Error! Car's waiting time shouldn't be negative");
                }
                else
                {
                    location = l;
                    destination = d;
                    waiting_time = t;
                    id = i;
                    priority = 999;
                }
            }
            public void print_info()
            {
                Console.WriteLine($"Car {id} with priority lvl {priority} is located at {location} and needs to get to {destination}, its waiting time is {waiting_time}");
            }
            public void travel()
            {
                Console.WriteLine($"Car {id} travels from {location} to {destination}");
                location = destination;
                destination = "none";
                waiting_time = 0;
            }
            public void wait(int s)
            {
                waiting_time += s;
                Console.WriteLine($"Car {id} waits for {s} seconds");
            }
        }
        class passenger : car
        {
            public passenger(string l, string d, int t, string i) : this(l, d, t, i, 0) { }
            public passenger(string l, string d, int t, string i, int p) : base(l, d, t, i)
            {
                priority = p;
            }

        }
        class cargo : car
        {
            public cargo(string l, string d, int t, string i) : this(l, d, t, i, 1) { }
            public cargo(string l, string d, int t, string i, int p) : base(l, d, t, i)
            {
                priority = p;
            }
        }
        static void Main(string[] args)
        {
            car test = new car("south", "north", 5);
            test.print_info();
            test.wait(15);
            test.print_info();
            test.travel();
            test.print_info();
        }
    }
}
