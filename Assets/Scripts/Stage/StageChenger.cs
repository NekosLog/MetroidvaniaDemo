/* 制作日 2024/01/17
*　製作者 ニシガキ
*　最終更新日 2024/01/17
*/

using UnityEngine;
using System.Collections;
 
public class StageChenger : MonoBehaviour 
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

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

    private void Teleportation(Vector2 position)
    {
         
    }
}