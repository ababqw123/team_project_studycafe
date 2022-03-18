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
        private Dictionary<ISeat, User> bookStatus;
        private List<ISeat> seat;
        private Admin admin;
        private string select;
        Person person;
        
        public StudyCafe()
        {
            admin = new Admin();
        }

        #region<Menu part>
        public void Menu()
        {           
            bool Menu = true;
            while (Menu)
            {
                Console.Clear();
                Console.WriteLine("**********************************************");
                Console.WriteLine("**********************************************");
                Console.WriteLine("*             Ecount Study Lounge            *");
                Console.WriteLine("**********************************************");
                Console.WriteLine("**********************************************");
                Console.WriteLine("*1. 로그인         2. 가입          3. 종료     *");
                Console.WriteLine("**********************************************");
                Notice();
                Console.WriteLine();
                Console.Write("원하시는 메뉴를 선택해주세요. : ");
                select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        login();
                        break;
                    case "2":
                        AddUser();
                        break;
                    case "3":
                        Menu = false;
                        break;
                    default:
                        Console.WriteLine("1,2,3만 입력해주세요. 엔터를 누르면 돌아갑니다.");
                        Console.ReadLine();                        
                        break;
                }
            }          
        }

        public void MainMenu(Person person)
        {
            string loginType = Convert.ToString(person.GetType());
            if (loginType == "Admin")
            {
                Console.WriteLine("******************************************************");
                Console.WriteLine("*                      관리자 모드                     *");
                Console.WriteLine("******************************************************");
                Console.WriteLine("*1. 회원조회  2. 예약현황  3. 예약금지 관리  4. 돌아가기    *");
                Console.WriteLine("******************************************************");
                Console.Write("원하시는 메뉴를 선택해주세요. : ");
                select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        CheckAllUser();
                        break;
                    case "2":
                        CheckAllBook();
                        break;
                    case "3":
                        Block();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("1,2,3,4만 입력해주세요. 엔터를 누르면 돌아갑니다.");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine("******************************************************");
                Console.WriteLine("*                Ecount Study Lounge                 *");
                Console.WriteLine("******************************************************");
                Console.WriteLine("*1. 회원조회  2. 예약현황  3. 예약금지 관리  4. 돌아가기    *");
                Console.WriteLine("******************************************************");
                Console.Write("원하시는 메뉴를 선택해주세요. : ");
                select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        CheckAllUser();
                        break;
                    case "2":
                        CheckAllBook();
                        break;
                    case "3":
                        Block();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("1,2,3만 입력해주세요. 엔터를 누르면 돌아갑니다.");
                        Console.ReadLine();
                        break;
                }
            }
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
            Console.Clear();
            Console.Write("이메일 주소를 입력해주세요. : ");
            string email = Console.ReadLine();
            Console.Write("비밀번호를 입력해주세요. : ");
            string pw = Console.ReadLine();

            if (email != "admin")
            {
                foreach (User item in users.Values)
                {
                    if (item.Email == email && item.PW == pw)
                    {
                        person = item;
                    }
                }
            }
            else
            {
                if (pw == admin.PW)
                {
                    person = admin;
                }
            }
            return person;
        }
        #endregion
    }
}
