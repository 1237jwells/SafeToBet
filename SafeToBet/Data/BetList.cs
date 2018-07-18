using System;
using SQLite;
using SafeToBet.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace SafeToBet.Data
{
    public class BetList
    {
        //CREATE DATABASE TABLE
        //Call plugin SQLite
        static object locker = new object();
        readonly SQLiteAsyncConnection database;
        //Creates Database
        public BetList(String databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);

            database.CreateTableAsync<BetListModel>().Wait();
        }
        //SAVE DATABASE
        //This function will save data into database
        public int SaveBetIntoDatabase(BetListModel mBetList)
        {
            if (!isUserExists(mBetList.BetName))
            {
                var data = database.InsertAsync(mBetList).Result;
                //Debug.WriteLine("SaveBetIntoDatabase >> " + data.ToString());
                return 1;
            }
            else
            {
                return 0;
            }
        }
        //This functio will delete account from database
        public Task<int> deleteBet(BetListModel mBetList)
        {
            return database.DeleteAsync(mBetList);
        }
        //This function will UPDATE data into database.
        public Task<int> UpdateBetIntoDatabase(BetListModel mBetList)
        {
            return database.UpdateAsync(mBetList);
        }
        //This function will FETCH ALL the person listing.
        public Task<List<BetListModel>> GetBetsListing()
        {
            return database.Table<BetListModel>().ToListAsync();
        } 
        //This function will check if BET EXISTS? or not when creating NEW BET
        public Boolean isUserExists(String strBetId)
        {
            Boolean isExists = false;

            var mData = database.Table<BetListModel>().Where(i => i.BetId.Equals(strBetId))
                                .FirstOrDefaultAsync().Result;
            if (mData != null)
            {
                isExists = true;
            }
            else
            {
                isExists = false;
            }
            return isExists;
        }

        //GET BET DATA
        public Task<BetListModel> getBetData(String strBetName)
        {
            return database.Table<BetListModel>().Where(i => i.BetName.Equals(strBetName)).FirstOrDefaultAsync();
        }
    }
}
