using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _220302_homework_array_
{
    class Program
    {
        static void Main(string[] args)
        {
            // 가위바위보 프로그램 만들기

            bool game = true;           // 가위 바위 보 게임 굴릴 while 문 안에 사용
            int wincount = 0;           // 이긴 수 세기
            int losecount = 0;          // 진 수 세기
            while (game)
            {
                Console.Clear();
                Console.WriteLine("***********************************");
                Console.WriteLine("1. 게임하기  2. 승률보기  3. 종료  ");
                Console.WriteLine("***********************************");

                Console.Write("메뉴를 선택해주세요. : ");
                int choice = Convert.ToInt32(Console.ReadLine());            // 메뉴 선택을 입력받아서 진행


                switch (choice)
                {
                    case 1:
                        string[] select = new string[] { "가위", "바위", "보" };           // 가위 바위 보를 배열로 묶어서 사용
                        Console.WriteLine("무엇을 내시겠습니까? 1.가위 2.바위 3.보 4. 돌아가기");
                        int playerChoice = Convert.ToInt32(Console.ReadLine());            // 플레이어 입력으로 가위바위보 및 돌아가기 선택
                        string player;                                                     // 플레이어가 고른 가위바위보 저장

                        Random random = new Random();                                      // 컴퓨터 가위 바위 보 랜덤 선택용
                        int comChoice = random.Next(0, 2);                                 // 컴퓨터는 랜덤하게 선택
                        string com = select[comChoice];                                    // 위 숫자를 이용해서 컴터가 가위바위보 고름
                        if (playerChoice > 4)
                        {
                            Console.WriteLine("1 ~ 4까지의 숫자만 입력 가능합니다.");
                            goto case 1;
                        }
                        else if (playerChoice == 4)
                        {
                            Console.Write("메인메뉴로 돌아갑니다. enter를 입력해주세요");
                            Console.ReadLine();
                            break;
                        }
                        else if (playerChoice == 1) { player = select[0]; }          // 가위 선택
                        else if (playerChoice == 2) { player = select[1]; }          // 바위 선택
                        else { player = select[2]; }                              // 보 선택

                        void result(string Player, string COM)
                        {
                            string resultmsg;                   // 결과에 따라 바뀌는 메세지 변수
                            Console.WriteLine($"플레이어 : {Player}, 컴퓨터 : {COM}");
                            if (Player == COM)
                            {
                                resultmsg = "비겼습니다.";
                            }
                            // 플레이어가 지는 경우
                            else if ((Player == select[0] && COM == select[1]) || (Player == select[1] && COM == select[2]) || (Player == select[2] && COM == select[0]))
                            {
                                resultmsg = "졌습니다.";
                                losecount = losecount + 1;      // 진 수 더해주기
                            }
                            // 플레이어가 이기는 경우
                            else
                            {
                                resultmsg = "이겼습니다";
                                wincount = wincount + 1;        // 이긴 수 더해주기
                            }
                            Console.WriteLine($"{resultmsg} 메인으로 돌아갑니다 enter를 눌려주세요.");
                            Console.ReadLine();
                        }
                        result(player, com);
                        break;

                    case 2:
                        int wholegames = wincount + losecount;          // 전체 게임 횟수 계산
                        double winrate;                                 // 승률 담을 double 변수
                        if (wincount == 0)
                        {
                            winrate = 0;
                        }
                        else
                        {
                            winrate = (double)wincount / (double)wholegames;
                            winrate = Math.Round(winrate, 2);
                        }
                        Console.WriteLine($"총 게임 횟수 : {wholegames}, 이긴 횟수 : {wincount}, 진 횟수 : {losecount}, 승률 : {winrate * 100}% 입니다. 메인으로 돌아갑니다 enter를 눌려주세요.");
                        Console.ReadLine();
                        break;
                    case 3:
                        game = false;
                        Console.WriteLine("프로그램을 종료합니다.");
                        break;
                    default:
                        Console.WriteLine("1~3 의 숫자중에 입력해주세요. enter를 입력하면 메인으로 돌아갑니다.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
