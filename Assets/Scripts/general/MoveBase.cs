/* 制作日 2024/01/12
*　製作者 ニシガキ
*　最終更新日 2024/01/15
*/

using UnityEngine;
 
public class MoveBase : MonoBehaviour 
{
    protected CheckFloor CheckFloor = default;
    protected CheckWall CheckWall = default;
    protected CheckCeiling CheckCeiling = default;

    private void Awake()
    {
        CheckFloor = new CheckFloor(this.transform);
        CheckWall = new CheckWall(this.transform);
        CheckCeiling = new CheckCeiling(this.transform);
    }
}