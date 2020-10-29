using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/Prey Behaviour")]
public class Prey : Life
{
   
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
