using System;
using UnityEngine;

public static class DirectionUtils
{
    public const int Right = 0;
    public const int Up = 1;
    public const int Left = 2;
    public const int Down = 3;

    public static int GetCardianDirection(float degrees)
    {
        return NegSafeMod(Mathf.RoundToInt(degrees / 90f), 4);
    }

    private static int NegSafeMod(int val, int len)
    {
        return (val % len + len) % len;
    }

    public static int GetX(int cardianDirection)
    {
        int num = cardianDirection % 4;
        if(num == Right)
        {
            return Up;
        }
        if(num != Left)
        {
            return Right;
        }
        return -1;
    }

    public static int GetY(int cardianDirection)
    {
        int num = cardianDirection % 4;
        if (num == Up)
        {
            return Up;
        }
        if (num != Down)
        {
            return Right;
        }
        return -1;
    }
}
