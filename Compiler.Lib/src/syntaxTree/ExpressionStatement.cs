using System;

namespace Compiler.Lib
{
  public class ExpressionStatement : AbstractSyntaxTree
  {
    public ExpressionStatement(Expression expr) : base(expr)
    {
    }

    Expression Expression { get { return _children[0] as Expression; } }
  }
}

