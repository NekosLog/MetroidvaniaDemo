/* 制作日 2023/12/12
*　製作者 ニシガキ
*　最終更新日 2023/12/12
*/

using System.Collections;
using UnityEngine;
 
public class PlayerMove : MoveBase, IFPlayerMove, IFLandingEvent
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

    // 攻撃の再使用までの時間
    private const float ATTACK_INTERVAL_TIME = 0.25f;

    // 攻撃後の行動可能になるまでの時間　攻撃後の硬直
    private const float ATTACK_STIFFENING = 0.3f;

    // 攻撃判定の持続時間
    private const float ATTACK_LIFE_TIME = 0.1f;

    // スキル１の消費SP量
    private const int SKILL1_COST = 30;

    // スキル１後の再行動可能になるまでの時間　硬直
    private const float SKILL1_STIFFENING = 0.3f;
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

    // 攻撃の判定コライダー
    [SerializeField]
    private Collider2D _attackCollider = default;

    // スキル１で発射する球
    [SerializeField]
    private GameObject _skill1_Bullet = default;
    #endregion

    #region インターフェース
    // PlayerStateのインターフェース
    private IFPlayerState _playerState = default;

    // Fallのインターフェース
    private IFFall _fall = default;

    // PlayerParameterのインターフェース
    private IFPlayerParameter _playerParameter = default;
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

    // 攻撃の使用間隔を測る変数
    private float _attackInterval = default;

    // 攻撃後の再行動可能になるまでの時間を測る変数
    private float _attackStiffening = default;

    #endregion

    private void Start()
    {
        // プレイヤーのトランスフォームを取得
        _player = this.transform;

        // _fallに自身が持つFallを代入
        _fall = this.GetComponent<IFFall>();

        // _playerStateに自身が持つPlayerStateを代入
        _playerState = this.GetComponent<PlayerState>();
        // _playerParameterに自身が持つPlayerParameterを代入
        _playerParameter = this.GetComponent<PlayerParamater>();
        // Fallの初期値設定
        CheckFloor.SetObjectSize(_playerDepth, _playerBottom);

        // CheckWallの初期値設定
        CheckWall.SetValue(_playerTop, _playerBottom, _playerDepth, _checkValue);
    }

    private void Update()
    {
        // 時間を測る
        TimeCount();

        // ダッシュを行う
        Dash(_dashTime);

        // 落下処理
        _fall.FallObject(CheckFloor.CheckLanding());
        
    }

    private void TimeCount()
    {
        // ダッシュのインターバルのカウントダウン
        if (_dashInterval > 0)
        {
            // 時間をカウント
            _dashInterval -= Time.deltaTime;
        }

        // 攻撃のインターバルのカウントダウン
        if (_attackInterval > 0)
        {
            // 時間をカウント
            _attackInterval -= Time.deltaTime;
        }

        // 攻撃後の再行動可能になるまでの時間のカウントダウン
        if (_attackStiffening > 0)
        {
            // 時間をカウント
            _attackStiffening -= Time.deltaTime;
        }
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
            Quaternion lookVector = Quaternion.Euler(Vector3.zero);

            // プレイヤーの向きを設定
            SetRotate(lookVector);

            // 壁と接触しているかどうか
            if (!CheckWall.CheckHit(E_InputType.Right))
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
            Quaternion lookVector = Quaternion.Euler(new Vector3(0, 180, 0));
            SetRotate(lookVector);

            // 壁と接触しているかどうか
            if (!CheckWall.CheckHit(E_InputType.Left))
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

        // 歩ける状態のときのみ
        if (_playerState.GetState(E_PlayerState.Walk))
        {
            // プレイヤーを移動
            _player.position += (Vector3)_walkValue * direction * Time.deltaTime;
        }
    }

    /// <summary>
    /// プレイヤーの角度を設定するメソッド
    /// </summary>
    /// <param name="lookVector"></param>
    private void SetRotate(Quaternion lookVector)
    {
        // ステータスから回転できるか判定
        if (_playerState.GetState(E_PlayerState.Rotate))
        {
            // プレイヤーの向きを設定
            if (transform.rotation != lookVector)
            {
                transform.rotation = lookVector;
            }
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
            if (_playerForword == 1 && CheckWall.CheckHit(E_InputType.Right) || _playerForword == -1 && CheckWall.CheckHit(E_InputType.Left))
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
                    if (!CheckFloor.CheckLanding())
                    {
                        _jumpToken = false;
                    }
                }

            }
            else
            {
                // 着地しているかどうか
                if (CheckFloor.CheckLanding())
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

        // 攻撃中に着地したら移動不可にする
        if (_attackStiffening > 0)
        {
            _playerState.SetState(E_PlayerState.Walk, false);
        }
    }

    /// <summary>
    /// プレイヤーの攻撃を行うメソッド
    /// </summary>
    public void PlayerAttack()
    {
        if (_playerState.GetState(E_PlayerState.Attack) && _attackInterval <= 0)
        {
            // 再攻撃までの時間を設定
            _attackInterval = ATTACK_INTERVAL_TIME;

            // 攻撃後の再行動可能になるまでの時間を設定
            _attackStiffening = ATTACK_STIFFENING;

            // プレイヤーのステータスを設定　攻撃だけtrue その他はfalse
            _playerState.SetAllState(false) ;
            _playerState.SetState(E_PlayerState.Attack, true);

            // 空中だった場合、移動のみ許可する
            if (!CheckFloor.CheckLanding())
            {
                // 歩行のみtrueに設定
                _playerState.SetState(E_PlayerState.Walk, true);
            }

            // 攻撃硬直が終わったらステータスを戻す
            _playerState.SetAllState(true, ATTACK_STIFFENING);

            // 攻撃を実行
            StartCoroutine(Attack());
        }
    }

    public void PlayerSkill(E_InputType skillType)
    {
        switch (skillType)
        {
            case E_InputType.Skill1:
                Skill1();
                break;

            case E_InputType.Skill2:
                // Skill2を実装
                break;
        }

    }

    private void Skill1()
    {
        if (_playerState.GetState(E_PlayerState.Skill1))
        {
            if (_playerParameter.GetPlayerSp() >= SKILL1_COST)
            {
                Quaternion lookVector = default;
                int right = 1;
                int left = -1;
                if (_playerForword == right)
                {
                    lookVector = Quaternion.Euler(Vector3.zero);
                }
                else if (_playerForword == left)
                {
                    lookVector = Quaternion.Euler(new Vector3(0, 180, 0));
                }
                Instantiate(_skill1_Bullet, transform.position, lookVector);

                _playerState.SetAllState(false);
                _playerState.SetAllState(true, )
            }
            else
            {
                print("SP足りないよ");
            }
        }
    }

    private IEnumerator Attack()
    {
        _attackCollider.enabled = true;
        yield return new WaitForSeconds(ATTACK_LIFE_TIME);
        _attackCollider.enabled = false;
    }
}