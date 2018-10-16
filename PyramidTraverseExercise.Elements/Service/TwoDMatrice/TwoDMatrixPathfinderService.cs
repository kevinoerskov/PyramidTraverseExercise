using PyramidTraverseExercise.Common.Extensions;
using PyramidTraverseExercise.Elements.Contracts.Service.TwoDMatrice;
using PyramidTraverseExercise.Elements.Service.TwoDMatrice.Entity;

namespace PyramidTraverseExercise.Elements.Service.TwoDMatrice
{
    public class TwoDMatrixPathfinderService : ITwoDMatrixPathfinderService
    {
        public int GetHighestPossibleSum(int[][] matrix)
        {
            var phantomMatrix = matrix.Copy();

            for (var rowIndex = matrix.Length - 2; rowIndex >= 0; rowIndex--)
            {
                var row = matrix[rowIndex];

                for (var columnIndex = 0; columnIndex < row.Length; columnIndex++)
                {
                    var currentValue = matrix[rowIndex][columnIndex];

                    var phantomChildLeft = GetPhantomChildElement(
                        ref matrix,
                        ref phantomMatrix,
                        rowIndex + 1,
                        columnIndex);

                    var phantomChildRight = GetPhantomChildElement(
                        ref matrix,
                        ref phantomMatrix,
                        rowIndex + 1,
                        columnIndex + 1);

                    var childHasToBeEven = currentValue.IsEven() == false;
                    var highestValueChild = FindHighestValueChild(
                        phantomChildLeft,
                        phantomChildRight,
                        childHasToBeEven);

                    var currentPhantomValue = phantomMatrix[highestValueChild.RowIndex][highestValueChild.ColumnIndex];
                    phantomMatrix[rowIndex][columnIndex] = currentValue + currentPhantomValue;
                }
            }

            var highestSumPath = phantomMatrix[0][0];

            return highestSumPath;
        }

        private static MatrixPhantomChildElement GetPhantomChildElement(
            ref int[][] matrix,
            ref int[][] phantomMatrix,
            int rowIndex,
            int columnIndex)
        {
            var childElement = GetChildElement(ref matrix, rowIndex, columnIndex);
            var phantomChildValue = phantomMatrix[childElement.RowIndex][childElement.ColumnIndex];
            var phantomChildElement = new MatrixPhantomChildElement(childElement, phantomChildValue);

            return phantomChildElement;
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
            MatrixPhantomChildElement childLeft,
            MatrixPhantomChildElement childRight,
            bool childHasToBeEven)
        {
            var finalChildLeft = GetChildElementOrDefault(childLeft, childHasToBeEven);
            var finalChildRight = GetChildElementOrDefault(childRight, childHasToBeEven);

            return finalChildLeft.Value >= finalChildRight.Value
                ? finalChildLeft
                : finalChildRight;
        }

        private static MatrixChildElement GetChildElementOrDefault(
            MatrixPhantomChildElement childElement,
            bool childHasToBeEven)
        {
            var childElementValue = childElement.OriginalValue.IsEven() == childHasToBeEven
                ? childElement.PhantomValue
                : 0;

            return new MatrixChildElement(
                childElementValue,
                childElement.RowIndex,
                childElement.ColumnIndex);
        }
    }
}