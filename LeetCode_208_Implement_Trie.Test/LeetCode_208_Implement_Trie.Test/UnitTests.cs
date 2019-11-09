using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode_208_Implement_Trie.Test
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Test1()
        {
            // arrange
            Trie<bool> trie = new Trie<bool>();
            var str2Add = "apple";

            // act
            trie.Insert(str2Add, true);
            var searchResult = trie.Search(str2Add);

            // assert
            Assert.IsTrue(searchResult);
        }
    }
}