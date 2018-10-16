namespace PyramidTraverseExercise.Common.Extensions
{
    public static class IntExtensions
    {
        public static bool IsEven(this int sourceValue)
        {
            return sourceValue % 2 == 0;
        }
    }
}