using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class InputKeyBoardController : IExecute
    {
        private IInvokeKeyBoard _invokeKeyBoard;

        public InputKeyBoardController(IInvokeKeyBoard invokeKeyBoard)
        {
            _invokeKeyBoard = invokeKeyBoard;
        }

        public void Execute(float deltatime)
        {
            _invokeKeyBoard.GetInvokeKeyBoard();
        }
    }
}

