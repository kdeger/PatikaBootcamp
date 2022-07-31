using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.TestTools;
using System;

namespace Tests
{
    public class NewTestScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            //Arrange
            Player player = new Player();

            //Act
            player.Heal(10);

            //Assert
            Assert.AreEqual(110, player.Health);
        }

        [TestCase(10, ExpectedResult = 110)]
        [TestCase(20, ExpectedResult = 120)]
        [TestCase(-10, ExpectedResult = 100)]
        public int SimpleHealthTest(int healingAmount)
        {
            //Arrange
            Player player = new Player();

            //Act
            player.Heal(healingAmount);

            //Assert
            return player.Health;
        }

        [TestCase(10, ExpectedResult = 90)]
        [TestCase(20, ExpectedResult = 80)]
        [TestCase(-10, ExpectedResult = 100)]
        public int SimpleDamageTest(int damageAmount)
        {
            //Arrange
            Player player = new Player();

            //Act
            player.TakeDamage(damageAmount);

            //Assert
            return player.Health;
        }

        [TestCase("07/30/2022 07:22:16", ExpectedResult = 1)]
        [TestCase("07/28/2022 07:22:16", ExpectedResult = 3)]
        public int DateTimeDayTest(string lastSessionExitDateTime)
        {
            //Arrange
            int dayDifference = -1;

            if (DateTime.TryParseExact(lastSessionExitDateTime, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime lastSessionExitDate))
            {
                DateTime dateTimeNow = DateTime.Now;

                //Act
                dayDifference = (dateTimeNow - lastSessionExitDate).Days;
            }

            //Assert
            return dayDifference;
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            // capsule.transform.position = new Vector3(0, 0, 0);
            // float movementTime = 0f;

            // float startingZ = capsule.transform.position.z;
            // while(movementTime < 3f)
            // {
            //     capsule.transform.Translate(Vector3.forward * Time.deltaTime);
            //     movementTime += Time.deltaTime;
            //     yield return null;
            // }

            // Assert.IsGreater(capsule.transform.position.z, startingZ);
            yield return null;
        }
    }
}

