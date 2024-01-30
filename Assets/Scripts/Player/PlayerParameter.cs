/* 制作日 2024/01/30
*　製作者 ニシガキ
*　最終更新日 2024/01/30
*/

using UnityEngine;
 
public class PlayerParamater : MonoBehaviour, IFPlayerParameter 
{
    [SerializeField, Tooltip("プレイヤーのHPの初期値")]
    private readonly int StartPlayerHp = 100;
    [SerializeField, Tooltip("プレイヤーのSPの初期値")]
    private readonly int StartPlayerSp = 100;

    private const int PLAYER_MAX_HP = 100;
    private const int PLAYER_MAX_SP = 100;

    private int _playerHp = default;
    private int _playerSp = default;

    public int GetPlayerHp()
    {
        return _playerHp;
    }

    public int GetPlayerSp()
    {
        return _playerSp;
    }

    public void AddPlayerHp(int value)
    {
        _playerHp += value;
        _playerHp = Mathf.Clamp(_playerHp, 0, PLAYER_MAX_HP);
    }

    public void AddPlayerSp(int value)
    {
        _playerSp += value;
        _playerSp = Mathf.Clamp(_playerSp, 0, PLAYER_MAX_SP);
    }
}