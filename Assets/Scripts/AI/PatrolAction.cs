using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(StateController controller, Enemy enemy)
    {
        Patrol(controller, enemy);
    }

    private void Patrol(StateController controller, Enemy enemy)
    {
        // if there isn't anything in My_Waypoints
        if ((enemy.myWaypoints.Length != 0) && (enemy.Moving))
        {

            // make sure the enemy is facing the waypoint (based on previous movement)
            enemy.Flip(enemy.VX);

            // determine distance between waypoint and enemy
            enemy.VX = enemy.myWaypoints[enemy.MyWaypointIndex].transform.position.x - enemy.EnemyTransform.position.x;

            // if the enemy is close enough to waypoint, make it's new target the next waypoint
            if (Mathf.Abs(enemy.VX) <= 0.05f)
            {
                // At waypoint so stop moving
                enemy.EnemyRB.velocity = new Vector2(0, 0);

                // increment to next index in array
                enemy.MyWaypointIndex++;

                // reset waypoint back to 0 for looping
                if (enemy.MyWaypointIndex >= enemy.myWaypoints.Length)
                {
                    if (enemy.loopWaypoints)
                        enemy.MyWaypointIndex = 0;
                    else
                        enemy.Moving = false;
                }

                // setup wait time at current waypoint
                enemy.moveTime = Time.time + enemy.waitAtWaypointTime;
            }
            else
            {
                // enemy is moving
                enemy.animator.SetBool("Moving", true);

                // Set the enemy's velocity to moveSpeed in the x direction.
                enemy.EnemyRB.velocity = new Vector2(enemy.EnemyTransform.localScale.x * enemy.moveSpeed, enemy.EnemyRB.velocity.y);
            }

        }
    }
}
