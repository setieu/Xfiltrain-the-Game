using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    public AudioSource audioSource;
    private GameManager gameManager;
    public bool playedh1 = false;
    public bool playedh2 = false;
    public bool playedh3 = false;
    public bool playedh4 = false;
    public bool playedh5 = false;
    public bool playedh6 = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }



    // Update is called once per frame
    void Update()
    {
        if (gameManager.modeeE == 1)
        {
            if (gameManager.Scoree >= 100)
            {
                if (playedh1 == false)
                {
                    PlayAudio();
                    Debug.Log("Try to ping");
                    playedh1 = true;
                }
                else if (gameManager.Scoree >= 200)
                {
                    if (playedh2 == false)
                    {
                        PlayAudio();
                        Debug.Log("Try to ping");
                        playedh2 = true;
                    }

                }

            }
        }


        if (gameManager.modeeE == 2)
        {
            if (gameManager.Scoree >= 250)
            {
                if (playedh1 == false)
                {
                    PlayAudio();
                    Debug.Log("Try to ping");
                    playedh1 = true;
                }
                else if (gameManager.Scoree >= 500)
                {
                    if (playedh2 == false)
                    {
                        PlayAudio();
                        Debug.Log("Try to ping");
                        playedh2 = true;
                    }
                    else if (gameManager.Scoree >= 750)
                    {
                        if (playedh3 == false)
                        {
                            PlayAudio();
                            Debug.Log("Try to ping");
                            playedh3 = true;
                        }
                        else if (gameManager.Scoree >= 1000)
                        {
                            if (playedh4 == false)
                            {
                                PlayAudio();
                                Debug.Log("Try to ping");
                                playedh4 = true;
                            }
                            else if (gameManager.Scoree >= 1250)
                            {
                                if (playedh5 == false)
                                {
                                    PlayAudio();
                                    Debug.Log("Try to ping");
                                    playedh5 = true;
                                }

                            }
                        }
                    }
                }

            }
        }


        if (gameManager.modeeE == 3)
        {
            if (gameManager.Scoree >= 200)
            {
                if (playedh1 == false)
                {
                    PlayAudio();
                    Debug.Log("Try to ping");
                    playedh1 = true;
                }
                else if (gameManager.Scoree >= 400)
                {
                    if (playedh2 == false)
                    {
                        PlayAudio();
                        Debug.Log("Try to ping");
                        playedh2 = true;
                    }
                    else if (gameManager.Scoree >= 600)
                    {
                        if (playedh3 == false)
                        {
                            PlayAudio();
                            Debug.Log("Try to ping");
                            playedh3 = true;
                        }
                        else if (gameManager.Scoree >= 800)
                        {
                            if (playedh4 == false)
                            {
                                PlayAudio();
                                Debug.Log("Try to ping");
                                playedh4 = true;
                            }

                        }
                    }
                }

            }
        }

        if (gameManager.modeeE == 4)
        {
            if (gameManager.Scoree >= 1000)
            {
                if (playedh1 == false)
                {
                    PlayAudio();
                    Debug.Log("Try to ping");
                    playedh1 = true;
                }
                else if (gameManager.Scoree >= 2000)
                {
                    if (playedh2 == false)
                    {
                        PlayAudio();
                        Debug.Log("Try to ping");
                        playedh2 = true;
                    }
                    else if (gameManager.Scoree >= 3000)
                    {
                        if (playedh3 == false)
                        {
                            PlayAudio();
                            Debug.Log("Try to ping");
                            playedh3 = true;
                        }

                    }
                }
            }
        }
    }

    public void PlayAudio()
    {
        // Play the audio on the AudioSource component
        audioSource.Play();
    }
}