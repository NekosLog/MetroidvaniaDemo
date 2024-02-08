/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEditor;

public class TitleManager : MonoBehaviour
{
    [SerializeField, Tooltip("決定時のSE")]
    private AudioClip _decisionSE = default;

    [SerializeField, Tooltip("GameStartの矢印")]
    private Image _gameStartArrow = default;

    [SerializeField, Tooltip("Exitの矢印")]
    private Image _ExitArrow = default;

    // メニュー選択のインデックス
    private int _nowIndex = default;

    // 入力の記録
    private float _inputLog = default;

    // 矢印を動かす距離
    private Vector3 _arrowMoveDistance = new Vector2(0.1f, 0);

    // メニュー項目の一覧
    private enum E_TitleMenu
    {
        GameStart = 1,
        Exit = 2
    }
    private void Awake()
    {
        // インデックスの初期化　ゲームスタートのインデックス
        _nowIndex = 1;

        // 見た目の初期化
        ChengeArrowPosition(_nowIndex);
    }

    private void Update()
    {
        // 上入力
        if (Input.GetAxisRaw("Vertical") > 0　&& _inputLog == 0)
        {
            int minIndex = 1;
            if (_nowIndex > minIndex)
            {
                _nowIndex--;
                ChengeArrowPosition(_nowIndex);
            }
        }
        // 下入力
        else if(Input.GetAxisRaw("Vertical") < 0 && _inputLog == 0)
        {
            int maxIndex = Enum.GetValues(typeof(E_TitleMenu)).Length;
            if (_nowIndex < maxIndex)
            {
                _nowIndex++;
                ChengeArrowPosition(_nowIndex);
            }
        }
        // 決定
        else if (Input.GetAxisRaw("Attack") > 0 && _inputLog == 0)
        {
            switch (_nowIndex)
            {
                case (int)E_TitleMenu.GameStart:
                    StartCoroutine(GameStart());
                    break;

                case (int)E_TitleMenu.Exit:
                    StartCoroutine(Exit());
                    break;
            }
        }

        _inputLog = Input.GetAxisRaw("Vertical");
    }

    private void ChengeArrowPosition(int index)
    {
        switch (index)
        {
            case (int)E_TitleMenu.GameStart:
                _gameStartArrow.enabled = true;
                _ExitArrow.enabled = false;
                break;

            case (int)E_TitleMenu.Exit:
                _gameStartArrow.enabled = false;
                _ExitArrow.enabled = true;
                break;
        }
    }

    private void DecisionSE()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(_decisionSE);
    }

    private IEnumerator GameStart()
    {
        DecisionSE();
        _gameStartArrow.rectTransform.position += _arrowMoveDistance;

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("InGameScene");   
    }

    private IEnumerator Exit()
    {
        DecisionSE();
        _ExitArrow.rectTransform.position += _arrowMoveDistance;

        yield return new WaitForSeconds(1);

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}