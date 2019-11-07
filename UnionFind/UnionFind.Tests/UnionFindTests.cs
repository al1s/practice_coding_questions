using Xunit;

namespace UnionFind.Tests
{
  public class UnionFindTest
  {
    [Fact]
    public void Ctor_GivenMap_ReturnsCorrectElementsCount()
    {
      // arrange
      var expectedCnt = 9;
      var map = new int[4][]
      {
          new int[5] {1,1,1,1,0},
          new int[5] {1,1,0,1,0},
          new int[5] {1,1,0,0,0},
          new int[5] {0,0,0,0,0},
      };

      // act
      var uf = new UnionFind.App.UnionFind(map);

      // assert
      Assert.Equal(expectedCnt, uf.GetCount());
    }

    [Fact]
    public void Find_GivenPosition_ReturnsParent()
    {
      // arrange
      var expectedParent1 = 1;
      var expectedParent4 = 0;
      var map = new int[4][]
      {
          new int[5] {1,1,1,1,0},
          new int[5] {1,1,0,1,0},
          new int[5] {1,1,0,0,0},
          new int[5] {0,0,0,0,0},
      };
      var uf = new UnionFind.App.UnionFind(map);

      // act
      var parent1 = uf.Find(1);
      var parent4 = uf.Find(4);

      // assert
      Assert.Equal(expectedParent1, parent1);
      Assert.Equal(expectedParent4, parent4);
    }

    [Fact]
    public void Union_GivenTwoPositions_CanUnionElements()
    {
      // arrange
      var expectedParent = 0;
      var map = new int[4][]
      {
          new int[5] {1,1,1,1,0},
          new int[5] {1,1,0,1,0},
          new int[5] {1,1,0,0,0},
          new int[5] {0,0,0,0,0},
      };
      var uf = new UnionFind.App.UnionFind(map);

      // act
      uf.Union(0, 1);
      var parent0 = uf.Find(0);
      var parent1 = uf.Find(1);

      // assert
      Assert.Equal(expectedParent, parent0);
      Assert.Equal(expectedParent, parent1);
    }

    [Fact]
    public void GetNumberOfIslans_GivenMapWith1Islan_Returns1()
    {
      //Given
      var map = new int[2][]
      {
          new int[2] {1,0},
          new int[2] {0,1},
      };
      var uf = new UnionFind.App.UnionFind(map);

      //When
      var nOfI = uf.GetNumberOfIslands(map);

      //Then
      Assert.Equal(2, nOfI);
    }
  }
}
