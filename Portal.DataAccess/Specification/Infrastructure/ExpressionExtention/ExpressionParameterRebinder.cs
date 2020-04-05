namespace Portal.DataAccess
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    internal class ExpressionParameterRebinder : ExpressionVisitor
    {
        private Dictionary<ParameterExpression, Expression> ParameterMap { get; }

        public ExpressionParameterRebinder(Dictionary<ParameterExpression, Expression> parameterMap)
        {
            ParameterMap = parameterMap;
        }

        protected override Expression VisitParameter(ParameterExpression parameter)
        {
            return ParameterMap
                .TryGetValue(parameter, out var replacement)
                ? replacement
                : parameter;
        }
    }
}