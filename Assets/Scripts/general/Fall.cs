/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using System.Collections;
 
public class Fall : MonoBehaviour, IFFall
{

    #region 定数
    // 重力の大きさ
    private const float GRAVITY = 35.0f;

    // 終端速度
    private const float TERMINAL = -15f;
    #endregion

    // オブジェクトの落下量
    private Vector2 _fallValue = default;

    // 着地時のイベントを渡すインターフェース
    private IFLandingEvent _landingEvent = default;

    private void Start()
    {
        _landingEvent = this.GetComponent<IFLandingEvent>();
    }

    /// <summary>
    /// オブジェクトの落下や上昇を行うメソッド
    /// </summary>
    public void FallObject(bool isLanding)
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
            if (_fallValue.y >= TERMINAL)
            {
                // 重力に応じて加速
                _fallValue.y -= GRAVITY * Time.deltaTime;
            }
        }

        // プレイヤーを移動
        transform.position += (Vector3)_fallValue * Time.deltaTime;
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
}