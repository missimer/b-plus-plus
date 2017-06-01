using System;

namespace Compiler.Lib
{
  public class PostfixExpression : AbstractSyntaxTree
  {
    public PostfixExpression(AbstractSyntaxTree child) : base(child)
    {
    }

    public PostfixExpression(AbstractSyntaxTree childOne, AbstractSyntaxTree childTwo) : base(childOne, childTwo)
    {
    }
  }

  public class PostfixExpressionPrimary : PostfixExpression
  {
    public PostfixExpressionPrimary(PrimaryExpression primary) : base(primary)
    {
    }

    public PrimaryExpression PrimaryExpr { get { return _children[0] as PrimaryExpression; } }
  }

  public class PostfixExpressionIndex : PostfixExpression
  {
    public PostfixExpressionIndex(PostfixExpression postfixExpr, Expression expr) : base(postfixExpr, expr)
    {
    }

    public PostfixExpression PostfixExpr { get { return _children[0] as PostfixExpression; } }

    public Expression Expr { get { return _children[1] as Expression; } }
  }

  public class PostfixExpressionCall : PostfixExpression
  {
    public PostfixExpressionCall(PostfixExpression postfixExpr, ArgumentExpressionList argumentExprList) : base(postfixExpr, argumentExprList)
    {
    }

    public PostfixExpression PostfixExpr { get { return _children[0] as PostfixExpression; } }

    public ArgumentExpressionList ArgumentExprList { get { return _children[1] as ArgumentExpressionList; } }
  }
}
