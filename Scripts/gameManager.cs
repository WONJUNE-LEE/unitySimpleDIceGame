using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public Text dice1T;
    public Text dice2T;
    public Text dice3T;
    public Text myScoreT;
    public Text comScoreT;

    public GameObject winText;
    public GameObject loseText;

    public Button shakeBut;
    public Button checkBut;

    public Text diceCount;

    float scoreTime;
    public static int turnCount = 3;
    int myScore = 0;
    int comScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        checkBut.interactable = false;
    }
    // Update is called once per frame
    void Update()
    {
        diceCount.text = "가능횟수 : " + turnCount.ToString();
        //cupMove에서 myturn을 넘겨줌
        if(cupMove.myturn == false && cupMove.comturn == true) {
            if (dice3T.text == dice2T.text) {
                if (dice2T.text == dice1T.text) {
                    comScore = 20;
                }
            }
            comScore = int.Parse(dice1T.text) + int.Parse(dice2T.text) + int.Parse(dice3T.text);
            comScoreT.text = comScore.ToString();

            if(comScore > myScore) {
                loseText.SetActive(true);
                checkBut.interactable = false;
                shakeBut.interactable = false;
            }
            else {
                winText.SetActive(true);
                checkBut.interactable = false;
                shakeBut.interactable = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "SIDE1") {
            dice1T.text = "1";
        }
        else if (other.gameObject.tag == "SIDE2") {
            dice1T.text = "2";
        }
        else if (other.gameObject.tag == "SIDE3") {
            dice1T.text = "3";
        }
        else if (other.gameObject.tag == "SIDE4") {
            dice1T.text = "4";
        }
        else if (other.gameObject.tag == "SIDE5") {
            dice1T.text = "5";
        }
        else if (other.gameObject.tag == "SIDE6") {
            dice1T.text = "6";
        }

        if(other.gameObject.tag == "SIDE2-1") {
            dice2T.text = "1";
        }
        else if(other.gameObject.tag == "SIDE2-2") {
            dice2T.text = "2";
        }
        else if (other.gameObject.tag == "SIDE2-3") {
            dice2T.text = "3";
        }
        else if (other.gameObject.tag == "SIDE2-4") {
            dice2T.text = "4";
        }
        else if (other.gameObject.tag == "SIDE2-5") {
            dice2T.text = "5";
        }
        else if (other.gameObject.tag == "SIDE2-6") {
            dice2T.text = "6";
        }

        if (other.gameObject.tag == "SIDE3-1") {
            dice3T.text = "1";
        }
        else if (other.gameObject.tag == "SIDE3-2") {
            dice3T.text = "2";
        }
        else if (other.gameObject.tag == "SIDE3-3") {
            dice3T.text = "3";
        }
        else if (other.gameObject.tag == "SIDE3-4") {
            dice3T.text = "4";
        }
        else if (other.gameObject.tag == "SIDE3-5") {
            dice3T.text = "5";
        }
        else if (other.gameObject.tag == "SIDE3-6") {
            dice3T.text = "6";
        }
    }

    public void ShakeButtonClick() {
        
    }

    public void CheckButtonClick() {
        turnCount = 0;

        myScore = int.Parse(dice1T.text) + int.Parse(dice2T.text) + int.Parse(dice3T.text);
        if (dice3T.text == dice2T.text) {
            if(dice2T.text == dice1T.text) {
                myScore = 20;
            }
        }
        myScoreT.text = myScore.ToString();

        checkBut.interactable = false;
        cupMove.comturn = true;
    }

    public void RestartButton() {
        SceneManager.LoadScene("Main");
    }
}
