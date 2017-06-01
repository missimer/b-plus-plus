using System;

namespace Compiler.Lib
{
  public class ArgumentExpressionList : AbstractSyntaxTree
  {
    public ArgumentExpressionList(AssignmentExpression assignmentExpr, ArgumentExpressionList argumentExprList) : base(assignmentExpr, argumentExprList)
    {
    }

    public AssignmentExpression AssignmentExpr { get { return _children[0] as AssignmentExpression; } }

    public ArgumentExpressionList ArgumentExprList { get { return _children[1] as ArgumentExpressionList; } }
  }
}

