/* 制作日 2023/11/30
*　製作者 猫の足跡
*　最終更新日 2023/11/30
*/

using UnityEngine;
 
public interface IFGetInputEvents 
{
    void GetRightEvent();
    void GetLeftEvent();
    void GetUpEvent();
    void GetDownEvent();
    void GetActionEvent();
    void GetJumpEvent();
    void GetDashEvent();
    void GetAttackEvent();
    void GetHealEvent();
    void GetSkill1Event();
    void GetSkill2Event();
    void GetMenuEvent();
    void GetMapEvent();
}