using System;

namespace Compiler.Lib
{
  public class InclusiveOrExpression : AbstractSyntaxTree
  {
    public InclusiveOrExpression(InclusiveOrExpression inclusiveOr, ExclusiveOrExpression exclusiveOr) : base(inclusiveOr, exclusiveOr)
    {
    }

    public ExclusiveOrExpression ExclusiveOrExpr { get { return _children[1] as ExclusiveOrExpression; } }

    public InclusiveOrExpression InclusiveOrExpr { get { return _children[0] as InclusiveOrExpression; } }
  }
}

