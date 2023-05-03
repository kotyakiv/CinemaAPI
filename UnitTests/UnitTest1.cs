using CinemaAPI.src;

/*
 * I am not familiar with C# and containers it has. So I have problem with comparing  CollectionAssert and List<int[]>
 * That's why I compare elements one by one (expected[0], actual[0]), (expected[1], actual[1]) 
 */

namespace TestShowTimeTable
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // All arguments are negative
        public void TestMethod1()
        {
            List<int[]> expected = new List<int[]>();
            List<int[]> actual = ShowTime.ShowTimeTable(-1, -10, -20);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        // Opening hours and Closing hours are equal
        public void TestMethod2()
        {
            List<int[]> expected = new List<int[]>();
            List<int[]> actual = ShowTime.ShowTimeTable(10, 10, 10);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        // Show finishes exactly after closingHour
        public void TestMethod3()
        {
            List<int[]> expected = new List<int[]>();
            List<int[]> actual = ShowTime.ShowTimeTable(0, 1, 61);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        // Show finishes exactly in closingHour
        public void TestMethod4()
        {
            List<int[]> expected = new List<int[]>();
            int [] arr = new int [] {0, 0 };
            expected.Add(arr);
            List<int[]> actual = new List<int[]>();
            actual.AddRange(ShowTime.ShowTimeTable(0, 1, 60));

            CollectionAssert.AreEqual(expected[0], actual[0]);
        }

        [TestMethod]
        // Check if session gaps included between the sessions
        public void TestMethod5()
        {
            List<int[]> expected = new List<int[]>();
            int[] arr = { 0, 0 };
            expected.Add(arr);
            arr= new int[] { 0, 30 };
            expected.Add(arr);

            List<int[]> actual = ShowTime.ShowTimeTable(0, 1, 15);

            CollectionAssert.AreEqual(expected[0], actual[0]);
            CollectionAssert.AreEqual(expected[1], actual[1]);
        }

        [TestMethod]
        // Test from the assignment1
        public void TestMethod6()
        {
            List<int[]> expected = new List<int[]>();
            int[] arr = { 13, 0 };
            expected.Add(arr);
            arr = new int[] { 14, 15 };
            expected.Add(arr);
            arr = new int[] { 15, 30 };
            expected.Add(arr);
            arr = new int[] { 16, 45 };
            expected.Add(arr);
            arr = new int[] { 18, 0 };
            expected.Add(arr);
            arr = new int[] { 19, 15 };
            expected.Add(arr);
            arr = new int[] { 20, 30 };
            expected.Add(arr);
            arr = new int[] { 21, 45 };
            expected.Add(arr);

            List<int[]> actual = ShowTime.ShowTimeTable(13, 23, 60);

            for (int i = 0; i < 8; i++)
                CollectionAssert.AreEqual(expected[i], actual[i]);
        }

        [TestMethod]
        // Test from the assignment2
        public void TestMethod7()
        {
            List<int[]> expected = new List<int[]>();
            int[] arr = { 16, 0 };
            expected.Add(arr);
            arr = new int[] { 17, 30 };
            expected.Add(arr);
            arr = new int[] { 19, 0 };
            expected.Add(arr);
            arr = new int[] { 20, 30 };
            expected.Add(arr);
            arr = new int[] { 22, 0 };
            expected.Add(arr);
            arr = new int[] { 23, 30 };
            expected.Add(arr);
            arr = new int[] { 1, 0 };
            expected.Add(arr);


            List<int[]> actual = ShowTime.ShowTimeTable(16, 3, 75);

            for (int i = 0; i < 7; i++)
                CollectionAssert.AreEqual(expected[i], actual[i]);
        }
    }
}