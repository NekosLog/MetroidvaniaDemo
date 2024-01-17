/* 制作日 2023/12/14
*　製作者 ニシガキ
*　最終更新日 2023/12/14
*/

using UnityEngine;
 
public class CheckFloor
{
    /// <summary>
    /// 使用しない
    /// </summary>
    public CheckFloor() { }

    /// <summary>
    /// コンストラクタ<br>
    /// 自身のオブジェクトを代入する
    /// </summary>
    /// <param name="thisTransform"></param>
    public CheckFloor(Transform thisTransform)
    {
        _thisTransform = thisTransform;
    }

    #region フィールド変数

    // オブジェクトの太さ　着地判定の幅を決めるのに使用　横幅の半分
    private float _objectDepth = default;

    // オブジェクトの下の幅　着地判定の出始めを決めるのに使用
    private float _objectBottom = default;

    // 処理を行うオブジェクトのトランスフォーム
    private Transform _thisTransform = default;
    #endregion

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
        RaycastHit2D hit1 = Physics2D.Raycast(_thisTransform.position + _objectDepth * Vector3.right - _objectBottom * Vector3.up, Vector2.down, rayLength, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(_thisTransform.position - _objectDepth * Vector3.right - _objectBottom * Vector3.up, Vector2.down, rayLength, groundLayer);

        // 結果を返す
        return hit1.collider != null || hit2.collider != null;
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