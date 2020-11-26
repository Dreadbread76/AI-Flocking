using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAIStateMachine : MonoBehaviour
{
    public RedCompositeBehavior RedComposite;
    public PursuitBehavior Pursuit;
    public Animator stateAnim;

  

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

   
    IEnumerator RedState()
    {

        while (redStates == Red.Wander)
        {
            RedPatrol();
            if (Pursuit.enemies != null)
            {
                redStates = Red.Pursue;
                
            }
            yield return 0;
        }
        while (redStates == Red.Pursue)
        {
            RedPursue();
            if (Pursuit.enemies == null)
            {
                redStates = Red.Wander;
            }
            yield return 0;
        }

    }

    public void RedPatrol()
    {
        Debug.Log("Wander");
        RedComposite.Flocks[6].weight = 0;
      

    }
    public void RedPursue()
    {
        Debug.Log("Pursue");
        RedComposite.Flocks[6].weight = 10;
      
    }
}
