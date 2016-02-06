using System;
using System.IO;
using System.Collections.Generic;

namespace VerticalArchip3l
{
    class ScoreManager
    {
        private List<Tuple<int, string, int>> scores;
        private int size;
        public int Score { get; private set; }
        public event EventHandler<ScoreUpdateEventArgs> ScoreUpdate;

        public ScoreManager()
        {
            this.scores = new List<Tuple<int, string, int>>();
            this.size = 0;
            loadPreviousScores();
        }
        public void increaseScore(int add)
        {
            this.Score += add;
            if(this.ScoreUpdate != null)
            {
                this.ScoreUpdate(this, new ScoreUpdateEventArgs { newScore = this.Score });
            }
        }
        public void loadPreviousScores()
        {
            string line;
            string path = "C:/tempConcours/scores.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split('@');
                    scores.Add(new Tuple<int, string, int>(Int32.Parse(words[0]), words[1], Int32.Parse(words[2])));
                    this.size++;
                }
                file.Close();
            }
            else
            {
                StreamWriter file = new StreamWriter("C:/tempConcours/scores.txt");
                file.Close();
            }
        }
        public List<Tuple<int, string, int>> getBestScores(int limit)
        {
            List<Tuple<int, string, int>> retour = new List<Tuple<int, string, int>>();
            int temp = limit;
            foreach(Tuple<int, string, int> item in this.scores)
            {
                if(temp > 0)
                {
                    retour.Add(item);
                    temp--;
                }
            }
            return retour;  
        }
        public List<Tuple<int, string, int>> getFinalResult(string teamName)
        {
            int count = 0;
            int limit = 10;
            bool flag = false;
            List<Tuple<int, string, int>> final = new List<Tuple<int, string, int>>();
            foreach(Tuple<int, string, int> item in this.scores)
            {
                if(count == limit)
                {
                    break;
                }
                if(item.Item2 == teamName)
                {
                    flag = true;
                }
                if((count == limit - 1) && !flag)
                {
                    continue;
                }
                else
                {
                    final.Add(item);
                    count += 1;
                }
            }
            return final;
        }
        public void addScore(string teamName)
        {
            bool flag = false;
            int count = 1;
            Tuple<int, string, int> add = new Tuple<int, string, int>(0, teamName, this.Score);
            List<Tuple<int, string, int>> temp = new List<Tuple<int, string, int>>();
            foreach (Tuple<int, string, int> item in this.scores)
            { 
                if ((item.Item3 <= this.Score) && !flag)
                {
                    flag = true;
                    temp.Add(new Tuple<int, string, int>(count, teamName, this.Score));
                    count += 1;
                    temp.Add(new Tuple<int, string, int>(count, item.Item2, item.Item3));
                }
                else
                {
                    temp.Add(new Tuple<int, string, int>(count, item.Item2, item.Item3));
                }
                count += 1;
            }
            if (!flag)
            {
                temp.Add(new Tuple<int, string, int>(count, teamName, this.Score));
            }
            this.scores = temp;
        }
        public void saveScores()
        {
            StreamWriter file = new StreamWriter("C:/tempConcours/scores.txt", false);
            string line;
            foreach (Tuple<int, string, int> item in this.scores)
            {
                line = item.Item1.ToString() + "@" + item.Item2 + "@" + item.Item3.ToString();
                file.WriteLine(line);
            }
            file.Close();
        }
    }
    public class ScoreUpdateEventArgs : EventArgs
    {
        public int newScore;
    }
}
