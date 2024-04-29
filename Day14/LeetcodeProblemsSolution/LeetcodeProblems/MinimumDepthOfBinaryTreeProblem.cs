using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetcodeProblems
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    internal class MinimumDepthOfBinaryTreeProblem
    {
        public async Task InsertNode(TreeNode root, int data)
        {
            if(root.val!= null)
            {
                if (data < root.val)
                {
                    if (root.left == null)
                        root.left = new TreeNode(data);
                    else
                        await InsertNode(root.left, data);
                }
                else if (data > root.val)
                {
                    if (root.right == null)
                        root.right = new TreeNode(data);
                    else
                        await InsertNode(root.right, data);
                }

            }            
            else
            {
                root.val = data;
            } 
        }

        public async Task<TreeNode> GenerateBinaryTreeAsync(int[] numbers)
        {
            TreeNode root = new TreeNode(numbers[0]);
            for(int i = 1; i < numbers.Length; i++)
            {
                await InsertNode(root, numbers[i]);
            }
            return root;
        }

        public async Task<int> MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            else if(root.left == null && root.right == null){
                return 1;
            }
            else if (root.left == null && root.right != null)
            {
                return await MinDepth(root.right) + 1;
            }
            else if (root.right == null && root.left != null)
            {
                return await MinDepth(root.left) + 1;
            }
            else
            {
                return  Math.Min(await MinDepth(root.left), await MinDepth(root.right)) + 1;
            }
        }

        public static async Task Main(string[] args)
        {
            MinimumDepthOfBinaryTreeProblem minDepth = new MinimumDepthOfBinaryTreeProblem();
            int[] nums = [3, 2,5,4,6];
            TreeNode root = await minDepth.GenerateBinaryTreeAsync(nums);
            int minValue = await minDepth.MinDepth(root);
            Console.WriteLine("Minimum Depth : "+minValue);
        }
    }
}
