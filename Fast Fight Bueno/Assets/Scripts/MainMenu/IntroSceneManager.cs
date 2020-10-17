using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class IntroSceneManager : MonoBehaviour
{
    public GameObject startText1;
    public GameObject startText2;
    float timer;
    bool loadingLevel;
    bool init;

    public int activeElement;
    public GameObject menuObj;
    public ButtonRef[] menuOptions;

    void Start()
    {
        menuObj.SetActive(false);
    }

    void Update()
    {
        if (!init)
        {
            timer += Time.deltaTime;
            if (timer > 0.3f)
            {
                timer = 0;
                startText2.SetActive(!startText2.activeInHierarchy);
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Intro"))
            {
                init = true;
                startText1.SetActive(false);
                startText2.SetActive(false);
                menuObj.SetActive(true);
            }
        }
        else
        {
            if (!loadingLevel)
            {
                menuOptions[activeElement].selected = true;

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    menuOptions[activeElement].selected = false;

                    if (activeElement > 0)
                    {
                        activeElement--;
                    }
                    else
                    {
                        activeElement = menuOptions.Length - 1;
                    }
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    menuOptions[activeElement].selected = false;
                    if (activeElement < menuOptions.Length - 1)
                    {
                        activeElement++;
                    }
                    else
                    {
                        activeElement = 0;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Intro"))
            {
                Debug.Log("load");
                loadingLevel = true;
                StartCoroutine("LoadLevel");
                menuOptions[activeElement].transform.localScale *= 1.2f;
            }
        }
    }
    /*void HandleSelectedOption()
    {
        switch (activeElement)
        {
            case 0:
                CharacterManager.GetInstance().numberOfUsers = 1;
            case 1:
                CharacterManager.GetInstance().numberOfUsers = 2;
                CharacterManager.GetInstance().players[1].playerType = PlayerBase.PlayerType.user;
                break;
        }
    }
    IEnumerator LoadLevel()
    {
        HandleSelectedOption();
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadSceneAsync("select", LoadSceneMode.Single);
    }*/

}

