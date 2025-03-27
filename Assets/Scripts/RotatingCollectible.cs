using UnityEngine;

public class RotatingCollectible : MonoBehaviour
{
    public float rotationSpeed = 50f;           // Velocidad de rotación
    public float floatAmplitude = 0.25f;        // Altura del movimiento vertical
    public float floatFrequency = 1f;           // Velocidad de flotación

    private Vector3 startPosition;              // Posición inicial

    void Start()
    {
        startPosition = transform.position;     // Guardar la posición inicial
    }

    void Update()
    {
        // Rotar sobre el eje Y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        // Movimiento vertical suave (flotación)
        float newY = startPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
