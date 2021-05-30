using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public List<TextMeshProUGUI> labelList;
    public TextMeshProUGUI labelMoney;
    public Button buttonSpin;
    public TextMeshProUGUI labelPickUpMoney;
    public Animator animatorPickUpMoney;

    public void OnBackToMenu()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void InitLabelList(List<int> values)
    {
        for(int i = 0; i < labelList.Count; i++)
            labelList[i].text = string.Format("{0:#,0}", values[i]);
    }

    public void OnUpdateMoney(int moneyValue)
    {
        labelMoney.text = FormatMoneyString(moneyValue);  
    }

    public void EnableSpin()
    {
        buttonSpin.enabled = true;
    }

    public void DisableSpin()
    {
        buttonSpin.enabled = false;
    }

    public void OnMoneyPickUp(int value)
    {
        labelPickUpMoney.text = "+"+string.Format("{0:#,0}", value);
        animatorPickUpMoney.SetTrigger("PickUpMoney");
    }

    private string FormatMoneyString(int value)
    {
        if (value >= 1000000000)
            return (value / 1000000000D).ToString("0.## B");
        if (value >= 1000000)
            return (value / 1000000D).ToString("0.## M");
        if (value >= 1000)
            return (value / 1000D).ToString("0.## K");

        return value.ToString("#,0");
    }
}
