using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    public State currentState;
    public State remainState;
    public float gizmoRadius;

    [HideInInspector] public Enemy enemy;

    void Awake()
    {
        enemy = GetComponent<Enemy>();    
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentState.UpdateState(this, enemy);
    }

    void OnDrawGizmos()
    {
        if (currentState != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(transform.position, gizmoRadius);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }
    }

    private void OnExitState()
    {
        //stateTimeElapsed = 0;
    }
}
