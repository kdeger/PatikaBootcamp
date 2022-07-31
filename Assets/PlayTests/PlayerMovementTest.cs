using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NSubstitute;

public class PlayerMovementTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void PlayerMovementTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TransformMoverTestWithEnumeratorPasses()
    {
        //Arrange
        AsyncOperation loadScene = SceneManager.LoadSceneAsync("SampleScene");

        while (!loadScene.isDone)
        {
            yield return null;
            Debug.Log("Loading scene");
        }

        Player player = GameObject.FindObjectOfType<Player>();
        float startingZ = player.transform.position.z;

        //Act
        var testPlayerInput = Substitute.For<IPlayerInput>();
        player.PlayerInput = testPlayerInput;
        testPlayerInput.Vertical.Returns(1f);

        yield return new WaitForSeconds(3f);
        
        //Assert
        Assert.Greater(player.transform.position.z, startingZ);
    }

}
