using System;

namespace Compiler.Lib
{
  public class TypeSpecifier : AbstractSyntaxTree
  {
    public TypeSpecifier()
    {
    }
    
    public TypeSpecifier(AbstractSyntaxTree child) : base(child)
    {
    }
  }

  public class TypeSpecifierLiteral : TypeSpecifier
  {
    private string _text;
    
    public TypeSpecifierLiteral(string text)
    {
      _text = text;
    }

    public string Text { get { return _text; } }
  }

  public class TypeSpecifierTypedefName : TypeSpecifier 
  {
    public TypeSpecifierTypedefName(TypedefName typedefName) : base(typedefName)
    {
    }

    public TypedefName TypedefName { get { return _children[0] as TypedefName; } }
  }
}

