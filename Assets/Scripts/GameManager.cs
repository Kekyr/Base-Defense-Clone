using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _restartWindow;
    [SerializeField] private MovingCamera _movingCamera;
    [SerializeField] private Barrier _barrier;
    [SerializeField] private Transform _field;
    [SerializeField] private TextMeshProUGUI _hpText;
    public Transform _left;
    public Transform _right;

    public bool isFollowing;

    private Vector3 position;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnEnemies",0f,2f);
    }
    
    public void TurnOnAndOffRestartWindow(bool isTurn)
    {
        _restartWindow.SetActive(isTurn);
    }
    
    public void PlayerRevival()
    {
        Destroy(_player);
        _player=Instantiate(_playerPrefab);
        _movingCamera.Target = _player.transform;
        EnemyMovement.Player = _player.transform;
        _barrier.Attack = true;
        TurnOnAndOffRestartWindow(false);
        _hpText.text = "HP: 150";
    }

    private void SpawnEnemies()
    {
        position = _field.GetChild(Random.Range(0, _field.childCount)).position;
        Instantiate(_enemyPrefab, position, Quaternion.identity);
    }
    
}
