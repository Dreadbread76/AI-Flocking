using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Flock/Behavior/Hide")]
public class HideBehaviour : FilteredFlockBehavior
{
    public ContextFilter obstaclesFilter;
    public float hideBehindObstacleDistance = 2f;
    public List<Transform> enemies;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, List<Transform> areaContext, Flock flock)
    {
        List<Transform> filteredContext = (filter == null) ? areaContext : filter.Filter(agent, areaContext);
        List<Transform> obstacleContext = (filter == null) ? areaContext : obstaclesFilter.Filter(agent, areaContext);

        if (filteredContext.Count == 0)
        {
            return Vector2.zero;
        }
        float nearestDistance = float.MaxValue;
        Transform nearestObstacle = null;
        foreach (Transform item in obstacleContext)
        {
            float Distance = Vector2.Distance(item.position, agent.transform.position);

            //Get when enemies are in range and start animating
            if(Distance < nearestDistance)
            {
                nearestObstacle = item;
                nearestDistance = Distance;
                agent.Animator.SetBool("flee", true);
            }
            else
            {
                agent.Animator.SetBool("flee", false);
            }
        }
        if (nearestObstacle == null)
        {
            return Vector2.zero;
        }
        Vector2 move = Vector2.zero;
        foreach(Transform item in filteredContext)
        {
            //DIRECTION FROM ITEM TO NEARESTOBSTACLE
            Vector2 obstacleDirection = nearestObstacle.position - item.position;

            //ADD TO THAT DIRECTION TO GET THE POINT (BEHIND THE OBSTACLE) THAT WE NEED TO HIDE
            obstacleDirection += obstacleDirection.normalized * hideBehindObstacleDistance;

            Vector2 hidePosition = ((Vector2)item.position) + obstacleDirection;

            move += hidePosition;
        }
        move /= filteredContext.Count;

        Debug.DrawRay(move, Vector2.up * 3f);

        move -= (Vector2)agent.transform.position;
        enemies = areaContext;
       
        return move;
    }
}
