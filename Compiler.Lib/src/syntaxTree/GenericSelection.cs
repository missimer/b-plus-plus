using System;

namespace Compiler.Lib
{
  public class GenericSelection : AbstractSyntaxTree
  {
    public GenericSelection(AssignmentExpression assignment, GenericAssocList associations) : base(assignment, associations)
    {
    }

    public AssignmentExpression Assignment { get { return _children[0] as AssignmentExpression; } }

    public GenericAssocList Associations { get { return _children[1] as GenericAssocList; } }
  }
}
