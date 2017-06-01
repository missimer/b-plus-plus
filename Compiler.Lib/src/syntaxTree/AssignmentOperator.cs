using System;

namespace Compiler.Lib
{
  public class AssignmentOperator : AbstractSyntaxTree
  {
    string _text;
    
    public AssignmentOperator(string text)
    {
      _text = text;
    }

    public string Text { get { return _text; } }
  }
}

