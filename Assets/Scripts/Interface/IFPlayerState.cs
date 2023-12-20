/* 制作日 2023/12/20
*　製作者 ニシガキ
*　最終更新日 2023/12/20
*/
 

/// <summary>
/// PlayerStateのインターフェース
/// </summary>
public interface IFPlayerState {
    public bool GetState(E_PlayerState state);
    public void SetState(E_PlayerState state, bool value);
    public void SetState(E_PlayerState state, bool value, float delayTime);
    public void SetAllState(bool value);
    public void SetAllState(bool value, float delayTime);
}