using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomeworkTests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void NodeTypeString_Value_Equals_test()
    {
        Node<string> newNode = new ("test");
        if (newNode is not null && newNode.Value is not null)
        {
            Assert.AreEqual<string>("test", newNode.Value);
        }

        Node<string> newNode2 = new("test2", newNode);
        if (newNode is not null && newNode2.Value is not null)
        {
            Assert.AreEqual<string>("test2", newNode2.Value);
        }
    }

    [TestMethod]
    public void NodeSetsRootToSelf_True()
    {

    }
}
