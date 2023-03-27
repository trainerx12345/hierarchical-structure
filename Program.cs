namespace hierarchical_structure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node node1 = new Node("Node 1");
            Node node2 = new Node("Node 2");
            Node node3 = new Node("Node 3");
            Node node4 = new Node("Node 4");

            node1.AddChild(node2);
            node2.AddChild(node3);
            node3.AddChild(node4);

            Console.WriteLine("Initial tree:");
            node1.Print();

            Console.WriteLine("\nAdding a child node to Node 2:");
            Node newNode = new Node("New Node");
            node2.AddChild(newNode);
            node2.AddChild(new Node("New Node2"));
            node2.AddChild(new Node("New Node3"));
            node2.AddChild(new Node("New Node4"));
            node3.AddChild(new Node("New Node5"));
            node3.AddChild(new Node("New Node6"));
            node3.AddChild(new Node("New Node7"));
            node1.Print();


            Console.WriteLine("\nUpdating Node 3:");
            node3.Update("Updated Node 3");
            node1.Print();

            Console.WriteLine("\nDeleting Node 4:");
            node4.Delete();
            node1.Print();

            Console.WriteLine("\nDeleting Node 3:");
            node3.Delete();
            node1.Print();

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

            public void Delete()
            {
                if (Children.Count > 0)
                {
                    Console.WriteLine("Node has children, cannot delete.");
                }
                else
                {
                    // Remove the node from its parent's children list
                    if (Parent != null)
                    {
                        Parent.Children.Remove(this);
                    }
                }
            }
        }

    }
}