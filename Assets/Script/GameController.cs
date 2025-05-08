using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
    using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameController : MonoBehaviour
{
    public GameObject all;
    public GameObject Gameover;
    public GameObject start;
    public GameObject Square;
    public GameObject Bosshmb;
    public GameObject clear;
    //public Ddong target;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text1;
    int score = 0;
    int score1 =  2;

    bool alls = false;
    void Start()
    {
        SetText();
        SetText1();
    }

    private void Update()
    {
        if (score1 == 0)
        {
            all.SetActive(false);
            Gameover.SetActive(true);
            Bosshmb.SetActive(false);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }

        if (alls == false)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                all.SetActive(true);
                start.SetActive(false);
                alls = true;
            }
        }

        if (score == 100)
        {
            Square.SetActive(false);
            Bosshmb.SetActive(true);
        }

    }


    public void clear1()
    {
        clear.SetActive(true);
        Bosshmb.SetActive(false);
        all.SetActive(false);
    }
    public void GetScore() //����
    {
        score += 1;
        SetText();
    }
    public void GetScore1() //�÷��̾� ü�¹�, Ÿ������ ��������
    {
        score1 -= 1;
        SetText1();
    }
    public void GetScore2() //�÷��̾� ü�¹�, ������ �Ծ�����
    {
        if(score1 < 2) 
        {score1 += 1; }
        
        SetText1();
    }

    public void SetText()
    {
        text.text = "Score : " + score;
    }
    public void SetText1()
    {
        text1.text = "Heart : " + score1;
    }
}
