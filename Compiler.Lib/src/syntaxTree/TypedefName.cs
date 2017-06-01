using System;

namespace Compiler.Lib
{
  public class TypedefName : AbstractSyntaxTree
  {
    string _text;
    
    public TypedefName(string text)
    {
      _text = text;
    }

    public string Text { get { return _text; } }
  }
}

