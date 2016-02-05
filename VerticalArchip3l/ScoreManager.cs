using System;
using System.IO;
using System.Collections.Generic;

namespace VerticalArchip3l
{
    class ScoreManager
    {
        private List<Tuple<int, string, int>> scores;
        private int size;

        public ScoreManager()
        {
            this.scores = new List<Tuple<int, string, int>>();
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
        public List<Tuple<int, string, int>> getFinalResult2(string teamName)
        {
            List<Tuple<int, string, int>> retour = new List<Tuple<int, string, int>>();
            //add index in scores list

            //int count = 0;
            //int limit = 9;
            //bool flag = false;
            //int i = 0;
            //int l = this.scores.
            //while ((limit != 0) && (this.scores[i] != null))
            //{
            //    count += 1;
            //    limit -= 1;
            //    if (this.scores[i].Item1 == teamName)
            //    {
            //        flag = true;

            //    }
            //    retour.Add(new Tuple<int, string, int>(count, this.scores[i].Item1, this.scores[i].Item2));
            //    i += 1;
            //}
            //if(flag)
            //{
            //    if(this.scores[i] != null)
            //    {
            //        retour.Add(new Tuple<int, string, int>(count, this.scores[i].Item1, this.scores[i].Item2));
            //    }
            //}
            //else
            //{
            //    while(this.scores[i].Item1 != teamName)
            //    {
            //        i += 1;
            //    }
            //    retour.Add(new Tuple<int, string, int>(count, this.scores[i].Item1, this.scores[i].Item2));
            //}
            //foreach (Tuple<string, int> item in this.scores)
            //{
            //    count += 1;
            //    if(limit == 0)
            //    {
            //        break;
            //    }
            //    if(item.Item1 == teamName)
            //    {
            //        flag = true;
                    
            //    }
            //    retour.Add(new Tuple<int, string, int>(count, item.Item1, item.Item2));
            //    limit -= 1;
            //}
            return retour;
        }
        public void addScore(string teamName, int value)
        {
            bool flag = false;
            int count = 1;
            Tuple<int, string, int> add = new Tuple<int, string, int>(0, teamName, value);
            List<Tuple<int, string, int>> temp = new List<Tuple<int, string, int>>();
            foreach (Tuple<int, string, int> item in this.scores)
            { 
                if ((item.Item3 <= value) && !flag)
                {
                    flag = true;
                    temp.Add(new Tuple<int, string, int>(count, teamName, value));
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
                temp.Add(new Tuple<int, string, int>(count, teamName, value));
            }
            this.scores = temp;
        }
        //public void addScore2(string teamName, int value)
        //{
        //    bool flag = false;
        //    Tuple<string, int> add = new Tuple<string, int>(teamName, value);
        //    List<Tuple<string, int>> temp = new List<Tuple<string, int>>();
        //    foreach (Tuple<string, int> item in this.scores)
        //    {
        //        if ((item.Item2 <= value) && !flag)
        //        {
        //            flag = true;
        //            temp.Add(add);
        //            temp.Add(item);
        //        }
        //        else
        //        {
        //            temp.Add(item);
        //        }
        //    }
        //    if(!flag)
        //    {
        //        temp.Add(add);
        //    }
        //    this.scores = temp;
        //}
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
        public void debug()
        {
            foreach (Tuple<int, string, int> item in this.scores)
            {
                Console.WriteLine(item);
            }
        }
    }
}
