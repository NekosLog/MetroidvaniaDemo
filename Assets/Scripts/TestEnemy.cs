/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using System.Collections;
 
public class TestEnemy : MonoBehaviour ,IFLandingEvent
{
	private int _speed = -1;
	IFCheckWall check;
	E_InputType forward = E_InputType.Left;
	private void Awake()
	{
		IFFallObject fall = this.GetComponent<IFFallObject>();
		check = this.GetComponent<IFCheckWall>();
		fall.SetObjectSize(1f,0.5f);
		check.SetValue(0.5f,0.5f,1,0);
	}
	
	private void Start()
	{
	}

	private void Update()
	{
		this.transform.position += _speed * Vector3.right * Time.deltaTime;

        if (check.CheckHit(forward))
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

	private void OnDestroy()
	{
	}

    public void LandingEvent()
    {
		return;
    }
}