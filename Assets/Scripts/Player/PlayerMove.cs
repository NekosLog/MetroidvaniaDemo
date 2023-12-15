/* 制作日 2023/12/12
*　製作者 ニシガキ
*　最終更新日 2023/12/12
*/

using UnityEngine;
using System.Collections;
 
public class PlayerMove : MonoBehaviour ,IFPlayerMove, IFLandingEvent
{
    // Fallのインターフェース
    private IFFallObject _fall = default;

    // CheckWallのインターフェース
    private IFCheckWall _checkWall = default;

    // プレイヤーのトランスフォーム
    private Transform _player = default;

    // プレイヤーの左右移動速度
    private const float PLAYER_MALK_SPEED = 6f;

    // プレイヤーの歩行の移動加算量
    private Vector2 _walkValue = new Vector2(PLAYER_MALK_SPEED, 0);

    // プレイヤーの跳躍力
    private const float PLAYER_JUMP_POWER = 15f;

    // 二段ジャンプができるかどうかのフラグ
    private bool _canDoubleJump = true;

    // 二段ジャンプを使用しているかどうか
    private bool _useJump = false;

    // 歩けるかどうかのフラグ
    private bool _canWalk = true;

    // ダッシュが可能かどうか
    private bool _canDash = true;

    // プレイヤーの横幅
    [SerializeField]
    private float _playerDepth = default;

    // プレイヤーの上の幅
    [SerializeField]
    private float _playerTop = default;

    // プレイヤーの下の幅
    [SerializeField]
    private float _playerBottom = default;

    // 接触判定の細かさ
    [SerializeField]
    private int _checkValue = default;

    private void Awake()
    {
        // プレイヤーのトランスフォームを取得
        _player = this.transform;

        // _fallに自身が持つFallを代入
        _fall = this.GetComponent<Fall>();

        // _checkWallに自身が持つCheckWallを代入
        _checkWall = this.GetComponent<CheckWall>();

        // Fallの初期値設定
        _fall.SetObjectSize(_playerDepth, _playerBottom);

        // CheckWallの初期値設定
        _checkWall.SetValue(_playerTop, _playerBottom, _playerDepth, _checkValue);
    }

    /// <summary>
    /// プレイヤーの左右移動を行うメソッド
    /// </summary>
    /// <param name="inputType">入力されたキー</param>
    public void PlayerWalking(E_InputType inputType)
    {
        // 歩ける状態のときのみ
        if (_canWalk)
        {
            // 移動方向
            int direction;

            // 入力から移動方向を設定
            if (inputType == E_InputType.Right)
            {
                // 壁と接触しているかどうか
                if (!_checkWall.CheckHit(E_InputType.Right))
                {
                    // 右に移動
                    direction = 1;
                }
                else
                {
                    // 壁と接触中
                    direction = 0;
                }
            }
            else if (inputType == E_InputType.Left)
            {
                // 壁と接触しているかどうか
                if (!_checkWall.CheckHit(E_InputType.Left))
                {
                    // 左に移動
                    direction = -1;
                }
                else
                {
                    // 壁と接触中
                    direction = 0;
                }
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
    }

    /// <summary>
    /// プレイヤーのダッシュを行うメソッド
    /// </summary>
    public void PlayerDash()
    {
        if (_canDash)
        {
            
        }
    }

    /// <summary>
    /// プレイヤーの落下や上昇を行うメソッド
    /// </summary>
    public void PlayerJump()
    {
        if (_canDoubleJump)
        {
            if (!_useJump)
            {
                _fall.SetFallValue(PLAYER_JUMP_POWER);
                if (!_fall.CheckLanding())
                {
                    _useJump = true;
                }
            }

        }
        else
        {
            if (_fall.CheckLanding())
            {
                _fall.SetFallValue(PLAYER_JUMP_POWER);
            }
        }
    }

    public void LandingEvent()
    {
        _useJump = false;
    }
}