using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CommandManager CommandManager;



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            lCommand moveRight = new MoveCommand(transform, Vector3.right);
            CommandManager.ExecuteCommand(moveRight);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lCommand moveLeft = new MoveCommand(transform, Vector3.left);
            CommandManager.ExecuteCommand(moveLeft);
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            CommandManager.UndoLastCommand();
        }
        
    }
}
