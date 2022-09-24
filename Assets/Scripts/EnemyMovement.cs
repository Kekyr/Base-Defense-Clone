using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private List<Vector3> _defaultPositions = new List<Vector3>();
    
    public static Transform Player;
    
    private Movement _movement;
    
    private Vector3 _newDirection;

    private Vector3 _randomDirection;

    private Vector3 _randomPosition;

    
    private void Start()
    {
        _movement = GetComponent<Movement>();
        Player = FindObjectOfType<PlayerMovement>().transform;
        
        _defaultPositions.Add(GameManager.instance._left.position);
        _defaultPositions.Add(GameManager.instance._right.position);

        _randomPosition = _defaultPositions[Random.Range(0, _defaultPositions.Count)];
    }

    private void Update()
    {
        if (GameManager.instance.isFollowing)
        {
            _newDirection = (Player.transform.position - transform.position).normalized;
            _randomPosition = _defaultPositions[Random.Range(0, _defaultPositions.Count)];
        }
        else
        {
            _randomDirection = (_randomPosition - transform.position).normalized;
            _newDirection =_randomDirection;
        }
    }

    private void FixedUpdate()
    {
        _movement.Move(_newDirection);
    }
    
    
}
