using NUnit.Framework;
using PyramidTraverseExercise.Elements.Contracts.Service.TwoDMatrice;
using PyramidTraverseExercise.Elements.Service.TwoDMatrice;

namespace PyramidTraverseExercise.UnitTest
{
    [TestFixture]
    public class TwoDMatricePathfinderUnitTest
    {
        private ITwoDMatrixPathfinderService _twoDMatrixPathfinderService;

        [SetUp]
        public void Setup()
        {
            _twoDMatrixPathfinderService = new TwoDMatrixPathfinderService();
        }

        [TestCase(0, ExpectedResult = 247)]
        [TestCase(1, ExpectedResult = 378)]
        [TestCase(2, ExpectedResult = 502)]
        [TestCase(3, ExpectedResult = 633)]
        [TestCase(4, ExpectedResult = 731)]
        public int GetHighestSum(int testDataIndex)
        {
            var matrix = TestData[testDataIndex];

            return _twoDMatrixPathfinderService.GetHighestPossibleSum(matrix);
        }

        private static int[][][] TestData => new[]
        {
            new[]
            {
                new[] {123}, new []{124, 125}
            },
            new[]
            {
                new[] {123}, new []{124, 126}, new[]{126,127,129}
            },
            new[]
            {
                new[] {123}, new []{124, 126}, new[]{125,123,128}, new [] {129,130,131,132}
            },
            new[]
            {
                new[] {123}, new []{124, 126}, new[]{127,127,127}, new [] {128,128,128,128}, new [] {129,129,129,129,129}
            },
            new[]
            {
                new[] {123}, new []{124, 126}, new[]{227,127,127}, new [] {128,128,128,128}, new [] {129,129,129,129,129}
            }
        };
    }
}
