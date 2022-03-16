using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _220304_ArrayCinema
{
    class Cinema
    {
        string[,] seat = new string[4,5];       // 좌석 배열
        int resultcode = 0;                     // 메인에 결과코드 보낼새기

        public Cinema()
        {
            for (int i = 0; i < seat.GetLength(0); i++)
            {
                for (int j = 0; j < seat.GetLength(1); j++)
                {
                    seat[i, j] = $"[{i}-{j}]";          //[0-0]
                }
            }
        }
        public void seatStatus()        // 좌석 배치도 띄우기
        {
            for (int i = 0; i < seat.GetLength(0); i++)
            {
                for (int j = 0; j < seat.GetLength(1); j++)
                {
                    // 좌석이 예매가 아니면 !
                    Console.Write(seat[i, j] == $"[{i}-{j}]" ? $"[{i}-{j}]" : "[예매]");
                }
                Console.WriteLine();
            }
        }
        public int booking(string input)           // 좌석 예약하기
        {
            int i = Convert.ToInt32(input.Substring(0,1));
            int j = Convert.ToInt32(input.Substring(2, 1));     ///  
            input = $"[{input}]";
            if (input == seat[i,j])
            {
                seat[i, j] = "[예매]";
                Console.WriteLine("예약이 완료되었습니다.");
                Console.WriteLine($"예약한 좌석은 {input} 입니다");
                
                resultcode = 0;
            }
            else if(seat[i,j] == "[예매]")
            {
                Console.WriteLine("이미 예매완료된 좌석입니다. 메인으로 돌아갑니다.");
                resultcode = 0;
            }
            return resultcode;
        }
        public int inquire(string input)           // 예약 조회하기
        {
            string bookingInput = input;
            int i = Convert.ToInt32(input.Substring(0, 1));
            int j = Convert.ToInt32(input.Substring(2, 1));
            input = $"[{input}]";
            if (seat[i, j] != "[예매]")
            {
                Console.WriteLine("현재 좌석은 예약이 안되었습니다 예약하시겠습니까? 1. 예약하기 2. 뒤로가기");
                int select = Convert.ToInt32(Console.ReadLine());
                if (select == 1)
                {
                    
                    booking(bookingInput);
                    resultcode = 0;
                }
                else if(select == 2)
                {
                    resultcode = 0;
                    return resultcode;
                }
                else
                {
                    Console.WriteLine("잘못입력하셨습니다. 1과 2만 입력가능합니다.");
                    resultcode = 1;
                }
                                              
            }
            else
            {
                Console.WriteLine("예매완료된 좌석입니다. 메인으로 돌아갑니다.");
                resultcode = 0; ;
            }
            return resultcode;
        }
        public void Cancle()
        {
            string booking;
            int select;
            Console.WriteLine("예매번호를 입력해주세요");
            booking = Console.ReadLine();

            Console.WriteLine($"고객님이 예매하신 좌석은 {booking} 입니다. \n");

            string booking_num_10 = booking.Substring(0, 1);
            string booking_num_1 = booking.Substring(2, 1);
            int low = Convert.ToInt32(booking_num_10);
            int col = Convert.ToInt32(booking_num_1);
            Console.WriteLine($"{low}, {col}");
            if (seat[low, col] == "[예매]")
            {
                Console.WriteLine(@"예매를 취소하시겠습니까?
 네(1), 아니오(2) 중 하나를 입력해주세요.");
                select = Convert.ToInt32(Console.ReadLine());
                if (select == 1)
                {
                    seat[low, col] = $"[{low}-{col}]";
                    Console.WriteLine("예약 취소가 완료되었습니다.");
                }
                if (select == 2)
                    Console.WriteLine("예매 취소를 하지 않겠습니다.\n");
            }
            else Console.WriteLine("예매 번호를 확인해주세요");
        }
        public void mainmenu()
        {
            int select = 0;
            bool auto = true;
            while (auto)
            {

                Console.WriteLine("**************************");
                Console.WriteLine("*****영화 예매 시스템*****");
                Console.WriteLine("**************************");
                Console.WriteLine("1. 예매하기 \n \n");
                Console.WriteLine("2. 예매조회 \n \n");
                Console.WriteLine("3. 예매취소 \n \n");

                select = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                switch (select)
                {
                    case 1:

                        Console.WriteLine("좌석을 선택해주세요  예) 1-1");
                        Console.WriteLine("이미 예매된 자석은 예매라고 표시됩니다.");
                        string input = Console.ReadLine();
                        int result1 = booking(input);
                        if (result1 == 0)
                        {
                            break;
                        }
                        else
                        {
                            goto case 1;
                        }

                    case 2:
                        seatStatus();
                        Console.WriteLine("예매하신 좌석을 입력해주세요. 예) 1-1");
                        string seat = Console.ReadLine();
                        int result2 = inquire(seat);
                        if (result2 == 0)
                        {
                            break;
                        }
                        else
                        {
                            goto case 2;
                        }
                    case 3:
                        Cancle();
                        break;
                    default:
                        auto = false;
                        break;
                }

            }
        }
    }
}
