using System;

namespace BookClub
{
    class Program
    {
        static void Main(string[] args)
        {
            BookClub bc = new BookClub("./XML Files/");

            bc.LoadData();
        }
    }
}
