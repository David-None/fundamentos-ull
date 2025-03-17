using UnityEngine;

public class RollAnimationEvents : MonoBehaviour
{
    private RollPlayerSkills skills;
    
    void Start()
    {
        skills=GetComponentInParent<RollPlayerSkills>();
    }

    public void PassOnRollEnd()
    {
        skills.actionEndRoll();
    }
}
