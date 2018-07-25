using System.Collections.Generic;
using System.Linq;
using SafeToBet.Model;
using SQLite;

namespace Project1.Models
{
    public class List
    {
        //[PrimaryKey, AutoIncrement]
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public decimal Budget { get; set; }
        //[Ignore]
        //public decimal Planned => Items.Sum(item => item.Total);
        //[Ignore]
        //public decimal Remain => Budget - Planned;
        public List<BetListModel> Items = new List<BetListModel>();
    }
}
