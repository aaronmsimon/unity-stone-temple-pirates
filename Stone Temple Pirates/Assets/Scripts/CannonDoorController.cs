using System.Collections;
using UnityEngine;

public class CannonDoors : MonoBehaviour
{
    [SerializeField] private float openCloseTime = 1f;

    private bool doorsOpen = false;
    private float closeZRot = 0f;
    private float openZRot = -85.937f;

    public void ToggleDoors()
    {
        doorsOpen = !doorsOpen;
        StartCoroutine(RotateTo(Quaternion.Euler(0f, 0f, doorsOpen ? openZRot : closeZRot)));
    }

    private IEnumerator RotateTo(Quaternion targetLocal)
    {
        Quaternion startRot = transform.localRotation;
        float elapsed = 0f;
        float duration = openCloseTime;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.localRotation = Quaternion.Slerp(startRot, targetLocal, elapsed / duration);
            yield return null;
        }

        transform.localRotation = targetLocal; // snap to exact end
    }
}
