using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behavior/Blue Composite")]
public class BlueCompositeBehavior : FlockBehavior
{
    [System.Serializable]
   public class FlockClass
    {
        public FlockBehavior behavior;
        public float weight;

    }
    public FlockClass[] Flocks;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, List<Transform> areaContext, Flock flock)
    {
        Vector2 move = Vector2.zero;

        for(int i = 0; i < Flocks.Length; i++)
        {
            Vector2 partialMove = Flocks[i].behavior.CalculateMove(agent, context, areaContext, flock) * Flocks[i].weight;

            if(partialMove != Vector2.zero)
            {
                if(partialMove.SqrMagnitude()> Flocks[i].weight * Flocks[i].weight)
                {
                    partialMove.Normalize();
                    partialMove *= Flocks[i].weight;
                }
                move += partialMove;
            }
        }
        return move;
    }
}
