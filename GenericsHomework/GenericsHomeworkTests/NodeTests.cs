using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomeworkTests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void TestMethod1()
    {
        Node<string> newNode1 = new ("10");
    }
}
