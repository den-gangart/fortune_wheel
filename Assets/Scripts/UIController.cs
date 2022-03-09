using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI labelMoney;
    [SerializeField] private Button buttonSpin;
    [SerializeField] private TextMeshProUGUI labelPickUpMoney;
    [SerializeField] private Animator animatorPickUpMoney;
    [SerializeField] private List<double> coinDivisionAmount;

    private const string PICK_UP_TRIGGER = "PickUpMoney";

    public void Awake()
    {
        WheelEventSystem.AddWheelEventListener(WheelEvent.OnEndSpin, EnableSpin);
        WheelEventSystem.AddWheelEventListener(WheelEvent.OnStartSpin, DisableSpin);
        WheelEventSystem.AddWheelEventListener<int>(WheelEvent.OnUpdateTotalEarnCredit, OnUpdateMoney);
        WheelEventSystem.AddWheelEventListener<int>(WheelEvent.OnCoinWin, OnMoneyPickUp);
    }

    public void OnBackToMenu()
    {
        SceneManager.LoadScene(GameScenes.MAIN_MENU);
    }

    private void OnUpdateMoney(int moneyValue)
    {
        labelMoney.text = FormatMoneyString(moneyValue);  
    }

    private void EnableSpin()
    {
        buttonSpin.enabled = true;
    }

    private void DisableSpin()
    {
        buttonSpin.enabled = false;
    }

    public void OnMoneyPickUp(int value)
    {
        labelPickUpMoney.text = "+"+string.Format(StringFormatTypes.WHEEL_SECTOR, value);
        animatorPickUpMoney.SetTrigger(PICK_UP_TRIGGER);
    }

    private string FormatMoneyString(int value)
    {
        for (int index = 0; index < coinDivisionAmount.Count; index++)
        {
            if (value >= coinDivisionAmount[index])
                return (value / coinDivisionAmount[index]).ToString(StringFormatTypes.GetFormatForCoins((CoinDivisionIndex)index));
        }

        return value.ToString(StringFormatTypes.EARN_CREDIT_DEFAULT);
    }
}
