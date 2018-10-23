using PyramidTraverseExercise.Common.Extensions;
using PyramidTraverseExercise.Elements.Contracts.Service.TwoDMatrice;
using PyramidTraverseExercise.Elements.Service.TwoDMatrice.Entity;

namespace PyramidTraverseExercise.Elements.Service.TwoDMatrice
{
    public class TwoDMatrixPathfinderService : ITwoDMatrixPathfinderService
    {
        public int GetHighestPossibleSum(int[][] matrix)
        {
            var accumulatedScoreMatrix = matrix.Copy();

            for (var rowIndex = matrix.Length - 2; rowIndex >= 0; rowIndex--)
            {
                var row = matrix[rowIndex];

                for (var columnIndex = 0; columnIndex < row.Length; columnIndex++)
                {
                    var currentValue = matrix[rowIndex][columnIndex];

                    var accumulatedChildLeft = GetAccumulatedChildElement(
                        ref matrix,
                        ref accumulatedScoreMatrix,
                        rowIndex + 1,
                        columnIndex);

                    var accumulatedChildRight = GetAccumulatedChildElement(
                        ref matrix,
                        ref accumulatedScoreMatrix,
                        rowIndex + 1,
                        columnIndex + 1);

                    var childHasToBeEven = currentValue.IsEven() == false;
                    var highestValueChild = FindHighestValueChild(
                        accumulatedChildLeft,
                        accumulatedChildRight,
                        childHasToBeEven);

                    var currentAccumulatedValue = accumulatedScoreMatrix[highestValueChild.RowIndex][highestValueChild.ColumnIndex];
                    accumulatedScoreMatrix[rowIndex][columnIndex] = currentValue + currentAccumulatedValue;
                }
            }

            var highestSumPath = accumulatedScoreMatrix[0][0];

            return highestSumPath;
        }

        private static MatrixAccumulatedChildElement GetAccumulatedChildElement(
            ref int[][] matrix,
            ref int[][] accumulatedScoreMatrix,
            int rowIndex,
            int columnIndex)
        {
            var childElement = GetChildElement(ref matrix, rowIndex, columnIndex);
            var accumulatedChildValue = accumulatedScoreMatrix[childElement.RowIndex][childElement.ColumnIndex];
            var accumulatedChildElement = new MatrixAccumulatedChildElement(childElement, accumulatedChildValue);

            return accumulatedChildElement;
        }

        private static MatrixChildElement GetChildElement(
            ref int[][] matrix,
            int rowIndex,
            int columnIndex)
        {
            var value = matrix[rowIndex][columnIndex];

            return new MatrixChildElement(value, rowIndex, columnIndex);
        }

        private static MatrixChildElement FindHighestValueChild(
            MatrixAccumulatedChildElement childLeft,
            MatrixAccumulatedChildElement childRight,
            bool childHasToBeEven)
        {
            var finalChildLeft = GetChildElementOrDefault(childLeft, childHasToBeEven);
            var finalChildRight = GetChildElementOrDefault(childRight, childHasToBeEven);

            return finalChildLeft.Value >= finalChildRight.Value
                ? finalChildLeft
                : finalChildRight;
        }

        private static MatrixChildElement GetChildElementOrDefault(
            MatrixAccumulatedChildElement childElement,
            bool childHasToBeEven)
        {
            var childElementValue = childElement.OriginalValue.IsEven() == childHasToBeEven
                ? childElement.AccumulatedValue
                : 0;

            return new MatrixChildElement(
                childElementValue,
                childElement.RowIndex,
                childElement.ColumnIndex);
        }
    }
}