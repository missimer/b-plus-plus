using System;

namespace Compiler.Lib
{
  public class Statement : AbstractSyntaxTree
  {
    public Statement(AbstractSyntaxTree child) : base(child)
    {
    }
  }

  public class StatementExpressionStatement : Statement
  {
    public StatementExpressionStatement(AbstractSyntaxTree child) : base(child)
    {
    }
  }
}

