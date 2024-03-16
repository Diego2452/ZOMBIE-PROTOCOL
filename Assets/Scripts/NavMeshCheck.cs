using UnityEngine;
using UnityEngine.AI;

public class NavMeshCheck : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("No se encontr� el componente NavMeshAgent en este objeto.");
        }
    }

    private void Update()
    {
        if (agent != null)
        {
            if (agent.isOnNavMesh)
            {
                Debug.Log("El NavMeshAgent est� tocando el NavMesh.");
                // Puedes agregar aqu� cualquier l�gica adicional que desees ejecutar cuando el NavMeshAgent est� tocando el NavMesh.
            }
            else
            {
                Debug.LogWarning("El NavMeshAgent NO est� tocando el NavMesh.");
                // Puedes agregar aqu� cualquier l�gica adicional que desees ejecutar cuando el NavMeshAgent NO est� tocando el NavMesh.
            }
        }
    }
}

