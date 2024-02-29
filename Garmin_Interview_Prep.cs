//sliding window
//two pointers
//fast and slow pointers
//DFS
//BFS
//Binary search **
//dynamic programming fibonacci



using System;

int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

int currentMinimum = Int32.MaxValue; // We start really high so that any element in the array will be lower than this.

for (int index = 0; index < array.Length; index++)
{
    if (array[index] < currentMinimum)
    {
        currentMinimum = array[index];
    }
}
//find min in a sorted array
int[] nums = new int[] { 3, 4, 5, 6, 7, 1, 2 };
public class Solution
{
    public int FindMin(int[] nums)
    {
        if (nums.Length < 1) return -1;
        if (nums.Length < 2) return nums[0];

        //instantiate variables
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] > nums[right])
            {
                left = mid + 1;
            }

            else
            {
                right = mid;
            }

        }
        return nums[left];
    }

}
//length of longest rfepeating intesubstring
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        int len = s.Length;
        int MaxLength = 0;
        Dictionary<char, int> charIndexMap = new Dictionary<char, int>();
        int left = 0;
        for (int right = 0; right < len; right++)
        {
            char currentChar = s[right];
            if (charIndexMap.ContainsKey(currentChar) && charIndexMap[currentChar] >= left)
            {
                left = charIndexMap[currentChar] + 1;
            }
            charIndexMap[currentChar] = right;
            MaxLength = Math.Max(MaxLength, right - left + 1);
        }
        return MaxLength;
    }
}
//max subarry
public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return 0;
        }
        int MaxSoFar = nums[0];
        int MaxEndingHere = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            MaxEndingHere = Math.Max(nums[i], MaxEndingHere + nums[i]);
            MaxSoFar = Math.Max(MaxSoFar, MaxEndingHere);
        }
        return MaxSoFar;
    }
}
//contains duplicates
public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> seenNumbers = new HashSet<int>();
        foreach (int num in nums)
        {
            if (!seenNumbers.Add(num))
            {
                return true;
            }
        }
        return false; //no duplicates found 
    }
}
//remove duplicates
public class Solution
{
    public static int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0) return 0;
        //first pointer
        int slow = 0;

        for (int fast = 1; fast < nums.Length; fast++)
        {
            if (nums[fast] != nums[slow])
            {
                slow++;
                nums[slow] = nums[fast];
            }
        }
        //return the length
        return slow + 1;
        //
        int[] uniqueArray = new int[slow + 1];
        //create new  array to store unique elements
        Array.Copy(nums,0,uniqueArray,0, slow+1);
        //apply change to original array
        Array.Copy(uniqueArray, nums, slow+1)
    }
}

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0; //base case if tree is empty it  is 0
        }
        else
        {
            int leftDepth = MaxDepth(root.left);
            int rightDepth = MaxDepth(root.right);
            //plus 1 for current node, recursion ends when both left and right are null
            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}
//reversecharacters in string array
public class Solution
{
    public void ReverseString(char[] s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            //swap left and right
            char temp = s[left];
            s[left] = s[right];
            s[right] = temp;
            left++;
            right--;
        }
    }
}

public class Solution
{
    public int NumWaterBottles(int numBottles, int numExchange)
    {
        // numExhange == empty bottles = numBottles
        // drinking full -- empty
        int emptyBottles = numBottles;
        int totalBottles = numBottles;

        while (emptyBottles >= numExchange)
        {
            int newBottles = emptyBottles / numExchange;
            totalBottles += newBottles;
            emptyBottles = (emptyBottles % numExchange) + newBottles;
        }
        return totalBottles;
    }
}

//give maximum amount of water
//height 
public class Solution
{
    public int MaxArea(int[] heights)
    {
        //[5,10,20,40,60]
        int maxArea = 0;
        int left = 0;
        int right = heights.Length - 1;
        //loop through  array
        while (left < right)
        {
            //needs to be minimum since the water will leakj out
            int h = Math.Min(heights[left], heights[right]);
            int w = right - left;
            int currentArea = h * w;
            maxArea = Math.Max(maxArea, currentArea);
            if (heights[left] < heights[right])
            {
                left++;
            }
            else
            {
                right--;
            }

        }
        return maxArea;
    }
}
//amount of water above each block, how much water is pooling in the below
//take the amount of water above each wall, take the max height of left and right
//then take the minimum of how much water  can pool there above each height, subtract height of block
public class Solution
{
    public int Trap(int[] height)
    {
        int[] heights = height;
        if (heights == null || heights.Length == 0)
            return 0;

        int length = heights.Length;
        int waterTrapped = 0;
        //Max height to left and right
        int[] leftMax = new int[length];
        int[] rightMax = new int[length];
        //fill left
        leftMax[0] = heights[0];
        for (int i = 1; i < length; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], heights[i]);
        }
        // fill rightMax
        rightMax[length - 1] = heights[length - 1];
        for (int i = length - 2; i >= 0; i--)
        {
            rightMax[i] = Math.Max(rightMax[i + 1], heights[i]);
        }

        for (int i = 0; i < length; i++)
        {
            waterTrapped += Math.Min(leftMax[i], rightMax[i]) - heights[i];
        }
        return waterTrapped;
    }

}

//min depth of a binary treee
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
//shortest distance to leaf, no right or left nodes 
public class Solution
{
    public int MinDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        if (root.left == null)
        {
            return MinDepth(root.right) + 1;
        }
        if (root.right == null)
        {
            return MinDepth(root.left) + 1;
        }
        return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
    }

}
// find root to leaf path that adds up to target integer, if possible return true
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
//add up values of each tree 
public class Solution
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        // if no root just return false 
        if (root == null)
        {
            return false;
        }
        //if root is also a leaf then check if its value is targetSUm
        if (root.left == null && root.right == null && root.val == targetSum)
        {
            return true;
        }
        //recursively go left and right, sets new target sum to be targetSum- root.val 
        return HasPathSum(root.left, targetSum - root.val) || HasPathSum(root.right, targetSum - root.val);
    }
}

//return preorder traversal of entire node tree
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
//given root, return preorder traversal of node values
public class Solution
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        if (root == null)
        {
            return new List<int>();
        }
        //store result
        //argument is 100 because question said not more than 100
        //more efficient to specify size because it limits reallocations, 
        //copying elements etc
        List<int> result = new List<int>(100);
        result.Add(root.val);
        //traverse left subtree
        result.AddRange(PreorderTraversal(root.left));
        //traverse right subtree
        result.AddRange(PreorderTraversal(root.right));
        return result;
    }
}

public class Solution
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        if (root == null)
        {
            return new List<int>(1);
        }
        List<int> result = new List<int>(100);

        Stack<TreeNode> stack = new Stack<TreeNode>();

        stack.Push(root);
        while (stack.Count > 0)
        {
            TreeNode node = stack.Pop();
            result.Add(node.val);

            if (node.right != null)
            {
                result.Push(node.right.val);
            }
            if (node.left != null)
            {
                result.Push(node.left.val);
            }


        }
        return result; 
    }


//give order from leaf to root:
        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         *         this.val = val;
         *         this.left = left;
         *         this.right = right;
         *     }
         * }
         */
        //give order from leaf to root
public class Solution
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        if (root == null)
        {
            return new List<int>(1);
        }

        List<int> result = new List<int>(100);
        result.AddRange(PostorderTraversal(root.left));
        result.AddRange(PostorderTraversal(root.right));
        result.Add(root.val);
        return result;
    }
}
//do  the above iteratively:
//example is root = 1, left =2, right= 3, left of 3 = 4
List<int> result = new List<int>();
if (root == null)
{
    return result:
}
Stack<TreeNode> stack = new Stack<TreeNode>;
//intial root is pushed onto stack
stack.Push(root);

while (stack.Count > 0)
{
    //pop 1 from the stack
    TreeNode node = stack.Pop();
    //insert the value which was 1 that was just popped
    result.Insert(0, node.val); //insert node value at beginnign of result list
    // result is now [1]
    //important that left is first and then right, so right gets processed before since it is reversed
    if(node.left != null)
    {
        stack.Push(node.left);
    }
    if (node.right != null)
    {
        stack.Push(node.right);
    }
    //stack is now 2 with 3 on top
}
return result;

//given the root of a binary  tree, every level is completely filled except the last
public class Solution
{
    public int CountNodes(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        int leftDepth = GetDepth(root, true);
        int rightDepth = GetDepth(root, false);

        //if left and right are same then its full
        if (leftDepth == rightDepth)
        {
            //biwise shift, take 2 to the leftdepth
            //return (1 << leftDepth) - 1;
            //>> would divide by 2^n
            //return (int)Math.Pow(2,leftDepth)-1
            return (int)Math.Pow(2, leftDepth) - 1; //2^nleftDepth-1
        }
        else
        {
            //if not then count left and right nodes add 1 for root
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }
    }
    private int GetDepth(TreeNode node, bool left)
    {
        int depth = 0;
        while (node != null)
        {
            depth++;
            // if left, node = node.left
            //else node = node.right
            node = left ? node.left : node.right;
        }
        return depth;
    }
}