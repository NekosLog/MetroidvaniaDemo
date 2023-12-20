/* 制作日 2023/12/20
*　製作者 ニシガキ
*　最終更新日 2023/12/20
*/

using UnityEngine;
using System.Collections; 

public class PlayerState : MonoBehaviour
{
    private bool _canWalk = false;
    private bool _canJump = false;
    private bool _canDash = false;
    private bool _canCrouch = false;
    private bool _canAction = false;
    private bool _canAttack = false;
    private bool _canHeal = false;
    private bool _canSkill1 = false;
    private bool _canSkill2 = false;

    /// <summary>
    /// PlayerStateを取得するためのプロパティ
    /// </summary>
    /// <param name="state">取得するState</param>
    /// <returns></returns>
    public bool GetState(E_PlayerState state)
    {
        switch (state)
        {
            case E_PlayerState.Walk:
                return _canWalk;

            case E_PlayerState.Jump:
                return _canJump;

            case E_PlayerState.Dash:
                return _canDash;

            case E_PlayerState.Crouch:
                return _canCrouch;

            case E_PlayerState.Action:
                return _canAction;

            case E_PlayerState.Attack:
                return _canAttack;

            case E_PlayerState.Heal:
                return _canHeal;

            case E_PlayerState.Skill1:
                return _canSkill1;

            case E_PlayerState.Skill2:
                return _canSkill2;
        }
        Debug.LogError("PlayerStateに異常あり");
        return false;
    }

    /// <summary>
    /// PlayerStateの値を設定するプロパティ
    /// </summary>
    /// <param name="state">設定するState</param>
    /// <param name="value">設定する値</param>
    public void SetState(E_PlayerState state, bool value)
    {
        switch (state)
        {
            case E_PlayerState.Walk:
                _canWalk = value;
                break;

            case E_PlayerState.Jump:
                _canJump = value;
                break;

            case E_PlayerState.Dash:
                _canDash = value;
                break;

            case E_PlayerState.Crouch:
                _canCrouch = value;
                break;

            case E_PlayerState.Action:
                _canAction = value;
                break;

            case E_PlayerState.Attack:
                _canAttack = value;
                break;

            case E_PlayerState.Heal:
                _canHeal = value;
                break;

            case E_PlayerState.Skill1:
                _canSkill1 = value;
                break;

            case E_PlayerState.Skill2:
                _canSkill2 = value;
                break;
        }
    }

    #region セット用プロパティ
    /// <summary>
    /// PlayerStateの値を設定するプロパティ
    /// </summary>
    /// <param name="state1">設定するState</param>
    /// <param name="state2">設定するState</param>
    /// <param name="value">設定する値</param>
    public void SetState(E_PlayerState state1 , E_PlayerState state2, bool value)
    {
        SetState(state1, value);
        SetState(state2, value);
    }

    /// <summary>
    /// PlayerStateの値を設定するプロパティ
    /// </summary>
    /// <param name="state1">設定するState</param>
    /// <param name="state2">設定するState</param>
    /// <param name="state3">設定するState</param>
    /// <param name="value">設定する値</param>
    public void SetState(E_PlayerState state1, E_PlayerState state2, E_PlayerState state3, bool value)
    {
        SetState(state1, value);
        SetState(state2, value);
        SetState(state3, value);
    }

    /// <summary>
    /// PlayerStateの値を設定するプロパティ
    /// </summary>
    /// <param name="state1">設定するState</param>
    /// <param name="state2">設定するState</param>
    /// <param name="state3">設定するState</param>
    /// <param name="state4">設定するState</param>
    /// <param name="value">設定する値</param>
    public void SetState(E_PlayerState state1, E_PlayerState state2, E_PlayerState state3, E_PlayerState state4, bool value)
    {
        SetState(state1, value);
        SetState(state2, value);
        SetState(state3, value);
        SetState(state4, value);
    }

    /// <summary>
    /// PlayerStateの値を設定するプロパティ
    /// </summary>
    /// <param name="state1">設定するState</param>
    /// <param name="state2">設定するState</param>
    /// <param name="state3">設定するState</param>
    /// <param name="state4">設定するState</param>
    /// <param name="state5">設定するState</param>
    /// <param name="value">設定する値</param>
    public void SetState(E_PlayerState state1, E_PlayerState state2, E_PlayerState state3, E_PlayerState state4, E_PlayerState state5, bool value)
    {
        SetState(state1, value);
        SetState(state2, value);
        SetState(state3, value);
        SetState(state4, value);
        SetState(state5, value);
    }
    #endregion

    /// <summary>
    /// すべてのStateに値を設定するプロパティ
    /// </summary>
    /// <param name="value">設定する値</param>
    public void SetAllState(bool value)
    {
        _canWalk = value;
        _canJump = value;
        _canDash = value;
        _canCrouch = value;
        _canAction = value;
        _canAttack = value;
        _canHeal = value;
        _canSkill1 = value;
        _canSkill2 = value;
    }

    /// <summary>
    /// <para>すべてのStateに値を設定するプロパティ</para>
    /// <para>指定した時間待ってから実行</para>
    /// </summary>
    /// <param name="value">設定する値</param>
    /// <param name="delayTime">処理を待つ時間</param>
    public void SetAllState(bool value, float delayTime)
    {
        StartCoroutine(DelaySet(value, delayTime));
    }

    /// <summary>
    /// 指定した時間待ってから実装するためのコルーチン
    /// </summary>
    /// <param name="value"></param>
    /// <param name="delayTime"></param>
    /// <returns></returns>
    private IEnumerator DelaySet(bool value, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SetAllState(value);
    }
}