using System;

namespace DelegateDemo
{
   public class Grid
   {
      public string Name { get; set; }

      // Define the method of the delegate method that will do the work
      public delegate void SomethingChangedHandler();

      // Create an event that requires the SOmethingChanged delegate 
      public event SomethingChangedHandler SomethingChanged;


      /// <summary>
      /// Invokes the SomethingChanged event if there are any subscribers
      /// </summary>
      private void OnSomethingChanged()
      {
         if (SomethingChanged != null)
         {
            Console.WriteLine("{0} - Notifying subscribers that SomethingChanged", Name);
            SomethingChanged();
         }
         else
         {
            Console.WriteLine(string.Format("{0} - I guess nobody cares about my event! :(", Name));
         }
      }

      /// <summary>
      /// This represents something chaning in the grid that will 
      /// notify subscribers that the grid changed. Will be fired in Grid 1
      /// </summary>
      public void MakeAChange()
      {
         // Do any work here
         Console.WriteLine();
         Console.WriteLine("{0} - Doing my event handlers for the change before telling subscribers.", Name);

         // Notify Subscribers
         OnSomethingChanged();
      }


      /// <summary>
      /// This does something after the change happens. This could be Grid 2 or 3
      /// </summary>
      public void ChangeHandler()
      {
         // Do some work on the grid that is listening for the change

         Console.WriteLine(string.Format("{0} - Making some thing happen", Name));

      }
   }
}