using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAIStateMachine : MonoBehaviour
{
    public RedCompositeBehavior RedComposite;
     GameObject enemyTarget;

    // Start is called before the first frame update
    public enum Red
    {
        Wander,
        Pursue

    }
    ;
    public Red redStates;
    private void Start()
    {
        StartCoroutine(RedState());
    }

    private void Update()
    {
        enemyTarget = GameObject.FindGameObjectWithTag("Enemy");
    }

    IEnumerator RedState()
    {
        while (redStates == Red.Wander)
        {
            RedPatrol();

            yield return 0;
        }
        while (redStates == Red.Pursue)
        {
            RedPursue();

            yield return 0;
        }

    }

    public void RedPatrol()
    {
        RedComposite.Flocks[6].weight = 0;
    }
    public void RedPursue()
    {
        RedComposite.Flocks[6].weight = 10;
    }
}
