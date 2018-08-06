using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour {

    public GameObject enemy;
    Animator _anim;

    void Awake()
    {
        _anim = enemy.GetComponent<Animator>();    
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
            _anim.SetTrigger("Shield");
        }
    }
}
