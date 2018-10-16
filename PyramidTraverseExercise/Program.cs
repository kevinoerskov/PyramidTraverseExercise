using Newtonsoft.Json;
using PyramidTraverseExercise.Elements.Contracts.Provider;
using PyramidTraverseExercise.Elements.Contracts.Service.TwoDMatrice;
using PyramidTraverseExercise.Elements.Provider;
using PyramidTraverseExercise.Elements.Service.TwoDMatrice;
using System;

namespace PyramidTraverseExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * Right now this provider provides a hardcoded matrix,
             * but we could easily switch to another implementation that reads from an external source
             * due to the interface abstraction.
             */
            ITwoDMatrixProvider matrixProvider = new TwoDMatrixProvider();
            ITwoDMatrixPathfinderService matrixPathfinderService = new TwoDMatrixPathfinderService();

            var matrice = matrixProvider.Get2DMatrice();

            var highestSum = matrixPathfinderService.GetHighestPossibleSum(matrice);

            Console.WriteLine($"The matrix looks like this: {JsonConvert.SerializeObject(matrice)}. \n");

            Console.WriteLine($"The highest possible sum is: {highestSum}. \n");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
