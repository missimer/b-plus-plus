using System;

namespace Compiler.Lib
{
  public class CompoundStatement : AbstractSyntaxTree
  {
    public CompoundStatement(BlockItemList blockItemList) : base(blockItemList)
    {
    }

    public BlockItemList BlockItemList { get { return _children[0] as BlockItemList; } }
  }
}

