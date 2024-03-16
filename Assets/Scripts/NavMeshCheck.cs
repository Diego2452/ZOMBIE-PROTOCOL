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
            Debug.LogError("No se encontró el componente NavMeshAgent en este objeto.");
        }
    }

    private void Update()
    {
        if (agent != null)
        {
            if (agent.isOnNavMesh)
            {
                Debug.Log("El NavMeshAgent está tocando el NavMesh.");
                // Puedes agregar aquí cualquier lógica adicional que desees ejecutar cuando el NavMeshAgent esté tocando el NavMesh.
            }
            else
            {
                Debug.LogWarning("El NavMeshAgent NO está tocando el NavMesh.");
                // Puedes agregar aquí cualquier lógica adicional que desees ejecutar cuando el NavMeshAgent NO esté tocando el NavMesh.
            }
        }
    }
}

