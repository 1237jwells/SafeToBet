using System;
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
    }
}
