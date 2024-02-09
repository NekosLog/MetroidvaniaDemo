/* 制作日 2024/01/12
*　製作者 ニシガキ
*　最終更新日 2024/01/15
*/

using UnityEngine;
 
public class MoveBase : MonoBehaviour
{
    // 床判定
    protected CheckFloor CheckFloor = default;

    // 壁判定
    protected CheckWall CheckWall = default;

    // 天井判定
    protected CheckCeiling CheckCeiling = default;

    /// <summary>
    /// 初期設定　クラスのインスタンス
    /// </summary>
    private void Awake()
    {
        // それぞれのクラスをインスタンス
        CheckFloor = new CheckFloor(this.transform);
        CheckWall = new CheckWall(this.transform);
        CheckCeiling = new CheckCeiling(this.transform);
    }
}