using UnityEngine;
using UnityEngine.UI;

public class DetectionFlashUI : MonoBehaviour
{
    public Image flashImage;
    public float flashDuration = 0.5f;

    void Start()
    {
        flashImage.enabled = false;
    }

    public void ShowFlash()
    {
        StopAllCoroutines();
        StartCoroutine(FlashEffect());
    }

    System.Collections.IEnumerator FlashEffect()
    {
        flashImage.enabled = true;
        yield return new WaitForSeconds(flashDuration);
        flashImage.enabled = false;
    }
}
