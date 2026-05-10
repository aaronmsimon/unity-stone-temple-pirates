using System.Collections;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonBall;
    public Transform[] firePoints;
    public float cannonPower;

    [SerializeField] private float gunReadyTime = 1.5f;

    private bool gunsReady = false;
    private float attackPos = -1.05f;
    private float restPos = -0.75f;

    // public void 

    public void Fire()
    {
        if (gunsReady)
        {
            foreach (Transform firePoint in firePoints)
            {
                GameObject newCannonBall = Instantiate(cannonBall, firePoint.position, firePoint.rotation);
                Rigidbody rb = newCannonBall.GetComponent<Rigidbody>();
                rb.AddRelativeForce(Vector3.left * cannonPower);
                firePoint.GetComponentInChildren<ParticleSystem>().Play();
            }
        }
    }

    public void ToggleCannons()
    {
        gunsReady = !gunsReady;
        StartCoroutine(PositionGuns(new Vector3(gunsReady ? attackPos : restPos, transform.localPosition.y, transform.localPosition.z)));
    }

    private IEnumerator PositionGuns(Vector3 targetPos)
    {
        Vector3 startPos = transform.localPosition;
        float elapsed = 0f;
        float duration = gunReadyTime;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            yield return null;
        }

        transform.localPosition = targetPos; // snap to exact end
    }
}
