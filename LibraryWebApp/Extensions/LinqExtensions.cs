using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace LibraryWebApp.Extensions
{
    public static class LinqExtensions
    {
        //public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> query, string name)
        //{
        //    var propInfo = GetPropertyInfo(typeof(T), name);
        //    var expr = GetOrderExpression(typeof(T), propInfo);

        //    var method = typeof(Enumerable).GetMethods().FirstOrDefault(m => m.Name == "OrderBy" && m.GetParameters().Length == 2);
        //    var genericMethod = method.MakeGenericMethod(typeof(T), propInfo.PropertyType);
        //    return (IEnumerable<T>)genericMethod.Invoke(null, new object[] { query, expr.Compile() });
        //}

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string name) => 
            query.OrderByWithDirection(name, false);


        public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string name) => 
            query.OrderByWithDirection(name, true);


        private static IQueryable<T> OrderByWithDirection<T>(this IQueryable<T> query, string name, bool isDesc)
        {
            var propInfo = GetPropertyInfo(typeof(T), name);
            var expr = GetOrderExpression(typeof(T), propInfo);
            var methodName = isDesc ? "OrderByDescending" : "OrderBy";
            var method = typeof(Queryable).GetMethods().FirstOrDefault(m => m.Name == methodName
                                                                            && m.GetParameters().Length == 2);
            var genericMethod = method.MakeGenericMethod(typeof(T), propInfo.PropertyType);
            return (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, expr });
        }

        private static PropertyInfo GetPropertyInfo(Type objType, string name)
        {
            var properties = objType.GetProperties();
            var matchedProperty = properties.FirstOrDefault(p => p.Name == name);
            if (matchedProperty == null)
            {
                throw new ArgumentException("name");
            }

            return matchedProperty;
        }
        private static LambdaExpression GetOrderExpression(Type objType, PropertyInfo pi)
        {
            var paramExpr = Expression.Parameter(objType);
            var propAccess = Expression.PropertyOrField(paramExpr, pi.Name);
            var expr = Expression.Lambda(propAccess, paramExpr);
            return expr;
        }

    }
}
