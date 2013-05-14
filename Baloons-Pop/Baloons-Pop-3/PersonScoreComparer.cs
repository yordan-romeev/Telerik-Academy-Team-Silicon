using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    public class PersonScoreComparer : IComparer<Person>
    {
         /// <summary>
        /// Compares two people by their score.
        /// </summary>
        /// <param name="firstPerson"></param>
        /// <param name="secondPerson"></param>
        /// <returns></returns>
        public int Compare(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Score.CompareTo(secondPerson.Score);
        }
    }
}
