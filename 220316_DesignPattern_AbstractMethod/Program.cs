using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _220316_DesignPattern_AbstractMethod
{
    #region 추상 팩토리 설정

    abstract class Race
    {
        public abstract MaincenterBuilding CreateMaincenterBuilding();
        public abstract PopulationBuilding CreatePopulationBuilding();
    }


    class Terran : Race
    {
        public override MaincenterBuilding CreateMaincenterBuilding()
        {
            return new CommandCenter();
        }
        public override PopulationBuilding CreatePopulationBuilding()
        {
            return new SupplyDepot();
        }

    }

    class Protoss : Race
    {
        public override MaincenterBuilding CreateMaincenterBuilding()
        {
            return new Nexus();
        }
        public override PopulationBuilding CreatePopulationBuilding()
        {
            return new Pylon();
        }
    }

    #endregion

    #region 추상 Product 클래스 생성

    abstract class MaincenterBuilding
    {
    }

    abstract class PopulationBuilding
    {
        public abstract void Interact(MaincenterBuilding a);
    }

    #endregion

    #region Product 클래스 생성

    class CommandCenter : MaincenterBuilding
    {
    }

    class SupplyDepot : PopulationBuilding
    {
        public override void Interact(MaincenterBuilding a)
        {
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }

    class Nexus : MaincenterBuilding
    {
    }

    class Pylon : PopulationBuilding
    {
        public override void Interact(MaincenterBuilding a)
        {
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }

    #endregion


    class Game
    {
        private MaincenterBuilding _maincenterBuilding;
        private PopulationBuilding _populationBuilding;


        public Game(Race _race)
        {
            _maincenterBuilding = _race.CreateMaincenterBuilding();
            _populationBuilding = _race.CreatePopulationBuilding();
        }

        public void Show()
        {
            _populationBuilding.Interact(_maincenterBuilding);
        }
    }
    class Program
    {
        static void Main(string[] args) {

            Race _race1 = new Terran();
            Game _game1 = new Game(_race1);
            _game1.Show();

            Race _race2 = new Protoss();
            Game _game2 = new Game(_race2);
            _game2.Show();

            Console.ReadKey();


        }
    }

}
