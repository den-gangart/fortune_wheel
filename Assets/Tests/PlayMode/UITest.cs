using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class UITest
{
    [UnityTest]
    public IEnumerator TestCorrectScoreDisplay()
    {
        GameObject gameObject = new GameObject();
        UIController uiController = gameObject.AddComponent<UIController>();

        GameObject gameObjectTMPro = new GameObject();
        TextMeshProUGUI textMeshPro = gameObjectTMPro.AddComponent<TextMeshProUGUI>();

        uiController.labelMoney = textMeshPro;

        yield return null;

        uiController.OnUpdateMoney(1500);

        yield return null;

        Assert.AreEqual(textMeshPro.text, "1,5 K");

        uiController.OnUpdateMoney(1230000);

        yield return null;

        Assert.AreEqual(textMeshPro.text, "1,23 M");
    }
}
