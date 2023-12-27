using System.Collections;
using System.Collections.Generic;
using TMPPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
public static GameManager instance;
public int vidas = 2;
publicint tijolosRestantes; 

public GameObject playerPrefab;
public GameObject ballPrefab;

public Transform PlayerSpawnPoint;
public Transform BallSpawnPoint;

public player playerAtual;
public ball ballAtual;

public TextMeshProUGUI Contador;
public TextMeshProUGUI MsgFinal;
public bool segurando;
private Vector3 offset;


private void Awake()
{
    instance = this;
}
// Start is called before the first frame update
public void  SpawnarNovoJogador()
{
   GameObject playerObj = Instantiate(playerPrefab,PlayerSpawnPoint.position,Quaternion.identity);
   GameObject ballObj = Instantiate(ballPrefab,ballSpawnPoint.position,Quaternion.identity);
   playerAtual = playerObj.GetComponent<player>();
   ballAtual = ballObj.GetComponent<ball>();

   segurando = true;

   offset = playerAtual.transform.position = ballAtual.transform.position;

}
}
 void Start()
{
   SpawnarNovoJogador();
   AtualizarContador();
}
public void AtualizarContador()
{
    contador.text = $"Vidas: {vidas}";
}


public void SpawnarNovoJogador()
{
    GameObject playerObj = 
        Instantiate(playerPrefab, SpawnPointPlayerB.position, Quaternion.identity);
    GameObject ballObj = 
        Instantiate(ballPrefab, SpawnPointBallB.position, Quaternion.identity);
}

void update()
{
    if (segurando)
    {

         ballAtual = transform.position = playerAtual.transform.position- offset;

         if(input.GetkeyDown(keyCode.Space)){
            ballAtual.DispararBolinha(playerAtual.inputX);
            segurando =  false;
         }
    }
}