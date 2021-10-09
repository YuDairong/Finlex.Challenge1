using NUnit.Framework;
using System;

namespace Finlex.Quiz1.Tests
{
    public class NestedArrayServiceTests
    {
        private NestedArrayService nestedArrayService;

        public NestedArrayServiceTests()
        {
            nestedArrayService = new NestedArrayService();
        }

        [Test]
        public void GetNumberAndSum_NullIsGiven_ReturnRightNestedArray()
        {
            var result = nestedArrayService.GetNumberAndSum(null);

            Assert.AreEqual(0, result.Length);
            Assert.AreEqual(0, result.Sum);
        }

        [Test]
        public void GetNumberAndSum_EmptyArrayIsGiven_ReturnRightNestedArray()
        {
            var result = nestedArrayService.GetNumberAndSum(new object[0]);

            Assert.AreEqual(0, result.Length);
            Assert.AreEqual(0, result.Sum);
        }

        [Test]
        public void GetNumberAndSum_NestedArrayWithStringIsGiven_ThrowException()
        {
            var testArray = new object[]
            {
                1,
                "test1",
                new object[]{0, 1, 5},
                new object[]{12, 1, 5, new object[]{4, 3}, 9 },
                11
            };


            Assert.Throws<Exception>(() => nestedArrayService.GetNumberAndSum(testArray));
        }

        [Test]
        public void GetNumberAndSum_NestedArrayWithBoolIsGiven_ThrowException()
        {
            var testArray = new object[]
            {
                1,
                true,
                11
            };


            Assert.Throws<Exception>(() => nestedArrayService.GetNumberAndSum(testArray));
        }

        [Test]
        public void GetNumberAndSum_NestedArrayIsGiven_Return10And53()
        {
            var testArray = new object[]
            {
                1,
                2,
                5,
                new object[]{12, 1, 5, new object[]{4, 3}, 9 },
                11
            };

            var result = nestedArrayService.GetNumberAndSum(testArray);

            Assert.AreEqual(10, result.Length);
            Assert.AreEqual(53, result.Sum);
        }

        [Test]
        public void GetNumberAndSum_NestedArray2IsGiven_Return13And54()
        {
            var testArray = new object[]
            {
                1,
                2,
                new object[]{0, 1, 5},
                new object[]{12, 1, 5, new object[]{4, 3}, 9 },
                11
            };

            var result = nestedArrayService.GetNumberAndSum(testArray);

            Assert.AreEqual(12, result.Length);
            Assert.AreEqual(54, result.Sum);
        }
    }
}