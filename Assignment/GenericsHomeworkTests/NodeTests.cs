using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericsHomeworkTests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void NodeTypeString_Value_Equals_test()
    {
        Node<string> newNode = new("test");
        Assert.AreEqual<string>("test", newNode.Value);

        Node<string> newNode2 = new("test2", newNode);
        Assert.AreEqual<string>("test2", newNode2.Value);
    }

    [TestMethod]
    public void NodeSetsRootToSelf_True()
    {
        Node<string> newNode = new("test");
        Assert.IsTrue(newNode.Equals(newNode.Root));

        Node<string> newNode2 = new("test2", newNode);
        Assert.IsTrue(newNode2.Equals(newNode2.Root));
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
    public void NodeExists_NullValue_ReturnTrue()
    {
        string empty = null!;
        Node<string> newNode = new("start");
        newNode.Append("middle");
        newNode.Append(empty);
        newNode.Append("end");

        Assert.IsTrue(newNode.Exists(null!));
    }

    [TestMethod]
    public void NodeAppend_DuplicateValue_throwsException()
    {
        _ = Assert.ThrowsException<ArgumentException>(() =>
        {
            Node<double> newNode = DoubleRadioStations();
            newNode.Append(42.0);
        });
    }

    [TestMethod]
    public void NodeAppend_AppendedExists_ReturnsTrue()
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
        Assert.AreEqual<string>("3", lastNode.ToString()!);
        Assert.AreEqual<string>(newNode.ToString()!, lastNode.Next.ToString()!);
    }

    [TestMethod]
    public void NodeClear_RemovesAllNonRootNodes()
    {
        Node<double> newNode = DoubleRadioStations();
        Assert.IsTrue(newNode.Exists(42.0));
        Assert.IsTrue(newNode.Exists(92.9));
        Assert.IsTrue(newNode.Exists(94.5));
        Assert.IsTrue(newNode.Exists(103.5));
        Assert.IsTrue(newNode.Exists(105.7));

        newNode.Clear();
        Assert.IsTrue(newNode.Exists(42.0));
        Assert.IsFalse(newNode.Exists(92.9));
        Assert.IsFalse(newNode.Exists(94.5));
        Assert.IsFalse(newNode.Exists(103.5));
        Assert.IsFalse(newNode.Exists(105.7));
    }

    [TestMethod]
    public void NodeIterator_ReturnCorrectValues()
    {
        Node<double> newNode = DoubleRadioStations();
        double[] stationsCorrect = new [] { 42.0, 92.9, 94.5, 103.5, 105.7 };
        double[] stationsTest = new double[5];
        int count = 0;
        foreach(Node<double> item in newNode)
        {
            stationsTest[count] = item.Value;
            count++;
        }
        Assert.IsTrue(stationsTest.SequenceEqual(stationsCorrect));
    }

    [TestMethod]
    public void NodeChildItems_ReturnsAll()
    {
        Node<double> newNode = DoubleRadioStations();
        List<Node<double>> nodeList = newNode.ChildItems(6).ToList();
        Assert.IsTrue(nodeList.Count == 5);
        Assert.IsTrue(nodeList.Contains(newNode));
        Assert.IsTrue(nodeList.Contains(newNode.Next));
        Assert.IsTrue(nodeList.Contains(newNode.Next.Next));
        Assert.IsTrue(nodeList.Contains(newNode.Next.Next.Next));
        Assert.IsTrue(nodeList.Contains(newNode.Next.Next.Next.Next));

    }

    [TestMethod]
    public void NodeChildItems_ReturnsLessThanSpecifiedMaximum()
    {
        Node<double> newNode = DoubleRadioStations();
        List<Node<double>> nodeList = newNode.ChildItems(4).ToList();
        Assert.IsTrue(nodeList.Count == 3);
        Assert.IsTrue(nodeList.Contains(newNode));
        Assert.IsTrue(nodeList.Contains(newNode.Next));
        Assert.IsTrue(nodeList.Contains(newNode.Next.Next));
    }

    [TestMethod]
    public void NodeChildItems_ReturnsUpToTotalItems()
    {
        Node<double> newNode = DoubleRadioStations();
        List<Node<double>> nodeList = newNode.ChildItems(10).ToList();
        Assert.IsTrue(nodeList.Count == 5);
        Assert.IsTrue(nodeList.Contains(newNode));
        Assert.IsTrue(nodeList.Contains(newNode.Next));
        Assert.IsTrue(nodeList.Contains(newNode.Next.Next));
        Assert.IsTrue(nodeList.Contains(newNode.Next.Next.Next));
        Assert.IsTrue(nodeList.Contains(newNode.Next.Next.Next.Next));
    }

    [TestMethod]
    public void Node_EnumeratorExists_True()
    {
        Node<double> newNode = DoubleRadioStations();
        var enumerator = newNode.GetEnumerator();
        Assert.IsNotNull(enumerator);
    }

    [TestMethod]
    public void NodeEnumerator()// probably need mock
    {
        Node<double> newNode = DoubleRadioStations();
        var enumerator = newNode.GetEnumerator();
        //Assert.AreEqual(0, enumerator.Current.Value);   

    }

    public static Node<double> DoubleRadioStations()
    {
        Node<double> newNode = new(42.0);
        newNode.Append(92.9);
        newNode.Append(94.5);
        newNode.Append(103.5);
        newNode.Append(105.7);
        return newNode;
    }



}