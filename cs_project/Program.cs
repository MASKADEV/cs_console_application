using System;

namespace cs_project
{

    class Program
    {

        static void Main(string[] args)
        {
            ShapesManagment shapes = new ShapesManagment();
            Console.Title = "Shapes Managment";
            Console.ForegroundColor = ConsoleColor.White;

            try
            {
                while (true)
                {
                    shapes.menu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
