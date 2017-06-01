using System;

namespace Compiler.Lib
{
  public class LogicalAndExpression : AbstractSyntaxTree
  {
    public LogicalAndExpression(LogicalAndExpression logicalAnd, InclusiveOrExpression inclusiveOr) : base(logicalAnd, inclusiveOr)
    {
    }

    public LogicalAndExpression LogicalAndExpr { get { return _children[0] as LogicalAndExpression; } }

    public InclusiveOrExpression InclusiveOrExpr { get { return _children[1] as InclusiveOrExpression; } }
  }
}

