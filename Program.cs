namespace hierarchical_structure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Build the structure from the PDF diagram (depth = 5)
            //
            //  Level 1:              (1) root
            //                        /      \
            //  Level 2:            (2)      (2)
            //                       |      / | \
            //  Level 3:            (3)   (3)(3)(3)
            //                              |
            //  Level 4:                   (4)
            //                              |
            //  Level 5:                   (5)

            Node root = new Node("Root (L1)");

            Node left  = new Node("Left (L2)");
            Node right = new Node("Right (L2)");
            root.AddChild(left);
            root.AddChild(right);

            // Left subtree: one child, dead-ends at level 3
            left.AddChild(new Node("Left-Child (L3)"));

            // Right subtree: three children, middle one goes deeper
            Node rChild1 = new Node("Right-Child-1 (L3)");
            Node rChild2 = new Node("Right-Child-2 (L3)");
            Node rChild3 = new Node("Right-Child-3 (L3)");
            right.AddChild(rChild1);
            right.AddChild(rChild2);
            right.AddChild(rChild3);

            // The deep branch: L3 -> L4 -> L5
            Node level4 = new Node("Deep (L4)");
            rChild2.AddChild(level4);

            Node level5 = new Node("Deepest (L5)");
            level4.AddChild(level5);

            // --- Print the tree ---
            Console.WriteLine("Tree structure:");
            root.Print();

            // --- The main task: calculate depth recursively ---
            Console.WriteLine($"\nDepth of structure: {root.GetDepth()}");

            // --- Bonus: demonstrate Update and Delete ---
            Console.WriteLine("\nUpdating 'Deep (L4)' node:");
            level4.Update("Deep-Updated (L4)");
            root.Print();
            Console.WriteLine($"Depth after update: {root.GetDepth()}");

            Console.WriteLine("\nDeleting 'Deepest (L5)' node:");
            level5.Delete();
            root.Print();
            Console.WriteLine($"Depth after deletion: {root.GetDepth()}");

            Console.ReadLine();
        }

        public class Node
        {
            public string Name { get; set; }
            public List<Node> Children { get; set; }
            public Node? Parent { get; set; }

            public Node(string name)
            {
                Name = name;
                Children = new List<Node>();
            }

            // The main task: recursive depth calculation.
            // Base case: a leaf (no children) has depth 1.
            // Recursive case: depth = 1 + depth of the deepest child.
            public int GetDepth()
            {
                if (Children.Count == 0)
                    return 1;

                int maxChildDepth = 0;
                foreach (var child in Children)
                {
                    int childDepth = child.GetDepth();
                    if (childDepth > maxChildDepth)
                        maxChildDepth = childDepth;
                }
                return 1 + maxChildDepth;
            }

            public void Print(string prefix = "", bool isLast = true)
            {
                Console.Write(prefix);
                if (isLast)
                {
                    Console.Write("└─");
                    prefix += "  ";
                }
                else
                {
                    Console.Write("├─");
                    prefix += "│ ";
                }
                Console.WriteLine(Name);
                for (int i = 0; i < Children.Count; i++)
                {
                    Children[i].Print(prefix, i == Children.Count - 1);
                }
            }

            public void AddChild(Node child)
            {
                Children.Add(child);
                child.Parent = this;
            }

            public void Update(string newName)
            {
                Name = newName;
            }

            public bool Delete()
            {
                if (Children.Count > 0)
                {
                    Console.WriteLine("Node has children, cannot delete.");
                    return false;
                }
                if (Parent != null)
                {
                    Parent.Children.Remove(this);
                    Parent = null;
                }
                return true;
            }
        }
    }
}
