using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Ruch : MonoBehaviour
{
    [Header("Ruch i Skok")]
    [SerializeField] private float predkosc = 6f;
    [SerializeField] private float wysokoscSkoku = 1.5f;
    [SerializeField] private float grawitacja = -19.62f;

    [Header("Strzelanie")]
    [SerializeField] private GameObject pociskPrefab;

    private CharacterController controller;
    private Vector3 predkoscPionowa;
    private bool czyNaZiemi;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 1. Sprawdzanie czy stoimy na ziemi
        czyNaZiemi = controller.isGrounded;
        if (czyNaZiemi && predkoscPionowa.y < 0)
        {
            // Lekki docisk w dół zapobiega ślizganiu się po rampach
            predkoscPionowa.y = -2f;
        }

        // 2. Kierunek poziomy (WASD) w oparciu o rotację postaci
        Vector3 kierunekRuchu = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) kierunekRuchu += transform.forward;
        if (Input.GetKey(KeyCode.S)) kierunekRuchu -= transform.forward;
        if (Input.GetKey(KeyCode.D)) kierunekRuchu += transform.right;
        if (Input.GetKey(KeyCode.A)) kierunekRuchu -= transform.right;

        // Przemieszczanie poziome (znormalizowane, aby po skosie nie biegać szybciej)
        controller.Move(kierunekRuchu.normalized * predkosc * Time.deltaTime);

        // 3. Skok (tylko w klatce wciśnięcia i tylko gdy stoimy na podłożu)
        if (Input.GetKeyDown(KeyCode.Space) && czyNaZiemi)
        {
            predkoscPionowa.y = Mathf.Sqrt(wysokoscSkoku * -2f * grawitacja);
        }

        // 4. Aplikowanie grawitacji w dół
        predkoscPionowa.y += grawitacja * Time.deltaTime;
        controller.Move(predkoscPionowa * Time.deltaTime);

        // 5. Strzał
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (pociskPrefab != null)
            {
                Instantiate(pociskPrefab, transform.position + transform.forward, transform.rotation);
            }
        }
    }
}