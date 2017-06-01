using System;

namespace Compiler.Lib
{
  public class AndExpression : AbstractSyntaxTree
  {
    public AndExpression(AndExpression and, EqualityExpression equality) : base(and, equality)
    {
    }

    public AndExpression AndExpr { get { return _children[0] as AndExpression; } }

    public EqualityExpression EqualityExpr { get { return _children[1] as EqualityExpression; } }
  }
}

