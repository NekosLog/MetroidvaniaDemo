/* 制作日 2023/12/12
*　製作者 ニシガキ
*　最終更新日 2023/12/12
*/

using UnityEngine;
 
public class PlayerMove : MonoBehaviour ,IFPlayerMove, IFLandingEvent
{
    #region フィールド変数

    #region 定数
    // プレイヤーの左右移動速度
    private const float PLAYER_MALK_SPEED = 6f;

    // プレイヤーの跳躍力
    private const float PLAYER_JUMP_POWER = 15f;

    // プレイヤーのダッシュ速度
    private const float PLAYER_DASH_SPEED = 20f;

    // ダッシュの再使用までの時間
    private const float DASH_INTERVAL_TIME = 0.6f;
    #endregion

    #region シリアライズ
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
    #endregion

    #region インターフェース
    // Fallのインターフェース
    private IFFallObject _fall = default;

    // CheckWallのインターフェース
    private IFCheckWall _checkWall = default;

    // PlayerStateのインターフェース
    private IFPlayerState _playerState = default;
    #endregion

    // プレイヤーのトランスフォーム
    private Transform _player = default;

    // プレイヤーの歩行の移動加算量
    private Vector2 _walkValue = new Vector2(PLAYER_MALK_SPEED, 0);

    // プレイヤーのダッシュの移動加算量
    private Vector2 _dashValue = new Vector2(PLAYER_DASH_SPEED, 0);

    // ダッシュの継続時間
    private float _dashTime = 0.2f;

    // ダッシュの使用間隔を測る変数
    private float _dashInterval = 0f;

    // ダッシュ開始からの経過時間
    private float _nowDashTime = 0f;

    // プレイヤーが向いている正面方向
    private int _playerForword = 1;

    // 二段ジャンプができるかどうかのフラグ
    private bool _canDoubleJump = true;

    // ジャンプトークン　二段ジャンプを使用したかどうか
    private bool _jumpToken = false;

    // ダッシュ中フラグ　trueでダッシュ中
    private bool _nowDash = false;

    #endregion


    private void Awake()
    {
        // プレイヤーのトランスフォームを取得
        _player = this.transform;

        // _fallに自身が持つFallを代入
        _fall = this.GetComponent<Fall>();

        // _checkWallに自身が持つCheckWallを代入
        _checkWall = this.GetComponent<CheckWall>();

        // _playerStateに自身が持つPlayerStateを代入
        _playerState = this.GetComponent<PlayerState>();
        // Fallの初期値設定
        _fall.SetObjectSize(_playerDepth, _playerBottom);

        // CheckWallの初期値設定
        _checkWall.SetValue(_playerTop, _playerBottom, _playerDepth, _checkValue);
    }

    private void Update()
    {
        // ダッシュを行う
        Dash(_dashTime);
    }

    /// <summary>
    /// プレイヤーの左右移動を行うメソッド
    /// </summary>
    /// <param name="inputType">入力されたキー</param>
    public void PlayerWalking(E_InputType inputType)
    {
        // 歩ける状態のときのみ
        if (_playerState.GetState(E_PlayerState.Walk))
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
                    _playerForword = 1;
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
                    _playerForword = -1;
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
        // ダッシュができる かつ インターバル中かどうか
        if (_playerState.GetState(E_PlayerState.Dash) && _dashInterval <= 0)
        {
            // ダッシュ中に設定
            _nowDash = true;

            // 操作入力を無効化
            _playerState.SetAllState(false);

            // 一定時間後に操作入力を有効化
            _playerState.SetAllState(true, _dashTime);

            // ダッシュのインターバル設定
            _dashInterval = DASH_INTERVAL_TIME;
        }
    }

    /// <summary>
    /// ダッシュ中の処理
    /// </summary>
    /// <param name="dashTime">ダッシュの最大継続時間</param>
    private void Dash(float dashTime)
    {
        // ダッシュ中のみ処理
        if (_nowDash)
        {
            // 継続時間のカウント
            _nowDashTime += Time.deltaTime;

            // 壁と衝突していなければ前方へダッシュ
            if (_playerForword == 1 && _checkWall.CheckHit(E_InputType.Right) || _playerForword == -1 && _checkWall.CheckHit(E_InputType.Left))
            {
                // 壁と衝突
            }
            else
            {
                // ダッシュの移動加算
                _player.position += (Vector3)_dashValue * _playerForword * Time.deltaTime;
            }
            // 落下の無効化
            _fall.SetFallValue(0);

            // 時間になったら終了
            if (_nowDashTime > dashTime)
            {
                // ダッシュフラグを消す
                _nowDash = false;

                // 経過時間のリセット
                _nowDashTime = 0f;
            }
        }

        // インターバルのカウントダウン
        if (_dashInterval > 0)
        {
            // 時間をカウント
            _dashInterval -= Time.deltaTime;
        }
    }

    /// <summary>
    /// プレイヤーの落下や上昇を行うメソッド
    /// </summary>
    public void PlayerJump()
    {
        // ジャンプが可能かどうか
        if (_playerState.GetState(E_PlayerState.Jump))
        {
            // 二段ジャンプができるかどうか
            if (_canDoubleJump)
            {
                // ジャンプトークンがある場合
                if (_jumpToken)
                {
                    // 上昇力を設定
                    _fall.SetFallValue(PLAYER_JUMP_POWER);

                    // 空中の場合 ジャンプトークンを消費
                    if (!_fall.CheckLanding())
                    {
                        _jumpToken = false;
                    }
                }

            }
            else
            {
                // 着地しているかどうか
                if (_fall.CheckLanding())
                {
                    // 上昇力を設定
                    _fall.SetFallValue(PLAYER_JUMP_POWER);
                }
            }
        }
    }

    /// <summary>
    /// 着地時の処理
    /// </summary>
    public void LandingEvent()
    {
        // ジャンプトークンの回復
        _jumpToken = true;
    }
}