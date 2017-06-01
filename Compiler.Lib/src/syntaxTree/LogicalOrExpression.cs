using System;

namespace Compiler.Lib
{
  public class LogicalOrExpression : AbstractSyntaxTree
  {
    public LogicalOrExpression(LogicalAndExpression andExpression) : base(andExpression)
    {
    }

    public LogicalOrExpression(LogicalOrExpression orExpression, LogicalAndExpression andExpression) : base(andExpression, orExpression)
    {
    }

    public LogicalOrExpression LogicalOrExpr { get { return _children.Length == 1 ? null : _children[1] as LogicalOrExpression; } }

    public LogicalAndExpression LogicalAndExpr { get { return _children[0] as LogicalAndExpression; } }
  }
}

