using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface lCommand
{
    void Execute();
    void Undo();
}

public class MoveCommand : lCommand
{
    private Transform objectMove;
    private Vector3 displacement;

    public MoveCommand(Transform obj, Vector3 displacement)
    {
        this.objectMove = obj;
        this.displacement = displacement;
    }

    public void Execute() { objectMove.position += displacement; }
    public void Undo() { objectMove.position -= displacement; }
}
public class CommandManager : MonoBehaviour
{
    private Stack<lCommand> commandHistory = new Stack<lCommand>();

    public void ExecuteCommand(lCommand command)
    {
        command.Execute();
        commandHistory.Push( command );
    }

    public void UndoLastCommand()
    {
        if ( commandHistory.Count > 0 )
        {
            lCommand lastCommand = commandHistory.Pop();
            lastCommand.Undo();
        }
    }
     
}