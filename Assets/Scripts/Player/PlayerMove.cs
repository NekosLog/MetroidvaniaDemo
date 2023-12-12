/* 制作日 2023/12/12
*　製作者 ニシガキ
*　最終更新日 2023/12/12
*/

using UnityEngine;
using System.Collections;
 
public class PlayerMove : MonoBehaviour ,IFPlayerMove
{
    // プレイヤーのトランスフォーム
    private Transform _player = default;

    // プレイヤーの左右移動速度
    private const float PLAYER_MALK_SPEED = 3f;

    // プレイヤーの歩行の移動加算量
    private Vector2 _walkValue = new Vector2(PLAYER_MALK_SPEED, 0);

    // プレイヤーの上下の移動加算量
    private Vector2 _fallValue = default;

    private void Awake()
    {
        // プレイヤーのトランスフォームを取得
        _player = this.transform;
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// プレイヤーの左右移動を行うメソッド
    /// </summary>
    /// <param name="inputType">入力されたキー</param>
    public void PlayerWalking(E_InputType inputType)
    {
        // 移動方向
        int direction;

        // 入力から移動方向を設定
        if (inputType == E_InputType.Right)
        {
            // 右に移動
            direction = 1;
        }
        else if (inputType == E_InputType.Left)
        {
            // 左に移動
            direction = -1;
        }
        else
        {
            // エラー入力
            direction = 0;
            Debug.LogError("移動入力に異常あり:入力が左右以外");
        }

        // プレイヤーを移動
        _player.position += (Vector3)_walkValue * direction * Time.deltaTime;
    }

    /// <summary>
    /// プレイヤーの落下や上昇を行うメソッド
    /// </summary>
    private void PlayerFall(bool isLanding)
    {
        if (isLanding)
        {
            _fallValue = Vector2.zero;
        }

        // プレイヤーを移動
        _player.position += (Vector3)_fallValue * Time.deltaTime;
    }
}