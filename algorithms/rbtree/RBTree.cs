namespace RBTree;

// Red-black property:
// 1. All nodes are either red or blue
// 2. All leaves are black
// 3. A red node's both children are black
// 4. For any two paths from the root to leaf, the number of red and black nodes are equal.

public enum NodeColor
{
    Black,
    Red
};

public class RBTreeNode<T> where T : IComparable<T>
{
    public T Value { get; set; } = default!;
    public NodeColor Color { get; set; }
    public RBTreeNode<T>? Parent { get; set; }
    public RBTreeNode<T>? LeftChild { get; set; }
    public RBTreeNode<T>? RightChild { get; set; }
}

public class RBTree<T> where T : IComparable<T>
{
    public RBTreeNode<T>? Root { get; set; }

    public void InOrderAction(Action<RBTreeNode<T>?> action)
    {
        if (Root is null)
        {
            return;
        }
        InOrderAction(Root, action);
    }

    private void InOrderAction(RBTreeNode<T>? node, Action<RBTreeNode<T>?> action)
    {
        if (node is null)
        {
            return;
        }
        InOrderAction(node.LeftChild, action);
        action(node);
        InOrderAction(node.RightChild, action);
    }

    private void RotateLeft(RBTreeNode<T>? x)
    {
        if (x is null || x.RightChild is null)
        {
            // otherwise left rotation is not possible
            return;
        }
        var y = x.RightChild;
        x.RightChild = y.LeftChild;
        if (y.LeftChild is not null)
        {
            y.LeftChild.Parent = x;
        }
        y.Parent = x.Parent;

        if (x.Parent is null)
        {
            // x was the tree root, now y is
            this.Root = y;
        }
        else
        {
            if (x == x.Parent.LeftChild)
            {
                // x is the left child of its parent
                x.Parent.LeftChild = y;
            }
            else
            {
                // x is the right child
                x.Parent.RightChild = y;
            }
        }
        y.LeftChild = x;
        x.Parent = y;
    }

    private void RotateRight(RBTreeNode<T>? y)
    {
        if (y is null || y.LeftChild is null)
        {
            // otherwise right rotation is not possible
            return;
        }
        var x = y.LeftChild;
        y.LeftChild = x.RightChild;
        if (x.RightChild is not null)
        {
            x.RightChild.Parent = y;
        }
        x.Parent = y.Parent;

        if (y.Parent is null)
        {
            // x was the tree root, now y is
            this.Root = x;
        }
        else
        {
            if (y == y.Parent.RightChild)
            {
                // x is the right child of its parent
                y.Parent.RightChild = x;
            }
            else
            {
                // x is the left child
                y.Parent.LeftChild = x;
            }
        }
        x.RightChild = y;
        y.Parent = x;
    }

    void Insert(RBTreeNode<T>? z)
    {
        if (z is null)
        {
            return;
        }

        var x = this.Root;
        RBTreeNode<T>? y = null;
        while (x != null)
        {
            y = x;
            // z.Value < x.Value
            if (Comparer<T>.Default.Compare(z.Value, x.Value) < 0)
            {
                x = x.LeftChild;
            } else {
                x = x.RightChild;
            }
        }
        z.Parent = y;
        if (y == null) {
            this.Root = z;
        } else {
            if (Comparer<T>.Default.Compare(z.Value, y.Value) < 0)
            {
                y.LeftChild = z;
            } else {
                y.RightChild = z;
            }
        }
    }
}