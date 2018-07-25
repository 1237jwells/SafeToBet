using System;
using System.Collections.Generic;
using SQLite;

namespace SafeToBet.Model
{
    public class BetListModel
    {
        [PrimaryKey, AutoIncrement]
        public int BetId { get; set; }
        public string BetName { get; set; }
        public string BetDate { get; set; }
        public string BetType { get; set; }
        public string BetDescription { get; set; }
        public string BetOpponent { get; set; }
        public string BetAmount { get; set; }
        public List<BetListModel> Items = new List<BetListModel>();

        public BetListModel()
        {
            
        }

    }
}
