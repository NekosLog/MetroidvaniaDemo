/* 制作日 2024/01/30
*　製作者 ニシガキ
*　最終更新日 2024/01/30
*/

using UnityEngine;
using System.Collections;
 
public class PlayerAttackCollider : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            print("あたってるよん");
            Destroy(collision.gameObject);
        }
    }
}