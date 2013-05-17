using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    public class PersonScoreComparer : IComparer<Person>
    {

        int IComparer<Person>.Compare(Person x, Person y)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        /// <summary>
        /// Compares two people by their score.
        /// </summary>
        /// <param name="firstPerson">first person</param>
        /// <param name="secondPerson">second person</param>
        /// <returns></returns>
        public static int Compare(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Score.CompareTo(secondPerson.Score);
        }
    }
}
