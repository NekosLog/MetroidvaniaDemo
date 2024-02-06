/* 制作日 2024/01/30
*　製作者 ニシガキ
*　最終更新日 2024/01/30
*/

using UnityEngine;
 
public class PlayerParamater : MonoBehaviour, IFPlayerParameter 
{
    //プレイヤーのHPの初期値
    private int _startPlayerHp = 5;
    
    // プレイヤーのSPの初期値
    private int _startPlayerSp = 100;

    // プレイヤーの通常攻撃の与ダメージ
    private int _attack_Damage = 2;

    // スキル１の消費SP
    private int _skill1_Cost = 30;

    // スキル１の与ダメージ
    private int _skill1_Damage = 5;

    // 回復の消費SP
    private int _heal_Cost = 50;

    // 回復するHPの量
    private int _heal_Value = 1;

    // プレイヤーのHPの最大値
    private int _maxPlayerHP = 5;

    // プレイヤーのSPの最大値
    private int _maxPlayerSP = 100;

    // プレイヤーの現在HP
    private int _playerHP = default;

    // プレイヤーの現在SP
    private int _playerSP = default;

    private void Awake()
    {
        _playerHP = _startPlayerHp;
        _playerSP = _startPlayerSp;
    }

    public int GetPlayerHp()
    {
        return _playerHP;
    }

    public bool IsHPMax()
    {
        if (_playerHP >= _maxPlayerHP)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetPlayerSp()
    {
        return _playerSP;
    }

    public bool IsSPMax()
    {
        if (_playerSP >= _maxPlayerSP)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddPlayerHp(int value)
    {
        _playerHP += value;
        _playerHP = Mathf.Clamp(_playerHP, 0, _maxPlayerHP);
    }

    public void AddPlayerSp(int value)
    {
        _playerSP += value;
        _playerSP = Mathf.Clamp(_playerSP, 0, _maxPlayerSP);
    }

    public int GetAttack_Damage()
    {
        return _attack_Damage;
    }

    public int GetSkill1_Cost()
    {
        return _skill1_Cost;
    }

    public int GetSkill1_Damage()
    {
        return _skill1_Damage;
    }

    public int GetHeal_Cost()
    {
        return _heal_Cost;
    }

    public int GetHeal_Value()
    {
        return _heal_Value;
    }
}