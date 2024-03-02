using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referencias de Unity
public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 500f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;

    void Start()
    {
        // Bloquear el cursor en el centro de la pantalla y hacerlo invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Obtener las entradas del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotación alrededor del eje x (mirar arriba y abajo)
        xRotation -= mouseY;

        // Limitar la rotación
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        // Rotación alrededor del eje y (mirar izquierda y derecha)
        yRotation += mouseX;

        // Aplicar rotaciones a nuestro transformador
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
