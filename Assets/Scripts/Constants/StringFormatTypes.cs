using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CoinDivisionIndex
{
    Billion,
    Million,
    Thousand,
}

public class StringFormatTypes
{
    public const string WHEEL_SECTOR = "{0:#,0}";
    public const string EARN_CREDIT_DEFAULT = "#,0";
    public const string EARN_CREDIT_K = "0.## K";
    public const string EARN_CREDIT_M = "0.## M";
    public const string EARN_CREDIT_B = "0.## B";

    public static string GetFormatForCoins(CoinDivisionIndex coinDivisionIndex)
    {
        switch (coinDivisionIndex)
        {
            case CoinDivisionIndex.Billion:
                return EARN_CREDIT_B;
            case CoinDivisionIndex.Million:
                return EARN_CREDIT_M;
            case CoinDivisionIndex.Thousand:
                return EARN_CREDIT_K;
            default:
                return EARN_CREDIT_DEFAULT;
        }
    }
}
