using DG.Tweening;
using MyFisrtGame.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamerManager : Singleton<GamerManager>
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;
   

    [Header("Animation")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;

    private GameObject _currentPlayer;

    public void Start()
    {
        Init();
    }
    public void Init()
    {
        spawnPlayer();
    }
    private void spawnPlayer()
    {
        _currentPlayer =Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(0,duration).SetEase(ease).From().SetDelay(delay);
    }
}
