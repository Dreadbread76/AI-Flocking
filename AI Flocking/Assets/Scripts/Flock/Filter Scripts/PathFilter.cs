using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Filter/Path")]
public class PathFilter : ContextFilter
{
    // Start is called before the first frame update
   public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();

        //Add a path to follow for every unit
        foreach(Transform item in original)
        {
            Path path = item.GetComponentInParent<Path>();
            //Add a path if there isnt one
            if (path == null)
            {
                filtered.Add(item);
            }
            
        }
        return filtered;
    }
}
