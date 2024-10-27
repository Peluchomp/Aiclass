using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoard : MonoBehaviour
{
    public void BrainFound(Vector3 brainPos)
    {
        BroadcastMessage("FollowBrain", brainPos);
    }
}
