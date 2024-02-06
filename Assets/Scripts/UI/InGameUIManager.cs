/* 制作日 2024/02/05
*　製作者 ニシガキ
*　最終更新日 2024/02/05
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class InGameUIManager : MonoBehaviour {

    [SerializeField, Tooltip("有効状態のHPポインター")]
    private Sprite _validPointer = default;

    [SerializeField, Tooltip("無効状態のHPポインター")]
    private Sprite _invalidPointer = default;

	// プレイヤーのHP量を表すポインターたち
	private List<Image> _playerHPPointers = default;

	// プレイヤーのSP量を表すゲージ
	private Image _playerSPGage = default;

	// プレイヤーのHPの最大値　表示しているポインターの個数
	private int _playerMaxHP = default;

    // プレイヤーのHPの最大値の上限　ポインターの総数
    private int _hpPointerLimit = default;

	// プレイヤーのHPの現在値　映しているポインターの数
	private int _playerHPIndex = default;

	// プレイヤーのSPの現在値　増減の判定に使用
	private int _playerMPValue = default;

    // HPポインターの設置開始位置
    private Vector2 _hpPointerStartPosition = new Vector2(0f, 0f);

    // HPポインターの設置間隔
    private const float HP_POINTER_DISTANCE = 20f;


    public void SetHPPointer(int maxHP)
    {
        // リストの設定をする時の最初のインデックス
        int startIndex;

        // 初期設定を行っていなければ初期設定を行う
        if (_playerHPPointers == null)
        {
            // 配列の最初から
            startIndex = 0;

            // ポインターのゲームオブジェクトを全取得する
            GameObject[] pointerObjects = GameObject.FindGameObjectsWithTag("HPPointer");

            // ポインターの総数を設定
            _hpPointerLimit = pointerObjects.Length;

            // リストにポインターを設定していく
            for (int i = 0; i < _hpPointerLimit; i++)
            {
                // ポインターのImageを設定
                _playerHPPointers[i] = pointerObjects[i].GetComponent<Image>();

                // ポインターの位置を設定
                _playerHPPointers[i].rectTransform.position = _hpPointerStartPosition + (Vector2.right * HP_POINTER_DISTANCE * i);

                // ポインターの表示を隠す
                _playerHPPointers[i].gameObject.SetActive(false);
            }

            // 現在の最大値を設定
            _playerMaxHP = 0;
        }

        // ポインターの総数を超えていないか判定
        if (_hpPointerLimit < maxHP)
        {
            Debug.LogError("ポインターの総数を超えている");
            return;
        }

        // 最大値をすでに超えていた場合
        if (_playerMaxHP > maxHP)
        {
            // 最大値を設定
            startIndex = maxHP;

            // 最大値より大きいポインターを消す
            for (int i = startIndex; i < _playerMaxHP; i++)
            {
                _playerHPPointers[i].gameObject.SetActive(false);
            }

            return;
        }
        // 最大値を超えていない場合
        else
        {
            // 配列の続きから
			startIndex = _playerMaxHP;
        }

        // 最大値を更新
		_playerMaxHP = maxHP;

        // ポインターの表示を増やす
        for (int i = startIndex; i < maxHP; i++)
        {
			_playerHPPointers[i].gameObject.SetActive(true);
        }
    }

	public void ChengePlayerHPUI(int nowHP)
    {
        if (nowHP > _playerMaxHP && nowHP < 0)
        {
            // 引数に異常あり
            Debug.LogError("HPおかしいかも");
            return;
        }

        // リストに合わせるために１を引く
        int nowHPIndex = nowHP - 1;

        // 増減の判定
        if (_playerHPIndex < nowHPIndex)
        {
            // 回復時のUI変更

            // ポインターを有効にしていく
            for (int i = _playerHPIndex + 1; i < nowHPIndex; i++)
            {
                _playerHPPointers[i].sprite = _validPointer;
            }

            // インデックスの位置を設定する
            _playerHPIndex = nowHPIndex;
        }
        else if(_playerHPIndex > nowHPIndex)
        {
            // ダメージを受けた時のUI変更

            // ポインターを無効にしていく
            for (int i = _playerHPIndex; i >= nowHPIndex; i--)
            {
                _playerHPPointers[i].sprite = _invalidPointer;
            }

            // インデックスの位置を設定する
            _playerHPIndex = nowHPIndex;
        }
        else
        {
            // 増減がない場合
            Debug.LogError("ノーダメージ");
            return;
        }
    }

	public void ChengePlayerSPUI(int nowSP)
    {

    }
}