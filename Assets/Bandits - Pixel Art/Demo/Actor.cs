using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    // 体力
    [SerializeField]
    int hp = 100;
    // 攻撃力
    [SerializeField]
    int atk = 10;
    // 防御率
    [SerializeField]
    float def = 1.0f;

    public int GetHp()
    {
        return hp;
    }

    public int GetAtk()
    {
        return atk;
    }

    public float GetDef()
    {
        return def;
    }

    public void Damage(int atk)
    {
        hp = hp -(int)((float)atk * def);
    }
}
