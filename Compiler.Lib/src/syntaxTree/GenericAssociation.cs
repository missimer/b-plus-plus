using System;

namespace Compiler.Lib

//typeName ':' assignmentExpression
{
  public class GenericAssociation : AbstractSyntaxTree
  {
    public GenericAssociation(TypeName type, AssignmentExpression expression) : base(type, expression)
    {
    }

    public TypeName TypeName { get { return _children[0] as TypeName; } }

    public AssignmentExpression AssignmentExpr { get { return _children[1] as AssignmentExpression; } }
  }
}

