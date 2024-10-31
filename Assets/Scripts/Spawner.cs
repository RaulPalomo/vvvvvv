using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float time = 3f;
    public GameObject SpikedBall;
    public GameObject SpawnPoint;
    public static Spawner spawner;
    public Stack<GameObject> stack;

    void Start()
    {
        // Singleton pattern para evitar duplicados
        if (Spawner.spawner != null && Spawner.spawner != this)
            Destroy(gameObject);
        Spawner.spawner = this;

        stack = new Stack<GameObject>();
        StartCoroutine(Spawn());
    }

    public void Push(GameObject obj)
    {
        // Desactiva el objeto y lo agrega a la pila para reutilización
        obj.SetActive(false);
        stack.Push(obj);
    }

    public GameObject Pop()
    {
        GameObject obj = stack.Pop();
        obj.SetActive(true);
        obj.transform.position = SpawnPoint.transform.position;
        obj.GetComponent<SpikeMovement>().SetProjectile(); // Reactiva el movimiento
        return obj;
    }

    private IEnumerator Spawn()
    {
        while (true) // Utiliza un bucle infinito controlado por tiempo
        {
            if (stack.Count != 0)
            {
                // Reutiliza un objeto de la pila
                Pop();
            }
            else
            {
                // Crea un nuevo objeto si la pila está vacía
                GameObject newSpike = Instantiate(SpikedBall, SpawnPoint.transform.position, Quaternion.identity);
                newSpike.GetComponent<SpikeMovement>().SetProjectile(); // Configura el movimiento
            }

            // Espera el tiempo especificado antes de la siguiente ejecución
            yield return new WaitForSeconds(time);
        }
    }
}