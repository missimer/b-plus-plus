using System;

namespace Compiler.Lib
{
  public class GenericAssocList : AbstractSyntaxTree
  {

    public GenericAssocList(GenericAssociation item) : base(item, null)
    {
    }

    public GenericAssocList(GenericAssocList list, GenericAssociation item) : base(item, list)
    {
    }

    public GenericAssociation Item { get { return _children[0] as GenericAssociation; } }

    public GenericAssocList List { get { return _children[1] as GenericAssocList; } }
  }
}

