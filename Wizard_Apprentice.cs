using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.BucketLib;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            int rcap, b1cap, b2cap;

            Console.WriteLine("Enter Room Capacity:");
            rcap = int.Parse(Console.ReadLine());
            while (rcap < 0)
            {
                Console.WriteLine("*ERROR* Room Capacity Must Be Greater Than Or Equal to 0");
                rcap = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter Bucket1 Capacity:");
            b1cap = int.Parse(Console.ReadLine());
            while (b1cap <= 0)
            {
                Console.WriteLine("*ERROR* Bucket1 Capacity Must Be Greater Than 0");
                b1cap = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter Bucket2 Capacity:");
            b2cap = int.Parse(Console.ReadLine());
            while (b2cap <= 0)
            {
                Console.WriteLine("*ERROR* Bucket2 Capacity Must Be Greater Than 0");
                b2cap = int.Parse(Console.ReadLine());
            }

            Bucket room = new Bucket(rcap, "Room");
            Bucket b1 = new Bucket(b1cap, "b1");
            Bucket b2 = new Bucket(b2cap, "b2");
            double amount;

            Console.WriteLine("Enter Amount for Room:");
            amount = double.Parse(Console.ReadLine());
            while (amount > rcap || amount < 0) {
                Console.WriteLine("*ERROR* Room Amount Must Be Less Than the Capacity or >=0");
                amount = int.Parse(Console.ReadLine());
            }

            room.Fill(amount);

            while (room.GetCurrentAmount() > 0) {
                room.PourInto(b1);
                b1.PourInto(b2);
                b2.Empty();
            }
        }
    }
}
