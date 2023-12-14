/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using System.Collections;
 
public class TestEnemy : MonoBehaviour ,IFLandingEvent
{
 
	private void Awake()
	{
		IFFallObject fall = this.GetComponent<IFFallObject>();
		fall.SetObjectSize(0.5f,0.5f);
	}
	
	private void Start()
	{
	}

	private void Update()
	{
		this.transform.position += -Vector3.right * Time.deltaTime;
	}

	private void OnDestroy()
	{
	}

    public void LandingEvent()
    {
		return;
    }
}