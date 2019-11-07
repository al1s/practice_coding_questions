using System;
using Xunit;
using LeetCode_622_Design_Circular_Queue;

namespace LeetCode_622_Design_Circular_Queue.Tests
{
  public class UnitTest1
  {
    [Fact]
    public void Test1()
    {
      // arrange
      var q = new CircularQueue(2);

      // act
      var resultEmpty = q.isEmpty();
      var resultFull = q.isFull();
      var resultDequeue = q.deQueue();

      // assert
      Assert.True(resultEmpty);
      Assert.False(resultFull);
      Assert.False(resultDequeue);
    }

    [Fact]
    public void Test2()
    {
      // arrange
      var queueSize = 2;
      var valueInQueue = 2;
      var q = new CircularQueue(queueSize);

      // act
      var resultEnqueue = q.enQueue(valueInQueue);
      var resultFront = q.Front();

      // assert
      Assert.True(resultEnqueue);
      Assert.Equal(valueInQueue, resultFront);
    }


    [Fact]
    public void Test3()
    {
      // arrange
      var queueSize = 3;
      var q = new CircularQueue(queueSize);

      // act
      var resultEnqueue1 = q.enQueue(1);
      var resultEnqueue2 = q.enQueue(2);
      var resultEnqueue3 = q.enQueue(3);
      var resultEnqueue4 = q.enQueue(4);
      var resultRear = q.Rear();
      var resultFull = q.isFull();
      var resultDequeue = q.deQueue();
      var resultEnqueue4v2 = q.enQueue(4);
      var resultRearv2 = q.Rear();

      // assert
      Assert.True(resultEnqueue1);
      Assert.True(resultEnqueue2);
      Assert.True(resultEnqueue3);
      Assert.False(resultEnqueue4);
      Assert.True(resultFull);
      Assert.True(resultDequeue);
      Assert.Equal(3, resultRear);
      Assert.True(resultEnqueue4v2);
      Assert.Equal(4, resultRearv2);
    }
  }
}
