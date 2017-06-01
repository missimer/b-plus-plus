using System;

namespace Compiler.Lib
{
  public enum RelationalExpressionOperator {
    None,
    LessThan,
    GreaterThan,
    LessThanOrEqual,
    GreaterThanOrEqual,
  }

  public class RelationalExpression : AbstractSyntaxTree
  {
    RelationalExpressionOperator _operator;
    
    public RelationalExpression(RelationalExpression relational, ShiftExpression shift, RelationalExpressionOperator op) : base(relational, shift)
    {
      _operator = op;
    }

    public RelationalExpression RelationalExpr { get { return _children[0] as RelationalExpression; } }

    public ShiftExpression ShiftExpr { get { return _children[1] as ShiftExpression; } }

    public RelationalExpressionOperator Operator { get { return _operator; } }
  }
}

