using System;
using System.Linq;
using System.Linq.Expressions;

namespace CultureRecommendation.Infraestructure
{

    public static class Query
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string sortingColumn, bool isAscending)
        {
            if (string.IsNullOrEmpty(sortingColumn))
            {
                return source;
            }

            ParameterExpression parameter = Expression.Parameter(source.ElementType, string.Empty);
            if (parameter.Type.GetProperty(sortingColumn) == null)
            {
                return source;
            }

            MemberExpression property = Expression.Property(parameter, sortingColumn);
            LambdaExpression lambda = Expression.Lambda(property, parameter);

            string methodName = isAscending ? "OrderBy" : "OrderByDescending";

            Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                                new Type[] { source.ElementType, property.Type },
                                                source.Expression, Expression.Quote(lambda));

            return source.Provider.CreateQuery<T>(methodCallExpression);
        }

    }

}
