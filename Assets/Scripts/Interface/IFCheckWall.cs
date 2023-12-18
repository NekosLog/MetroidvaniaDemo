/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
 
public interface IFCheckWall {
    void SetValue(float top, float bottom, float depth, int checkValue);
    bool CheckHit(E_InputType direction);
}