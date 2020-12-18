using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cupMove : MonoBehaviour
{
    public AudioSource audioSource;
    public Button shakebut;
    public Button checkBut;

    bool buttonInput = false;

    float speed = 10f;
    Vector3 moveToDice = new Vector3(-3, 12, 0);
    Vector3 coverTheDice = new Vector3(-3, 1.9f, 0);
    Vector3 originPos;
    Quaternion originRot;

    public GameObject dice1;
    public GameObject dice2;
    public GameObject dice3;


    public static bool myturn = true; // 컴퓨터한테 턴을 넘겨줌
    public static bool comturn = false; // 컴퓨터 턴인지 확인용

    public int gameMode = 0; // 컵흔들기위해서 방향에 따라서 숫자를 주는놈
    int where = -1; // 컵방향
    int count = 0; // 컵 몇번흔들지 정할놈

    int[] diceRot = new int[] { 0, 90, 180, 270 };

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
        originRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMode == 0) {
            transform.rotation = originRot;
            transform.position = originPos;
        }
        if (buttonInput) {
            buttonInput = false;

            gameMode = 1;
        }

        if (gameMode == 1) {
            transform.position = Vector3.MoveTowards(transform.position, moveToDice, Time.deltaTime * speed);
            if(transform.position == moveToDice) {
                transform.Rotate(new Vector3(180, 0, 0));
                gameMode = 2;
            }
        }
        else if(gameMode == 2) {
            Debug.Log("Now In Mode 2");
            audioSource.Play();
            transform.position = Vector3.MoveTowards(transform.position, coverTheDice, Time.deltaTime * speed);
            if(transform.position == coverTheDice) {
                gameMode = 3;
            }
        }

        else if (gameMode == 3) {
            dice1.SetActive(false);
            dice2.SetActive(false);
            dice3.SetActive(false);
            Shake();
        }
        else if(gameMode == 4) {
            transform.position = Vector3.MoveTowards(transform.position, moveToDice, Time.deltaTime * speed);
            if(transform.position == moveToDice) {
                gameMode = 5;
                transform.Rotate(new Vector3(-180, 0, 0));
            }
        }
        else if(gameMode == 5) {
            transform.position = Vector3.MoveTowards(transform.position, originPos, Time.deltaTime * speed);
            if(transform.position == originPos) {
                gameMode = 0;
                gameManager.turnCount--;
                if (myturn == false) {
                    comturn = true;
                }

                if (gameManager.turnCount > 0) {
                    checkBut.interactable = true;
                    shakebut.interactable = true;
                }
                else if(gameManager.turnCount == 0 && myturn == true){
                    checkBut.interactable = true;
                }
                else {
                    myturn = false;
                }
            }
        }
    }

    void Shake() {
        if (transform.position.x > 1.5) {
            where = 1;
            count++;
        }
        if(transform.position.x < -6.5) {
            where = -1;
        }
        if(count == 3) {
            int dice1X = diceRot[Random.Range(0, 4)];
            int dice2X = diceRot[Random.Range(0, 4)];
            int dice3X = diceRot[Random.Range(0, 4)];

            int dice1Z = diceRot[Random.Range(0, 4)];
            int dice2Z = diceRot[Random.Range(0, 4)];
            int dice3Z = diceRot[Random.Range(0, 4)];

            dice1.SetActive(true);
            dice1.transform.Rotate(dice1X, dice1.transform.rotation.y, dice1Z);

            dice2.SetActive(true);
            dice2.transform.Rotate(dice2X, dice2.transform.rotation.y, dice2Z);

            dice3.SetActive(true);
            dice3.transform.Rotate(dice3X, dice3.transform.rotation.y, dice3Z);
            transform.position = transform.position;

            count = 0;
            gameMode = 4;
            
        }
        transform.Translate(Vector3.left * 10f * Time.deltaTime * where);
    }

    public void ButtonClick() {
        buttonInput = true;
        shakebut.interactable = false;
        checkBut.interactable = false;
    }

}
