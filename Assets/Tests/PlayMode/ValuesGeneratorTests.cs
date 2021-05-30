using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ValuesGeneratorTests
{
    [UnityTest]
    public IEnumerator TestValuesOfListIsMultiplies100()
    {
        GameObject gameObjectSpinner = new GameObject();
        gameObjectSpinner.AddComponent<SpinTicker>();

        GameObject gameObject = new GameObject();
        var wheelGenerator = gameObject.AddComponent<WheelGenerator>();
        wheelGenerator.rotationElements = gameObjectSpinner.transform;

        yield return null;

        List<int> listValues = wheelGenerator.GetListValues();

        for (int i = 0; i < listValues.Count; i++)
        {
            Assert.IsTrue(listValues[i] % 100 == 0);
        }
    }

    [UnityTest]
    public IEnumerator TestValuesOfListIsUnique()
    {
        GameObject gameObjectSpinner = new GameObject();
        gameObjectSpinner.AddComponent<SpinTicker>();

        GameObject gameObject = new GameObject();
        var wheelGenerator = gameObject.AddComponent<WheelGenerator>();
        wheelGenerator.rotationElements = gameObjectSpinner.transform;

        yield return null;

        List<int> listValues = wheelGenerator.GetListValues();

        for (int i = 0; i < listValues.Count; i++)
            for (int j = 0; j < listValues.Count; j++)
                if (i != j)
                    Assert.AreNotEqual(listValues[i], listValues[j]);
    }
}
