using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreController : MonoBehaviour
{
    private int _money;

    // Start is called before the first frame update
    void Awake()
    {
        WheelEventSystem.AddWheelEventListener<int>(WheelEvent.OnCoinWin, AddMoney);
    }

    void Start()
    {
        _money = PlayerPrefs.GetInt("Money", 0);
        WheelEventSystem.Broadcast(WheelEvent.OnUpdateTotalEarnCredit, _money);
    }

    private void AddMoney(int value)
    {
        _money += value;
        PlayerPrefs.SetInt("Money", _money);
        WheelEventSystem.Broadcast(WheelEvent.OnUpdateTotalEarnCredit, _money);
    }
}
