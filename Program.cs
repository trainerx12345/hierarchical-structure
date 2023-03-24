namespace hierarchical_structure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Branch rootBranch = new Branch(1);

            Branch childBranch1 = new Branch(2);
            rootBranch.AddChild(childBranch1);

            Branch childBranch2 = new Branch(3);
            rootBranch.AddChild(childBranch2);

            Branch grandChildBranch1 = new Branch(4);
            childBranch1.AddChild(grandChildBranch1);

            Branch grandChildBranch2 = new Branch(5);
            childBranch1.AddChild(grandChildBranch2);

            Branch grandChildBranch3 = new Branch(6);
            childBranch2.AddChild(grandChildBranch3);

            Branch grandChildBranch4 = new Branch(7);
            childBranch2.AddChild(grandChildBranch4);

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
        }

    }
}