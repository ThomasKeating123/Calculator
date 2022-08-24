using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Calculator.Data;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Database database;
        // creates a public UserDatabase class item 
        public static Database Database
        {
            get
            {
                // If the database variable is null then...
                if (database == null)
                {
                    // Sets the database variable to a new UserDatabase with a path
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Answers.db3"));
                }
                // Returns the database
                return database;
            }
        }
    }
}
