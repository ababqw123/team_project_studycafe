using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class Program
    {
        enum a { 가위, 바위, 보 };

        static void Main(string[] args)
        {
            Boolean auto = true;
            Boolean auto1 = true;
            Random rnd = new Random();
            int me = 0;
            string me_k;
            string other_k;
            double win = 0;
            double percent = 0;
            int select = 0;
            double score = 0;
            double percent_s = 0;





            while (auto)
            {
                Console.WriteLine("***********************************");
                Console.WriteLine("1. 게임하기  2. 승률보기  3. 종료  ");
                Console.WriteLine("***********************************");
                Console.WriteLine(" ");
                select = Convert.ToInt32(Console.ReadLine());

                auto1 = true;


                if (select == 1)
                {
                    while (auto1)
                    {
                        score += 1;
                        int other = rnd.Next(0, 3);
                        Console.WriteLine("0. 가위  1. 바위  2. 보  3. 종료  ");
                        Console.WriteLine("***********************************");
                        Console.Write("선택 : ");
                        Console.WriteLine(" ");
                        me = Convert.ToInt32(Console.ReadLine());
                        me_k = Enum.GetName(typeof(a), me);
                        other_k = Enum.GetName(typeof(a), other);

                        Console.WriteLine($"나 : {me_k}, 상대 : {other_k}");

                        if (me == other)
                        {
                            Console.WriteLine("비겼습니다. \n");
                        }

                        else
                        {
                            switch (me)
                            {
                                case 0:
                                    if (other == 2)
                                    {
                                        Console.WriteLine("이겼습니다. \n");
                                        win += 1;
                                    }
                                    else Console.WriteLine("졌습니다. \n");
                                    break;
                                case 1:
                                    if (other == 0)
                                    {
                                        Console.WriteLine("이겼습니다. \n");
                                        win += 1;
                                    }
                                    else Console.WriteLine("졌습니다. \n");
                                    break;
                                case 2:
                                    if (other == 1)
                                    {
                                        Console.WriteLine("이겼습니다. \n");
                                        win += 1;
                                    }
                                    else Console.WriteLine("졌습니다. \n");
                                    break;
                                case 3:
                                    auto1 = false;
                                    Console.WriteLine("종료되었습니다. \n");
                                    break;
                                default:
                                    Console.WriteLine("다시 선택해주세요 \n");
                                    break;
                            }
                        }
                    }


                }
                else if (select == 2)
                {
                    if (score == 0)
                    {
                        Console.WriteLine("게임을 하지 않앗습니다.");
                    }
                    else
                        percent_s = Math.Round(percent = (win / score) * 100, 2);
                    { Console.WriteLine($"승리 : {win}, 패배 : {score - win}," + $"승률 : {percent_s}%"); }

                }
                else if (select == 3)
                {
                    auto = false;
                    Console.WriteLine("종료되었습니다.");
                }
                else
                {
                    Console.WriteLine("다른것을 선택해주세요");

                }

                Console.WriteLine("\n \n");
            }
        }
    }
}