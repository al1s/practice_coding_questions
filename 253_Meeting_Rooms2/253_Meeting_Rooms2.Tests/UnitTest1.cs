using System;
using Xunit;
using _253_Meeting_Rooms2.App;

namespace _253_Meeting_Rooms2.Tests
{
  public class UnitTest1
  {
    [Fact]
    public void Test1()
    {
      // arrange
      var meetings = new int[][]
        {
            new[] {0,30},
            new[] {5,10},
            new[] {15,20},
        };
      var expected = 2;
      // act
      var rooms = Program.GetRooms(meetings);
      // assert
      Assert.Equal(expected, rooms);
    }

    [Fact]
    public void Test2()
    {
      //Given
      var meetings = new int[][]
        {
            new[] {13,15},
            new[] {1,13},
        };
      var expected = 1;
      // act
      var rooms = Program.GetRooms(meetings);
      // assert
      Assert.Equal(expected, rooms);
    }

    [Fact]
    public void test3()
    {
      //Given
      var meetings = new int[][]
        {
            new[] {4,9},
            new[] {4,17},
            new[] {9,10},
        };
      var expected = 2;
      // act
      var rooms = Program.GetRooms(meetings);
      // assert
      Assert.Equal(expected, rooms);
    }

    [Fact]
    public void test4()
    {
      //Given
      var meetings = new int[][]
        {
            new[] {2,4},
            new[] {7,10},
        };
      var expected = 1;
      // act
      var rooms = Program.GetRooms(meetings);
      // assert
      Assert.Equal(expected, rooms);
    }

    [Fact]
    public void test5()
    {
      //Given
      var meetings = new int[][]
        {
            new[] {0,30},
            new[] {5,10},
            new[] {9,20},
        };
      var expected = 3;
      // act
      var rooms = Program.GetRooms(meetings);
      // assert
      Assert.Equal(expected, rooms);
    }

    [Fact]
    public void test6()
    {
      //Given
      var meetings = new int[][]
        {
            new[] {1,3},
            new[] {2,4},
            new[] {3,5},
            new[] {9,11},
        };
      var expected = 2;
      // act
      var rooms = Program.GetRooms(meetings);
      // assert
      Assert.Equal(expected, rooms);
    }

    [Fact]
    public void test7()
    {
      //Given
      var meetings = new int[][]
        {
            new[] {1,5},
            new[] {8,9},
            new[] {8,9},
        };
      var expected = 2;
      // act
      var rooms = Program.GetRooms(meetings);
      // assert
      Assert.Equal(expected, rooms);
    }
  }
}
