﻿namespace Portal.DataAccess
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public static class ExpressionExtenstions
    {
        public static Expression<T> Combine<T>(
            this Expression<T> leftExpression, Expression<T> rightExpression,
            Func<Expression, Expression, Expression> mergeFunction)
        {
            if (leftExpression == null)
            {
                throw new ArgumentException(nameof(leftExpression));
            }
            if (rightExpression == null)
            {
                throw new ArgumentException(nameof(rightExpression));
            }
            if (mergeFunction == null)
            {
                throw new ArgumentException(nameof(mergeFunction));
            }

            if (leftExpression.Parameters.Count != rightExpression.Parameters.Count)
            {
                throw new ArgumentException("Parameters count in expressions not equal");
            }

            var parametersMap = rightExpression.Parameters
                .Select((rightParamener, index) => new {
                    rightParamener,
                    leftParameter = leftExpression.Parameters[index]
                })
                .ToDictionary(relation => relation.rightParamener, relation => (Expression)relation.leftParameter);

            foreach (var parameterItem in parametersMap)
            {
                if (parameterItem.Key.Type != parameterItem.Value.Type)
                {
                    throw new ArgumentException("Parameters types not equal");
                }
            }

            var rightExpressionBody = new ExpressionParameterRebinder(parametersMap).Visit(rightExpression.Body);

            return Expression.Lambda<T>(mergeFunction(leftExpression.Body, rightExpressionBody), leftExpression.Parameters);
        }
    }
}