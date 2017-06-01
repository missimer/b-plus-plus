using System;

namespace Compiler.Lib
{
  public class BlockItemList : AbstractSyntaxTree
  {
    public BlockItemList(BlockItemList blockItemList, BlockItem blockItem) : base(blockItemList, blockItem)
    {
    }

    public BlockItemList BlockItemLst { get { return _children[0] as BlockItemList; } }

    public BlockItem BlockItem { get { return _children[1] as BlockItem; } }
  }
}

