using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public static int cont=0;
    public float speed;
	public int contIni;
	public Text countText;
	public Text countText2;
	public Text winText;
	private int puntuacionMax;
	public Button but;

	public float force;
	private bool changeDir;
	private Vector3 dir;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
		but.gameObject.SetActive (false);
		contIni = cont;
		changeDir = false;
        rb = GetComponent<Rigidbody>();
		dir = new Vector3 (0, 0, 0);
		SetCountText ();
		SetCountText2 ();
		winText.text = "";

		//PlayerPrefs.SetInt ("puntuacionMax", 0);
	}
	void Update(){
		if (transform.position.y < -1) {
			this.transform.position= new Vector3(4,0.5f,4);
			rb.Sleep();
			dir= new Vector3(0,0,0);
		}
		if (Input.GetMouseButtonDown (0)) {
			rb.Sleep ();
			if(changeDir){
				dir= new Vector3(0,0,1);
				changeDir= false;
				
			}else{
				dir= new Vector3(1,0,0);
				changeDir=true;
			}
		}
	}
	// Update is called once per frame
	void FixedUpdate () {

		rb.MovePosition (transform.position + dir * Time.deltaTime * force);
        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);*/

    }
	public void OnCollisionEnter(Collision node)
	{
		if(node.gameObject.tag == "destruye")
		{
			Destroy(node.gameObject);
			cont++;
			SetCountText();

		}
		if(node.gameObject.tag == "abismo")
		{
			cont= contIni;
			Application.LoadLevel(Application.loadedLevelName);
			
		}
		if(node.gameObject.tag == "final")
		{
			Application.LoadLevel("zigzag2");
			
		}
		if(node.gameObject.tag == "final2")
		{
			Application.LoadLevel("zigzag3");
			
		}
		if(node.gameObject.tag == "finjuego")
		{

			if(cont>PlayerPrefs.GetInt("puntuacionMax"))
			{	winText.text = "NEW RECORD";
				PlayerPrefs.SetInt("puntuacionMax", cont);
				SetCountText2();

			}
			else winText.text = "YOU LOSE";
			cont=0;
			but.gameObject.SetActive (true);
			this.gameObject.SetActive(false);
			
		}
	}

	void SetCountText()
	{
		countText.text = "Marcador: " + cont.ToString ();

	}
	void SetCountText2(){
		countText2.text = "Record: " + PlayerPrefs.GetInt("puntuacionMax");
	}

}
