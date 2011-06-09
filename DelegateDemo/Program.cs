namespace DelegateDemo
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;

   /// <summary>
   /// Summary description for Program
   /// </summary>
   class Program
   {
      /// <summary>
      /// The main entry point for the console application.
      /// </summary>
      /// <param name="args">The command line arguments</param>
      static void Main(string[] args)
      {
         RunSimpleGridDemo();

         RunFancyGridDemo();

         Console.WriteLine("Press any key to exit!");
         Console.ReadLine();

      }

      private static void RunSimpleGridDemo()
      {
         var grid1 = new Grid { Name = "Grid1" };
         var grid2 = new Grid { Name = "Grid2" };
         var grid3 = new Grid { Name = "Grid3" };

         Console.WriteLine("Making Grid2 and Grid3 listen for the change on Grid1");
         grid1.SomethingChanged += new Grid.SomethingChangedHandler(grid2.ChangeHandler);
         grid1.SomethingChanged += new Grid.SomethingChangedHandler(grid3.ChangeHandler);
         Console.WriteLine();

         Console.WriteLine("Making a change on Grid1");
         grid1.MakeAChange();
         Console.WriteLine();


         Console.WriteLine("Making a change on Grid2, I bet nobody is listening!");
         grid2.MakeAChange();
         Console.WriteLine();
      }

      private static void RunFancyGridDemo()
      {
         Console.WriteLine("Now for some custom evernt args.....................\r\n");

         var customGrid1 = new GridWithCustomEventHandler { Name = "CustomGrid1" };
         var customGrid2 = new GridWithCustomEventHandler { Name = "CustomGrid2" };
         var customGrid3 = new GridWithCustomEventHandler { Name = "CustomGrid3" };

         Console.WriteLine("Making CustomGrid2 and CustomGrid3 listen for the change on CustomGrid1");
         customGrid1.SomethingChanged += new GridWithCustomEventHandler.SomethingChangedHandler(customGrid2.ChangeHandler);
         customGrid1.SomethingChanged += new GridWithCustomEventHandler.SomethingChangedHandler(customGrid3.ChangeHandler);
         Console.WriteLine();

         Console.WriteLine("Making a change on CustomGrid1");
         customGrid1.MakeAChange();
         Console.WriteLine();

         Console.WriteLine("Making a change on CustomGrid2, I bet nobody is listening!");
         customGrid2.MakeAChange();
         Console.WriteLine();
      }

   }
}
