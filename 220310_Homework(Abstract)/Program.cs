using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _220310_Homework_Abstract_
{
    /*

 요구사항

 카트 (Cart)

 카트에는 매장에 있는 모든 전자제품을 담을 수 있다 

 카트의 크기는 고정되어 있다 (10개) : 1개 , 2개 담을 수 있고 최대 10개까지 담을 수 있다

 고객이 물건을 구매 하면 ... 카트에 담는다

 ​

 계산대에 가면 전체 계산

 계산기능이 필요

 summary() 기능 추가해 주세요

 당신이 구매한 물건이름 과 가격정보 나열

 총 누적금액 계산 출력

 ​

 hint) 카트 물건을 담는 행위 (Buy() 함수안에서 cart 담는 것을 구현 )

 hint) Buyer ..>> summary() main 함수에서 계산할때

 ​

 구매자는 default 금액을 가지고 있고 초기금액을 설정할 수 도 있다

 */
    class Product : Object
    {
        public int price;
        public int bonuspoint;
        public Product() { }
        public Product(int price)
        {
            this.price = price;
            this.bonuspoint = (int)(this.price / 10.0);
        }
    }

    class KtTv : Product
    {
        public KtTv() : base(500)  //상위 생성자를 호출하는  base
        {

        }

        public override string ToString()  //Object 가지는 public virtual 자원 
        {
            return "KtTv";
        }

    }


    class Audio : Product
    {
        public Audio() : base(100)
        {

        }

        public override string ToString()
        {
            return "Audio";
        }
    }


    class NoteBook : Product
    {
        public NoteBook() : base(150)
        {

        }

        public override string ToString()
        {
            return "NoteBook";
        }
    }

    //구매자
    class Buyer
    {
        private int money;
        private int bonuspoint;
        Product[] cart;

        public Buyer() : this(1000)
        {

        }
        public Buyer(int money)
        {
            this.money = money;
        }

        //hint)
        //오버로딩 개념
        //다형성 개념


        //모든 전자제품의 부모는  Product  (다형성)
        //Product product = new Audio();
        //Product product = new KtTv();
        //Product product = new NoteBook();
        //단 product 는 자신의 자원 볼 수 있다 (

        public void Buy(Product[] n)
        {  //함수가 제품 객체의 주소를  parameter  받아서 가격 ,포인트
            // 만약 제품을 배열에 추가하지 않고 함수에 넣을 경우 돌아가기
            if (n.Length == 0)
            {
                Console.WriteLine("카트에 제품이 없습니다.");
                return;
            }
            // 상품을 여러 종류를 구매해서 저장할 수 있게 배열로 받음.
            cart = n;
            // cart에 담긴 제품 전체 가격의 합에 사용할 변수 선언
            int p_sum = 0;
            foreach (Product item in cart)
            {
                p_sum += item.price;
            }
            summary(p_sum);
        }
        private void summary(int p_sum)
        {
            if (this.money < p_sum)
            {
                Console.WriteLine("고객님 잔액이 부족합니다 ^^! " + this.money);
                return; //함수 종료  (구매행위 종료)
            }
            //실 구매 행위
            this.money -= p_sum; //잔액
            // 포인트 누적 및 구매한 제품명 나열
            string productList = null;
            foreach (Product item in cart)
            {
                this.bonuspoint += item.bonuspoint;
                productList += $"{item.ToString()}, ";
            }
            Console.WriteLine($"구매한 물건은 : {productList.ToString()}");
            Console.WriteLine($"잔액은 : {this.money} 입니다.");
            Console.WriteLine($"포인트는 : {this.bonuspoint} 입니다.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 매장 제품 3개 배치
            KtTv tv = new KtTv();
            Audio audio = new Audio();
            NoteBook notebook = new NoteBook();


            // 고객생성 가진돈 기본값할건지 입력 받을건지
            Buyer buyer;
            Console.Write("현재 고객이 가진 돈 수를 입력하세요. 미입력시 기본값은 1000 입니다.");
            string inputMoney = Console.ReadLine();
            int money = inputMoney.Length == 0 ? 0 : Convert.ToInt32(inputMoney);
            if (money == 0)
            {
                buyer = new Buyer();
            }
            else
            {
                buyer = new Buyer(money);
            }
            // 고객 카트 객체배열 생성 최대 10개, 여기서는 예시로 notebook 4개 audio 2개 TV 1개를 사본다
            Product[] cart = new Product[] { notebook, notebook, audio, audio, tv };
            if (cart.Length > 10) // 10개가 넘어가면 바로 return !
            {
                Console.WriteLine("제품을 더 이상 담을 수 없습니다.");
                cart = null;
                return;
            }
            // buy 함수 실행, parameter로 생성해둔 제품 객체를 최대 10개까지 넣는다 
            buyer.Buy(cart);
        }
    }
}
