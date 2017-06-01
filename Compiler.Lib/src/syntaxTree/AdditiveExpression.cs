using System;

namespace Compiler.Lib
{
  public enum AdditiveExpressionOperator {
    None,
    Add,
    Subtract,
  }

  public class AdditiveExpression : AbstractSyntaxTree
  {
    private AdditiveExpressionOperator _operator;
    
    public AdditiveExpression(AdditiveExpression additive, MultiplicativeExpression multiplicative, AdditiveExpressionOperator op) : base(additive, multiplicative)
    {
      _operator = op;
    }

    public AdditiveExpression AdditiveExpr { get { return _children[0] as AdditiveExpression; } }

    public MultiplicativeExpression MultiplicativeExpr { get { return _children[1] as MultiplicativeExpression; } }

    public AdditiveExpressionOperator Operator { get { return _operator; } }
  }
}

