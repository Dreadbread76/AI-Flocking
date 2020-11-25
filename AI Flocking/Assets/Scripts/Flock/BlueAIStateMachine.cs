using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAIStateMachine : MonoBehaviour
{

    public BlueCompositeBehavior BlueComposite;
    // Start is called before the first frame update
   public enum Blue
    {
        Wander,
        FleeNHide,
    }
    ;

    public Blue blueStates;
    IEnumerator BlueState()
    {
        while (blueStates == Blue.Wander)
        {
            BluePatrol();

            yield return 0;
        }
        while (blueStates == Blue.FleeNHide)
        {
            BlueFleeNHide();

            yield return 0;
        }

    }

    public void BluePatrol()
    {
        Debug.Log("Wander Enter");
        BlueComposite.Flocks[6].weight = 0;
    }
    public void BlueFleeNHide()
    {
        BlueComposite.Flocks[6].weight = 2;
    }
}
