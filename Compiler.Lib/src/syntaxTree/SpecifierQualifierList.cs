using System;

namespace Compiler.Lib
{
  public class SpecifierQualifierList : AbstractSyntaxTree
  {
    public SpecifierQualifierList(AbstractSyntaxTree type, SpecifierQualifierList list) : base(type, list)
    {
    }

    public SpecifierQualifierList SpecQualList { get { return _children[1] as SpecifierQualifierList; } }
  }

  public class SpecifierQualifierListSpecifier : SpecifierQualifierList
  {
    public SpecifierQualifierListSpecifier(TypeSpecifier type, SpecifierQualifierList list) : base(type, list)
    {
    }

    public TypeSpecifier TypeSpecifier { get { return _children[0] as TypeSpecifier; } }
  }

  public class SpecifierQualifierListQualifier : SpecifierQualifierList
  {
    public SpecifierQualifierListQualifier(TypeQualifier type, SpecifierQualifierList list) : base(type, list)
    {
    }

    public TypeQualifier TypeQualifier { get { return _children[0] as TypeQualifier; } }
  }
}

