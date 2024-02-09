/* 制作日 2023/12/15
*　製作者 ニシガキ
*　最終更新日 2023/12/15
*/

using UnityEngine;
 
public class CheckWall
{
    /// <summary>
    /// コンストラクタ<br />
    /// 使用しない
    /// </summary>
    public CheckWall() { }

    /// <summary>
    /// コンストラクタ<br />
    /// 自身のオブジェクトを代入する
    /// </summary>
    /// <param name="thisTransform">代入するTransform</param>
    public CheckWall(Transform thisTransform)
    {
        // 自身のTransformを取得
        _thisTransform = thisTransform;
    }

    #region フィールド変数

    // 自身のオブジェクト
    private Transform _thisTransform = default;
    
	// オブジェクトの下の幅　接触判定の下端を決めるのに使用
    private float _objectButtom = default;

    // オブジェクトの太さ　着地判定の幅を決めるのに使用　横幅の半分
    private float _objectDepth = default;
	
	// 接触判定の細かさ　上端と下端の間に何本の判定をとるか
	private int _checkValue = default;

	// 判定の間隔　上下端と本数によって変動
	private float _checkDistance = default;

    #endregion

    /// <summary>
    /// 接触判定の設定用メソッド
    /// </summary>
    /// <param name="top">オブジェクトの上の幅</param>
    /// <param name="bottom">オブジェクトの下の幅</param>
    /// <param name="objectDepth">オブジェクトの横幅</param>
    /// <param name="checkValue">判定の細かさ</param>
    public void SetValue(float objectHeight, float objectDepth, int checkValue)
    {
		// 判定の細かさの最低値
		int checkMinimunValue = 2;

		// 各値を設定
		_objectDepth = objectDepth / 2; // 横幅の半分
		_objectButtom = objectHeight / 2; // 縦幅の半分

        // 判定の細かさの最低値を下回っていないか
        if (checkValue >= checkMinimunValue)
        {
			// 上回っている
			_checkValue = checkValue;
        }
        else
        {
			// 下回っている
			_checkValue = checkMinimunValue;
        }

		// 値から判定の間隔を設定　間隔を求めるため上下幅÷(本数ー１)
		_checkDistance = objectHeight / (_checkValue - 1);
    }


    /// <summary>
    /// オブジェクトと接触しているかどうか
    /// </summary>
    /// <param name="direction">左右どちらの判定をとるか</param>
    /// <returns></returns>
    public bool CheckHit(E_InputType direction)
    {
        // 正面のベクトル
        Vector3 forwardVector = default;

        // 左右どちから
        switch (direction)
        {
            // 右
            case E_InputType.Right:
                forwardVector = Vector3.right;
                break;

            // 左
            case E_InputType.Left:
                forwardVector = -Vector3.right;
                break;
        }

        // レイの長さ
        float rayLength = 0.1f;

        // ステージのレイヤーマスク
        LayerMask groundLayer = 1 << 6;

        // レイの生成と判定
        for (int i = 0; i < _checkValue; i++)
        {
            // オブジェクトと接触しているか判定
            RaycastHit2D isHit = Physics2D.Raycast(_thisTransform.position + _objectDepth * forwardVector - (_objectButtom - _checkDistance * i) * Vector3.up, forwardVector, rayLength, groundLayer);

            // オブジェクトに当たっているかどうか
            if (isHit.collider != null)
            {
                // ぶつかっている場合
                return true;
            }
        }
        // ぶつかっていない場合
        return false;
    }
}