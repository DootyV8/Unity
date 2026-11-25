using UnityEngine;

public class Przeciwnik : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pociski"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
