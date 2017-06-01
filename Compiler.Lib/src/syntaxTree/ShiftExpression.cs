using System;

namespace Compiler.Lib
{
  public enum ShiftExpressionOperator {
    None,
    Left,
    Right,
  }
  
  public class ShiftExpression : AbstractSyntaxTree
  {
    private ShiftExpressionOperator _operator;

    public ShiftExpression(ShiftExpression shift, AdditiveExpression additive, ShiftExpressionOperator op) : base(shift, additive)
    {
      _operator = op;
    }

    public ShiftExpression ShiftExpr { get { return _children[0] as ShiftExpression; } }

    public AdditiveExpression AdditiveExpr { get { return _children[1] as AdditiveExpression; } }

    public ShiftExpressionOperator Operator { get { return _operator; } }
  }
}

