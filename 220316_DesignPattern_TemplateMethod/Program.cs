using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _220316_DesignPattern_TemplateMethod
{
    // 추상 클래스 선생님
    abstract class Teacher
    {
        public void start_class()
        {
            inside();
            attendance();
            teach();
            outside();
        }
        // 공통 메서드
        public void inside()
        {
            Console.WriteLine("선생님이 강의실로 들어옵니다.");
        }

        public void attendance()
        {
            Console.WriteLine("선생님이 출석을 부릅니다.");
        }

        public void outside()
        {
            Console.WriteLine("선생님이 강의실을 나갑니다.");
        }
        // 추상 메서드
        public abstract void teach();
    }

    // 국어 선생님
    class Korean_Teacher : Teacher
    {        
        public override void teach()
        {
            Console.WriteLine("선생님이 국어를 수업합니다.");
        }
    }
    // 수학 선생님
    class Math_Teacher : Teacher
    {    
        public override void teach()
        {
            Console.WriteLine("선생님이 수학을 수업합니다.");
        }
    }
    //영어 선생님
    class English_Teacher : Teacher
    {
        public override void teach()
        {
            Console.WriteLine("선생님이 영어를 수업합니다.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Korean_Teacher kr = new Korean_Teacher(); //국어
            Math_Teacher mt = new Math_Teacher(); //수학
            English_Teacher en = new English_Teacher(); //영어

            kr.start_class();
            Console.WriteLine("----------------------------");
            mt.start_class();
            Console.WriteLine("----------------------------");
            en.start_class();
        }
    }
}
