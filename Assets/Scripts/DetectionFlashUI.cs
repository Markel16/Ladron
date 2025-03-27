using UnityEngine;
using UnityEngine.UI;

public class DetectionFlashUI : MonoBehaviour
{
    public Image flashImage;
    public float flashDuration = 0.5f;
    private float timer;

    public void ShowFlash()
    {
        if (flashImage != null)
        {
            flashImage.enabled = true;
            timer = flashDuration;
        }
    }

    void Update()
    {
        if (flashImage != null && flashImage.enabled)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                flashImage.enabled = false;
            }
        }
    }
}
