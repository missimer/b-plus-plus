using System;
using Antlr4.Runtime.Tree;

namespace Compiler.Lib
{
  
  public class Visitor : BPPBaseVisitor<AbstractSyntaxTree>
  {
    public Visitor()
    {
    }

    public override AbstractSyntaxTree
    VisitPrimaryExpressionCompoundStatement(BPPParser.PrimaryExpressionCompoundStatementContext context)
    {
      return new PrimaryExpressionCompoundStatement(Visit(context.compoundStatement()) as CompoundStatement);
    }

    public override AbstractSyntaxTree
    VisitPrimaryExpressionOffsetof(BPPParser.PrimaryExpressionOffsetofContext context)
    {
      return new PrimaryExpressionOffsetof(Visit(context.typeName()) as TypeName, Visit(context.unaryExpression()) as UnaryExpression);
    }

    public override AbstractSyntaxTree
    VisitPrimaryExpressionIndentifier(BPPParser.PrimaryExpressionIndentifierContext context)
    {
      return new PrimaryExpressionIdentifier(context.Identifier().GetText());
    }

    public override AbstractSyntaxTree
    VisitPrimaryExpressionParens(BPPParser.PrimaryExpressionParensContext context)
    {
      return new PrimaryExpressionParens(Visit(context.expression()) as Expression);
    }

    public override AbstractSyntaxTree
    VisitPrimaryExpressionConstant(BPPParser.PrimaryExpressionConstantContext context)
    {
      return new PrimaryExpressionConstant(context.Constant().GetText());
    }

    public override AbstractSyntaxTree
    VisitPrimaryExpressionVaArg(BPPParser.PrimaryExpressionVaArgContext context)
    {
      return new PrimaryExpressionVaArg(Visit(context.unaryExpression()) as UnaryExpression, Visit(context.typeName()) as TypeName);
    }

    public override AbstractSyntaxTree
    VisitPrimaryExpressionStringLiteral(BPPParser.PrimaryExpressionStringLiteralContext context)
    {
      string[] strs = new string[context.StringLiteral().Length];

      for(int i = 0; i < context.StringLiteral().Length; i++) {
        strs[i] = context.StringLiteral()[i].ToString();
      }
      return new PrimaryExpressionStringLiteral(strs);
    }

    public override AbstractSyntaxTree
    VisitPrimaryExpressionGenericSelection(BPPParser.PrimaryExpressionGenericSelectionContext context)
    {
      return new PrimaryExpressionGenericSelection(Visit(context.genericSelection()) as GenericSelection);
    }

    public override AbstractSyntaxTree
    VisitGenericSelection(BPPParser.GenericSelectionContext context)
    {
      return new GenericSelection(Visit(context.assignmentExpression()) as AssignmentExpression, Visit(context.genericAssocList()) as GenericAssocList);
    }

    public override AbstractSyntaxTree
    VisitGenericAssocList(BPPParser.GenericAssocListContext context)
    {
      if(context.genericAssocList() == null) {
        return new GenericAssocList(Visit(context.genericAssociation()) as GenericAssociation);
      }
      else {
        return new GenericAssocList(Visit(context.genericAssocList()) as GenericAssocList, Visit(context.genericAssociation()) as GenericAssociation);
      }
    }

    public override AbstractSyntaxTree
    VisitGenericAssociation(BPPParser.GenericAssociationContext context)
    {
      return new GenericAssociation(context.typeName() == null ? null : Visit(context.typeName()) as TypeName, Visit(context.assignmentExpression()) as AssignmentExpression);
    }

    public override AbstractSyntaxTree
    VisitPostfixExpressionPrimary(BPPParser.PostfixExpressionPrimaryContext context)
    {
      return new PostfixExpressionPrimary(Visit(context.primaryExpression()) as PrimaryExpression);
    }

    public override AbstractSyntaxTree
    VisitPostfixExpressionIndex(BPPParser.PostfixExpressionIndexContext context)
    {
      return new PostfixExpressionIndex(Visit(context.postfixExpression()) as PostfixExpression, Visit(context.expression()) as Expression);
    }

    public override AbstractSyntaxTree
    VisitPostfixExpressionCall(BPPParser.PostfixExpressionCallContext context)
    {
      return new PostfixExpressionCall(Visit(context.postfixExpression()) as PostfixExpression,
        context.argumentExpressionList() == null ? null : Visit(context.argumentExpressionList()) as ArgumentExpressionList);
    }

    public override AbstractSyntaxTree
    VisitPostfixExpressionDot(BPPParser.PostfixExpressionDotContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitPostfixExpressionArrow(BPPParser.PostfixExpressionArrowContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitPostfixExpressionAddition(BPPParser.PostfixExpressionAdditionContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitPostfixExpressionSubtraction(BPPParser.PostfixExpressionSubtractionContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitPostfixExpressionTypeNameList(BPPParser.PostfixExpressionTypeNameListContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitArgumentExpressionList(BPPParser.ArgumentExpressionListContext context)
    {
      return new ArgumentExpressionList(Visit(context.assignmentExpression()) as AssignmentExpression,
        context.argumentExpressionList() == null ? null : Visit(context.argumentExpressionList()) as ArgumentExpressionList);
    }

    public override AbstractSyntaxTree
    VisitUnaryExpressionPostfix(BPPParser.UnaryExpressionPostfixContext context)
    {
      return new UnaryExpressionPostfix(Visit(context.postfixExpression()) as PostfixExpression);
    }

    public override AbstractSyntaxTree
    VisitUnaryExpressionPrefixAddition(BPPParser.UnaryExpressionPrefixAdditionContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitUnaryExpressionPrefixSubtraction(BPPParser.UnaryExpressionPrefixSubtractionContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitUnaryExpressionCast(BPPParser.UnaryExpressionCastContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitUnaryExpressionSizeofUnary(BPPParser.UnaryExpressionSizeofUnaryContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitUnaryExpressionSizeofTypeName(BPPParser.UnaryExpressionSizeofTypeNameContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitUnaryExpressionAlignofTypeName(BPPParser.UnaryExpressionAlignofTypeNameContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitUnaryExpressionIdentifierAddress(BPPParser.UnaryExpressionIdentifierAddressContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitUnaryOperator(BPPParser.UnaryOperatorContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitCastExpression(BPPParser.CastExpressionContext context)
    {
      if(context.unaryExpression() == null) {
        throw new NotImplementedException();
      }
      else {
        return new CastExpression(Visit(context.unaryExpression()) as UnaryExpression);
      }
    }

    public override AbstractSyntaxTree
    VisitMultiplicativeExpressionCast(BPPParser.MultiplicativeExpressionCastContext context)
    {
      return new MultiplicativeExpression(null, Visit(context.castExpression()) as CastExpression, MultiplicativeExpressionOperator.None);
    }

    public override AbstractSyntaxTree
    VisitMultiplicativeExpressionMultiple(BPPParser.MultiplicativeExpressionMultipleContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitMultiplicativeExpressionDivide(BPPParser.MultiplicativeExpressionDivideContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitMultiplicativeExpressionMod(BPPParser.MultiplicativeExpressionModContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitAdditiveExpressionMultiplicative(BPPParser.AdditiveExpressionMultiplicativeContext context)
    {
      return new AdditiveExpression(null, Visit(context.multiplicativeExpression()) as MultiplicativeExpression, AdditiveExpressionOperator.None);
    }

    public override AbstractSyntaxTree
    VisitAdditiveExpressionAdd(BPPParser.AdditiveExpressionAddContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitAdditiveExpressionSubtract(BPPParser.AdditiveExpressionSubtractContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitShiftExpressionAdditive(BPPParser.ShiftExpressionAdditiveContext context)
    {
      return new ShiftExpression(null, Visit(context.additiveExpression()) as AdditiveExpression, ShiftExpressionOperator.None);
    }

    public override AbstractSyntaxTree
    VisitShiftExpressionLeft(BPPParser.ShiftExpressionLeftContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitShiftExpressionRight(BPPParser.ShiftExpressionRightContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitRelationalExpressionShift(BPPParser.RelationalExpressionShiftContext context)
    {
      return new RelationalExpression(null, Visit(context.shiftExpression()) as ShiftExpression, RelationalExpressionOperator.None);
    }

    public override AbstractSyntaxTree
    VisitRelationalExpressionLessThan(BPPParser.RelationalExpressionLessThanContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitRelationalExpressionGreaterThan(BPPParser.RelationalExpressionGreaterThanContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitRelationalExpressionLessThanOrEqual(BPPParser.RelationalExpressionLessThanOrEqualContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitRelationalExpressionGreaterThanOrEqual(BPPParser.RelationalExpressionGreaterThanOrEqualContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitEqualityExpressionEqual(BPPParser.EqualityExpressionEqualContext context)
    {
      return new EqualityExpression(Visit(context.equalityExpression()) as EqualityExpression,
        Visit(context.relationalExpression()) as RelationalExpression, true);
    }

    public override AbstractSyntaxTree
    VisitEqualityExpressionNotEqual(BPPParser.EqualityExpressionNotEqualContext context)
    {
      return new EqualityExpression(Visit(context.equalityExpression()) as EqualityExpression,
        Visit(context.relationalExpression()) as RelationalExpression, false);
    }

    public override AbstractSyntaxTree
    VisitEqualityExpressionRelational(BPPParser.EqualityExpressionRelationalContext context)
    {
      return new EqualityExpression(null,
        Visit(context.relationalExpression()) as RelationalExpression, true);
    }

    public override AbstractSyntaxTree
    VisitAndExpression(BPPParser.AndExpressionContext context)
    {
      return new AndExpression(
        context.andExpression() == null ? null : Visit(context.andExpression()) as AndExpression,
        Visit(context.equalityExpression()) as EqualityExpression);
    }

    public override AbstractSyntaxTree
    VisitExclusiveOrExpression(BPPParser.ExclusiveOrExpressionContext context)
    {
      return new ExclusiveOrExpression(
        context.exclusiveOrExpression() == null ? null : Visit(context.exclusiveOrExpression()) as ExclusiveOrExpression,
        Visit(context.andExpression()) as AndExpression);
    }

    public override AbstractSyntaxTree
    VisitInclusiveOrExpression(BPPParser.InclusiveOrExpressionContext context)
    {
      return new InclusiveOrExpression(
        context.inclusiveOrExpression() == null ? null : Visit(context.inclusiveOrExpression()) as InclusiveOrExpression,
        Visit(context.exclusiveOrExpression()) as ExclusiveOrExpression);
    }

    public override AbstractSyntaxTree
    VisitLogicalAndExpression(BPPParser.LogicalAndExpressionContext context)
    {
      return new LogicalAndExpression(
        context.logicalAndExpression() == null ? null : Visit(context.logicalAndExpression()) as LogicalAndExpression,
        Visit(context.inclusiveOrExpression()) as InclusiveOrExpression);
    }

    public override AbstractSyntaxTree
    VisitLogicalOrExpression(BPPParser.LogicalOrExpressionContext context)
    {
        return new LogicalOrExpression(
          context.logicalOrExpression() == null ? null : Visit(context.logicalOrExpression()) as LogicalOrExpression, 
          Visit(context.logicalAndExpression()) as LogicalAndExpression);
    }

    public override AbstractSyntaxTree
    VisitConditionalExpression(BPPParser.ConditionalExpressionContext context)
    {
      return new ConditionalExpression(Visit(context.logicalOrExpression()) as LogicalOrExpression,
        context.expression() == null ? null : Visit(context.expression()) as Expression,
        context.conditionalExpression() == null ? null : Visit(context.conditionalExpression()) as ConditionalExpression);
    }

    public override AbstractSyntaxTree
    VisitAssignmentExpression(BPPParser.AssignmentExpressionContext context)
    {
      if(context.conditionalExpression() == null) {
        return new AssignmentExpression(Visit(context.unaryExpression()) as UnaryExpression, 
          Visit(context.assignmentOperator()) as AssignmentOperator,
          Visit(context.assignmentExpression()) as AssignmentExpression);
      }
      else {
        return new AssignmentExpression(Visit(context.conditionalExpression()) as ConditionalExpression);
      }
    }

    public override AbstractSyntaxTree
    VisitAssignmentOperator(BPPParser.AssignmentOperatorContext context)
    {
      return new AssignmentOperator(context.GetText());
    }

    public override AbstractSyntaxTree
    VisitExpression(BPPParser.ExpressionContext context)
    {
      return new Expression(context.expression() == null ? null : Visit(context.expression()) as Expression, Visit(context.assignmentExpression()) as AssignmentExpression);
    }

    public override AbstractSyntaxTree
    VisitConstantExpression(BPPParser.ConstantExpressionContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitDeclaration(BPPParser.DeclarationContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitDeclarationSpecifiers(BPPParser.DeclarationSpecifiersContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitDeclarationSpecifiers2(BPPParser.DeclarationSpecifiers2Context context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitDeclarationSpecifier(BPPParser.DeclarationSpecifierContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitInitDeclaratorList(BPPParser.InitDeclaratorListContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitInitDeclarator(BPPParser.InitDeclaratorContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitStorageClassSpecifier(BPPParser.StorageClassSpecifierContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitTypeSpecifierLiteral(BPPParser.TypeSpecifierLiteralContext context)
    {
      return new TypeSpecifierLiteral(context.GetText());
    }

    public override AbstractSyntaxTree
    VisitTypeSpecifierExtensionLiteral(BPPParser.TypeSpecifierExtensionLiteralContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitTypeSpecifierAtomic(BPPParser.TypeSpecifierAtomicContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitTypeSpecifierStructOrUnion(BPPParser.TypeSpecifierStructOrUnionContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitTypeSpecifierEnum(BPPParser.TypeSpecifierEnumContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitTypeSpecifierTypedefName(BPPParser.TypeSpecifierTypedefNameContext context)
    {
      return new TypeSpecifierTypedefName(Visit(context.typedefName()) as TypedefName);
    }

    public override AbstractSyntaxTree
    VisitTypeSpecifierTypeof(BPPParser.TypeSpecifierTypeofContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitStructOrUnionSpecifier(BPPParser.StructOrUnionSpecifierContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitStructOrUnion(BPPParser.StructOrUnionContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitStructDeclarationList(BPPParser.StructDeclarationListContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitStructDeclaration(BPPParser.StructDeclarationContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitSpecifierQualifierListSpecifier(BPPParser.SpecifierQualifierListSpecifierContext context)
    {
      return new SpecifierQualifierListSpecifier(Visit(context.typeSpecifier()) as TypeSpecifier,
        context.specifierQualifierList() == null ? null : Visit(context.specifierQualifierList()) as SpecifierQualifierList);
    }

    public override AbstractSyntaxTree
    VisitSpecifierQualifierListQualifier(BPPParser.SpecifierQualifierListQualifierContext context)
    {
      return new SpecifierQualifierListQualifier(Visit(context.typeQualifier()) as TypeQualifier,
        context.specifierQualifierList() == null ? null : Visit(context.specifierQualifierList()) as SpecifierQualifierList);
    }

    public override AbstractSyntaxTree
    VisitStructDeclaratorList(BPPParser.StructDeclaratorListContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitStructDeclarator(BPPParser.StructDeclaratorContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitEnumSpecifier(BPPParser.EnumSpecifierContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitEnumeratorList(BPPParser.EnumeratorListContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitEnumerator(BPPParser.EnumeratorContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitEnumerationConstant(BPPParser.EnumerationConstantContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitAtomicTypeSpecifier(BPPParser.AtomicTypeSpecifierContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitTypeQualifier(BPPParser.TypeQualifierContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitFunctionSpecifier(BPPParser.FunctionSpecifierContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitAlignmentSpecifier(BPPParser.AlignmentSpecifierContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitDeclarator(BPPParser.DeclaratorContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitDirectDeclarator(BPPParser.DirectDeclaratorContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitGccDeclaratorExtension(BPPParser.GccDeclaratorExtensionContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitGccAttributeSpecifier(BPPParser.GccAttributeSpecifierContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitGccAttributeList(BPPParser.GccAttributeListContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitGccAttribute(BPPParser.GccAttributeContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitNestedParenthesesBlock(BPPParser.NestedParenthesesBlockContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitPointer(BPPParser.PointerContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitTypeQualifierList(BPPParser.TypeQualifierListContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitParameterTypeList(BPPParser.ParameterTypeListContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitParameterList(BPPParser.ParameterListContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitParameterDeclaration(BPPParser.ParameterDeclarationContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitIdentifierList(BPPParser.IdentifierListContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitTypeName(BPPParser.TypeNameContext context)
    {
      return new TypeName(Visit(context.specifierQualifierList()) as SpecifierQualifierList,
        context.abstractDeclarator() == null ? null : Visit(context.abstractDeclarator()) as AbstractDeclarator);
    }

    public override AbstractSyntaxTree
    VisitAbstractDeclarator(BPPParser.AbstractDeclaratorContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitDirectAbstractDeclarator(
      BPPParser.DirectAbstractDeclaratorContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitTypedefName(BPPParser.TypedefNameContext context)
    {
      return new TypedefName(context.Identifier().GetText());
    }

    public override AbstractSyntaxTree
    VisitInitializer(BPPParser.InitializerContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitInitializerList(BPPParser.InitializerListContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitDesignation(BPPParser.DesignationContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitDesignatorList(BPPParser.DesignatorListContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitDesignator(BPPParser.DesignatorContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitStaticAssertDeclaration(
      BPPParser.StaticAssertDeclarationContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitStatementLabeledStatement(BPPParser.StatementLabeledStatementContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitStatementCompoundStatement(BPPParser.StatementCompoundStatementContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitStatementExpressionStatement(BPPParser.StatementExpressionStatementContext context)
    {
      return new StatementExpressionStatement(Visit(context.expressionStatement()));
    }

    public override AbstractSyntaxTree
    VisitStatementSelectionStatement(BPPParser.StatementSelectionStatementContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitStatementIterationStatement(BPPParser.StatementIterationStatementContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitStatementJumpStatement(BPPParser.StatementJumpStatementContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitStatementAsmVolatile(BPPParser.StatementAsmVolatileContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitLabeledStatement(BPPParser.LabeledStatementContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitCompoundStatement(BPPParser.CompoundStatementContext context)
    {
      return new CompoundStatement(context.blockItemList() == null ? null : Visit(context.blockItemList()) as BlockItemList);
    }

    public override AbstractSyntaxTree
    VisitBlockItemList(BPPParser.BlockItemListContext context)
    {
      return new BlockItemList(context.blockItemList() == null ? null : Visit(context.blockItemList()) as BlockItemList,
        Visit(context.blockItem()) as BlockItem);
    }

    public override AbstractSyntaxTree
    VisitBlockItemDeclaration(BPPParser.BlockItemDeclarationContext context)
    {
      Console.WriteLine(context.GetText());
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitBlockItemStatement(BPPParser.BlockItemStatementContext context)
    {
      return new BlockItemStatement(Visit(context.statement()) as Statement);
    }

    public override AbstractSyntaxTree
    VisitExpressionStatement(BPPParser.ExpressionStatementContext context)
    {
      return new ExpressionStatement(context.expression() == null ? null : Visit(context.expression()) as Expression);
    }

    public override AbstractSyntaxTree
    VisitSelectionStatement(BPPParser.SelectionStatementContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitIterationStatement(BPPParser.IterationStatementContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitJumpStatement(BPPParser.JumpStatementContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitCompilationUnit(BPPParser.CompilationUnitContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitTranslationUnit(BPPParser.TranslationUnitContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitExternalDeclaration(BPPParser.ExternalDeclarationContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitFunctionDefinition(BPPParser.FunctionDefinitionContext context)
    {
      throw new NotImplementedException();
    }

    public override AbstractSyntaxTree
    VisitDeclarationList(BPPParser.DeclarationListContext context)
    {
      throw new NotImplementedException();
    }

  }
}
