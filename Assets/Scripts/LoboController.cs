
using UnityEngine;

public class LoboController : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float velocidad; // Velocidad a la que el lobo se moverá
    public float distanciaDetencion; // Distancia a la que el lobo se detiene

    private Animator animator; // Referencia al componente Animator
    private Vector3 posicionAnteriorJugador; // Posición del jugador en el frame anterior

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el componente Animator
        posicionAnteriorJugador = player.position;
    }

    void Update()
    {
        // Si la referencia al jugador no es nula, mueve el lobo hacia él
        if (player != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direccion = player.position - transform.position;
            direccion.y = 0f; // Mantén la misma altura para evitar inclinaciones

            // Normaliza la dirección para que el lobo se mueva a una velocidad constante
            direccion.Normalize();

            // Calcula la distancia entre el lobo y el jugador
            float distancia = direccion.magnitude;

            // Controla la animación del lobo
            if (distancia > distanciaDetencion)
            {
                animator.SetBool("Walking", true); // El lobo está caminando
                animator.SetBool("Idle", false); // El lobo no está en reposo
            }
            else
            {
                animator.SetBool("Walking", false); // El lobo se detiene
                animator.SetBool("Idle", true); // El lobo está en reposo
                return; // Detener la actualización del script si el lobo está en reposo
            }

            // Mueve al lobo en la dirección del jugador
            transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);

            // Rota al lobo hacia la dirección del jugador
            transform.rotation = Quaternion.LookRotation(direccion);

            // Actualiza la posición anterior del jugador
            posicionAnteriorJugador = player.position;
        }
    }
}
