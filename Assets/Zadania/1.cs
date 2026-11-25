using UnityEngine;
using UnityEngine.AI;

public class PrzeciwnikFollow : MonoBehaviour
{
    // KROK 1: Stwórz publiczną zmienną typu Transform o nazwie player
    public WPISZ_TUTAJ_TYP TUTAJ_WPISZ_NAZWE;

    private NavMeshAgent agent;

    void Start()
    {
        // KROK 2: Dodaj siatke agenta
        agent = GetComponent<WPISZ_TUTAJ_NAZWE>();
    }

    void Update()
    {
        // KROK 3: Sprawdź, czy player nie jest pusty (użyj przeciwieństwa == null)
        // podpowiedź !
        if (player WPISZ_TUTAJ_WARUNEK)
        {
            // KROK 4: Wyślij agenta do pozycji(position) player'a 
            agent.SetDestination(WPISZ_TUTAJ_POZYCJE_GRACZA);
        }
    }
}