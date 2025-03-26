using UnityEngine;

public class RotatingCollectible : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public Transform rotatingPart;

    void Update()
    {
        if (rotatingPart != null)
        {
            rotatingPart.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
        else
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
    }
}
