using SofthinkCore.UI.Controls.Keyboard.AutoComplete;
using SofthinkCore.UI.Keyboard.AutoComplete;
using SofthinkCore.UI.Keyboard.KeyboardControl;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SofthinkCoreShowCase.Demos.TestKeyboard
{
    /// <summary>
    /// Interaction logic for TestKeyboard.xaml
    /// </summary>
    [SofthinkCoreShowCase.DemoManager.Demo(Name = "Test Keyboard")]
    public partial class TestKeyboard : UserControl
    {
        public TestKeyboard()
        {
            InitializeComponent();

            Loaded += TestKeyboard_Loaded;

            /*SofthinkCore.Utils.Spelling spell = new SofthinkCore.Utils.Spelling();
            var p = spell.GetProposition("att"); 
            foreach (Capture pr in p)
                System.Diagnostics.Debug.Write(pr.Value);*/


            /*SQLiteConnection.CreateFile("C:\\Users\\softhink\\prog\\frdic.sqlite");


            var db = new SQLiteConnection("Data Source=C:\\Users\\softhink\\prog\\frdic.sqlite;Version=3;");
            db.Open();
            SQLiteCommand command = new SQLiteCommand("CREATE TABLE words (id INTEGER PRIMARY KEY AUTOINCREMENT,value VARCHAR(255),freq REAL  );"
            + "CREATE INDEX index_name on words (value,freq);", db);
            command.ExecuteNonQuery();

            var txt = System.Windows.Application.GetResourceStream(SofthinkCore.Utils.UtilsHelper.CreateUri("Resources/Dictionnary/fr_freq.txt", "SofthinkCore"));
            var fileContent = new StreamReader(txt.Stream).ReadToEnd();

            var tr = db.BeginTransaction();

            List<string> wordList = fileContent.Split('\n').ToList();

            foreach (string word in wordList)
            {
                var w = word.Split('\t');
                if (w.Count() != 2)
                    continue;
                SQLiteCommand insert = new SQLiteCommand("insert into words (value,freq) values (@param1,@param2)", db, tr);
                insert.Parameters.Add(new SQLiteParameter("@param1", w[0]));
                insert.Parameters.Add(new SQLiteParameter("@param2", w[1]));
                insert.ExecuteNonQuery();


            }
            tr.Commit();


            SQLiteCommand query = new SQLiteCommand("SELECT value,freq FROM WORDS index_name WHERE VALUE LIKE 'att%' ORDER BY FREQ DESC LIMIT 10", db);
            var reader = query.ExecuteReader();
            while (reader.Read())
                System.Console.WriteLine(reader.GetString(0) + " " + reader.GetFloat(1));*/

        }

      

        void TestKeyboard_Loaded(object sender, RoutedEventArgs e)
        {

            keyboard.Target = text;

            
            

            /*SQLDictionary dic = new SQLDictionary();
            var p = dic.GetProposition("att");
            foreach (object pr in p)
            {
                int i = 0;
            }*/

            /*var txt = System.Windows.Application.GetResourceStream(SofthinkCore.Utils.UtilsHelper.CreateUri("Resources/Dictionnary/fr.txt", "SofthinkCore"));
            var fileContent = new StreamReader(txt.Stream).ReadToEnd();

            SymSpell.CreateDictionary(fileContent, "");
            var lst = SymSpell.Lookup("att","",2);
            foreach (var w in lst)
            {
                int i = 0;
            }

            var db = new SQLiteConnection("foofoo");
            db.CreateTable<Stock>();
            db.CreateTable<Valuation>();*/

            /*LinqDictionary dic = new LinqDictionary();
            var lst = dic.GetProposition("att");
            foreach (string w in lst)
            {
                int i = 0;
            }*/
        }

        public enum CurrentTheme
        {
            Generic,
            IOS
        }

        private CurrentTheme Theme = CurrentTheme.Generic;

        private void TouchButton_ButtonTap(object sender, RoutedEventArgs e)
        {
           Theme++;
           if ((int)Theme > 1)
               Theme = 0;
            if(Theme.Equals(CurrentTheme.Generic))
            {
                var dic = new ResourceDictionary { Source = SofthinkCore.Utils.UtilsHelper.CreateUri("Themes/generic.xaml", "SofthinkCore") };
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dic);
                //keyboard.Style = (Style)dic[typeof(KeyboardControl)];
            }
            else
            {
                var dic =  new ResourceDictionary { Source = SofthinkCore.Utils.UtilsHelper.CreateUri("Themes/IOS.xaml","SofthinkCore") };
                //keyboard.Style = (Style) dic[typeof(KeyboardControl)];
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dic);
            }
           
        }
    }
}
