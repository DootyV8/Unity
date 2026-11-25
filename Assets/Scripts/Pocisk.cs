using UnityEngine;

public class Pocisk : MonoBehaviour
{
    // Zwiększono zakres i wartość domyślną, ponieważ z Time.deltaTime prędkość podaje się w jednostkach na sekundę (np. 15-30)
    [SerializeField] private float predkoscPocisku = 20f;
    [SerializeField] private float maxDystans = 100f;

    private Vector3 pozycjaStartowa;

    void Start()
    {
        pozycjaStartowa = transform.position;
    }

    void Update()
    {
        // transform.forward to kierunek, w który pocisk jest aktualnie obrócony
        transform.position += transform.forward * predkoscPocisku * Time.deltaTime;

        if (Vector3.Distance(pozycjaStartowa, transform.position) >= maxDystans)
        {
            Destroy(gameObject);
        }
    }
}