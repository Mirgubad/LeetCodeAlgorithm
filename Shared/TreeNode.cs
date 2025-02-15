using System.Collections;

namespace Shared;
public class TreeNode : IEnumerable
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

    public IEnumerator GetEnumerator()
    {
        while (true)
        {
            yield return val;
            if (left != null)
            {
                foreach (var item in left)
                {
                    yield return item;
                }
            }
            if (right != null)
            {
                foreach (var item in right)
                {
                    yield return item;
                }
            }
            yield break;
        }
    }
}
