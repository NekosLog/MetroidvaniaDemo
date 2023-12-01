/* 制作日 2023/11/30～
*　製作者 猫の足跡
*　最終更新日 2023/12/01
*/

using System;
using System.Collections.Generic;
 
public class InputEvents
{
    // 入力時間の管理配列　要素数は入力の種類
    private float[] _inputTimer = new float[13];

    /// <summary>
    /// 入力に応じた押している時の処理を実行するクラス
    /// </summary>
    /// <param name="inputType"></param>
    public void Execution(E_InputType inputType)
    {
        switch (inputType)
        {
            case E_InputType. :

                break;

            case E_InputType. :

                break;

            case E_InputType. :

                break;

            case E_InputType. :

                break;

            case E_InputType. :

                break;

            case E_InputType. :

                break;

            case E_InputType. :

                break;

            case E_InputType. :

                break;

            case E_InputType. :

                break;

            case E_InputType. :

                break;

            case E_InputType. :

                break;

            case E_InputType. :

                break;

            case E_InputType. :

                break;
        }
        _inputTimer[inputType] += Time.deltaTime;
    }

    /// <summary>
    /// 入力のに応じた離した時の処理を実行するクラス
    /// </summary>
    /// <param name="inputType"></param>
    public void Exit(E_InputType inputType)
    {
        switch (inputType)
        {

        }
        _inputTimer[inputType] = 0f;
    }
}