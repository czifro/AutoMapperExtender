using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperExtender.Parsers;

namespace AutoMapperExtender
{
    public static class AutoMapperExtender
    {
        public static IMappingExpression<TSource, TDestination> IgnoreExtraProperties<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            foreach (var property in Mapper.GetAllTypeMaps()
                                      .First(x => x.SourceType == typeof(TSource) && x.DestinationType == typeof(TDestination))
                                      .GetUnmappedPropertyNames())
            {
                expression.ForMember(property, opt => opt.Ignore());
            }
            return expression;
        }

        public static IMappingExpression<TSource, TDestination> FromSourceProperty<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression,
            Expression<Func<TSource, object>> propertyExpression)
        {
            IExpressionInvoker invoker = new ExpressionInvoker();
            foreach (var property in Mapper.GetAllTypeMaps()
                                      .First(x => x.SourceType == typeof(TSource) && x.DestinationType == typeof(TDestination))
                                      .GetUnmappedPropertyNames())
            {
                expression.ForMember(property, opt => opt.ResolveUsing(src => invoker.InvokeFunctionExpression(propertyExpression, src, property)));
            }
            return expression;
        }

        public static object Test<TSource>(MemberExpression expression, Func<TSource, object> func, TSource src, string propertyName)
        {
            var obj = func(src);

            var type = obj.GetType();
            var property = type.GetProperty(propertyName);
            var val = property.GetValue(obj);


            return null;
        }
    }
}
