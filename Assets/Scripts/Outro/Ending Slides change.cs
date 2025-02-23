using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    ProgressManager manager;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    private Sprite nextSprite;

    public bool phaseOne = true; //to definiuje, czy gracz ma dobry klucz
    public bool phaseTwo = true; //to definiuje, czy gracz ma dobry item do kodu

    public bool phaseThree1 = false; //to definiuje, czy gracz ma dobry item do zakonczenia z laserami
    public bool phaseThree1Exists = false; //to definiuje, czy gracz ma jako przeszkode lasery (reszta musi byc na false)



    public bool phaseThree2 = false; //to definiuje, czy gracz ma dobry item do zakonczenia z kamerami
    public bool phaseThree2Exists = false;  //to definiuje, czy gracz ma jako przeszkode kamery (reszta musi byc na false)



    public bool phaseThree3 = true; //to definiuje, czy gracz ma dobry item do zakonczenia z czujnikiem ruchu
    public bool phaseThree3Exists = true; //to definiuje, czy gracz ma jako przeszkode czujnik ruchu (reszta musi byc na false)
    public int currentPhase = 1;

    public AudioSource remoteClick;
    // Start is called before the first frame update

    public TMP_Text newsText;

    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

    void Start()
    {
        ChangeSprite(spriteArray[0]);
        manager = GameObject.FindObjectOfType<ProgressManager>();
        phaseOne = manager.PH2Decisions[1].pass;
        phaseTwo = manager.PH2Decisions[2].pass;
        if(manager.whichSec == 1){
            phaseThree1Exists = true;
            phaseThree1 = manager.PH2Decisions[0].pass;
        }
        if(manager.whichSec == 2){
            phaseThree2Exists = true;
            phaseThree2 = manager.PH2Decisions[0].pass;
        }
        if(manager.whichSec == 0){
            phaseThree3Exists = true;
            phaseThree3 = manager.PH2Decisions[0].pass;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            remoteClick.Play();
            switch (currentPhase)
            {
                case 1:
                    {
                        nextSprite = spriteArray[1];
                        if (phaseOne)
                        {
                            newsText.text = "\"The perpetrator opened the door to the vault. There were no visible signs of tampering with the lock, so authorities concluded that he must have used a matching key that he had previously stolen.\"";
                        }
                        else
                        {
                            newsText.text = "\"The perpetrator attempted to open the vault door.\"";
                        }

                        currentPhase++;
                        break;
                    }
                case 2:
                    {
                        if (phaseOne)
                        {

                            if (phaseTwo)
                            {
                                newsText.text = "\"Then, the perpetrator went to the vault's opening panel, where he entered a code that opened the gates. How the burglar learned the secret code, authorities are unable to determine.\"";
                            }
                            else
                            {
                                newsText.text = "\"Then, the perpetrator went to the vault's opening panel, where he entered the code that would open the gates.\"";
                            }

                            nextSprite = spriteArray[3];

                            if (phaseThree1Exists)
                            {
                                currentPhase = 3;
                            }
                            else if (phaseThree2Exists)
                            {
                                currentPhase = 4;
                            }
                            else if (phaseThree3Exists)
                            {
                                currentPhase = 5;
                            }

                        }
                        else
                        {
                            nextSprite = spriteArray[2];
                            newsText.text = "\"After a thorough analysis of the damage sustained by the lock, authorities determined that the burglar had spent approximately 4 hours trying to fit a wrong key into the lock, which he eventually did achieve, but it did not unlock the door.\"";
                            currentPhase = 12;
                        }
                        break;
                    }




                case 3:
                    {
                        if (phaseTwo)
                        {
                            if (phaseThree1)
                            {
                                newsText.text = "\"Eventually, the perpetrator got into the vault, where laser security was waiting for him. During the investigation, it was determined that the laser system stopped working during the hours of the break-in for unknown reasons.\"";
                                currentPhase = 11;
                            }
                            else
                            {
                                newsText.text = "\"Eventually, the perpetrator got into the vault, where laser security was waiting for him.\"";
                                currentPhase = 6;
                            }
                            nextSprite = spriteArray[5];

                        }
                        else
                        {
                            newsText.text = "\"Unfortunately, it was not the correct code. For the next five hours, the perpetrator tried to guess the combination by trial and error, but police findings revealed that he pressed the “1” key continuously.\"";
                            nextSprite = spriteArray[4];
                            currentPhase = 12;
                        }
                        break;
                    }
                case 4:
                    {
                        if (phaseTwo)
                        {
                            if (phaseThree2)
                            {
                                newsText.text = "\"Eventually, the perpetrator got into the vault, where security cameras were patrolling the area. During the investigation, it was determined that the camera system stopped working during the hours of the break-in for unknown reasons.\"";
                                currentPhase = 11;
                            }

                            else
                            {
                                newsText.text = "\"Eventually, the perpetrator got into the vault, where security cameras were patrolling the area.\"";
                                currentPhase = 7;
                            }
                            nextSprite = spriteArray[9];
                            
                        }
                        else
                        {
                            newsText.text = "\"Unfortunately, it was not the correct code. For the next five hours, the perpetrator tried to guess the combination by trial and error, but police findings revealed that he pressed the “1” key continuously.\"";
                            nextSprite = spriteArray[4];
                            currentPhase = 12;
                        }
                        break;
                    }
                case 5:
                    {
                        if (phaseTwo)
                        {
                            if (phaseThree3)
                            {
                                newsText.text = "\"Eventually, the perpetrator got into the vault, where the silent alarm was operating. Unfortunately, the alarm was not activated and the burglar got into the vault. The reason for the malfunction of the silent alarm still remains to be explained.\"";
                                currentPhase = 11;
                            }
                            else
                            {
                                newsText.text = "\"Eventually, the perpetrator got into the vault, where the silent alarm was operating.\"";
                                currentPhase = 8;
                            }
                            nextSprite = spriteArray[7];
                            
                        }
                        else
                        {
                            newsText.text = "\"Unfortunately, it was not the correct code. For the next five hours, the perpetrator tried to guess the combination by trial and error, but police findings revealed that he pressed the “1” key continuously.\"";
                            nextSprite = spriteArray[4];
                            currentPhase = 12;
                        }
                        break;
                    }
                case 6:
                    {
                        newsText.text = "\"The burglar was evidently unaware of the operation of the security features, as he walked straight into the laser, setting off the alarm and at the same time notifying the police of the break-in.\"";
                        nextSprite = spriteArray[6];
                        currentPhase=12;
                        break;
                    }
                case 7:
                    {
                        newsText.text = "\"The burglar was unaware that the cameras were running all the time, which may have explained his surprise when the police showed up 5 minutes after entering the vault.\"";
                        nextSprite = spriteArray[10];
                        currentPhase=12;
                        break;
                    }
                case 8:
                    {
                        newsText.text = "\"The burglar was unaware that the silent alarm was working, which he found out moments later. Authorities arrived 5 minutes later to find the burglar stunned by the alarm.\"";
                        nextSprite = spriteArray[8];
                        currentPhase=12;
                        break;
                    }

                case 11:
                    {
                        newsText.text = "\"The identity of the burglar still remains undetermined, but the authorities are working hard to find him and make him pay for his actions. ‘Nothing can go wrong’ he probably thought to himself, and unfortunately he was right...\"";
                        nextSprite = spriteArray[11];
                        currentPhase=14;
                        break;
                    }
                case 12:
                    {
                        newsText.text = "\"The perpetrator was caught and will suffer the consequences of his actions. ‘Nothing can go wrong’ he probably thought to himself, but unfortunately reality is not a video game. It is brutal and full of traps.\"";
                        nextSprite = spriteArray[12];
                        currentPhase++;
                        break;
                    }
                case 13:
                    {
                        SceneLoader.LoadMenu();
                        break;
                    }
                case 14:
                    {
                    SceneLoader.LoadMenu();
                break;
                }
            }
            ChangeSprite(nextSprite);


        }
    }


}
