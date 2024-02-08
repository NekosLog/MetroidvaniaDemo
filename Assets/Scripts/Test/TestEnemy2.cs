/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;

public class TestEnemy2 : MoveBase
{
	private float _speed = -2.5f;
	E_InputType forward = E_InputType.Left;
	private void Start()
	{
		CheckFloor.SetObjectSize(1f, 0.5f, 3);
		CheckWall.SetValue(1, 1, 3);
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
	}
}