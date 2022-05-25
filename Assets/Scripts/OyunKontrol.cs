using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public GameObject oyunBittiPanel, duraklatmaPanel, tebriklerPanel,duraklatmaBtn;
    public AudioSource altinSesi, tuzakSesi;
    AudioSource bgSesi;
    KarakterKontrol karakterKontrol;

    public int sesAcikmi = 1, musicAcikmi = 1;

    private void Start()
    {
        oyunBittiPanel.SetActive(false);
        duraklatmaPanel.SetActive(false);
        tebriklerPanel.SetActive(false);
        karakterKontrol = GameObject.FindGameObjectWithTag("Player").GetComponent<KarakterKontrol>();
        musicAcikmi = PlayerPrefs.GetInt("musicAcikmi");
        sesAcikmi = PlayerPrefs.GetInt("sesAcikmi");

    }

    private void Update()
    {
        
        if (sesAcikmi==1)
        {
            altinSesi.mute = false;
            tuzakSesi.mute = false;
        }
        else
        {
            altinSesi.mute = true;
            tuzakSesi.mute = true;
        }

        if (musicAcikmi==1)
        {
            bgSesi = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
            bgSesi.mute = false;
        }
        else
        {
            bgSesi = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
            bgSesi.mute = true;
        }
       
    }

    public void oyunBitti()
    {
        duraklatmaBtn.SetActive(false);
        oyunBittiPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void bolumGecis()
    {
        tebriklerPanel.SetActive(true);
        karakterKontrol.enabled = false;
    }

    public void bolumGecBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        karakterKontrol.enabled = true;
    }

    public void tekrarOyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cikis()
    {
        Application.Quit();
    }

    public void Duraklatma()
    {
        Time.timeScale = 0;
        duraklatmaPanel.SetActive(true);
    }

    public void devamEt()
    {
        Time.timeScale = 1;
        duraklatmaPanel.SetActive(false);
    }
    public void sesAc()
    {
        if (sesAcikmi == 1)
        {
            sesAcikmi = 0;
            PlayerPrefs.SetInt("sesAcikmi", sesAcikmi);
        }
        else
        {
            sesAcikmi = 1;
            PlayerPrefs.SetInt("sesAcikmi", sesAcikmi);
        }
    }
    public void musicAc()
    {
        if (musicAcikmi == 1)
        {
            musicAcikmi = 0;
            PlayerPrefs.SetInt("musicAcikmi", musicAcikmi);
        }
        else
        {
            musicAcikmi = 1;
            PlayerPrefs.SetInt("musicAcikmi", musicAcikmi);
        }
    }

    public void Level1()
    {
        SceneManager.LoadScene("1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("4");
    }
    public void Level5()
    {
        SceneManager.LoadScene("5");
    }
    public void AnaMenu()
    {
        SceneManager.LoadScene("0");
    }


}
