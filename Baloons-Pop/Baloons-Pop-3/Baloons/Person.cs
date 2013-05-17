using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    public class Person
    {
        private string name;
        private int score;

        public Person()
        {
            this.Name = "Unknown player";
            this.Score = 0;
        }

        public Person(int score)
            : this()
        {
            this.Score = score;
        }

        public Person(string name, int score)
            : this(score)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == string.Empty)
                {
                    this.name = "Unknown player";
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                this.score = value;
            }
        }

        /// <summary>
        /// Implementation of mathematical operator less for Person 
        /// </summary>
        /// <param name="firstPerson">First person</param>
        /// <param name="secondPerson">Second person</param>
        /// <returns>True if the first person is smaller, otherwize false</returns>
        public static bool operator <(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Score < secondPerson.Score;
        }

        /// <summary>
        ///  Implementation of mathematical operator bigger for Person
        /// </summary>
        /// <param name="firstPerson">First person</param>
        /// <param name="secondPerson">Second person</param>
        /// <returns>True if the first person is bigger, otherwize false</returns>
        public static bool operator >(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Score > secondPerson.Score;
        }
    }
}
