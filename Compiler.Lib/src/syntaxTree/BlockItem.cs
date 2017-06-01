using System;

namespace Compiler.Lib
{
  public class BlockItem : AbstractSyntaxTree
  {
    public BlockItem(AbstractSyntaxTree child) : base(child)
    {
    }
  }

  public class BlockItemStatement : BlockItem
  {
    public BlockItemStatement(Statement statement) : base(statement)
    {
    }

    public Statement Statement { get { return _children[0] as Statement; } }
  }
}

