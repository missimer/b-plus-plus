using NUnit.Framework;
using System;
using Compiler.Lib;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Compiler.Tests
{
  [TestFixture()]
  public class TestVisitor
  {
    private Visitor v;
    
    [TestFixtureSetUp]
    public void Init()
    {
      v = new Visitor();
    }
    
    private BPPParser GetParser(string s)
    {
      MemoryStream stream = new MemoryStream();
      StreamWriter writer = new StreamWriter(stream);
      writer.Write(s);
      writer.Flush();
      stream.Position = 0;

      AntlrInputStream input = new AntlrInputStream(stream);
      BPPLexer lexer = new BPPLexer(input);
      CommonTokenStream tokens = new CommonTokenStream(lexer);
      BPPParser parser = new BPPParser(tokens);
      parser.BuildParseTree = true;

      return parser;
    }
    
    [Test()]
    public void
    TestPrimaryExpressionConstant()
    {
      AbstractSyntaxTree tree;
 
      tree = v.Visit(GetParser("5").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionConstant>(tree);
      Assert.IsTrue(tree.Node);
      Assert.AreEqual("5", ((PrimaryExpressionConstant)tree).Text);

      tree = v.Visit(GetParser("5.5").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionConstant>(tree);
      Assert.IsTrue(tree.Node);
      Assert.AreEqual("5.5", ((PrimaryExpressionConstant)tree).Text);

      tree = v.Visit(GetParser("'c'").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionConstant>(tree);
      Assert.IsTrue(tree.Node);
      Assert.AreEqual("'c'", ((PrimaryExpressionConstant)tree).Text);

      tree = v.Visit(GetParser("L'c'").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionConstant>(tree);
      Assert.IsTrue(tree.Node);
      Assert.AreEqual("L'c'", ((PrimaryExpressionConstant)tree).Text);

      tree = v.Visit(GetParser("u'c'").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionConstant>(tree);
      Assert.IsTrue(tree.Node);
      Assert.AreEqual("u'c'", ((PrimaryExpressionConstant)tree).Text);

      tree = v.Visit(GetParser("U'c'").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionConstant>(tree);
      Assert.IsTrue(tree.Node);
      Assert.AreEqual("U'c'", ((PrimaryExpressionConstant)tree).Text);
    }

    [Test()]
    public void
    TestPrimaryExpressionIdentifier()
    {
      AbstractSyntaxTree tree;

      tree = v.Visit(GetParser("foo").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionIdentifier>(tree);
      Assert.IsTrue(tree.Node);
      Assert.AreEqual("foo", ((PrimaryExpressionIdentifier)tree).Text);

      tree = v.Visit(GetParser("int").primaryExpression());
      Assert.AreEqual(null, tree);

      tree = v.Visit(GetParser("float").primaryExpression());
      Assert.AreEqual(null, tree);
    }

    [Test()]
    public void
    TestPrimaryExpressionStringLiteral()
    {
      AbstractSyntaxTree tree;
      PrimaryExpressionStringLiteral string_literial;

      tree = v.Visit(GetParser("\"foo\"").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionStringLiteral>(tree);
      Assert.IsTrue(tree.Node);
      string_literial = (PrimaryExpressionStringLiteral)tree;
      Assert.AreEqual("\"foo\"", string_literial.Texts[0]);
      Assert.AreEqual(1, string_literial.TextsCount);

      tree = v.Visit(GetParser("u\"foo\"").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionStringLiteral>(tree);
      Assert.IsTrue(tree.Node);
      string_literial = (PrimaryExpressionStringLiteral)tree;
      Assert.AreEqual(1, string_literial.TextsCount);
      Assert.AreEqual("u\"foo\"", string_literial.Texts[0]);

      tree = v.Visit(GetParser("u8\"foo\"").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionStringLiteral>(tree);
      Assert.IsTrue(tree.Node);
      string_literial = (PrimaryExpressionStringLiteral)tree;
      Assert.AreEqual(1, string_literial.TextsCount);
      Assert.AreEqual("u8\"foo\"", string_literial.Texts[0]);

      tree = v.Visit(GetParser("U\"foo\"").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionStringLiteral>(tree);
      Assert.IsTrue(tree.Node);
      string_literial = (PrimaryExpressionStringLiteral)tree;
      Assert.AreEqual(1, string_literial.TextsCount);
      Assert.AreEqual("U\"foo\"", string_literial.Texts[0]);

      tree = v.Visit(GetParser("L\"foo\"").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionStringLiteral>(tree);
      Assert.IsTrue(tree.Node);
      string_literial = (PrimaryExpressionStringLiteral)tree;
      Assert.AreEqual(1, string_literial.TextsCount);
      Assert.AreEqual("L\"foo\"", string_literial.Texts[0]);

      tree = v.Visit(GetParser("\"foo\" \"bar\"").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionStringLiteral>(tree);
      Assert.IsTrue(tree.Node);
      string_literial = (PrimaryExpressionStringLiteral)tree;
      Assert.AreEqual(2, string_literial.TextsCount);
      Assert.AreEqual("\"foo\"", string_literial.Texts[0]);
      Assert.AreEqual("\"bar\"", string_literial.Texts[1]);
    }

    [Test()]
    public void
    TestPrimaryExpressionParens()
    {
      AbstractSyntaxTree tree;

      tree = v.Visit(GetParser("(5)").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionParens>(tree);
      Assert.IsFalse(tree.Node);
      Assert.AreEqual("5", (((((tree as PrimaryExpressionParens).Expression).AssignmentExpr.ConditionalExpr
        .LogicalOrExpr.LogicalAndExpr.InclusiveOrExpr.ExclusiveOrExpr.AndExpr.EqualityExpr.RelationalExpr
        .ShiftExpr.AdditiveExpr.MultiplicativeExpr.CastExpr.UnaryExpr as UnaryExpressionPostfix).PostfixExpr as PostfixExpressionPrimary)
        .PrimaryExpr as PrimaryExpressionConstant).Text);
    }

    [Test()]
    public void
    TestPrimaryExpressionGenericSelection()
    {
      AbstractSyntaxTree tree;

      tree = v.Visit(GetParser("_Generic (5, int : 7, char : 10)").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionGenericSelection>(tree);
      Assert.AreEqual("5", ((((tree as PrimaryExpressionGenericSelection).GenericSelection.Assignment.ConditionalExpr
        .LogicalOrExpr.LogicalAndExpr.InclusiveOrExpr.ExclusiveOrExpr.AndExpr.EqualityExpr.RelationalExpr
        .ShiftExpr.AdditiveExpr.MultiplicativeExpr.CastExpr.UnaryExpr as UnaryExpressionPostfix).PostfixExpr as PostfixExpressionPrimary)
        .PrimaryExpr as PrimaryExpressionConstant).Text);

      Assert.AreEqual("char", (((tree as PrimaryExpressionGenericSelection).GenericSelection.Associations.Item.TypeName
        .SpecifierQualifierList as SpecifierQualifierListSpecifier).TypeSpecifier as TypeSpecifierLiteral).Text);
      Assert.AreEqual("10", ((((tree as PrimaryExpressionGenericSelection).GenericSelection.Associations.Item.AssignmentExpr.ConditionalExpr
        .LogicalOrExpr.LogicalAndExpr.InclusiveOrExpr.ExclusiveOrExpr.AndExpr.EqualityExpr.RelationalExpr
        .ShiftExpr.AdditiveExpr.MultiplicativeExpr.CastExpr.UnaryExpr as UnaryExpressionPostfix).PostfixExpr as PostfixExpressionPrimary)
        .PrimaryExpr as PrimaryExpressionConstant).Text);

      Assert.AreEqual("int", (((tree as PrimaryExpressionGenericSelection).GenericSelection.Associations.List.Item.TypeName
        .SpecifierQualifierList as SpecifierQualifierListSpecifier).TypeSpecifier as TypeSpecifierLiteral).Text);
      Assert.AreEqual("7", ((((tree as PrimaryExpressionGenericSelection).GenericSelection.Associations.List.Item.AssignmentExpr.ConditionalExpr
        .LogicalOrExpr.LogicalAndExpr.InclusiveOrExpr.ExclusiveOrExpr.AndExpr.EqualityExpr.RelationalExpr
        .ShiftExpr.AdditiveExpr.MultiplicativeExpr.CastExpr.UnaryExpr as UnaryExpressionPostfix).PostfixExpr as PostfixExpressionPrimary)
        .PrimaryExpr as PrimaryExpressionConstant).Text);

      Assert.IsNull((tree as PrimaryExpressionGenericSelection).GenericSelection.Associations.List.List);
    }

    [Test()]
    public void
    TestPrimaryExpressionCompoundStatement()
    {
      AbstractSyntaxTree tree;

      tree = v.Visit(GetParser("({i = 5; i = 2;})").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionCompoundStatement>(tree);

      tree = v.Visit(GetParser("__extension__ ({i = 5; i = 2;})").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionCompoundStatement>(tree);
    }

    [Test()]
    public void
    TestPrimaryExpressionVaArg()
    {
      AbstractSyntaxTree tree;

      tree = v.Visit(GetParser("__builtin_va_arg(list, int)").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionVaArg>(tree);
      Assert.AreEqual("list", ((((tree as PrimaryExpressionVaArg).UnaryExpr as UnaryExpressionPostfix).PostfixExpr as PostfixExpressionPrimary)
        .PrimaryExpr as PrimaryExpressionIdentifier).Text);
      Assert.AreEqual("int", (((tree as PrimaryExpressionVaArg).TypeName.SpecifierQualifierList as SpecifierQualifierListSpecifier).TypeSpecifier as TypeSpecifierLiteral).Text);
    }

    [Test()]
    public void
    TestPrimaryExpressionOffsetof()
    {
      AbstractSyntaxTree tree;

      tree = v.Visit(GetParser("__builtin_offsetof(type, member)").primaryExpression());
      Assert.IsInstanceOf<PrimaryExpressionOffsetof>(tree);
      Assert.AreEqual("type", (((tree as PrimaryExpressionOffsetof).TypeName.SpecifierQualifierList as SpecifierQualifierListSpecifier).TypeSpecifier as TypeSpecifierTypedefName).TypedefName.Text);
      Assert.AreEqual("member", ((((tree as PrimaryExpressionOffsetof).UnaryExpression as UnaryExpressionPostfix).PostfixExpr as PostfixExpressionPrimary).PrimaryExpr as PrimaryExpressionIdentifier).Text);
    }

    [Test()]
    public void
    TestGenericSelection()
    {
      AbstractSyntaxTree tree;

      tree = v.Visit(GetParser("_Generic (5 , int : 10)").genericSelection());
      Assert.IsInstanceOf<GenericSelection>(tree);

      Assert.AreEqual("5", ((((tree as GenericSelection).Assignment.ConditionalExpr.LogicalOrExpr.LogicalAndExpr.InclusiveOrExpr
        .ExclusiveOrExpr.AndExpr.EqualityExpr.RelationalExpr.ShiftExpr.AdditiveExpr.MultiplicativeExpr.CastExpr.UnaryExpr as UnaryExpressionPostfix)
        .PostfixExpr as PostfixExpressionPrimary).PrimaryExpr as PrimaryExpressionConstant).Text);

      Assert.AreEqual("int", (((tree as GenericSelection).Associations.Item.TypeName
        .SpecifierQualifierList as SpecifierQualifierListSpecifier).TypeSpecifier as TypeSpecifierLiteral).Text);

      Assert.AreEqual("10", ((((tree as GenericSelection).Associations.Item.AssignmentExpr.ConditionalExpr
        .LogicalOrExpr.LogicalAndExpr.InclusiveOrExpr.ExclusiveOrExpr.AndExpr.EqualityExpr.RelationalExpr
        .ShiftExpr.AdditiveExpr.MultiplicativeExpr.CastExpr.UnaryExpr as UnaryExpressionPostfix).PostfixExpr as PostfixExpressionPrimary)
        .PrimaryExpr as PrimaryExpressionConstant).Text);

      Assert.IsNull((tree as GenericSelection).Associations.List);
    }

    [Test()]
    public void
    TestGenericAssocList()
    {
      AbstractSyntaxTree tree;

      tree = v.Visit(GetParser("default : 5").genericAssocList());
      Assert.IsInstanceOf<GenericAssocList>(tree);
      Assert.IsNull((tree as GenericAssocList).List);
      Assert.AreEqual("5", ((((tree as GenericAssocList).Item.AssignmentExpr.ConditionalExpr
        .LogicalOrExpr.LogicalAndExpr.InclusiveOrExpr.ExclusiveOrExpr.AndExpr.EqualityExpr.RelationalExpr
        .ShiftExpr.AdditiveExpr.MultiplicativeExpr.CastExpr.UnaryExpr as UnaryExpressionPostfix).PostfixExpr as PostfixExpressionPrimary)
        .PrimaryExpr as PrimaryExpressionConstant).Text);


      tree = v.Visit(GetParser("default : 5, int : 8").genericAssocList());
      Assert.IsInstanceOf<GenericAssocList>(tree);
      Assert.IsNotNull((tree as GenericAssocList).List);
      Assert.IsNull((tree as GenericAssocList).List.List);
      Assert.AreEqual("8", ((((tree as GenericAssocList).Item.AssignmentExpr.ConditionalExpr
        .LogicalOrExpr.LogicalAndExpr.InclusiveOrExpr.ExclusiveOrExpr.AndExpr.EqualityExpr.RelationalExpr
        .ShiftExpr.AdditiveExpr.MultiplicativeExpr.CastExpr.UnaryExpr as UnaryExpressionPostfix).PostfixExpr as PostfixExpressionPrimary)
        .PrimaryExpr as PrimaryExpressionConstant).Text);
      Assert.AreEqual("int", (((tree as GenericAssocList).Item.TypeName.SpecifierQualifierList as SpecifierQualifierListSpecifier).TypeSpecifier as TypeSpecifierLiteral).Text);

      Assert.AreEqual("5", ((((tree as GenericAssocList).List.Item.AssignmentExpr.ConditionalExpr
        .LogicalOrExpr.LogicalAndExpr.InclusiveOrExpr.ExclusiveOrExpr.AndExpr.EqualityExpr.RelationalExpr
        .ShiftExpr.AdditiveExpr.MultiplicativeExpr.CastExpr.UnaryExpr as UnaryExpressionPostfix).PostfixExpr as PostfixExpressionPrimary)
        .PrimaryExpr as PrimaryExpressionConstant).Text);
      Assert.IsNull((tree as GenericAssocList).List.Item.TypeName);

      
    }

    [Test()]
    public void
    TestGenericAssociation()
    {
      AbstractSyntaxTree tree;

      tree = v.Visit(GetParser("default : 5").genericAssociation());
      Assert.IsInstanceOf<GenericAssociation>(tree);
      Assert.IsNull((tree as GenericAssociation).TypeName);
      Assert.AreEqual("5", ((((tree as GenericAssociation).AssignmentExpr.ConditionalExpr
        .LogicalOrExpr.LogicalAndExpr.InclusiveOrExpr.ExclusiveOrExpr.AndExpr.EqualityExpr.RelationalExpr
        .ShiftExpr.AdditiveExpr.MultiplicativeExpr.CastExpr.UnaryExpr as UnaryExpressionPostfix).PostfixExpr as PostfixExpressionPrimary)
        .PrimaryExpr as PrimaryExpressionConstant).Text);

      tree = v.Visit(GetParser("int : \"foo\"").genericAssociation());
      Assert.IsInstanceOf<GenericAssociation>(tree);
      Assert.IsInstanceOf<SpecifierQualifierListSpecifier>((tree as GenericAssociation).TypeName.SpecifierQualifierList);
      Assert.IsInstanceOf<TypeSpecifierLiteral>(((tree as GenericAssociation).TypeName.SpecifierQualifierList as SpecifierQualifierListSpecifier).TypeSpecifier);
      Assert.AreEqual("int", (((tree as GenericAssociation).TypeName.SpecifierQualifierList as SpecifierQualifierListSpecifier).TypeSpecifier as TypeSpecifierLiteral).Text);
      Assert.AreEqual("\"foo\"", ((((tree as GenericAssociation).AssignmentExpr.ConditionalExpr
        .LogicalOrExpr.LogicalAndExpr.InclusiveOrExpr.ExclusiveOrExpr.AndExpr.EqualityExpr.RelationalExpr
        .ShiftExpr.AdditiveExpr.MultiplicativeExpr.CastExpr.UnaryExpr as UnaryExpressionPostfix).PostfixExpr as PostfixExpressionPrimary)
        .PrimaryExpr as PrimaryExpressionStringLiteral).Texts[0]);
    }

    [Test()]
    public void
    TestPostfixExpressionPrimary()
    {
      AbstractSyntaxTree tree;

      tree = v.Visit(GetParser("foo").postfixExpression());
      Assert.IsInstanceOf<PostfixExpressionPrimary>(tree);
      Assert.AreEqual("foo", ((tree as PostfixExpressionPrimary).PrimaryExpr as PrimaryExpressionIdentifier).Text);
    }

    [Test()]
    public void
    TestPostfixExpressionIndex()
    {
      AbstractSyntaxTree tree;

      tree = v.Visit(GetParser("foo[4]").postfixExpression());
      Assert.IsInstanceOf<PostfixExpressionIndex>(tree);
      Assert.AreEqual("foo", (((tree as PostfixExpressionIndex).PostfixExpr as PostfixExpressionPrimary).PrimaryExpr as PrimaryExpressionIdentifier).Text);
      Assert.AreEqual("4", ((((tree as PostfixExpressionIndex).Expr.AssignmentExpr.ConditionalExpr.LogicalOrExpr.LogicalAndExpr.InclusiveOrExpr.ExclusiveOrExpr.
        AndExpr.EqualityExpr.RelationalExpr.ShiftExpr.AdditiveExpr.MultiplicativeExpr.CastExpr.UnaryExpr as UnaryExpressionPostfix).PostfixExpr as PostfixExpressionPrimary).
        PrimaryExpr as PrimaryExpressionConstant).Text);
    }

    [Test()]
    public void
    TestPostfixExpressionCall()
    {
      AbstractSyntaxTree tree;

      tree = v.Visit(GetParser("func(3, 4)").postfixExpression());
      Assert.IsInstanceOf<PostfixExpressionCall>(tree);
      Assert.AreEqual("func", (((tree as PostfixExpressionCall).PostfixExpr as PostfixExpressionPrimary).PrimaryExpr as PrimaryExpressionIdentifier).Text);
      Assert.AreEqual("4", ((((tree as PostfixExpressionCall).ArgumentExprList.AssignmentExpr.ConditionalExpr.LogicalOrExpr.LogicalAndExpr.
        InclusiveOrExpr.ExclusiveOrExpr.AndExpr.EqualityExpr.RelationalExpr.ShiftExpr.AdditiveExpr.MultiplicativeExpr.CastExpr.UnaryExpr as UnaryExpressionPostfix).
        PostfixExpr as PostfixExpressionPrimary).PrimaryExpr as PrimaryExpressionConstant).Text);
      Assert.AreEqual("3", ((((tree as PostfixExpressionCall).ArgumentExprList.ArgumentExprList.AssignmentExpr.ConditionalExpr.LogicalOrExpr.LogicalAndExpr.
        InclusiveOrExpr.ExclusiveOrExpr.AndExpr.EqualityExpr.RelationalExpr.ShiftExpr.AdditiveExpr.MultiplicativeExpr.CastExpr.UnaryExpr as UnaryExpressionPostfix).
        PostfixExpr as PostfixExpressionPrimary).PrimaryExpr as PrimaryExpressionConstant).Text);

      tree = v.Visit(GetParser("func()").postfixExpression());
      Assert.AreEqual("func", (((tree as PostfixExpressionCall).PostfixExpr as PostfixExpressionPrimary).PrimaryExpr as PrimaryExpressionIdentifier).Text);
      Assert.AreEqual(null, (tree as PostfixExpressionCall).ArgumentExprList);
    }
  }
}
