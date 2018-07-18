using System;
using SQLite;

namespace SafeToBet.Data
{
    public class DatabaseModel
    {
        [PrimaryKey, AutoIncrement]
        //Person Database
        public int id { get; set; }
        public string personUsername { get; set; }
        public string personEmail { get; set; }
        public string personPassword { get; set; }
        public string personPhoneNumber { get; set; }
    }

}