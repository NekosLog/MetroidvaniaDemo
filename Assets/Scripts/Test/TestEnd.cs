/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using UnityEngine.SceneManagement;
 
public class TestEnd : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}