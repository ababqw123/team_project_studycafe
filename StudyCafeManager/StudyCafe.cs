using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace StudyCafeManager
{
    [Serializable]
    class StudyCafe
    {
        private Dictionary<string, Person> users;
        private Dictionary<ISeat, Person> bookStatus;
        private List<ISeat> seat;
        private Admin admin;
        private string select;
        Person person;
        
        public StudyCafe()
        {
            admin = new Admin();
            users = new Dictionary<string, Person>();
            bookStatus = new Dictionary<ISeat, Person>();
            seat = new List<ISeat>();
            Load();
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
            bool start = true;
            string name = null;
            string email = null;
            while (start)
            {
                Console.Clear();
                Console.Write($"이름 : ");
                name = Console.ReadLine();
                Console.Write($"이메일 : ");
                email = Console.ReadLine();
                Check_email(email);
            }
            Console.Write($"password : ");
            string pw = Console.ReadLine();

            users.Add(email, new User(name, email, pw));
            Save_user();
        }

        public bool Check_email(string email)
        {
            Regex regex = new Regex(@"^([0-9a-zA-Z]+){3,}@([0-9a-zA-Z]+){3,}(\.[0-9a-zA-Z]+){1,}$");
            bool check = regex.IsMatch(email);

            if (check != true)
            {
                Console.WriteLine("이메일을 잘못 입력하셨습니다. 다시 입력해주세요");
                return true;
            }
            else return false;

        }
        public void DelUser()
        {
            Console.Clear();
            Console.WriteLine("삭제하실 분의 이메일을 입력해주세요");
            string email = Console.ReadLine();

            users.Remove(email);
            Save_user();
        }
        public void Book()
        {
            // 민성
            Console.Clear();

            // 좌석현황 보여주기 
            ShowAllSeat();

            Console.WriteLine("좌석을 선택해 주세요");

            string input = Console.ReadLine();
            bool select = true;

            while (select)
            {

                if (seat.Exists(x => x.SeatNum == input) && seat[seat.FindIndex(x => x.SeatNum == input)].Status == "예약가능") // 정의해야 함 (예약가능,예약됨,금지)
                {
                    Console.WriteLine("현재 좌석은 예약이 안되었습니다 예약하시겠습니까? 1. 예약하기 2. 뒤로가기");
                    string input2 = Console.ReadLine();

                    if (input2 == "1")
                    {
                        bookStatus.Add(seat[seat.FindIndex(x => x.SeatNum == input)], person);
                    }
                    else if (input2 == "2")
                    {
                        Console.WriteLine(input2 == "2");
                        select = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("1. 예약하기 또는 2. 뒤로가기를 입력해주세요.");
                    }

                    bookStatus.Add(seat[seat.FindIndex(x => x.SeatNum == input)], person);
                    Save_bookstatus();
                }
                else
                {
                    Console.WriteLine("예약 불가능한 좌석입니다");
                }
            }
        }
        public void Change()
        {

        }
        #endregion
        #region<Admin Method>
        public void CheckAllUser()
        {
            Console.Clear();
            Console.Write("전체 회원 현황");

            foreach (var item in users)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void CheckAllBook()
        {

        }
        public void Block()
        {
            Console.Clear();

            ShowAllSeat();
            CheckAllBook();

            Console.WriteLine("금지할 좌석을 선택해 주세요");

            string input = Console.ReadLine();
            bool select = true;

            while (select)
            {

                if (seat.Exists(x => x.SeatNum == input) && seat[seat.FindIndex(x => x.SeatNum == input)].Status == "예약가능") // 정의해야 함 (예약가능,예약됨,금지)
                {
                    Console.WriteLine("현재 좌석을 금지 하시겠습니까? 1. 금지하기 2. 뒤로가기");
                    string input4 = Console.ReadLine();

                    if (input4 == "1")
                    {
                        seat[seat.FindIndex(x => x.SeatNum == input)].Status = "예약금지";
                        Save_seat();
                    }
                    else if (input4 == "2")
                    {
                        Console.WriteLine("관리자 메뉴로 돌아갑니다.");
                        select = false;
                        break;
                    }


                    else
                    {
                        Console.WriteLine("해당 좌석은 금지가 불가능합니다.");
                    }
                    return;
                }
            }
        }
        #endregion
        #region<Common and Private Method>
        private List<ISeat> SeatPosition()
        {
            return null;
        }
        private void Load()
        {
            string user_path = $@"C:\Users\r2com\Desktop\homework\" + $"{DateTime.Now.ToString("yy.MM.dd")}_user.txt";
            string admin_path = $@"C:\Users\r2com\Desktop\homework\admin.txt";
            string bookstatus_path = $@"C:\Users\r2com\Desktop\homework\" + $"{DateTime.Now.ToString("yy.MM.dd")}_bookstatus.txt";
            string seat_path = $@"C:\Users\r2com\Desktop\homework\" + $"{DateTime.Now.ToString("yy.MM.dd")}_seat.txt";

            // user 로드

            if (!File.Exists(user_path))
            {
                using (Stream user_maker = new FileStream(user_path, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                }
            }

            else
            {
                using (Stream user_open = new FileStream(user_path, FileMode.Open))
                {
                    BinaryFormatter user_bf = new BinaryFormatter();

                    users = (Dictionary<string, Person>)user_bf.Deserialize(user_open);
                }
            }


            //admin 로드

            if (!File.Exists(admin_path))
            {
                using (Stream admin_maker = new FileStream(admin_path, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                }
            }

            else
            {
                using (Stream admin_open = new FileStream(admin_path, FileMode.Open))
                {
                    BinaryFormatter admin_bf = new BinaryFormatter();

                    admin = (Admin)admin_bf.Deserialize(admin_open);
                }
            }

            //book_status 로드

            if (!File.Exists(bookstatus_path))
            {
                using (Stream bookstatus_maker = new FileStream(bookstatus_path, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                }
            }

            else
            {
                using (Stream bookstatus_open = new FileStream(bookstatus_path, FileMode.Open))
                {
                    BinaryFormatter bookstatus_bf = new BinaryFormatter();

                    bookStatus = (Dictionary<ISeat, Person>)bookstatus_bf.Deserialize(bookstatus_open);
                }
            }

            //seat 로드
            if (!File.Exists(bookstatus_path))
            {
                using (Stream seat_maker = new FileStream(seat_path, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                }
            }

            else
            {
                using (Stream seat_open = new FileStream(seat_path, FileMode.Open))
                {
                    BinaryFormatter seat_bf = new BinaryFormatter();

                    bookStatus = (Dictionary<ISeat, Person>)seat_bf.Deserialize(seat_open);
                }
            }
        }
        private void Save_user()
        {
            string user_path = $@"C:\Users\r2com\Desktop\homework\" + $"{DateTime.Now.ToString("yy.MM.dd")}_user.txt";

            using (Stream user_save = new FileStream(user_path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(user_save, users);
            }

        }

        private void Save_bookstatus()
        {
            string bookstatus_path = $@"C:\Users\r2com\Desktop\homework\" + $"{DateTime.Now.ToString("yy.MM.dd")}_bookstatus.txt";

            using (Stream bookstatus_save = new FileStream(bookstatus_path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(bookstatus_save, bookStatus);
            }

        }

        private void Save_seat()
        {
            string seat_path = $@"C:\Users\r2com\Desktop\homework\" + $"{DateTime.Now.ToString("yy.MM.dd")}_bookstatus.txt";

            using (Stream seat_save = new FileStream(seat_path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(seat_save, bookStatus);
            }

        }
        private void Notice()
        {
            // 민성
            int count = 0;

            foreach (var item in seat)
            {
                if (item.Status == "예약금지" || item.Status == "예약완료")
                {
                    count++;
                }
            }
            Console.WriteLine($"전체 이용 가능 좌석 수는 :  {seat.Count} , 예약 가능한 좌석 수는 : {seat.Count - count} , 예약 불가능 한 좌석 수는  : {count}");
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
                        return person;
                    }
                }
                Console.WriteLine("아아디, 비밀번호를 잘못 입력했습니다.");
            }
            else
            {
                if (pw == admin.PW)
                {
                    person = admin;
                }
                else
                {
                    Console.WriteLine("아아디, 비밀번호를 잘못 입력했습니다.");
                }
            }
            return person;
        }
        #endregion
    }
}
