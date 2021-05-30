using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class WheelSpinTests
{
    [UnityTest]
    public IEnumerator TestWheelIsSpinning()
    {
        GameObject listener = new GameObject();
        listener.AddComponent<AudioListener>();

        GameObject gameObjectSpinner = new GameObject();
        gameObjectSpinner.AddComponent<SpinTicker>();
        gameObjectSpinner.AddComponent<AudioSource>();

        GameObject gameObject = new GameObject();
        var wheelGenerator = gameObject.AddComponent<WheelGenerator>();
        wheelGenerator.rotationElements = gameObjectSpinner.transform;

        wheelGenerator.rotationMaxSpeed = 400;
        wheelGenerator.rotationMinSpeed = 100;
        wheelGenerator.revolutionCount = 4;

        yield return null;

        wheelGenerator.StartSpin();
        float startRotationPoz = gameObjectSpinner.transform.rotation.eulerAngles.z;

        yield return new WaitForSeconds(0.5f);

        float endRotationPoz = gameObjectSpinner.transform.rotation.eulerAngles.z;
        Assert.AreNotEqual(endRotationPoz, startRotationPoz);
    }
}
