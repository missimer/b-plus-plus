using System;

namespace Compiler.Lib
{
  public class EqualityExpression : AbstractSyntaxTree
  {
    private bool _equalOperator;

    public EqualityExpression(EqualityExpression equality, RelationalExpression relational, bool equalOperator) : base(equality, relational)
    {
      _equalOperator = equalOperator;
    }

    public EqualityExpression EqualityExpr { get { return _children[0] as EqualityExpression; } }

    public RelationalExpression RelationalExpr { get { return _children[1] as RelationalExpression; } }

    public bool EqualOperator { get { return _equalOperator; } }
  }
}

