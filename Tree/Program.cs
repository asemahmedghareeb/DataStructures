namespace tree
{ 

    class program{

        static void Main()
        {
            node root = new node(1); 
            node node2 = new node(2); 
            node node3 = new node(3); 
            node node4= new node(4); 
            node node5 = new node(5);
            node node6 = new node(6);
            node node7 = new node(7);
            node node8 = new node(8);
            root.left = node2;
            root.right = node3;
            node2.left = node4;
            node2.right = node5;
            node5.right = node7;
            node3.right = node6;
            node6.left = node8;
            inorder(root);
            Console.WriteLine("\n");
            postorder(root);
            Console.WriteLine("\n");
            preorder(root);
        }
        static void inorder(node root)
        {
            if (root == null)
                return;

            inorder(root.left);
            Console.Write(root.data +" ");
            inorder(root.right);


        }  
        static void preorder(node root)
        {
            if (root==null)
                return;

            Console.Write(root.data +" ");
            preorder(root.left);
            preorder(root.right);


        }  

        static void postorder(node root)
        {
            if (root == null)
                return;

            postorder(root.left);
            postorder(root.right);
            Console.Write(root.data +" ");


        }
    }
     
    class node
    {
        public int data;
        public node right;
        public node left;

        public node(int data)
        {
            this.data = data;
        }
    }
    //strict binary tree is the tree which has 0 or 2 children


}