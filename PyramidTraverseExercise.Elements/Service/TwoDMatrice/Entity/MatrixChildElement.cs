namespace PyramidTraverseExercise.Elements.Service.TwoDMatrice.Entity
{
    public class MatrixChildElement
    {
        public int Value { get; }
        public int RowIndex { get; }
        public int ColumnIndex { get; }

        public MatrixChildElement(
            int value,
            int rowIndex,
            int columnIndex)
        {
            Value = value;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }
    }
}