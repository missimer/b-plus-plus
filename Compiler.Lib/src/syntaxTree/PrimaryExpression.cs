using System;

namespace Compiler.Lib
{
  public class PrimaryExpression : AbstractSyntaxTree
  {
    public PrimaryExpression()
    {
    }

    public PrimaryExpression(AbstractSyntaxTree child) : base(child)
    {
    }

    public PrimaryExpression(AbstractSyntaxTree childOne, AbstractSyntaxTree childTwo) : base(childOne, childTwo)
    {
    }
  }
  
  public class PrimaryExpressionConstant : PrimaryExpression
  {
    private string _text;

    public PrimaryExpressionConstant(string text)
    {
      _text = text;
    }

    public string Text { get { return _text; } }
  }

  public class PrimaryExpressionIdentifier : PrimaryExpression
  {
    private string _text;

    public PrimaryExpressionIdentifier(string text)
    {
      _text = text;
    }

    public string Text { get { return _text; } }
  }

  public class PrimaryExpressionStringLiteral : PrimaryExpression
  {
    private string[] _texts;

    public PrimaryExpressionStringLiteral(string[] texts)
    {
      _texts = (string[])texts.Clone();
    }

    public string[] Texts { get { return _texts; } }

    public int TextsCount { get { return _texts.Length; } }
  }

  public class PrimaryExpressionParens : AbstractSyntaxTree
  {
    public PrimaryExpressionParens(Expression child) : base(child)
    {
    }

    public Expression Expression { get { return _children[0] as Expression; } }
  }

  public class PrimaryExpressionGenericSelection : PrimaryExpression
  {
    public PrimaryExpressionGenericSelection(GenericSelection child) : base(child)
    {
    }

    public GenericSelection GenericSelection { get { return _children[0] as GenericSelection; } }
  }

  public class PrimaryExpressionCompoundStatement : PrimaryExpression
  {
    public PrimaryExpressionCompoundStatement(CompoundStatement child): base(child)
    {
    }

    public CompoundStatement Statements { get { return _children[0] as CompoundStatement; } }
  }

  public class PrimaryExpressionVaArg : PrimaryExpression
  {
    public PrimaryExpressionVaArg(UnaryExpression expression, TypeName name) : base(expression, name)
    {
    }

    public UnaryExpression UnaryExpr { get { return _children[0] as UnaryExpression; } }

    public TypeName TypeName { get { return _children[1] as TypeName; } }
  }

  public class PrimaryExpressionOffsetof : PrimaryExpression
  {
    public PrimaryExpressionOffsetof(TypeName typeName, UnaryExpression unaryExpression) : base(typeName, unaryExpression)
    {
    }

    public TypeName TypeName { get { return _children[0] as TypeName; } }

    public UnaryExpression UnaryExpression { get { return _children[1] as UnaryExpression; } }
  }
}

