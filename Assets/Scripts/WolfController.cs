using UnityEngine;
using System.Collections.Generic;

public class WolfController : MonoBehaviour
{
    [SerializeField]
    private float followRadius = 10f; // Radio en el que el lobo sigue al jugador

    [SerializeField]
    private float moveSpeed = 5f; // Velocidad de movimiento del lobo

    [SerializeField]
    private List<GameObject> objectsToAttack; // Lista de objetos a atacar

    private Transform player; // Referencia al transform del jugador
    private Animator animator; // Referencia al animator del lobo

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>(); // Obtener el componente Animator del lobo
    }

    private void Update()
    {
        // Calculamos la dirección del movimiento
        Vector3 moveDirection = (player.position - transform.position).normalized;

        // Verificar si el jugador está dentro del radio de seguimiento
        if (Vector3.Distance(transform.position, player.position) <= followRadius)
        {
            // Calcular un punto dentro del radio de seguimiento
            Vector3 targetPosition = Random.insideUnitCircle * followRadius;
            targetPosition += player.position;

            // Seguir al jugador
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Llamar al trigger "walk" del animator cuando el lobo sigue al jugador
            animator.SetTrigger("walk");

            // Rotar el lobo hacia la dirección del movimiento
            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveDirection);
            }

            // Si el jugador está quieto, el lobo también se queda en idle
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                animator.SetTrigger("breathes");
            }
        }
        else
        {
            // Si no está siguiendo al jugador, buscar y moverse hacia los objetos a atacar
            foreach (GameObject obj in objectsToAttack)
            {
                if (obj != null && Vector3.Distance(transform.position, obj.transform.position) <= followRadius)
                {
                    // Moverse hacia el objeto
                    transform.position = Vector3.MoveTowards(transform.position, obj.transform.position, moveSpeed * Time.deltaTime);

                    // Llamar al trigger "run" del animator cuando el lobo se mueve hacia un objetivo
                    animator.SetTrigger("run");
                }
            }
        }
    }
}
