using System;

namespace Compiler.Lib
{
  public class AssignmentExpression : AbstractSyntaxTree
  {
    public AssignmentExpression(ConditionalExpression expression) : base(expression)
    {
    }

    public AssignmentExpression(UnaryExpression unary, AssignmentOperator op, AssignmentExpression assignment) : base(unary, op, assignment)
    {
    }

    public ConditionalExpression ConditionalExpr { get { return _children.Length == 1 ? _children[0] as ConditionalExpression: null; } }

    public UnaryExpression UnaryExpr { get { return _children.Length == 1 ? null : _children[0] as UnaryExpression; } }

    public AssignmentOperator AssignmentOperator { get { return _children.Length == 1 ? null : _children[1] as AssignmentOperator; } }

    public AssignmentExpression AssignExpr { get { return _children.Length == 1 ? null : _children[2] as AssignmentExpression; } }
  }
}

