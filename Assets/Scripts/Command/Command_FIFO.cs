using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command_FIFO
{
    /// <summary>
    /// Execute the command selected
    /// </summary>
    public abstract void Execute();

    /// <summary>
    /// To know if the command is finished
    /// </summary>
    public abstract bool IsFinished { get; }
}
