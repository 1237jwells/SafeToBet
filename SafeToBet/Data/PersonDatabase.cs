using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SQLite;

namespace SafeToBet.Data
{
    public class PersonDatabase
    {
        //CREATE DATABASE TABLE
        //Call plugin SQLite
        readonly SQLiteAsyncConnection database;
        //Creates Database
        public PersonDatabase(String databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);

            database.CreateTableAsync<DatabaseModel>().Wait();
            //BetList
        }
        //SAVE DATABASE
        //This function will save data into database
        public int SaveDataIntoDatabase(DatabaseModel mDatabaseModel)
        {
            if (!isUserExists(mDatabaseModel.personUsername))
            {
                var data = database.InsertAsync(mDatabaseModel).Result;
                Debug.WriteLine("SaveDataIntoDatabase >> " + data.ToString());
                return 1;
            }
            else
            {
                return 0;
            }
        }
        //This functio will delete account from database
        public Task<int> deleteAccount(DatabaseModel mDatabaseModel)
        {
            return database.DeleteAsync(mDatabaseModel);

        }
        //This function will UPDATE data into database.
        public Task<int> UpdateDataIntoDatabase(DatabaseModel mDatabaseModel)
        {

            return database.UpdateAsync(mDatabaseModel);
        }
        //This function will FETCH ALL the person listing.
        public Task<List<DatabaseModel>> GetPersonListing()
        {
            return database.Table<DatabaseModel>().ToListAsync();
        }
        //This function will CHECK LOGIN CREDENTIAL from database
        public Boolean isUserAuthenticated(String strUsername, String strPassword)
        {
            Boolean isAuthenticated = false;

            var mDatabaseModel = database.Table<DatabaseModel>().Where(i => i.personUsername == strUsername)
                                         .FirstOrDefaultAsync().Result;
            if (mDatabaseModel != null)
            {
                if (mDatabaseModel.personUsername.Equals(strUsername) && mDatabaseModel.personPassword.ToLower()
                    .Equals(strPassword.ToLower()))
                {
                    isAuthenticated = true;
                }
            }
            return isAuthenticated;
        }
        //This function will check if USER EXISTS? or not when creating NEW USER
        public Boolean isUserExists(String strUsername)
        {
            Boolean isExists = false;

            var mData = database.Table<DatabaseModel>().Where(i => i.personUsername.Equals(strUsername))
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

        //This function will UPDATE THE EMAIL of your account
        public Boolean updateEmail(string strUsername, string strEmail)
        {
            var mData = database.Table<DatabaseModel>().Where(i => i.personUsername.Equals(strUsername))
                                            .FirstOrDefaultAsync().Result;
            if (mData != null)
            {
                DatabaseModel mDatabaseModel = new DatabaseModel();
                mDatabaseModel.id = mData.id;
                mDatabaseModel.personEmail = strEmail;
                mDatabaseModel.personPassword = mData.personPassword;
                mDatabaseModel.personUsername = mData.personUsername;

                database.UpdateAsync(mDatabaseModel);
                return true;
            }
            else
            {
                return false;
            }
        }
        //This function will UPDATE THE PHONENUMBER of your account
        public Boolean updatePhoneNumber(string strUsername, string strPhoneNumber)
        {
            var mData = database.Table<DatabaseModel>().Where(i => i.personUsername.Equals(strUsername))
                                            .FirstOrDefaultAsync().Result;
            if (mData != null)
            {
                DatabaseModel mDatabaseModel = new DatabaseModel();
                mDatabaseModel.id = mData.id;
                mDatabaseModel.personEmail = mData.personEmail;
                mDatabaseModel.personPassword = mData.personPassword;
                mDatabaseModel.personUsername = mData.personUsername;
                mDatabaseModel.personPhoneNumber = strPhoneNumber;

                database.UpdateAsync(mDatabaseModel);
                return true;
            }
            else
            {
                return false;
            }
        }
        //This function will UPDATE THE PASSWORD of your account
        public Boolean updatePassword(string strUsername, string strPassword)
        {
            var mData = database.Table<DatabaseModel>().Where(i => i.personUsername.Equals(strUsername))
                                            .FirstOrDefaultAsync().Result;
            if (mData != null)
            {
                DatabaseModel mDatabaseModel = new DatabaseModel();
                mDatabaseModel.id = mData.id;
                mDatabaseModel.personEmail = mData.personEmail;
                mDatabaseModel.personPassword = strPassword;
                mDatabaseModel.personUsername = mData.personUsername;

                database.UpdateAsync(mDatabaseModel);
                return true;
            }
            else
            {
                return false;
            }
        }
        //GET USER DATA
        //public Task<DatabaseModel> getUserData(String strUsername)
        //{
        //    return database.Table<DatabaseModel>().Where(i => i.personUsername.Equals(strUsername))
        //                                                .FirstOrDefaultAsync();
        //}
        public Task<int> getUserData(String strUsername)
        {
            var mData = database.Table<DatabaseModel>().Where(i => i.personUsername.Equals(strUsername))
                                            .FirstOrDefaultAsync().Result;

                DatabaseModel mDatabaseModel = new DatabaseModel();
                mDatabaseModel.id = mData.id;
                mDatabaseModel.personEmail = mData.personEmail;
                mDatabaseModel.personPassword = mData.personPassword;
                mDatabaseModel.personUsername = mData.personUsername;
                mDatabaseModel.personPhoneNumber = mData.personPhoneNumber;

                return database.UpdateAsync(mDatabaseModel);

        }
    }
}
