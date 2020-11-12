using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/Predator Behaviour")]

public class Predator : Life
{


    #region Variables
    public float pursueMultiplier = 2f;
    public float pounceMultiplier = 5f;

    [System.Serializable]
    public class PredatorBehavior
    {
        public Life life;
        public float weight;
    }
    public PredatorBehavior[] behaviors;
    #endregion
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, List<Transform> areaContext, Flock flock)
    {
        Vector2 move = Vector2.zero;

        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 partialMove = behaviors[i].life.CalculateMove(agent, context, areaContext, flock) * behaviors[i].weight;

            if (partialMove != Vector2.zero)
            {
                if (partialMove.SqrMagnitude() > behaviors[i].weight * behaviors[i].weight)
                {
                    partialMove.Normalize();
                    partialMove *= behaviors[i].weight;
                }
                move += partialMove;
            }
        }
        return move;
    }

    public enum predatorInstincts
    {
        Patrol,
        Seek,
        Pursue,
        Attack,

    }
    ;

    public predatorInstincts predator;
    void Start()
    {
        
    }

    // Update is called once per frame
   IEnumerator States()
   {
        while(predator == predatorInstincts.Patrol)
        {
            Patrol();

            yield return 0;
        }

   }

    public void Patrol()
    {

    }
    public void Pursue()
    {

    }
    public void Attack()
    {

    }
    
    
    
}
