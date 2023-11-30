/* 制作日 2023/11/30
*　製作者 猫の足跡
*　最終更新日 2023/11/30
*/

using System;
using System.Collections.Generic;
 
public class InputEvents:IFSetInputEvents,IFGetInputEvents
{
    public delegate void InputDelegate();

    public InputDelegate _rightEvent;
    public InputDelegate _leftEvent;
    public InputDelegate _upEvent;
    public InputDelegate _downEvent;
    public InputDelegate _actionEvent;
    public InputDelegate _jumpEvent;
    public InputDelegate _dashEvent;
    public InputDelegate _attackEvent;
    public InputDelegate _healEvent;
    public InputDelegate _skill1Event;
    public InputDelegate _skill2Event;
    public InputDelegate _menuEvent;
    public InputDelegate _mapEvent;



    #region GetEvents
    public void GetRightEvent()
    {
        throw new System.NotImplementedException();
    }

    public void GetLeftEvent()
    {
        throw new System.NotImplementedException();
    }

    public void GetUpEvent()
    {
        throw new System.NotImplementedException();
    }

    public void GetDownEvent()
    {
        throw new System.NotImplementedException();
    }

    public void GetActionEvent()
    {
        throw new System.NotImplementedException();
    }

    public void GetJumpEvent()
    {
        throw new System.NotImplementedException();
    }

    public void GetDashEvent()
    {
        throw new System.NotImplementedException();
    }

    public void GetAttackEvent()
    {
        throw new System.NotImplementedException();
    }

    public void GetHealEvent()
    {
        throw new System.NotImplementedException();
    }

    public void GetSkill1Event()
    {
        throw new System.NotImplementedException();
    }

    public void GetSkill2Event()
    {
        throw new System.NotImplementedException();
    }

    public void GetMenuEvent()
    {
        throw new System.NotImplementedException();
    }

    public void GetMapEvent()
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #region SetEvents
    public void SetRightEvent(List<Action> eventList)
    {
        throw new NotImplementedException();
    }

    public void SetLeftEvent(List<Action> eventList)
    {
        throw new NotImplementedException();
    }

    public void SetUpEvent(List<Action> eventList)
    {
        throw new NotImplementedException();
    }

    public void SetDownEvent(List<Action> eventList)
    {
        throw new NotImplementedException();
    }

    public void SetActionEvent(List<Action> eventList)
    {
        throw new NotImplementedException();
    }

    public void SetJumpEvent(List<Action> eventList)
    {
        throw new NotImplementedException();
    }

    public void SetDashEvent(List<Action> eventList)
    {
        throw new NotImplementedException();
    }

    public void SetAttackEvent(List<Action> eventList)
    {
        throw new NotImplementedException();
    }

    public void SetHealEvent(List<Action> eventList)
    {
        throw new NotImplementedException();
    }

    public void SetSkill1Event(List<Action> eventList)
    {
        throw new NotImplementedException();
    }

    public void SetSkill2Event(List<Action> eventList)
    {
        throw new NotImplementedException();
    }

    public void SetMenuEvent(List<Action> eventList)
    {
        throw new NotImplementedException();
    }

    public void SetMapEvent(List<Action> eventList)
    {
        throw new NotImplementedException();
    }
    #endregion
}