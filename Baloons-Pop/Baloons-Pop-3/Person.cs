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
            this.name = string.Empty;
            this.score = 0;
        }

        public Person(int score)
            : this()
        {
            this.score = score;
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
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        public static bool operator <(Person x, Person y)
        {
            return x.Score < y.Score;
        }

        public static bool operator >(Person x, Person y)
        {
            return x.Score > y.Score;
        }
    }
}
