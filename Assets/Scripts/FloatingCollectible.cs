using UnityEngine;

public class FloatingCollectible : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float floatAmplitude = 0.25f; // Altura de flotación
    public float floatFrequency = 1f;    // Velocidad de flotación

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotar el objeto sobre su eje Y
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        // Calcular nueva altura con seno para efecto de "subir y bajar"
        float newY = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = startPosition + new Vector3(0f, newY, 0f);
    }
}
