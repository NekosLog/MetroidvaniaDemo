/* 制作日
*　製作者
*　最終更新日
*/

using System;
using System.Collections.Generic;
 
public interface IFSetInputEvents 
{
    void SetRightEvent(List<Action> eventList);
    void SetLeftEvent(List<Action> eventList);
    void SetUpEvent(List<Action> eventList);
    void SetDownEvent(List<Action> eventList);
    void SetActionEvent(List<Action> eventList);
    void SetJumpEvent(List<Action> eventList);
    void SetDashEvent(List<Action> eventList);
    void SetAttackEvent(List<Action> eventList);
    void SetHealEvent(List<Action> eventList);
    void SetSkill1Event(List<Action> eventList);
    void SetSkill2Event(List<Action> eventList);
    void SetMenuEvent(List<Action> eventList);
    void SetMapEvent(List<Action> eventList);
}