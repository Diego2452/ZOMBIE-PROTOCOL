
using UnityEngine;

public class LoboController : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float velocidad; // Velocidad a la que el lobo se mover�
    public float distanciaDetencion; // Distancia a la que el lobo se detiene

    private Animator animator; // Referencia al componente Animator
    private Vector3 posicionAnteriorJugador; // Posici�n del jugador en el frame anterior

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el componente Animator
        posicionAnteriorJugador = player.position;
    }

    void Update()
    {
        // Si la referencia al jugador no es nula, mueve el lobo hacia �l
        if (player != null)
        {
            // Calcula la direcci�n hacia el jugador
            Vector3 direccion = player.position - transform.position;
            direccion.y = 0f; // Mant�n la misma altura para evitar inclinaciones

            // Normaliza la direcci�n para que el lobo se mueva a una velocidad constante
            direccion.Normalize();

            // Calcula la distancia entre el lobo y el jugador
            float distancia = direccion.magnitude;

            // Controla la animaci�n del lobo
            if (distancia > distanciaDetencion)
            {
                animator.SetBool("Walking", true); // El lobo est� caminando
                animator.SetBool("Idle", false); // El lobo no est� en reposo
            }
            else
            {
                animator.SetBool("Walking", false); // El lobo se detiene
                animator.SetBool("Idle", true); // El lobo est� en reposo
                return; // Detener la actualizaci�n del script si el lobo est� en reposo
            }

            // Mueve al lobo en la direcci�n del jugador
            transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);

            // Rota al lobo hacia la direcci�n del jugador
            transform.rotation = Quaternion.LookRotation(direccion);

            // Actualiza la posici�n anterior del jugador
            posicionAnteriorJugador = player.position;
        }
    }
}
