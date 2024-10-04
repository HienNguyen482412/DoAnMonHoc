using System.Data;

namespace BinaryTree
{
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }
    }
    class MyBinaryTree
    {
        public TreeNode root;
        public void init()
        {
            TreeNode n0 = new TreeNode(0);
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            TreeNode n4 = new TreeNode(4);
            TreeNode n5 = new TreeNode(5);

            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n1.right = n4;
            n2.right = n5;

            root = n0;
        }

    }
    class MyBinarySearchTree
    {
        public TreeNode mroot;
        public TreeNode insert(TreeNode root, int value)
        {
            TreeNode newNode = new TreeNode(value);
            //Dùng vòng lặp
            if (root == null)
            {
                root = new TreeNode(value);
                return root;
            }
            else
            {
                TreeNode temp = root;
                while (true)
                {
                    if (value > temp.val)
                    {
                        if (temp.right == null)
                        {
                            temp.right = newNode;
                            break;
                        }
                        else
                        {
                            temp = temp.right;
                        }
                    }
                    else
                    {
                        if (temp.left == null)
                        {
                            temp.left = newNode;
                            break;
                        }
                        else
                        {
                            temp = temp.left;
                        }

                    }
                }
                return root;
            }

        }
        //Dùng đệ quy
        public TreeNode InsertIntoBST(TreeNode rootNode, int value)
        {
            if (rootNode == null)
            {
                return new TreeNode(value);
            }
            if (value < rootNode.val)
            {
                if (rootNode.left == null)
                {
                    rootNode.left = new TreeNode(value);
                }
                else
                {
                    InsertIntoBST(rootNode.left, value);
                }
            }
            else
            {
                if (rootNode.right == null)
                {
                    rootNode.right = new TreeNode(value);
                }
                else
                {
                    InsertIntoBST(rootNode.right, value);
                }
            }
            return rootNode;
        }
        //Tìm node trái cùng
        public TreeNode findLeftModeNode(TreeNode root)
        {
            if (root == null) return null;
            TreeNode leftMostNode = root;
            while (leftMostNode.left != null)
            {
                leftMostNode = leftMostNode.left;
            }
            return leftMostNode;
        }
        public TreeNode deleteNode(TreeNode root, int key)
        {
            //Bước 1: Tìm node xóa
            if (root == null)
            {
                return null;
            }
            if (key < root.val)
            {
                root.left = deleteNode(root.left, key);
            }
            else if (key > root.val)
            {
                root.right = deleteNode(root.right, key);
            }
            //Bước 2: Xóa node
            else
            {
                //Node lá
                if (root.left == null && root.right == null)
                {
                    return null;
                }
                //Chỉ có 1 node con bên trái
                if (root.left != null && root.right == null)
                    return root.left;
                //Chỉ có 1 node con bên phải
                if (root.left == null && root.right != null)
                    return root.right;
                //Tồn tại 2 con
                TreeNode leftModeNode = findLeftModeNode(root.right);
                root.val = leftModeNode.val;
                root.right = deleteNode(root.right, leftModeNode.val);


            }
            return root;
        }
        public TreeNode searchBST(TreeNode root, int key)
        {
            if (root == null)
            {
                return null;
            }
            if (key < root.val)
            {
                return searchBST(root.left, key);
            }
            else if (key > root.val)
            {
                return searchBST(root.right, key);
            }
            else
            {
                return root;
            }
        }
        public void PreOrder(TreeNode currentNode)
        {
            if (currentNode == null)
            {
                return;
            }
            Console.Write(currentNode.val + " ");
            PreOrder(currentNode.left);
            PreOrder(currentNode.right);
        }
        public void InOrder(TreeNode currentNode)
        {

            if (currentNode == null)
            {
                return;
            }
            InOrder(currentNode.left);
            Console.Write(currentNode.val + " ");
            InOrder(currentNode.right);
        }
        public int maxDepth(TreeNode root)
        {
            if (root == null) return 0;
            int chieuCaoCayBenTrai = maxDepth(root.left);
            int chieuCaoCayBenPhai = maxDepth(root.right);
            int result = Math.Max(chieuCaoCayBenPhai, chieuCaoCayBenTrai) + 1;
            return result;
        }
        public void PostOrder(TreeNode currentNode)
        {
            if (currentNode == null)
            {
                return;
            }
            PostOrder(currentNode.left);
            PostOrder(currentNode.right);
            Console.Write(currentNode.val + " ");

        }
        public bool isLeaf(TreeNode node)
        {
            return node.left == null && node.right == null;
        }
        public bool duyet(TreeNode curNode, int curSum, int targetSum)
        {
            if (curNode == null) return false;
            curSum += curNode.val;
            if (isLeaf(curNode))
            {
                if (curSum == targetSum)
                    return true;

            }

            bool kqBenTrai = duyet(curNode.left, curSum, targetSum);
            bool kqBenPhai = duyet(curNode.right, curSum, targetSum);

            return kqBenTrai || kqBenPhai;
        }
        public bool hasPathSum(TreeNode root, int targetSum)
        {
            return duyet(root, 0, targetSum);
        }
        public static int count = 0;
        public static int sum = 0;
        public static int evenCount = 0;
        public void CountChildNode(TreeNode currentNode)
        {
            if (currentNode == null) return;
            Console.WriteLine(currentNode.val + "có " + (CountNode(currentNode) - 1) + " node con");
            CountChildNode(currentNode.left);
            CountChildNode(currentNode.right);

        }

        
        public int CountNode(TreeNode currentNode)
        {
            if (currentNode == null) return 0;
            else return CountNode(currentNode.left) + CountNode(currentNode.right) + 1;
        }
        public int SumNode(TreeNode currenNode)
        {
            if (currenNode == null) return 0;
            sum += currenNode.val;
            SumNode(currenNode.left);
            SumNode(currenNode.right);
            return sum;
        }
        public int CountEvenNode(TreeNode currenNode)
        {
            if (currenNode == null) return 0;
            if (currenNode.val % 2 == 0)
                evenCount++;
            CountEvenNode(currenNode.left);
            CountEvenNode(currenNode.right);
            return evenCount;
        }
        public void DisplayEvenNode(TreeNode currenNode)
        {
            if (currenNode == null) return;
            if (currenNode.val % 2 == 0)
            {
                Console.Write(currenNode.val + " ");

            }
            DisplayEvenNode(currenNode.left);
            DisplayEvenNode(currenNode.right);
        }
    }
    class Program
    {
        static void Main()
        {
            TreeNode n0 = new TreeNode(0);
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            TreeNode n4 = new TreeNode(4);
            TreeNode n5 = new TreeNode(5);
            TreeNode n6 = new TreeNode(6);
            TreeNode n7 = new TreeNode(7);

            n0.left = n1;
            n1.left = n3;
            n1.right = n4;
            n4.left = n6;
            n4.right = n7;
            n0.right = n2;
            n2.right = n5;
            MyBinarySearchTree myBST = new MyBinarySearchTree();
            myBST.InOrder(n0);
            Console.WriteLine();
            myBST.PostOrder(n0);
            Console.WriteLine(myBST.maxDepth(n0));
            bool a = myBST.hasPathSum(n0, 7);
            int b = myBST.CountEvenNode(n0);
            Console.WriteLine("___________________");
            myBST.CountChildNode(n0);
            Console.WriteLine("Done");
        }
    }
}