/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using System.Collections;
 
public class SkillBulletMove : MonoBehaviour
{
    [SerializeField, Tooltip("弾速")]
    private float _bulletSpeed = 10f;

    private float _lifeTime = default;

    private const float LIFE_TIME_LIMITE = 2f;

    private Renderer _myRenderer = default;

    private void Awake()
    {
        _myRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _bulletSpeed * Time.deltaTime);

        _lifeTime += Time.deltaTime;

        if (!_myRenderer.isVisible)
        {
            Destroy(gameObject);
        }

        if (_lifeTime > LIFE_TIME_LIMITE)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Enemy":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                print("たまたま");
                break;

            default:
                print("これじゃない");
                break;
        }
    }

}