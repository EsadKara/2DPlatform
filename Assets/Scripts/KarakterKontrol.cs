using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarakterKontrol : MonoBehaviour
{
    public Joystick joystick;
    public float kosuHizi, ziplamaHizi;
    public bool kosuyorMu;
    float horizontal, joyHorizontal;
    public yerdeMi yerde_Mi;
    Rigidbody2D fizik;
    public GameObject[] altinlar;
    public GameObject giris;
    int hedef, toplananAltin, aktifLevel = 1;
    bool gecis = false;
    public Text altinTxt;
    public Transform baslangicPos;
    public AudioSource altinToplamaSesi, tuzakSesi;
    OyunKontrol kontrol;
    public int levelSayisi = 1;

    Animator anim;
    void Start()
    {
        Time.timeScale = 1;
        anim = gameObject.GetComponent<Animator>();
        fizik = gameObject.GetComponent<Rigidbody2D>();
        hedef = altinlar.Length;
        toplananAltin = 0;
        altinTxt.text = toplananAltin.ToString() + " / " + hedef.ToString();
        kontrol = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<OyunKontrol>();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ziplama();
        }
        if (toplananAltin == hedef)
        {
            gecis = true;
            giris.SetActive(false);
        }
        altinTxt.text = toplananAltin.ToString() + " / " + hedef.ToString();
    }

    private void FixedUpdate()
    {
        //Karakter Hareket Ettirme
        kosuyorMu = false;
        horizontal = Input.GetAxis("Horizontal");
        joyHorizontal = joystick.Horizontal;
        transform.position += new Vector3(horizontal * kosuHizi * Time.deltaTime, 0, 0);
        transform.position += new Vector3(joyHorizontal * kosuHizi * Time.deltaTime, 0, 0);
        if (horizontal != 0 || joyHorizontal != 0) 
        {
            kosuyorMu = true;
        }
        anim.SetBool("Running", kosuyorMu);
        YonDegistir();
    }

    void YonDegistir()
    {
        if (horizontal > 0 || joyHorizontal > 0)
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
        else if (horizontal < 0 || joyHorizontal < 0)
        {
            transform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
        }
    }

    public void Ziplama()
    {
        if(yerde_Mi.yerdemi == true)
        {
            fizik.AddForce(Vector3.up * ziplamaHizi);
        }
    }
  

    private void OnCollisionEnter2D(Collision2D nesne)
    {
        if (nesne.transform.tag == "Tuzak")
        {
            tuzakSesi.Play();
            kontrol.oyunBitti();
        }
    }

    private void OnTriggerEnter2D(Collider2D nesne)
    {
        if (nesne.transform.tag == "Altin")
        {
            altinToplamaSesi.Play();
            Destroy(nesne.gameObject);
            toplananAltin++;
        }
        if (nesne.transform.tag == "Gecis")
        {
            if (gecis)
            {
                if (levelSayisi >= aktifLevel)
                {
                    aktifLevel = levelSayisi;
                    PlayerPrefs.SetInt("level", aktifLevel);
                }
                kontrol.bolumGecis();
            }
        }
    }

    public void Right()
    {
        horizontal = 1;
    }
    public void Left()
    {
        horizontal = -1;
    }
    public void Stop()
    {
        horizontal = 0;
    }


}
