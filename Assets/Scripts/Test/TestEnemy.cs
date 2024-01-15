/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using System.Collections;
 
public class TestEnemy : MoveBase, IFLandingEvent
{
	private int _speed = -1;
	E_InputType forward = E_InputType.Left;
	IFFall _fall = default;
	private void Start()
	{
		_fall = this.GetComponent<IFFall>();
		CheckFloor.SetObjectSize(1f,0.5f);
		CheckWall.SetValue(0.5f,0.5f,1,0);
	}

	private void Update()
	{
		this.transform.position += _speed * Vector3.right * Time.deltaTime;

        if (CheckWall.CheckHit(forward))
        {
            if (forward == E_InputType.Left)
            {
				forward = E_InputType.Right;
            }
            else
            {
				forward = E_InputType.Left;
            }
			_speed = _speed * -1;
        }

		_fall.FallObject(CheckFloor.CheckLanding());
	}

    public void LandingEvent()
    {
		return;
    }
}