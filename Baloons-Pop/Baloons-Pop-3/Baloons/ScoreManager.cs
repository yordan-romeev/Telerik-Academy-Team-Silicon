using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BalloonsPops
{
    public class ScoreManager
    {
        public const int MAX_TOP_SCORE_COUNT = 5;
        private List<Person> topScoreList;
        private const string PATH = @"..\..\TopScore.txt";

        public ScoreManager()
        {
            this.topScoreList = new List<Person>();
        }

        public bool IsTopScore(Person person)
        {
            if (this.topScoreList.Count >= MAX_TOP_SCORE_COUNT)
            {
                PersonScoreComparer comparer = new PersonScoreComparer();
                this.topScoreList.Sort(comparer);
                if (this.topScoreList[MAX_TOP_SCORE_COUNT - 1] > person || this.topScoreList[MAX_TOP_SCORE_COUNT - 1] == person)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public void AddToTopScoreList(Person person)
        {
            this.topScoreList.Add(person);
            PersonScoreComparer comparer = new PersonScoreComparer();
            this.topScoreList.Sort(comparer);
            while (this.topScoreList.Count > MAX_TOP_SCORE_COUNT)
            {
                this.topScoreList.RemoveAt(MAX_TOP_SCORE_COUNT);
            }
        }

        public void LoadTopScoreList()
        {
            using (StreamReader topScoreStreamReader = new StreamReader(PATH))
            {
                string line = topScoreStreamReader.ReadLine();
                while (line != null)
                {
                    char[] separators = { ' ' };
                    string[] substrings = line.Split(separators);
                    int substringsCount = substrings.Count<string>();
                    if (substringsCount > 0)
                    {
                        string playerName = substrings[1];
                        int playerScore = int.Parse(substrings[substringsCount - 2]);
                        Person player = new Person(playerName, playerScore);
                        this.topScoreList.Add(player);
                    }

                    line = topScoreStreamReader.ReadLine();
                }
            }
        }

        public void SaveTopScoreList()
        {
            if (this.topScoreList.Count > 0)
            {
                string toWrite = string.Empty;
                using (StreamWriter topScoreStreamWriter = new StreamWriter(PATH, false))
                {
                    for (int i = 0; i < this.topScoreList.Count; i++)
                    {
                        toWrite += i.ToString() + ". " + this.topScoreList[i].Name + " --> " + this.topScoreList[i].Score.ToString() + " moves";
                        topScoreStreamWriter.WriteLine(toWrite);
                        toWrite = string.Empty;
                    }
                }
            }
        }

        public void PrintScoreList()
        {
            Console.WriteLine("Scoreboard:");
            if (this.topScoreList.Count > 0)
            {
                for (int i = 0; i < this.topScoreList.Count; i++)
                {
                    Console.WriteLine(i.ToString() + ". " + this.topScoreList[i].Name + " --> " + this.topScoreList[i].Score.ToString() + "moves");
                }
            }
            else
            {
                Console.WriteLine("Scoreboard is empty");
            }
        }
    }
}
