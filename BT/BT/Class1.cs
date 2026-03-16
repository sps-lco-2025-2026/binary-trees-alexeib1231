using System.Numerics;
using Microsoft.VisualBasic;

namespace BT;

public class BT
{
    Node _root;
    public void Insert(int n)
    {
        if(_root == null)
        {
            _root = new Node(n);
        }
        else
        {
            _root.Insert(n);
        }
    }
    public bool isPresent(int n)
    {
        return _root.isPresent(n);
    }
    public int Sum()
    {
        return _root.Sum();
    }
    public override string ToString()
    {
        return _root.ToString();
    }
    public bool HasDuplicate()
    {
        return _root.HasDuplicate();
    }
    public int depth()
    {
        return _root.depth()+1;
    }
    public bool IsBalanced()
    {
        if(_root == null)
        {
            return true;
        }
        return _root.IsBalanced();
    }
    public int LCA(int n1, int n2)
    {
        return _root.LCA(n1,n2);
    }
}

internal class Node
{
    int _value;
    Node _left;
    Node _right;
    internal Node(int n)
    {
        _value = n;
        _left = null;
        _right = null;
    }
    internal void Insert(int n)
    {
        if (n >= _value)
        {
            if(_right == null)
            {
                Node _right = new Node(n);
                return;
            }
            else
            {
                _right.Insert(n);
            }
        }
        else
        {
            if(_left == null)
            {
                Node _left = new Node(n);
                return;
            }
            else
            {
                _left.Insert(n);
            }
        }
    }
    internal bool IsPresent(int n)
    {
        if(_left==null && _right == null)
        {
            return false;
        }
        if(n == _value)
        {
            return true;
        }
        else if(n >= _value){
            return _right.IsPresent(n);
        }
        else
        {
            return _left.IsPresent(n);
        }
    }
    internal int Sum()
    {
        int total = _value;
        if(_left != null)
        {
            total += _left.Sum();
        }
        if(_right != null)
        {
            total += _right.Sum();
        }
        return total;
    }
    internal string ToString()
    {
        string left = _left.ToString();
        string right = _right.ToString();
        string middle = _value.ToString();
        return left+middle+right;
    }
    internal bool HasDuplicate()
    {
        if(_right != null)
        {
            if (_right.IsPresent(_value))
            {
                return true;
            }
            if (_right.HasDuplicate())
            {
                return true;
            }
        }
        if(_left != null)
        {
            if (_left.HasDuplicate()){
                return true;
            }
        }
        return false;

    }
    internal int depth()
    {
        if (_left != null)
        {
            int leftDepth = _left.depth();   
        }
        if(_right != null)
        {
            int rightDepth = _right.depth();
        }
        return Math.Max(leftDepth, rightDepth);
    }
    internal int CheckHeight()
    {
        if(_left != null)
        {
            int leftHeight = _left.CheckHeight();
            if(leftHeight == false)
            {
                return false;
            }
        }
        if(_right != null)
        {
            int rightHeight = _right.CheckHeight();
            if(rightHeight == false)
            {
                return false;
            }
        }
        if(Math.Abs(leftHeight - rightHeight) > 1)
        {
            return false;
        }
        return true;
    }
    internal int LCA(int n1, int n2)
    {
        if(n1<_value && n2 < _value)
        {
            return _left.LCA(n1,n2);
        }
        if(n1>_value && n2 > _value)
        {
            return _right.LCA(n1,n2);
        }
        return _value;
    }
}