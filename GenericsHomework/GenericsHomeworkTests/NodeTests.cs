using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomeworkTests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void NodeTypeString_Value_test()
    {
        Node<string> newNode = new ("test");
        if (newNode is not null && newNode.Value is not null)
        {
            Assert.AreEqual<string>("test", newNode.Value);
        }
    }

    [TestMethod]
    public void MyTestMethod()
    {

    }
}
