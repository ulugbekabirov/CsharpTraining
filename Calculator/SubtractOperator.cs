﻿using System.Numerics;

namespace Calculator
{
    public class SubtractOperator : IOperator
    {
        public decimal doOperation(decimal num1, decimal num2)
        {
            return num1 - num2;
        }
    }
}
