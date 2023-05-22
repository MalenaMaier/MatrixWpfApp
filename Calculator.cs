using Matrix.Enums;
using System;
using System.Collections.Generic;

namespace Matrix
{
    internal class Calculator
    {
        internal List<List<int>> Calculate(List<List<int>> matrixOne, List<List<int>> matrixTwo, OperationEnum selectedOperation)
        {
            switch (selectedOperation)
            {
                case OperationEnum.addition: return AddUp(matrixOne, matrixTwo);
                case OperationEnum.substraction: return Substract(matrixOne, matrixTwo);
                case OperationEnum.multiplication: return Multiply(matrixOne, matrixTwo);
                case OperationEnum.division: return Divide(matrixOne, matrixTwo);
                default: return null;
            }
        }

        private List<List<int>> Divide(List<List<int>> matrixOne, List<List<int>> matrixTwo)
        {
            throw new NotImplementedException();
        }

        private List<List<int>> Multiply(List<List<int>> matrixOne, List<List<int>> matrixTwo)
        {
            throw new NotImplementedException();
        }

        private List<List<int>> Substract(List<List<int>> matrixOne, List<List<int>> matrixTwo)
        {
            throw new NotImplementedException();
        }

        private List<List<int>> AddUp(List<List<int>> matrixOne, List<List<int>> matrixTwo)
        {
            throw new NotImplementedException();
        }
    }
}
