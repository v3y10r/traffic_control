using System;

namespace cars
{
    abstract public class car
    {
        public virtual string loc { get; set; }
        public virtual string dest { get; set; }
        private protected string location, destination, id;
        private protected int waiting_time, priority;
        public car(string l) : this(l, "none") { }
        public car(string l, string d) : this(l, d, 0) { }
        public car(string l, string d, int t) : this(l, d, t, "undefined") { }
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
        public virtual void print_info()
        {
            Console.WriteLine($"Car {id} is located at {location} and needs to get to {destination}, its waiting time is {waiting_time}");
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
        public void wait(int s, car second)
        {
            waiting_time += s;
            Console.WriteLine($"Car {id} waits before {second.id} for {s} seconds");
        }
        public int waiting_time_output()
        {
            return waiting_time;
        }
        public int waiting_time_output(bool is_idle)
        {
            if (!is_idle)
                return waiting_time;
            else
                return waiting_time + 5;
        }
        public static bool operator >(car car1, car car2)
        {
            return car1.waiting_time > car2.waiting_time;
        }
        public static bool operator <(car car1, car car2)
        {
            return car1.waiting_time < car2.waiting_time;
        }
    }
    public class cargo : car
    {
        private protected int load = 0;
        public cargo(string l) : this(l, "none") { }
        public cargo(string l, string d) : this(l, d, 0) { }
        public cargo(string l, string d, int t) : this(l, d, t, "undefined") { }
        public cargo(string l, string d, int t, string i) : this(l, d, t, i, 0) { }
        public cargo(string l, string d, int t, string i, int load) : base(l, d, t, i)
        {
            priority = 1;
        }
        public override void print_info()
        {
            base.print_info();
            Console.WriteLine($"It has {load} load");
        }
        public void travel(bool is_idle)
        {
            if (is_idle)
                this.wait(5);
            Console.WriteLine($"Car {id} travels from {location} to {destination}");
            location = destination;
            destination = "none";
            waiting_time = 0;
        }
        public static int operator >(cargo car1, cargo car2)
        {
            return car1.load - car2.load;
        }
        public static int operator <(cargo car1, cargo car2)
        {
            return car2.load - car1.load;
        }
    }
    public class passenger : car
    {
        public override string loc
        {
            get
            {
                return location;
            }
            set
            {
                if (value == "south" || value == "north" || value == "east" || value == "west")
                    location = value;
            }
        }
        public override string dest
        {
            get
            {
                return destination;
            }
            set
            {
                if (value == "south" || value == "north" || value == "east" || value == "west")
                    destination = value;
            }
        }
        public passenger(string l) : this(l, "none") { }
        public passenger(string l, string d) : this(l, d, 0) { }
        public passenger(string l, string d, int t) : this(l, d, t, "undefined") { }
        public passenger(string l, string d, int t, string i) : base(l, d, t, i)
        {
            priority = 0;
        }
        public override void print_info()
        {
            Console.WriteLine($"Passenger car {id} is located at {location} and needs to get to {destination}, its waiting time is {waiting_time}");
        }
    }
}
