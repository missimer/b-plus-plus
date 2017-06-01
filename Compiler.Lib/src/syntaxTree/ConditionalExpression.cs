using System;

namespace Compiler.Lib
{
  public class ConditionalExpression : AbstractSyntaxTree
  {
    public ConditionalExpression(LogicalOrExpression logical, Expression expression, ConditionalExpression conditional) : base(logical, expression, conditional)
    {
    }

    public LogicalOrExpression LogicalOrExpr { get { return _children[0] as LogicalOrExpression; } }

    public Expression Expr { get { return _children[1] as Expression; } }

    public ConditionalExpression ConditionalExpr { get { return _children[2] as ConditionalExpression; } }
  }
}

