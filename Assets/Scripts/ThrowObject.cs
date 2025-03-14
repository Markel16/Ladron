using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public GameObject distractionPrefab; // Prefab del objeto que se lanza
    public Transform throwPoint; // Lugar desde donde se lanza 
    public float throwForce = 10f; // Fuerza del lanzamiento

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Presiona 'G' para lanzar
        {
            ThrowDistraction();
        }
    }

    void ThrowDistraction()
    {
        if (distractionPrefab != null)
        {
            GameObject distraction = Instantiate(distractionPrefab, throwPoint.position, Quaternion.identity);
            Rigidbody rb = distraction.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);
            }
        }
    }
}
