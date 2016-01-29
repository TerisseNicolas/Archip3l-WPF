using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace VerticalArchip3l
{
    class ScoreManager
    {
        private List<Tuple<string, int>> scores;
        private int size;

        public ScoreManager()
        {
            this.scores = new List<Tuple<string, int>>();
            this.size = 0;
            loadPreviousScores();
        }
        public void loadPreviousScores()
        {
            string line;
            string path = "C:/tempConcours/scores.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path); // Si le fichier n'existe pas?
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split('@');
                    scores.Add(new Tuple<string, int>(words[0], Int32.Parse(words[1])));
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
        public List<Tuple<string, int>> getBestScores(int limit)
        {
            List<Tuple<string, int>> retour = new List<Tuple<string, int>>();
            int temp = limit;
            foreach(Tuple<string, int> item in this.scores)
            {
                if(temp > 0)
                {
                    retour.Add(item);
                    temp--;
                }
            }
            return retour;  
        }
        public void addScore(string teamName, int value)
        {
            bool flag = false;
            Tuple<string, int> add = new Tuple<string, int>(teamName, value);
            List<Tuple<string, int>> temp = new List<Tuple<string, int>>();
            foreach (Tuple<string, int> item in this.scores)
            {
                if ((item.Item2 <= value) && !flag)
                {
                    flag = true;
                    temp.Add(add);
                    temp.Add(item);
                }
                else
                {
                    temp.Add(item);
                }
            }
            if(!flag)
            {
                temp.Add(add);
            }
            this.scores = temp;
        }
        public void saveScores()
        {
            StreamWriter file = new StreamWriter("C:/tempConcours/scores.txt", false);
            string line;
            foreach (Tuple<string, int> item in this.scores)
            {
                line = item.Item1 + "@" + item.Item2.ToString();
                file.WriteLine(line);
            }
            file.Close();
        }
    }
}
