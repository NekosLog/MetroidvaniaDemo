/* 制作日 2023/12/14
*　製作者 ニシガキ
*　最終更新日 2023/12/14
*/

using UnityEngine;
 
public class Fall : MonoBehaviour,IFFallObject
{
    #region フィールド変数

    #region 定数
    // 重力の大きさ
    private const float GRAVITY = 35.0f;

    // 終端速度
    private const float TERMINAL = -15f;
    #endregion

    #region インターフェース
    // 落下時のイベントを渡すためのインターフェース
    private IFLandingEvent _landingEvent = default;
    #endregion

    // 落下するオブジェクト
    private Transform _object = default;

    // オブジェクトの落下量
    private Vector2 _fallValue = default;

    // オブジェクトの太さ　着地判定の幅を決めるのに使用　横幅の半分
    private float _objectDepth = default;

    // オブジェクトの下の幅　着地判定の出始めを決めるのに使用
    private float _objectBottom = default;

    #endregion


    private void Awake()
    {
        // 落下するオブジェクトを設定する
        _object = this.transform;

        // 落下時のイベントを登録
        _landingEvent = this.GetComponent<IFLandingEvent>();
    }

    private void Update()
    {
        // 落下処理を実行
        FallObject(CheckLanding());
    }

    /// <summary>
    /// オブジェクトの落下や上昇を行うメソッド
    /// </summary>
    private void FallObject(bool isLanding)
    {
        // 着地しているかどうか
        if (_fallValue.y <= 0 && isLanding)
        {
            if (_fallValue.y != 0)
            {
                // 速度を０にする
                _fallValue = Vector2.zero;

                // 着地時のイベントを実行
                _landingEvent.LandingEvent();
            }
        }
        else
        {
            // 終端速度より遅いなら加速
            if(_fallValue.y >= TERMINAL)
            {
                // 重力に応じて加速
                _fallValue.y -= GRAVITY * Time.deltaTime;
            }
        }

        // プレイヤーを移動
        _object.position += (Vector3)_fallValue * Time.deltaTime;
    }

    /// <summary>
    /// オブジェクトが着地しているかどうかを判定するbool
    /// </summary>
    public bool CheckLanding()
    {
        // レイの長さ
        float rayLength = 0.02f;

        // ステージのレイヤーマスク
        LayerMask groundLayer = 1 << 6;

        // レイの生成と判定
        RaycastHit2D hit1 = Physics2D.Raycast(_object.position + _objectDepth * Vector3.right - _objectBottom * Vector3.up, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(_object.position - _objectDepth * Vector3.right - _objectBottom * Vector3.up, Vector2.down, rayLength, groundLayer);

        // 結果を返す
        return hit1.collider != null || hit2.collider != null;
    }

    /// <summary>
    /// 落下量を設定するメソッド
    /// </summary>
    /// <param name="setValue">設定する落下量</param>
    public void SetFallValue(float setValue)
    {
        // 値を設定
        _fallValue.y = setValue;
    }

    /// <summary>
    /// オブジェクトのサイズを設定するメソッド
    /// </summary>
    /// <param name="objectDepth">オブジェクトの横幅</param>
    /// <param name="objectBottom">オブジェクトの下幅</param>
    public void SetObjectSize(float objectDepth, float objectBottom)
    {
        // 各値を設定
        _objectDepth = objectDepth / 2; // 横幅の半分
        _objectBottom = objectBottom;
    }
}