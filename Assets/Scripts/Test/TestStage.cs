/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using System.Collections;
 
public class TestStage : MonoBehaviour 
{
    private CameraMove M = default;

    public Vector2 a = new Vector2(0,0);
    public float b = default;
    public float c = default;

    private void Awake()
    {
        M = GetComponent<CameraMove>();
        M.SetStage(a,b,c);
    }
}