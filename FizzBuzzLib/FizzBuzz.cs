using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace FizzBuzzLib
{
    public class FizzBuzz
    {
        private Func<int, bool> _compiledIsFizz;
        private Func<int, bool> _compiledIsBuzz;
        private Func<int, bool> _isFizzBuzzExpression;

        public FizzBuzz()
        {
            var parameter = Expression.Parameter(typeof(int), "input number");
            var (isFizz , isFizzExpression)= CreateLogicFunctionToCheckFor(3, parameter);
            var (isBuzz , isBuzzExpression) = CreateLogicFunctionToCheckFor(5, parameter);
            var isFizzBuzzExpression = Expression.AndAlso(isFizzExpression , isBuzzExpression);
            Expression<Func<int, bool>> lambdaIsFizzBuzzExpression =
                Expression.Lambda<Func<int, bool>>(isFizzBuzzExpression,
                new ParameterExpression[]
                {
                    parameter
                });

            _isFizzBuzzExpression = lambdaIsFizzBuzzExpression.Compile();
            _compiledIsFizz = isFizz.Compile();
            _compiledIsBuzz = isBuzz.Compile();
        }

        private (Expression<Func<int, bool>>, BinaryExpression) CreateLogicFunctionToCheckFor(int constant, ParameterExpression parameter)
        {
            BinaryExpression binaryExpressionEqualsZero = GetModuloCheckExpressionFor(constant, parameter);
            var isFizzEqualsZero = Expression.Lambda<Func<int, bool>>(
                binaryExpressionEqualsZero,
                new ParameterExpression[] {parameter});

            return (isFizzEqualsZero, binaryExpressionEqualsZero);
            
        }

        private static BinaryExpression GetModuloCheckExpressionFor(int constant, ParameterExpression parameterExpression)
        {
            var constantExpression = Expression.Constant(constant);
            var moduloExpression = Expression.Modulo(parameterExpression, constantExpression);

            var constZero = Expression.Constant(0);

            return Expression.Equal(moduloExpression, constZero);
        }

        public string Echo(int i)
        {
            Console.WriteLine(_compiledIsFizz(i));
            if (_isFizzBuzzExpression(i))
            {
                return "FizzBuzz";
            }
            if (_compiledIsFizz(i) )
            {
                return "Fizz";
            }

            if (_compiledIsBuzz(i))
            {
                return "Buzz";
            }

            return i.ToString();
        }
    }
}
