namespace PyramidTraverseExercise.Common.Extensions
{
    public static class JaggedIntArrayExtensions
    {
        public static int[][] Copy(this int[][] sourceJaggedIntArray)
        {
            var copyJaggedIntArray = new int[sourceJaggedIntArray.Length][];

            for (var i = 0; i < sourceJaggedIntArray.Length; i++)
            {
                copyJaggedIntArray[i] = new int[sourceJaggedIntArray[i].Length];

                for (var j = 0; j < sourceJaggedIntArray[i].Length; j++)
                {
                    copyJaggedIntArray[i][j] = sourceJaggedIntArray[i][j];
                }
            }

            return copyJaggedIntArray;
        }
    }
}