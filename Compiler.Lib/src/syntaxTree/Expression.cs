using System;

namespace Compiler.Lib
{
  public class Expression : AbstractSyntaxTree
  {
    public Expression(Expression expression, AssignmentExpression assignment) : base(expression, assignment)
    {
    }

    public Expression Expr { get { return _children[0] as Expression; } }

    public AssignmentExpression AssignmentExpr { get { return _children[1] as AssignmentExpression; } }
  }
}
