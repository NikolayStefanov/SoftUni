using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5._Date_Modifier_EXE
{
    public static class DataModifier
    {

        public static int TimeDifference(string firstTime, string secondTime)
        {
            // / Difference in days, hours, and minutes.
            //
            //TimeSpan ts = EndDate - StartDate;
            //
            // // Difference in days.
            //
            // int differenceInDays = ts.Days; // This is in int
            // double differenceInDays = ts.TotalDays; // This is in double
            // Difference in Hours.
            // int differenceInHours = ts.Hours; // This is in int
            // double differenceInHours = ts.TotalHours; // This is in double
            //
            // Difference in Minutes.
            // int differenceInMinutes = ts.Minutes; // This is in int
            // double differenceInMinutes = ts.TotalMinutes; // This is in double
            var firstTimeInList = firstTime.Split().Select(int.Parse).ToList();
            var firstTimeYear = firstTimeInList[0];
            var fistTimeMonth = firstTimeInList[1];
            var firstTimeDay = firstTimeInList[2];

            var secondTimeInList = secondTime.Split().Select(int.Parse).ToList();
            var secondTimeYear = secondTimeInList[0];
            var secondTimeMonth = secondTimeInList[1];
            var secondTimeDay = secondTimeInList[2];

            DateTime firstDate = new DateTime(firstTimeYear, fistTimeMonth, firstTimeDay);
            DateTime secondDate = new DateTime(secondTimeYear, secondTimeMonth, secondTimeDay);
            TimeSpan diff = secondDate - firstDate;
            int diffDays = diff.Days;
            return Math.Abs(diffDays);
        }
    }
}
