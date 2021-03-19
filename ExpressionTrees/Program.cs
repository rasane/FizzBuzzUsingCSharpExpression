using System;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "input number");
            ConstantExpression constantExpression = Expression.Constant(5, typeof(int));
            BinaryExpression binaryExpression = Expression.LessThan(parameterExpression, constantExpression);
            Expression<Func<int, bool>> numberLessThan5 =
                Expression.Lambda<Func<int, bool>>(binaryExpression, new ParameterExpression[] {parameterExpression});

            var compiledExpression = numberLessThan5.Compile();

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"{i}: {compiledExpression(i)}");
            }

        }
    }
}
