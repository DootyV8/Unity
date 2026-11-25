using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;
    public int maxEnemies = 10;

    private float timer;

    void Update()
    {
        // KROK 1: Dodawaj czas klatki (Time.deltaTime) do zmiennej timer
        WPISZ_TU_TIMER += WPISZ_TUTAJ_CZAS_KLATKI;

        // KROK 2: Sprawdź, czy timer jest większy lub równy (>=) spawnInterval
        if (WPISZ_TU_TIMER >= WPISZ_TUTAJ_CZAS_SPAWNU)
        {
            // Wyzeruj timer (pamiętaj że liczba musi być z 'f')
            timer = WPISZ_TUTAJ_ZERO;

            // KROK 3: Policz, ile obiektów ze skryptem EnemyAI jest teraz na scenie
            int currentEnemies = FindObjectsOfType<WPISZ_TUTAJ_NAZWE_SKRYPTU_WROGA>().Length;

            // KROK 4: Jeśli obecnych wrogów (currentEnemies) jest mniej (<) niż maxEnemies ORAZ (&&) enemyPrefab != null:
            if (OBECNY_WRÓG < WPISZ_TUTAJ_LIMIT_WROGOW && WPISZ_PREFAB_PRZECIWNIKA != null)
            {
                // KROK 5: Stwórz nowy obiekt używając Instantiate(coStworzyc, pozycja, rotacja)
                // podpowiedź pozycje i rotacje wykorzystywaliśmy już w innych skryptach, sprawdźcie jak to zapisywaliśmy
                Instantiate(WPISZ_TUTAJ_PREFAB, pozycja, rotacja);
            }
        }
    }
}