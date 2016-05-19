using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class UnitTesting {

	[Test]
	public void EditorTest()
	{
		//Arrange
		var gameObject = new GameObject();

		//Act
		//Try to rename the GameObject
		var newGameObjectName = "My game object";
		gameObject.name = newGameObjectName;

		//Assert
		//The object has a new name
		Assert.AreEqual(newGameObjectName, gameObject.name);
	}

	[Test]
	public void TestDestroyBrick()
	{
		GameManager gm = new GameManager();
		gm.bricks = 50;
		gm.DestroyBrick();
		Assert.AreEqual(49, gm.bricks);
	}

	[Test]
	public void TestLoseLife()
	{
		GameManager gm = new GameManager();
		gm.lives = 1;
		gm.LoseLife(true);
		Assert.AreEqual(0, gm.lives);
	}
}
