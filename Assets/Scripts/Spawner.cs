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
        if(Spawner.spawner != null && Spawner.spawner!=this)
        
            Destroy(gameObject);
        Spawner.spawner = this;
        stack = new Stack<GameObject>();
        StartCoroutine(Spawn());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Push(GameObject obj)
    {
        Debug.Log(obj.name);
        obj.SetActive(false);
        stack.Push(obj);
    }
    public GameObject Pop()
    {
        GameObject obj = stack.Pop();
        obj.SetActive(true);
        obj.transform.position = SpawnPoint.transform.position;
        return obj;
    }
    public GameObject Peek()
    {
        return stack.Peek();
    }
    private IEnumerator Spawn()
    {
        if(stack.Count != 0)
        {
            Pop();
        }
        else
        {
            Instantiate(SpikedBall, SpawnPoint.transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(time);
        yield return Spawn();
    }
}
