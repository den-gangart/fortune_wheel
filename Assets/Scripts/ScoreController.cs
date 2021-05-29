using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int _money;
    private UIController uIController;

    // Start is called before the first frame update
    void Start()
    {
        _money = PlayerPrefs.GetInt("Money", 0);
        uIController = GetComponent<UIController>();
        uIController.OnUpdateMoney(_money);
    }

    public void AddMoney(int value)
    {
        _money += value;
        PlayerPrefs.SetInt("Money", _money);
        uIController.OnUpdateMoney(_money);
        uIController.OnMoneyPickUp(value);
    }
}
