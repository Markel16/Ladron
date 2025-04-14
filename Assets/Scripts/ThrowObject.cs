using UnityEngine;
using TMPro;

public class ThrowObject : MonoBehaviour
{
    public GameObject distractionPrefab;
    public Transform throwPoint;
    public float minForce = 5f;
    public float maxForce = 20f;
    public float chargeRate = 10f; // velocidad de carga por segundo
    public float maxVelocity = 15f;

    public GameObject throwMessage;

    private bool canThrow = true;
    private float currentForce;

    void Start()
    {
        currentForce = minForce;

        if (throwMessage != null)
            throwMessage.SetActive(false);
    }

    void Update()
    {
        if (canThrow && throwMessage != null)
            throwMessage.SetActive(true);
        else if (throwMessage != null)
            throwMessage.SetActive(false);

        // 🔁 Cargar fuerza mientras mantienes presionada G
        if (canThrow && Input.GetKey(KeyCode.G))
        {
            currentForce += chargeRate * Time.deltaTime;
            currentForce = Mathf.Clamp(currentForce, minForce, maxForce);
        }

        // 🚀 Lanzar cuando sueltas la tecla G
        if (canThrow && Input.GetKeyUp(KeyCode.G))
        {
            ThrowDistraction(currentForce);
            currentForce = minForce; // reiniciar fuerza
        }
    }

    void ThrowDistraction(float force)
    {
        if (distractionPrefab != null)
        {
            GameObject distraction = Instantiate(distractionPrefab, throwPoint.position, Quaternion.identity);
            Rigidbody rb = distraction.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(Camera.main.transform.forward * force, ForceMode.Impulse);

                if (rb.linearVelocity.magnitude > maxVelocity)
                    rb.linearVelocity = rb.linearVelocity.normalized * maxVelocity;
            }
        }

        canThrow = false;

        if (throwMessage != null)
            throwMessage.SetActive(false);

        Invoke(nameof(ResetThrow), 3f);
    }

    void ResetThrow()
    {
        canThrow = true;
    }
}
