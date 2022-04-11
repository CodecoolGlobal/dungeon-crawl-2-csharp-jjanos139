using System.Collections;
using System.Collections.Generic;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    [SetUp]
    public void Setup()
    {
        //MapLoader.LoadMap(4);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [Test]
    public void GetActorAtTest()
    {
        var result = ActorManager.Singleton.GetActorAt((2, -2));
        Assert.AreEqual("Player", result.DefaultName);
    }
}