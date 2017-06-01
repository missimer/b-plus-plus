using System;

namespace Compiler.Lib
{
  public class TypeName : AbstractSyntaxTree
  {
    public TypeName(SpecifierQualifierList specifierQualifierList, AbstractDeclarator abstractDeclarator) : base(specifierQualifierList, abstractDeclarator)
    {
    }

    public SpecifierQualifierList SpecifierQualifierList { get { return _children[0] as SpecifierQualifierList; } }

    public AbstractDeclarator AbstractDeclarator { get { return _children[1] as AbstractDeclarator; } }
  }


}
