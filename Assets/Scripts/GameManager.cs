using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	[Header("Setup")]
    public Transform parentBricks;
    public Transform parentBricksPrefab;
    public Paddle paddlePrefab;
	public Paddle spawnedPaddle;

    [Header("Gameplay Setup")]
    public int jmlBrick, nyawa;
	public GameObject winObj, loseObj;
	public Text liveTxt;
	public Bola bola;
	public static GameManager instance;
	// Use this for initialization
	void Awake(){
		instance = this;
		jmlBrick = parentBricks.childCount;
	}
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {	
		if(Input.GetKeyDown(KeyCode.Backspace)){
			nyawa = 1;
			OnBallDestroy();
		}
	}
	public void OnBrickDestroyed(){
		jmlBrick -=1;
		if(jmlBrick<=0){
			// print("WON");
			winObj.SetActive(true);
			Time.timeScale = 0.2f;
		}
	}
	public void OnBallDestroy(){
		print(string.Format("nyawa = {0} - 1 result: {1}", nyawa, nyawa-1));
		nyawa--;
		liveTxt.text ="Nyawa : " + nyawa;
		if(nyawa <=0){
			loseObj.SetActive(true);
			Time.timeScale= 0.2f;
			print("NOOB");
		}
	}
    public void Restart(){
        nyawa = 3;
		bola.Respawn();

		loseObj.SetActive(false);
		winObj.SetActive(false);
		Destroy(parentBricks.gameObject);
		Vector3 PaddlePos= spawnedPaddle.transform.position;
		PaddlePos.x=0f;
		spawnedPaddle.transform.position=PaddlePos;

        liveTxt.text = "Nyawa : " + nyawa;
		
		parentBricks = Instantiate(parentBricksPrefab);
        jmlBrick = parentBricks.childCount;
		Time.timeScale = 1f;
    }
	public void QuitGame(){
		Application.Quit();
	}
}
