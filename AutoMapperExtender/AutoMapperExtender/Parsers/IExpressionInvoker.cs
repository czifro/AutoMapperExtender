using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperExtender.Parsers
{
    public interface IExpressionInvoker
    {
        TOut InvokeFunctionExpression<TIn, TOut>(Expression<Func<TIn, TOut>> expression, TIn src, string propertyName);

        TOut InvokeFunction<TIn, TOut>(Func<TIn, TOut> function, TIn src, string propertyName);
    }
}
