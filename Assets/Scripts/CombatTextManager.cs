using System.Collections.Generic;
using UnityEngine;

public class CombatTextManager : MonoBehaviour
{
    public float spawnDelay;
    private float currentSpawnDelay;
    private Queue<CombatText> textQueue;

    private void Start()
    {
        textQueue = new Queue<CombatText>();
        currentSpawnDelay = spawnDelay;
    }
    private void Update()
    {
        currentSpawnDelay -= Time.deltaTime;

        if(currentSpawnDelay <= 0 && textQueue.Count > 0)
        {
            textQueue.Dequeue().ActivateRequest();
            currentSpawnDelay = spawnDelay;
        }
    }

    public void AddTextRequest(CombatText c)
    {
        textQueue.Enqueue(c);
    }
}
