using System;
using System.Collections.Generic;
using Extensions;
using NUnit.Framework;
using FluentAssertions;

namespace ExtensionsTests
{
    public class Tests
    {
        [Test]
        public void Map_does_not_change_anything_if_the_input_function_is_identical()
        {
            var inputEnumerable = new[] {42, 2000, 1900};

            var resultEnumerable = inputEnumerable.Map(item => item);

            resultEnumerable.Should().Equal(42, 2000, 1900);
        }

        private static object[] _mapCasesWithDifferentTypes =
        {
            new object[]
            {
                new[] {"I", "am", "here", "help", "me", ""}, new Func<string, int>(item => item.Length),
                new[] {1, 2, 4, 4, 2, 0}
            },
            
            new object[]
            {
                new[] {"12", "42", "0"}, new Func<string, int>(int.Parse),
                new[] {12, 42, 0}
            },
        };

        [TestCaseSource(nameof(_mapCasesWithDifferentTypes))]
        public void
            Map_should_work_correctly_if_the_type_of_the_input_value_of_the_function_is_different_from_the_result(
                IEnumerable<string> inputEnumerable, Func<string, int> func, IEnumerable<int> resultEnumerable)
        {
            inputEnumerable.Map(func).Should().Equal(resultEnumerable);
        }

        private static object[] _mapCasesWithSameType =
        {
            new object[]
            {
                new[] {12, 42, 1300}, new Func<int, int>(item => item * 2),
                new[] {24, 84, 2600}
            },

            new object[]
            {
                new[] {12, 42, 1300}, new Func<int, int>(item => 0),
                new[] {0, 0, 0}
            }
        };

        [TestCaseSource(nameof(_mapCasesWithSameType))]
        public void Map_should_work_correctly_if_the_input_type_of_the_function_is_the_same_as_the_result(
            IEnumerable<int> inputEnumerable, Func<int, int> func, IEnumerable<int> resultEnumerable)
        {
            inputEnumerable.Map(func).Should().Equal(resultEnumerable);
        }

        [Test]
        public void Map_must_support_method_chaining()
        {
            var inputEnumerable = new[] {12, 42, 1300};

            inputEnumerable
                .Map(item => item * 2)
                .Map(item => item * 3)
                .Map(item => item)
                .Should().Equal(72, 252, 7800);
        }

        [Test]
        public void Filter_should_not_change_anything_if_input_function_always_return_true()
        {
            var inputEnumerable = new[] {12, 42, 1300};

            inputEnumerable.Filter(item => true).Should().Equal(inputEnumerable);
        }

        [Test]
        public void Filter_should_return_empty_enumerable_if_input_function_always_return_false()
        {
            var inputEnumerable = new[] {12, 42, 1300};

            inputEnumerable.Filter(item => false).Should().BeEmpty();
        }

        private static object[] _filterCases =
        {
            new object[]
            {
                new[] {12, 1337, 42}, new Func<int, bool>(item => item % 2 == 0),
                new[] {12, 42}
            },

            new object[]
            {
                new[] {12, 42, 54, 1337}, new Func<int, bool>(item => Math.Pow(item, 2) <= 2000),
                new[] {12, 42}
            }
        };

        [TestCaseSource(nameof(_filterCases))]
        public void Filter_should_work_correctly_on_standard_scripts(IEnumerable<int> inputEnumerable,
            Func<int, bool> func, IEnumerable<int> resultEnumerable)
        {
            inputEnumerable.Filter(func).Should().Equal(resultEnumerable);
        }

        [Test]
        public void Filter_must_support_method_chaining()
        {
            var inputEnumerable = new[] {12, 42, 1300, 2001, 54};

            inputEnumerable
                .Filter(item => item >= 54)
                .Filter(item => item % 2 == 0)
                .Should().Equal(1300, 54);
        }

        [Test]
        public void Filter_and_map_together_should_work_correctly_on_standard_scripts()
        {
            var inputEnumerable = new[] {1, 3, 5, 10, 7, 9};

            inputEnumerable
                .Filter(item => item % 2 == 1)
                .Map(item => item * 2)
                .Filter(item => item > 6)
                .Should().Equal(10, 14, 18);
        }

        [Test]
        public void Fold_should_not_change_starting_accumulate_value_if_input_function_does_nothing()
        {
            var inputEnumerable = new[] {12, 42, 1300, 2001, 54};

            inputEnumerable.Fold(12.5, (acc, item) => acc)
                .Should().Be(12.5);
        }

        private static object[] _foldCasesWithDifferentTypes =
        {
            new object[]
            {
                new[] {"I", "am", "here"}, 0,
                new Func<int, string, int>((currentSeed, item) => currentSeed + item.Length), 7
            },

            new object[]
            {
                new[] {"A", "long", "text"}, 0,
                new Func<int, string, int>((currentSeed, item) => currentSeed + item[0]), 'A' + 'l' + 't'
            }
        };

        [TestCaseSource(nameof(_foldCasesWithDifferentTypes))]
        public void
            Fold_should_work_correctly_if_the_type_of_the_input_value_of_the_function_is_different_from_the_result(
                IEnumerable<string> inputEnumerable, int seed, Func<int, string, int> func, int result)
        {
            inputEnumerable.Fold(seed, func).Should().Be(result);
        }

        private static object[] _foldCasesWithSameTypes =
        {
            new object[]
            {
                new[] {1, 3, 5}, 0,
                new Func<int, int, int>((currentSeed, item) => currentSeed + item * item), 35
            },

            new object[]
            {
                new[] {1, 3, 5, -12}, 12,
                new Func<int, int, int>((currentSeed, item) => currentSeed % 5 + item), -11
            }
        };

        [TestCaseSource(nameof(_foldCasesWithSameTypes))]
        public void Fold_should_work_correctly_if_the_input_type_of_the_function_is_the_same_as_the_result(
            IEnumerable<int> inputEnumerable, int seed, Func<int, int, int> func, int result)
        {
            inputEnumerable.Fold(seed, func).Should().Be(result);
        }
    }
}