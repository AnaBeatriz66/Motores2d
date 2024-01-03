using System.Collections;
using System.Collections.Generic;
using TMPPro;
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

public TextMeshProUGUI Contador;
public TextMeshProUGUI MsgFinal;
public bool segurando;
private Vector3 offset;


private void Awake()
{
    instance = this;
}
    // Start is called before the first frame update

      void Start()
    {
        
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
    GameObject playerObj =  Instantiate(playerPrefab, PlayerSpawnPointPlayerB.position, Quaternion.identity);
    GameObject ballObj = Instantiate(ballPrefab, SpawnPointBallB.position, Quaternion.identity);

        playerAtual = playerObj.GetComponent<PlayerB>();
        ballAtual =  ballObj.GetComponent<BallB>();
        segurando = true;
        offset - playerAtual.transform.position - ballAtual.transform.position;
        
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