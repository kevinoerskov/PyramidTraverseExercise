namespace PyramidTraverseExercise.Elements.Service.TwoDMatrice.Entity
{
    public class MatrixAccumulatedChildElement
    {
        public int OriginalValue { get; }
        public int AccumulatedValue { get; }
        public int RowIndex { get; }
        public int ColumnIndex { get; }

        public MatrixAccumulatedChildElement(
            MatrixChildElement childElement,
            int accumulatedValue)
        {
            OriginalValue = childElement.Value;
            AccumulatedValue = accumulatedValue;
            RowIndex = childElement.RowIndex;
            ColumnIndex = childElement.ColumnIndex;
        }
    }
}