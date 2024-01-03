using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int vidas = 2;
    public int tijolosRestantes;

    public GameObject playerPrefab;
    public GameObject ballPrefab;

    public Transform PlayerSpawnPoint;
    public Transform BallSpawnPoint;

    public PlayerB playerAtual;
    public BallB ballAtual;

    public TextMeshProUGUI contador;
    public TextMeshProUGUI MsgFinal;
    public bool segurando;
    private Vector3 offset;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnarNovoJogador();
        AtualizarContador();
        tijolosRestantes = FindGameObjectsWithTag("Tijolo").Leght;

    }
    public void AtualizarContador()
    {
        contador.text = $"Vidas: {vidas}";
    }


    public void SpawnarNovoJogador()
    {
        GameObject playerObj = Instantiate(playerPrefab, PlayerSpawnPoint.position, Quaternion.identity);
        GameObject ballObj = Instantiate(ballPrefab, BallSpawnPoint.position, Quaternion.identity);

        playerAtual = playerObj.GetComponent<PlayerB>();
        ballAtual = ballObj.GetComponent<BallB>();
        segurando = true;
        offset = playerAtual.transform.position - ballAtual.transform.position;

    }

    public void subtrairTijolo() 
    {
        tijolosRestantes--;
        if (tijolosRestantes <= 0)
        {
            Vitoria();
        }
    }

    public void subtrairTVida()
    {
    }
    public void Vitoria()
    {
    }
    public void GameOver()
    {
    }


    void update()
    {
        if (segurando)
        {

            ballAtual.transform.position = playerAtual.transform.position - offset;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ballAtual.DispararBolinha(playerAtual.inputX);
                segurando = false;
            }
        }
    }
}