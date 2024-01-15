/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using System.Collections;
 
public class CheckCeiling
{
    public CheckCeiling() { }

    public CheckCeiling(Transform thisTransform)
    {
        _thisTransfrom = thisTransform;
    }

    private Transform _thisTransfrom = default;
}