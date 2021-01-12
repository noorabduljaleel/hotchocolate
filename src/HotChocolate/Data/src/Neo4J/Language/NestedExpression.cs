namespace HotChocolate.Data.Neo4J.Language
{
    public class NestedExpression : Expression
    {
        public override ClauseKind Kind => ClauseKind.NestedExpression;
        private readonly Expression _expression;

        public NestedExpression(Expression expression)
        {
            _expression = expression;
        }

        public override void Visit(CypherVisitor visitor)
        {
            visitor.Enter(this);
            Expressions.NameOrExpression(_expression).Visit(visitor);
            visitor.Leave(this);
        }
    }
}