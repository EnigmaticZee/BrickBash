using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using UnityEngine.SceneManagement;

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
        gm.DestroyBrick();
        gm.DestroyBrick();
        Assert.AreEqual(47,gm.bricks);
	}

	[Test]
	public void TestLoseLife()
	{
		GameManager gm = new GameManager();
		gm.lives = 1;
		gm.LoseLife(true);
		Assert.AreEqual(0, gm.lives);
	}

	[Test]
	public void TestShowMenuAndMessage()
	{
		GameManager gm = new GameManager();
		GameObject message = new GameObject();
		message.SetActive(false);
		gm.ShowMenuAndMessage(message, true);
		Assert.IsTrue(message.activeSelf);
	}

   /* [Test]
    public void TestLoadedScene()
    {
        SceneManager.LoadScene("Main");
        Assert.IsTrue(SceneManager.GetActiveScene().name == "Main");
    }*/
}
