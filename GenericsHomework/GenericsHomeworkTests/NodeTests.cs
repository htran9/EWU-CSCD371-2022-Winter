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
        Assert.AreEqual<string>("test", newNode.Value!);

        Node<string> newNode2 = new("test2", newNode);
        Assert.AreEqual<string>("test2", newNode2.Value!);
    }

    [TestMethod]
    public void NodeSetsRootToSelf_True()
    {
        Node<string> newNode = new("test");
        Assert.AreEqual(newNode, newNode.Root);

        Node<string> newNode2 = new("test2", newNode!);
        Assert.AreEqual(newNode2, newNode2.Root);
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

    [TestMethod]
    public void NodeAppend_ExistsAppended_True()
    {
        Node<string> newNode = new("first");
        newNode.Append("Second");
        Assert.IsTrue(newNode.Exists("Second"));
    }
    [TestMethod]
    public void NodeLast_ReturnLast()
    {
        Node<string> newNode = new("1");
        newNode.Append("2");
        newNode.Append("3");
        Node<string> lastNode = newNode.GetLast();
        Assert.AreEqual<string>("3", lastNode);
    }


}
