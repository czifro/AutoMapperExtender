using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

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

        public static IMappingExpression<TSource, TDestination> MapFromProperty<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression,
            Expression<Func<TSource, object>> propertyExpression)
        {
            var thisMap = Mapper.GetAllTypeMaps()
                .First(x => x.SourceType == typeof (TSource) && x.DestinationType == typeof (TDestination));
            thisMap.
            var memberExpression = (MemberExpression) propertyExpression.Body;
            var val = Expression.Parameter(propertyExpression.Body.Type);
            var srcExpr = memberExpression.Expression;
            var srcObj = Expression.Convert(srcExpr, typeof (TSource));
            
            var getter = propertyExpression.Compile();
            //var src = getter();

            return expression;
        } 
    }
}
