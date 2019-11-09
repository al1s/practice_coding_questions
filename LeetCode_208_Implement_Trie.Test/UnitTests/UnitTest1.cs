using LeetCode_208_Implement_Trie;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // arrange
            Trie<bool> trie = new Trie<bool>();
            var str2Add = "apple";

            // act
            trie.Insert(str2Add, true);
            var searchResult = trie.Search(str2Add);

            // assert
            Assert.True(searchResult);
        }

        [Fact]
        public void Test2()
        {
            // arrange
            Trie<bool> trie = new Trie<bool>();
            var str2Add1 = "apple";
            var str2Add2 = "app";

            // act
            trie.Insert(str2Add1, true);
            var searchResult = trie.Search(str2Add2);

            // assert
            Assert.False(searchResult);
        }

        [Fact]
        public void Test3()
        {
            // arrange
            Trie<bool> trie = new Trie<bool>();
            var str2Add1 = "apple";
            var str2Add2 = "app";

            // act
            trie.Insert(str2Add1, true);
            var searchResult = trie.StartsWith(str2Add2);

            // assert
            Assert.True(searchResult);
        }

        [Fact]
        public void Test4()
        {
            // arrange
            Trie<bool> trie = new Trie<bool>();
            var str2Add1 = "apple";
            var str2Add2 = "app";

            // act
            trie.Insert(str2Add1, true);
            trie.Insert(str2Add2, true);
            var searchResult = trie.Search(str2Add2);

            // assert
            Assert.True(searchResult);
        }

        [Fact]
        public void Test5()
        {
            // arrange
            Trie<bool> trie = new Trie<bool>();

            // act
            var searchResult = trie.Search("some");

            // assert
            Assert.False(searchResult);
        }

        [Fact]
        public void Test6()
        {
            // arrange
            Trie<string> trie = new Trie<string>();
            var key = "apple";
            var val = "banana";

            // act
            trie.Insert(key, val);
            var searchResult = trie.Search(key);

            // assert
            Assert.Equal(val, searchResult);
        }

        [Fact]
        public void Test7()
        {
            // arrange
            Trie<string> trie = new Trie<string>();
            var key = "apple";
            var val = "banana";

            // act
            trie.Insert(key, val);
            var searchResult = trie.Search(key.Substring(0, 3));

            // assert
            Assert.Null(searchResult);
        }
    }
}