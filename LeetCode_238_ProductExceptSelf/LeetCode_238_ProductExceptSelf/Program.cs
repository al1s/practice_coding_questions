using System.Linq;

namespace LeetCode_238_ProductExceptSelf
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var nums = new[] { 1, 2, 3, 4 };
            var res = ProductExceptSelf(nums);
            var expected = SelfCheck(nums);

            nums = new[] { 2, 3, 4, 5 };
            res = ProductExceptSelf(nums);
            expected = SelfCheck(nums);
        }

        /// <summary>
        /// The idea is to calculate two rows - one starting from the left, other - starting from the right with all previous number products except current. Then, fill in resulting array with product of two numbers from both rows. Space - O(n), Time - O(n).
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] ProductExceptSelf(int[] nums)
        {
            var n = nums.Length;
            var productArr = new int[n];
            var left = new int[n];
            var right = new int[n];

            left[0] = 1;
            left[1] = left[0] * nums[0];

            right[n - 1] = 1;
            right[n - 2] = right[n - 1] * nums[n - 1];

            for (int i = 2; i < nums.Length; i++)
            {
                left[i] = left[i - 1] * nums[i - 1];
                right[n - 1 - i] = right[n - 1 - i + 1] * nums[n - 1 - i + 1];
            }
            for (int j = 0; j < n; j++)
            {
                productArr[j] = left[j] * right[j];
            }
            return productArr;
        }

        public static int[] SelfCheck(int[] nums)
        {
            var totalProduct = nums.Aggregate(1, (total, next) => total *= next);
            return nums.ToList().Select(x => totalProduct / x).ToArray();
        }
    }
}