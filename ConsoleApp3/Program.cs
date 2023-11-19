using System;
using System.Collections.Generic;

namespace Strategy
{
    public abstract class Bird
    {
        public string Name { get; }
        public MoveStrategy MoveStrategy { get; set; }

        protected Bird(string name, MoveStrategy moveStrategy)
        {
            Name = name;
            MoveStrategy = moveStrategy;
        }

        public void Move()
        {
            Console.Write(Name + " movement: ");
            MoveStrategy.Execute();
        }

        public void SetStrategy(MoveStrategy moveStrategy)
        {
            MoveStrategy = moveStrategy;
        }
    }

    public interface MoveStrategy
    {
        void Execute();
    }

    public class FlyStrategy : MoveStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Flaps its wings and soars through the air!");
        }
    }

    public class SwimStrategy : MoveStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Uses its little feet to propel itself in the water!");
        }
    }

    public class RunStrategy : MoveStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Uses its magnificent legs to walk on the land!");
        }
    }

    public class Sparrow : Bird
    {
        public Sparrow(MoveStrategy moveStrategy) : base("Sparrow", moveStrategy)
        {
        }
    }

    public class Penguin : Bird
    {
        public Penguin(MoveStrategy moveStrategy) : base("Penguin", moveStrategy)
        {
        }
    }

    public class Ostrich : Bird
    {
        public Ostrich(MoveStrategy moveStrategy) : base("Ostrich", moveStrategy)
        {
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create all the different types of birds
            Bird sparrow = new Sparrow(new FlyStrategy());
            Bird penguin = new Penguin(new SwimStrategy());
            Bird ostrich = new Ostrich(new RunStrategy());

            // Initialise the list of birds with default values
            List<Bird> birdList = new List<Bird> { sparrow, penguin, ostrich };

            // Make every bird in the list move
            foreach (Bird bird in birdList)
            {
                bird.Move();
            }

            // Display the capability of changing movement strategy at runtime
            Console.WriteLine("\nLooks like the penguin has reached the shore!");
            penguin.SetStrategy(new RunStrategy());
            penguin.Move();
        }
    }
}

