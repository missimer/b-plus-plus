using System;

namespace Compiler.Lib
{
  public class ExclusiveOrExpression : AbstractSyntaxTree
  {
    public ExclusiveOrExpression(ExclusiveOrExpression exclusiveOr, AndExpression andExpression) : base(exclusiveOr, andExpression)
    {
    }

    public ExclusiveOrExpression ExclusiveOrExpr { get { return _children[0] as ExclusiveOrExpression; } }

    public AndExpression AndExpr { get { return _children[1] as AndExpression; } }
  }
}

