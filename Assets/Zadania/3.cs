using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float viewDistance = 15f;
    public float wanderRadius = 10f;
    public float wanderTimer = 4f;

    private Transform player;
    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        // KROK 0: Dodaj siatke agenta
        agent = GetComponent<WPISZ_TUTAJ_NAZWE>();


        // KROK 1: Znajdź obiekt gracza po jego tagu
        GameObject playerObj = GameObject.FindGameObjectWithTag("WPISZ_TUTAJ_TAG_GRACZA");

        if (playerObj // KROK 1,5: Nie równa się 'niczemu')
        {
            player = playerObj.transform;
        }
        timer = wanderTimer;
    }

    void Update()
    {
        // KROK 2: Sprawdź, czy gracz istnieje  ORAZ (&&) czy wróg go widzi
        if (player TO_CO_W_KROK_1.5 ORAZ WPISZ_TUTAJ_FUNKCJE_WIDZENIA())
        {
            // Ustaw cel agenta na pozycję gracza
            agent.SetDestination(WPISZ_TUTAJ_POZYCJE_GRACZA);
            timer = wanderTimer;
        }
        else
        {
            // KROK 3: Doliczaj czas od ostatniej klatki (Time.deltaTime) do zmiennej timer
            WPISZ_TU_TIMER += WPISZ_TUTAJ_CZAS_KLATKI;

            // Jeśli minął czas patrolu LUB (||) agent dotarł do celu:
            if (timer >= wanderTimer LUB agent.remainingDistance <= agent.stoppingDistance)
            {
                // Wylosuj nowy punkt używając funkcji RandomNavMeshPoint(pozycja, włóczenie się przeciwnika)
                Vector3 newPos = RandomNavMeshPoint(WPISZ_TUTAJ_POZYCJE, WPISZ_TUTAJ_PROMIEN_PATROLU);

                agent.SetDestination(newPos);

                // Wyzeruj licznik czasu
                timer = WPISZ_TUTAJ_ZERO;
            }
        }
    }

    bool CanSeePlayer()
    {
        // KROK 4: Oblicz odległość między pozycją wroga  a gracza pozycją
        float distance = Vector3.Distance(TU_WPISZ_POZYCJĘ, WPISZ_TUTAJ_POZYCJE_GRACZA);

        // Jeśli odległość (distance) jest większa niż zasięg wzroku, zwróć false
        if (odległość > WPISZ_TUTAJ_ZASIEG_WZROKU) return CO ?;

        Vector3 eyePos = POZYCJA + Vector3.up * 0.5f;
        Vector3 targetPos = POZYCJA_GRACZA + Vector3.up * 0.5f;

        if (Physics.Linecast(eyePos, targetPos, out RaycastHit hit))
        {
            // KROK 5: Zwróć true, jeśli promień trafił w gracza  LUB  w jego część)
            return hit.transform == GRACZ LUB hit.transform.IsChildOf(WPISZ_TUTAJ_ZMIENNA_GRACZA);
        }

        return true;
    }

    Vector3 RandomNavMeshPoint(Vector3 origin, float dist)
    {
        // KROK 6: Wylosuj punkt w kuli (Random.insideUnitSphere) pomnożony przez dist i dodaj origin
        Vector3 randDirection = WPISZ_TUTAJ_LOSOWA_KULA * dist + origin;

        if (NavMesh.SamplePosition(randDirection, out NavMeshHit navHit, dist, NavMesh.AllAreas))
        {
            return navHit.position;
        }
        return origin;
    }
}