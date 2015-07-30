using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperExtender.Parsers
{
    public class ExpressionInvoker : IExpressionInvoker
    {
        public TOut InvokeFunctionExpression<TIn, TOut>(Expression<Func<TIn, TOut>> expression, TIn src, string propertyName)
        {
            var func = expression.Compile();
            return InvokeFunction(func, src, propertyName);
        }

        public TOut InvokeFunction<TIn, TOut>(Func<TIn, TOut> function, TIn src, string propertyName)
        {
            var obj = function(src);

            var type = obj.GetType();
            var property = type.GetProperty(propertyName);
            var val = property.GetValue(obj);

            return (TOut) val;
        }
    }
}
