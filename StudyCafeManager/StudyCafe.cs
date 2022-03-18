using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace StudyCafeManager
{
    [Serializable]
    class StudyCafe
    {
        private Dictionary<string, User> users;
        private Dictionary<ISeat, User> BookStatus;
        private List<ISeat> seat;
        private Admin admin;
        private int select;
        Person person;
        
        public StudyCafe()
        {
            
        }

        #region<Menu part>
        public void Menu()
        {

        }

        public void MainMenu(Person person)
        {
           
        }
        #endregion
        #region<User Method>
        public void AddUser()
        {

        }
        public void DelUser()
        {

        }
        public void Book()
        {

        }
        public void Change()
        {

        }
        #endregion
        #region<Admin Method>
        public void CheckAllUser()
        {

        }
        public void CheckAllBook()
        {

        }
        public void Block()
        {

        }
        #endregion
        #region<Common and Private Method>
        private List<ISeat> SeatPosition()
        {
            return null;
        }
        private void Load()
        {

        }
        private void Save()
        {

        }
        private void Notice()
        {

        }
        private void ShowAllSeat()
        {

        }
        public Person login()
        {
            string id = null;
            string pw = null;
            if (id == "admin")
            {
                if (pw == admin.PW)
                {
                    person = admin;
                    return person;
                }
                else
                {
                    Console.WriteLine("꺼져");
                }
            }
            else
            {
                foreach (var item in users)
                {
                    if (true)
                    {

                    }
                }
            }
            return person;
        }
        #endregion
    }
}
