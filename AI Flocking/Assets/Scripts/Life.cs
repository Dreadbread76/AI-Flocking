using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Life : ScriptableObject 
{
    #region Variables
    public float health;
    public float speed;

    #endregion
    public abstract Vector2 CalculateMove(FlockAgent agent, List<Transform> context, List<Transform> areaContext, Flock flock);

    void Update()
    {
        if(health <= 0)
        {
            Destroy(this);
        }
    }
}
