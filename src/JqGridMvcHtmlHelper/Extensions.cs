using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JqGridMvcHtmlHelper.Models;

namespace JqGridMvcHtmlHelper
{
    public static class Extensions
    {
        public static IQueryable<T> Where<T>(this IQueryable<T> query, JqGridRule[] rules, GrpOperation groupOp)
        {
            Expression resultCondition = null;

            var parameter = Expression.Parameter(query.ElementType, "p");

            foreach (var rule in rules)
            {
                if (string.IsNullOrEmpty(rule.Field)) continue;

                var memberAccess = rule.Field.Split('.').Aggregate<string, MemberExpression>(null, 
                    (current, property) => Expression.Property(current ?? (parameter as Expression), property));

                var filter = Expression.Constant(StringToType(rule.Data, memberAccess.Type));

                Expression e1 = memberAccess;
                Expression e2 = filter;
                if (IsNullableType(e1.Type) && !IsNullableType(e2.Type)) e2 = Expression.Convert(e2, e1.Type);
                else if (!IsNullableType(e1.Type) && IsNullableType(e2.Type)) e1 = Expression.Convert(e1, e2.Type);

                Expression condition;
                switch (rule.OpEnum)
                {
                    case WhereOperation.Eq:
                        condition = Expression.Equal(e1, e2);
                        break;
                    case WhereOperation.Ne:
                        condition = Expression.NotEqual(e1, e2);
                        break;
                    case WhereOperation.Gt:
                        condition = Expression.GreaterThan(e1, e2);
                        break;
                    case WhereOperation.Ge:
                        condition = Expression.GreaterThanOrEqual(e1, e2);
                        break;
                    case WhereOperation.Lt:
                        condition = Expression.LessThan(e1, e2);
                        break;
                    case WhereOperation.Le:
                        condition = Expression.LessThanOrEqual(e1, e2);
                        break;
                    case WhereOperation.Cn:
                        condition = Expression.Call(
                            memberAccess,
                            typeof(string).GetMethod("Contains"),
                            Expression.Constant(rule.Data));
                        break;
                    case WhereOperation.Bw:
                        condition = Expression.Call(
                            memberAccess,
                            typeof(string).GetMethod("StartsWith", new[] { typeof(string) }),
                            Expression.Constant(rule.Data));
                        break;
                    case WhereOperation.Ew:
                        condition = Expression.Call(
                            memberAccess,
                            typeof(string).GetMethod("EndsWith", new[] { typeof(string) }),
                            Expression.Constant(rule.Data));
                        break;
                    case WhereOperation.Nc:
                        condition = Expression.Not(
                            Expression.Call(
                                memberAccess,
                                typeof(string).GetMethod("Contains"),
                                Expression.Constant(rule.Data)));
                        break;
                    case WhereOperation.Bn:
                        condition = Expression.Not(
                            Expression.Call(
                                memberAccess,
                                typeof(string).GetMethod("StartsWith", new[] { typeof(string) }),
                                Expression.Constant(rule.Data)));
                        break;
                    case WhereOperation.En:
                        condition = Expression.Not(
                            Expression.Call(
                                memberAccess,
                                typeof(string).GetMethod("EndsWith", new[] { typeof(string) }),
                                Expression.Constant(rule.Data)));
                        break;

                    default: continue;
                }
                if (groupOp == GrpOperation.Or)
                {
                    resultCondition = resultCondition != null ? Expression.Or(resultCondition, condition) : condition;
                }
                else
                {
                    resultCondition = resultCondition != null ? Expression.And(resultCondition, condition) : condition;
                }
            }

            var lambda = Expression.Lambda(resultCondition, parameter);

            var result = Expression.Call(
                typeof(Queryable),
                "Where",
                new[] { query.ElementType },
                query.Expression,
                lambda);
            return query.Provider.CreateQuery<T>(result);
        }

        public static object StringToType(string value, Type propertyType)
        {
            var underlyingType = Nullable.GetUnderlyingType(propertyType);
            if (underlyingType == null)
            {
                return Convert.ChangeType(value, propertyType, System.Globalization.CultureInfo.InvariantCulture);
            }

            return string.IsNullOrEmpty(value)
                       ? null
                       : Convert.ChangeType(value, underlyingType, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static string ToJqGridSelectValues(this IEnumerable<KeyValuePair<int, string>> keyValuePairs)
        {
            return string.Join(";", keyValuePairs.Select(k => string.Format("{0}:{1}", k.Key, k.Value)));
        }

        static bool IsNullableType(Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}