/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehavior : FlockBehavior
{
    [System.Serializable]
    
    public struct BehaviorGroup
    {
        public FlockBehavior behaviors;
        public float weights;
    }
    public BehaviorGroup[] behaviors;
    // Update is called once per frame
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector2 move = Vector2.zero;

        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 partialMove = behaviors[i].behaviors.CalculateMove(agent,context,flock) * behaviors[i].weights;
            if(partialMove != Vector2.zero)
            {
                if (partialMove.sqrMagnitude > behaviors[i].weights * behaviors[i].weights)
                {
                    partialMove.Normalize();
                    partialMove *= behaviors[i].weights;
                }
                move += partialMove;
            }
            
        }
    
    }
}*/

