using System;

namespace Compiler.Lib
{
  public class UnaryExpression : AbstractSyntaxTree
  {
    public UnaryExpression(AbstractSyntaxTree childOne) : base(childOne)
    {
    }


  }

  public class UnaryExpressionPostfix : UnaryExpression
  {
    public UnaryExpressionPostfix(PostfixExpression postfix) : base(postfix)
    {
    }

    public PostfixExpression PostfixExpr { get { return _children[0] as PostfixExpression; } }
  }
}

