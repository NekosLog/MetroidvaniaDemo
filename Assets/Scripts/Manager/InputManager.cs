/* 制作日 2023/11/30～
*　製作者 猫の足跡
*　最終更新日 2023/11/30
*/

using UnityEngine;
using System.Collections;
 
public class InputManager : MonoBehaviour 
{
	private const float INPUT_MINIMUN_VALUE = 0.71f;
 
	private void Awake()
	{
	}
	
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	private void InputSystem(E_InputType inputType ,float inputValue)
    {
        if (inputValue > INPUT_MINIMUN_VALUE)
        {
            switch (inputType)
            {
				case E_InputType.Right:

					break;
				case E_InputType.Left:

					break;
				case E_InputType.Up:

					break;
				case E_InputType.Down:

					break;
				case E_InputType.Action:

					break;
				case E_InputType.Jump:

					break;
				case E_InputType.Dash:

					break;
				case E_InputType.Attack:

					break;
				case E_InputType.Heal:

					break;
				case E_InputType.Skill1:

					break;
				case E_InputType.Skill2:

					break;
				case E_InputType.Menu:

					break;
				case E_InputType.Map:

					break;
			}
        }
    }
}