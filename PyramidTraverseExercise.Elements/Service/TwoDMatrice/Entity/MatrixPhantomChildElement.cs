namespace PyramidTraverseExercise.Elements.Service.TwoDMatrice.Entity
{
    public class MatrixPhantomChildElement
    {
        public int OriginalValue { get; }
        public int PhantomValue { get; }
        public int RowIndex { get; }
        public int ColumnIndex { get; }

        public MatrixPhantomChildElement(
            MatrixChildElement childElement,
            int phantomValue)
        {
            OriginalValue = childElement.Value;
            PhantomValue = phantomValue;
            RowIndex = childElement.RowIndex;
            ColumnIndex = childElement.ColumnIndex;
        }
    }
}