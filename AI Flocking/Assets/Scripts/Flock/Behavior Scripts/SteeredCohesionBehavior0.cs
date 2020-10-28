using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behavior/SteeredCohesion")]
public class SteeredCohesionBehavior0 : CohesionBehavior
{
    Vector2 currentVelocity = Vector2.zero;
    public float agentSmoothTime = 0.5f;
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, List<Transform> nearbyContext, Flock flock)
    {
        Vector2 cohesionMove = base.CalculateMove(agent, context, nearbyContext, flock);
        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);
        return cohesionMove;
    }
}