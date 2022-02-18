using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

/// <summary>
/// In Command pattern we create a list of command executed in FIFO (First In First Out) order ;
/// The next command from the list wil be executed at the end of the actual command
/// </summary>

public class Command_FIFO_ListManager : MonoBehaviour
{
    /// <summary>
    /// Cylinder gameObject as agent
    /// </summary>
    [SerializeField]
    private NavMeshAgent m_navMeshAgent = null;

    /// <summary>
    /// MainCamera game object as camera
    /// </summary>
    [SerializeField]
    private Camera m_camera = null;

    /// <summary>
    /// List of commands
    /// </summary>
    private Queue<Command_FIFO> m_commands;
    
    /// <summary>
    /// Actual command of our list
    /// </summary>
    private Command_FIFO m_currentCommand;

    private void Start()
    {
        m_commands = new Queue<Command_FIFO>();
    }

    // Update is called once per frame
    void Update()
    {
        ListenForCommand();
        ProcessCommand();
    }

    /// <summary>
    /// Listenig and adding the points from the plan (with the mouse click) to our the list of commands
    /// </summary>
    private void ListenForCommand()
    {
        // If we press the left click mousse and we had passed tha agent and the camera to the component
        if (Input.GetMouseButtonDown(0) && m_navMeshAgent != null && m_camera != null)
        {
            // We create a raycast from the mousse click position 
            Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the raycasr hit the plane, the hit point is added to our list of commands
            if (Physics.Raycast(ray, out hit))
            {
                Command_FIFO_MoveManager commend_FIFO_MoveManager = new Command_FIFO_MoveManager(hit.point, m_navMeshAgent);
                m_commands.Enqueue(commend_FIFO_MoveManager);
            }
        }
        else
            Debug.LogWarning("Do not forget to set the serialized fields of a component");
    }

    /// <summary>
    /// Check if command exist and switch between them
    /// </summary>
    private void ProcessCommand()
    {
        // If our current command exist (is well passed in the component) and is not finish we "wait" the end of our command
        if (m_currentCommand != null && m_currentCommand.IsFinished == false)
            return;

        // If ther is no more commands we do nothing
        if (m_commands.Any() == false)
            return;

        // We change of command in our list and we execute the new current command
        m_currentCommand = m_commands.Dequeue();
        m_currentCommand.Execute();
    }
}
