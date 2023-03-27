namespace hierarchical_structure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Branch rootBranch = new Branch(1);

            Branch leftBranch = new Branch(2);
            rootBranch.AddChild(leftBranch);

            Branch rightBranch = new Branch(3);
            rootBranch.AddChild(rightBranch);

            Branch thirdDepth1 = new Branch(4);
            leftBranch.AddChild(thirdDepth1);

            Branch thirdDepth2 = new Branch(5);
            rightBranch.AddChild(thirdDepth2);

            Branch thirdDepth3 = new Branch(6);
            rightBranch.AddChild(thirdDepth3);

            Branch thirdDepth4 = new Branch(7);
            rightBranch.AddChild(thirdDepth4);

            Branch fourthDepth1 = new Branch(8);
            thirdDepth2.AddChild(fourthDepth1);

            Branch fourthDepth2 = new Branch(9);
            thirdDepth3.AddChild(fourthDepth2);

            Branch fourthDepth3 = new Branch(10);
            thirdDepth3.AddChild(fourthDepth3);

            Branch fithDepth1 = new Branch(11);
            fourthDepth1.AddChild(fithDepth1);

            rootBranch.PrintBranch();
            Console.ReadLine();
        }

        public class Branch
        {
            public List<Branch> branches { get; set; }
            public int Value { get; set; }

            public Branch(int value)
            {
                Value = value;
                branches = new List<Branch>();
            }

            public void AddChild(Branch child)
            {
                branches.Add(child);
            }
            public void PrintBranch() { 
               foreach (Branch child in branches)
                {
                    Console.WriteLine($"{child.Value}");  
       
                }
            }
        }

    }
}