/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using System.Collections;
 
public class TestStartGame : MonoBehaviour {
	private void Awake()
	{
		CameraMove CameraMove = this.gameObject.GetComponent<CameraMove>();
		StageDatas stageDatas = GameObject.FindWithTag("StageDatas").GetComponent<StageDatasManager>().GetStageDatas();
		StageParameter parameter = default;
		foreach(StageParameter parm in stageDatas.StageParameterList)
        {
            if (parm.StageNumber == E_StageNumber.TEST1.ToString())
            {
				parameter = parm;
            }
        }
		CameraMove.SetStage(parameter);
	}
	
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}
}