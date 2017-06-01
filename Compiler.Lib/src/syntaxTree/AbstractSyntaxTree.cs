using System;
using System.Collections.Generic;

namespace Compiler.Lib
{
  public class AbstractSyntaxTree
  {
    protected AbstractSyntaxTree[] _children;

    public AbstractSyntaxTree()
    {
      _children = null;
    }

    public AbstractSyntaxTree(AbstractSyntaxTree[] children) : this()
    {
      _children = (AbstractSyntaxTree[])children.Clone();
    }

    public AbstractSyntaxTree(AbstractSyntaxTree child) : this()
    {
      _children = new AbstractSyntaxTree[1];
      _children[0] = child;
    }

    public AbstractSyntaxTree(AbstractSyntaxTree childOne, AbstractSyntaxTree childTwo) : this()
    {
      _children = new AbstractSyntaxTree[2];
      _children[0] = childOne;
      _children[1] = childTwo;
    }

    public AbstractSyntaxTree(AbstractSyntaxTree childOne, AbstractSyntaxTree childTwo, AbstractSyntaxTree childThree) : this()
    {
      _children = new AbstractSyntaxTree[3];
      _children[0] = childOne;
      _children[1] = childTwo;
      _children[2] = childThree;
    }

    public bool Node { get { return _children == null; } }
  }
}
