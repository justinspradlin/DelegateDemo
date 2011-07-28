using System;

namespace DelegateDemo
{
   public class GridWithCustomEventHandler
   {
      public string Name { get; set; }

      // Define the method of the delegate method that will do the work
      public delegate void SomethingChangedHandler(object sender, GridChangedEventArgs e);

      // Create an event that requires the SomethingChanged delegate 
      public event SomethingChangedHandler SomethingChanged;


      /// <summary>
      /// Invokes the SomethingChanged event if there are any subscribers
      /// </summary>
      private void OnSomethingChanged()
      {
         if (SomethingChanged != null)
         {
            Console.WriteLine("{0} - Notifying subscribers that SomethingChanged", Name);
            // Raise the event and pass the new EventArgs that will be available to the subscribers
            SomethingChanged(this,
                             new GridChangedEventArgs(string.Format("{0} says \"Hi\"", this.Name), DateTime.Now));
         }
         else
         {
            Console.WriteLine(string.Format("{0} - I guess nobody cares about my event! :(", Name));
         }
      }

      /// <summary>
      /// This represents something changing in the grid that will 
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
      public void ChangeHandler(object sender, GridChangedEventArgs e)
      {
         // Do some work on the grid that is listening for the change

         Console.WriteLine(string.Format("{0} - I received this message from {1} at {2}\r\n\r\n\t{3}\r\n",
                                         this.Name,
                                         ((GridWithCustomEventHandler)sender).Name,
                                         e.Time,
                                         e.Status));

      }
   }
}