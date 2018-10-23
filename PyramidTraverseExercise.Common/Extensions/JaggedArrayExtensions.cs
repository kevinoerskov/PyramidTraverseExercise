namespace PyramidTraverseExercise.Common.Extensions
{
    public static class JaggedArrayExtensions
    {
        public static T[][] Copy<T>(this T[][] sourceJaggedArray)
        {
            var copyJaggedArray = new T[sourceJaggedArray.Length][];

            for (var i = 0; i < sourceJaggedArray.Length; i++)
            {
                copyJaggedArray[i] = new T[sourceJaggedArray[i].Length];

                for (var j = 0; j < sourceJaggedArray[i].Length; j++)
                {
                    copyJaggedArray[i][j] = sourceJaggedArray[i][j];
                }
            }

            return copyJaggedArray;
        }
    }
}