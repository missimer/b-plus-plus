using System;

namespace Compiler.Lib
{
  public class CastExpression : AbstractSyntaxTree
  {
    public CastExpression(TypeName type, CastExpression cast) : base(type, cast)
    {
    }

    public CastExpression(UnaryExpression unary) : base(unary) 
    {
    }

    public TypeName TypeName { get { return _children[0] as TypeName; } }

    public CastExpression CastExpr { get { return _children[1] as CastExpression; } }

    public UnaryExpression UnaryExpr { get { return _children[0] as UnaryExpression; } }
  }
}

