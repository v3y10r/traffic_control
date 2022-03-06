using System;

namespace traffic
{
    class Program
    {
        class car
        {
            public string location, destination, id;
            public int waiting_time;

            public car(string l) : this(l, "none") { }
            public car(string l, string d) : this(l, d, 0) { }
            public car(string l, string d, int t) : this (l, d, t, "undefined") { }
            public car(string l, string d, int t, string i)
            {
                location = l;
                destination = d;
                waiting_time = t;
                id = i;
            }

            public void print_info()
            {
                Console.WriteLine($"Car {id} is located at {location} and needs to get to {destination}, its waiting time is {waiting_time}");
            }

            public void travel()
            {
                location = destination;
                destination = "none";
                waiting_time = 0;
                Console.WriteLine($"Car {id} travels from {location} to {destination}");
            }

            public void wait(int s)
            {
                waiting_time += s;
                Console.WriteLine($"Car {id} waits for {s} seconds");
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
