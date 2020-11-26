using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;//
    List<FlockAgent> agents = new List<FlockAgent>();//
    public int agentsCount { get { return agents.Count; } }
    public FlockBehavior behavior;//

    [Range(1, 500)]
    public int startingCount = 250;//
    const float AgentDensity = 0.08f;//

    [Range(1f, 100f)]
    public float driveFactor = 10f;//Speed
    [Range(1f, 100f)]
    public float maxSpeed = 5f;//
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(1f, 100f)]
    public float areaRadius = 20f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;//multiplier
                                                  // [Range(0f, 5f)]
                                                  // public float otherAvoidanceRadiusMultiplier = 0.5f;//multiplier

    float squareMaxSpeed;//
    float squareNeighborRadius;
    float squareAvoidanceRadius;//radius
    //float otherSquareAvoidanceRadius;//radius
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }//
                                                                                // public float OtherSquareAvoidanceRadius { get { return otherSquareAvoidanceRadius; } }//
    private void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;//0.5 x bigger then neighbor radius
                                                                                                             // otherSquareAvoidanceRadius = squareNeighborRadius * otherAvoidanceRadiusMultiplier * otherAvoidanceRadiusMultiplier;
        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                ((Vector2)transform.position) + Random.insideUnitCircle * startingCount * AgentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform);

            
            newAgent.name = "Agent " + i;
            newAgent.Initialize(this);
            agents.Add(newAgent);
        }
    }
    private void Update()
    {
        foreach (FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent, neighborRadius);
            List<Transform> areaContext = GetNearbyObjects(agent, areaRadius);
            //FOR TESTING ONLY
            //agent.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count / 6f);
            Vector2 move = behavior.CalculateMove(agent, context, areaContext, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent agent, float radius)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
        foreach (Collider2D contextCollider in contextColliders)
        {
            if (contextCollider != agent.AgentCollider)
            {
                context.Add(contextCollider.transform);
            }
        }
        return context;
    }

   
}