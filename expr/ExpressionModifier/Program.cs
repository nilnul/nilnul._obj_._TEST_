using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace ExpressionModifier
{
    public class MyExpressionVisitor : ExpressionVisitor
    {
        string _varName = "t";

        public ParameterExpression shiftExpression = Expression.Parameter(typeof(double), "shift");

        public Expression Modify(LambdaExpression expression)
        {
            SubstExpression = Expression.Add(expression.Parameters[0], shiftExpression);

            return Visit(expression);
        }

        Expression SubstExpression = null;

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Expression left = null, right = null;
            bool substLeft = false;
            bool substRight = false;

            if (node.Left is ParameterExpression)
            {
                left = SubstExpression;
                substLeft = true;
            }
            else
                left = node.Left;

            if (node.Right is ParameterExpression)
            {
                right = SubstExpression;
                substRight = true;
            }
            else
                right = node.Right;

            if (substLeft || substRight)
            {
                if (!substLeft)
                {
                    left = Visit(left);
                }

                if (!substRight)
                {
                    right = Visit(right);
                }

                return Expression.MakeBinary(node.NodeType, left, right, node.IsLiftedToNull, node.Method);
            }

            return base.VisitBinary(node);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<double, double>> e =
                //(t) => (2 + t) * t + (t + 1) * t;
                (t) => (1 - t) * (1 - t) * (1 - t) * (-50) +
                        3 * (1 - t) * (1 - t) * t * (-25) +
                        3 * (1 - t) * t * t * 25 +
                        t * t * t * 50;
                 /*
            MyExpressionVisitor myExVis = new MyExpressionVisitor();

            Expression<Func<double, double>> e1 = 
                (Expression<Func<double, double>>) myExVis.Modify(e);

            Expression e2 = 
                Expression.Lambda
                (
                    e1.Body,
                    new ParameterExpression[]
                    {
                        e.Parameters[0],
                        myExVis.shiftExpression
                    });

            var d = (e2 as LambdaExpression).Compile();

            Func<double, double, double> d1 = (Func<double, double, double>)d;

            Console.WriteLine(d.DynamicInvoke(0.1, 0.3));
            Console.WriteLine(e);
            Console.WriteLine(e2);
            */

            Expression<Func<double, double, double, double>> substExpr = (t, shift, factor) => t * factor + shift;

            LambdaExpression e1 = e.Substitute("t", substExpr);

            Console.WriteLine(e);
            Console.WriteLine(e1);

            Func<double, double, double, double> resultFunc = e1.Compile() as Func<double, double, double, double>;

            Console.WriteLine(resultFunc(10, 3, 5));
        }
    }
}
