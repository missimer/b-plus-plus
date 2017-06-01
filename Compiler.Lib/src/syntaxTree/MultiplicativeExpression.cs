using System;

namespace Compiler.Lib
{
  public enum MultiplicativeExpressionOperator {
    None,
    Multiplication,
    Division,
    Modulo,
  }
  
  public class MultiplicativeExpression : AbstractSyntaxTree
  {
    public MultiplicativeExpressionOperator _operator;
    
    public MultiplicativeExpression(MultiplicativeExpression multiplicative, CastExpression cast, MultiplicativeExpressionOperator op) : base(multiplicative, cast)
    {
      _operator = op;
    }

    public MultiplicativeExpression MultiplicativeExpr { get { return _children[0] as MultiplicativeExpression; } }

    public CastExpression CastExpr { get { return _children[1] as CastExpression; } }

    public MultiplicativeExpressionOperator Operator { get { return _operator; } }
  }
}

