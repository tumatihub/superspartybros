using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float arrowVelocity;

    bool _facingRight = true;
    float _vx;
    Rigidbody2D _rb;
    [SerializeField]
    float _arrowLifeTime;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();    
    }

    // Use this for initialization
    void Start () {
        Destroy(gameObject, _arrowLifeTime);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
	}

    public void Move(bool _facingRight)
    {
        _vx = arrowVelocity;
        if (!_facingRight)
        {
            _vx *= -1;
        }
        _rb.velocity = new Vector2(_vx, 0);
    }
}
