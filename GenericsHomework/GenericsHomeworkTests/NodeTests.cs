using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomeworkTests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void NodeTypeString_Value_Equals_test()
    {
        Node<string> newNode = new("test");
        if (newNode is not null && newNode.Value is not null)
        {
            Assert.AreEqual<string>("test", newNode.Value);
        }
        else
        {
            Assert.Fail();
        }
        if (newNode is not null)
        {
            Node<string> newNode2 = new("test2", newNode);
            if (newNode is not null && newNode2.Value is not null)
            {
                Assert.AreEqual<string>("test2", newNode2.Value);
            }
            else
            {
                Assert.Fail();
            }
        }
        else
        {
            Assert.Fail();
        }
    }

    [TestMethod]
    public void NodeSetsRootToSelf_True()
    {
        Node<string> newNode = new("test");
        if (newNode is not null)
        {
            Assert.AreEqual(newNode, newNode.Root);
        }

        Node<string> newNode2 = new("test2", newNode);
    }

    [TestMethod]
    public void NodeExists_ReturnTrue()
    {
        Node<string> newNode = new("10");
        Assert.IsTrue(newNode.Exists("10"));
    }
    [TestMethod]
    public void NodeExists_ReturnFalse()
    {
        Node<string> newNode = new("10");
        Assert.IsFalse(newNode.Exists("12"));
    }
}
