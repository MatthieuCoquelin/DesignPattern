using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Command_FIFO_MoveManager : Command_FIFO
{
    /// <summary>
    /// the next destination of the mesh agent
    /// </summary>
    private Vector3 m_destination;

    /// <summary>
    /// Cylinder gameObject as agent
    /// </summary>
    private NavMeshAgent m_navMeshAgent;

    /// <summary>
    /// Set the actual element of the list as next destination ;
    /// Repass the agent (this class do not inherit from MonoBehaviour so we use construnctor method instead using the componant value)
    /// </summary>
    /// <param name="destination"></param>
    /// <param name="m_navMeshAgent"></param>
    public Command_FIFO_MoveManager(Vector3 destination, NavMeshAgent m_navMeshAgent)
    {
        m_destination = destination;
        this.m_navMeshAgent = m_navMeshAgent;
    }
    
    /// <summary>
    /// Set the next destination of our agent
    /// </summary>
    public override void Execute()
    {
        m_navMeshAgent.SetDestination(m_destination);
    }

    /// <summary>
    /// Verifie if the destination is reached
    /// </summary>
    public override bool IsFinished => m_navMeshAgent.remainingDistance < 0.1f;
}
