using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/EnemyStats")]
public class EnemyStats : ScriptableObject
{

    [Range(0f, 10f)]
    public float moveSpeed = 4f;  // enemy move speed when moving
    public int damageAmount = 10; // probably deal a lot of damage to kill player immediately

    [Tooltip("Child gameObject to detect stun.")]
    public GameObject stunnedCheck; // what gameobject is the stunnedCheck

    public float stunnedTime = 3f;   // how long to wait at a waypoint

    public string stunnedLayer = "StunnedEnemy";  // name of the layer to put enemy on when stunned
    public string playerLayer = "Player";  // name of the player layer to ignore collisions with when stunned

    [HideInInspector]
    public bool isStunned = false;  // flag for isStunned

    public GameObject[] myWaypoints; // to define the movement waypoints

    [Tooltip("How much time in seconds to wait at each waypoint.")]
    public float waitAtWaypointTime = 1f;   // how long to wait at a waypoint

    public bool loopWaypoints = true; // should it loop through the waypoints
}
