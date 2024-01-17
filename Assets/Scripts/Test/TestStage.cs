/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using System.Collections.Generic;
 
public class TestStage : MonoBehaviour 
{
    [SerializeField]
    StageDatas stagedatas = default;

    [SerializeField]
    CameraMove M = default;

    private void Awake()
    {
        SearchStage(StageNumberList.TEST1);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SearchStage(StageNumberList.TEST2);
            GameObject.Find("Player").transform.position = new Vector2(50,50);
        }
    }

    private void SearchStage(string stageNumber)
    {
        foreach (StageParameter emp in stagedatas.EnemyParamList)
        {
            if (emp.StageNumber == stageNumber)
            {
                M.SetStage(emp.CameraOrigin, emp.StageWidth, emp.StageHeight);
                return;
            }
        }
        Debug.LogError("ステージが見つかりませんでした。");
    }
}