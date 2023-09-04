using Microsoft.VisualStudio.TestTools.UnitTesting;
using lr1x;
using System;
using System.Collections.Generic;
using System.Text;

namespace lr1x.Tests
{
    [TestClass()]
    public class WorkOnArrayTests
    {
        [TestMethod()]
        public void Get_maxTest()
        {
            // Arrange
            int[] expected = new int[] { 2, 10 };
            int[] input = new int[] { -2, -3, 10, -7, 0, 8 };
            
            // Act
            var actual = WorkOnArray.get_max(input);
            
            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        public void Zero_maxTest()
        {
            // Arrange
            int[] expected = new int[] { 0, 0 };
            int[] input = new int[] { -2, -3, -10, -7, 0, -8 };
            
            // Act
            int[] actual = WorkOnArray.get_max(input);
            
            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        public void Negative_maxTest()
        {
            // Arrange
            int[] expected = new int[] { 0, 0 };
            int[] input = new int[] { -2, -1, -10, -7, -9, -8 };
            
            // Act
            int[] actual = WorkOnArray.get_max(input);
            
            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}