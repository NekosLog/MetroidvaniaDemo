/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
 
public class TestGoTitle : MonoBehaviour {

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}