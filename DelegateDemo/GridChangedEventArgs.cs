using System;

namespace DelegateDemo
{
   public class GridChangedEventArgs : EventArgs
   {
      public string Status { get; private set; }
      public DateTime Time { get; private set; }

      public GridChangedEventArgs(string status, DateTime time)
      {
         Status = status;
         Time = time;
      }

   }
}