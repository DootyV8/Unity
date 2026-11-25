using UnityEngine;

public class MyszkaKamera : MonoBehaviour
{
    [Header("Ustawienia")]
    [SerializeField] private float czuloscMyszki = 200f;
    [SerializeField] private Transform cialoGracza;

    private float rotacjaX = 0f;

    void Start()
    {
        // Zablokowanie kursora na środku ekranu i ukrycie go
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Pobranie ruchu myszki z uwzględnieniem czasu klatki
        float myszX = Input.GetAxis("Mouse X") * czuloscMyszki * Time.deltaTime;
        float myszY = Input.GetAxis("Mouse Y") * czuloscMyszki * Time.deltaTime;

        // 1. Ruch w pionie (góra / dół) - obracamy samą kamerę wokół osi X
        rotacjaX -= myszY;
        // Ograniczenie kąta patrzenia, żeby nie wykręcać głowy do tyłu
        rotacjaX = Mathf.Clamp(rotacjaX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacjaX, 0f, 0f);

        // 2. Ruch w poziomie (lewo / prawo) - obracamy całą postać wokół osi Y
        if (cialoGracza != null)
        {
            cialoGracza.Rotate(Vector3.up * myszX);
        }
    }
}
