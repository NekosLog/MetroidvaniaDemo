/* 制作日 2024/01/30
*　製作者 ニシガキ
*　最終更新日 2024/01/30
*/

using UnityEngine;
using System.Collections;
 
public class PlayerAttackCollider : MonoBehaviour {
    [SerializeField]
    private int _addSp = 30;

    private IFPlayerParameter _playerParameter = default;

    private void Awake()
    {
        _playerParameter = GameObject.FindWithTag("Player").GetComponent<PlayerParamater>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            _playerParameter.AddPlayerSp(_addSp);
            Destroy(collision.gameObject);
        }
    }
}