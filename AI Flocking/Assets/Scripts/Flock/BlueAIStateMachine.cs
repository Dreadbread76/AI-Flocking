using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAIStateMachine : MonoBehaviour
{

    public RedCompositeBehavior BlueComposite;
    public HideBehaviour Hide;
    public Animator stateAnim;

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
            if (Hide.enemies != null)
            {
                blueStates = Blue.FleeNHide;

            }

            yield return 0;
        }
        while (blueStates == Blue.FleeNHide)
        {
            BlueFleeNHide();
            if (Hide.enemies == null)
            {
                blueStates = Blue.Wander;
            }
            yield return 0;
        }

    }

    public void BluePatrol()
    {
        Debug.Log("Wander Enter");
        BlueComposite.Flocks[6].weight = 0;
        stateAnim.SetBool("flee", false);
    }
    public void BlueFleeNHide()
    {
        Debug.Log("Flee Enter");
        BlueComposite.Flocks[6].weight = 2;
        stateAnim.SetBool("flee", true);
    }
}
