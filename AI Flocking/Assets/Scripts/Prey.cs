using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/Prey Behaviour")]
public class Prey : Life
{
    public class PreyBehaviors
    {
        public Life life;
        public float weight;
    }
    public PreyBehaviors[] behaviors;
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
    public enum preyInstincts
    {

        Wander,
        Hide,
        Evade,

    }
    ;

    private void Awake()
    {
        
    }
}
