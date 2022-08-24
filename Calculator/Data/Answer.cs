using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Calculator.Data
{
    public class Answer
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Number { get; set; }
    }
}
