using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{


    public List<ButtonSetting> laserSettings;

    List<GameObject> laserList;
    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
    public GameObject laser4;
    public GameObject laser5;
    public GameObject laser6;
    public GameObject laser7;
    public GameObject laser8;


    int bleepCount = 3;

    List<int> bleeps;
    List<int> playerBleeps;

    System.Random rg;

    bool gameOver = false;

    void Start()
    {
        
        

        laserList = new List<GameObject>();
        laserList.Add(laser1);
        laserList.Add(laser2);
        laserList.Add(laser3);
        laserList.Add(laser4);
        laserList.Add(laser5);
        laserList.Add(laser6);
        laserList.Add(laser7);
        laserList.Add(laser8);

        StartCoroutine(SimonSays());
    }

   /* void CreateGameButton(int index, Vector3 position)
    {
        GameObject gameButton = Instantiate(gameButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        gameButton.transform.SetParent(gameFieldPanelTransform);
        gameButton.transform.localPosition = position;

        gameButton.GetComponent<Image>().color = laserSettings[index].normalColor;
        gameButton.GetComponent<Button>().onClick.AddListener(() => {
            OnGameButtonClick(index);
        });

        laserList.Add(gameButton);
    }*/

    void PlayAudio(int index)
    {
        float length = 0.5f;
        float frequency = 0.001f * ((float)index + 1f);

        AnimationCurve volumeCurve = new AnimationCurve(new Keyframe(0f, 1f, 0f, -1f), new Keyframe(length, 0f, -1f, 0f));
        AnimationCurve frequencyCurve = new AnimationCurve(new Keyframe(0f, frequency, 0f, 0f), new Keyframe(length, frequency, 0f, 0f));

        LeanAudioOptions audioOptions = LeanAudio.options();
        audioOptions.setWaveSine();
        audioOptions.setFrequency(44100);

        AudioClip audioClip = LeanAudio.createAudio(volumeCurve, frequencyCurve, audioOptions);

        LeanAudio.play(audioClip, 0.5f);
    }

    void OnGameButtonClick(int index)
    {

        ClickLaser clickLaser = GetComponent<ClickLaser>();
        if (!clickLaser.laserOn)
        {
            return;
        }

        Bleep(index);

        playerBleeps.Add(index);

        if (bleeps[playerBleeps.Count - 1] != index)
        {
            GameOver();
            return;
        }

        if (bleeps.Count == playerBleeps.Count)
        {
            StartCoroutine(SimonSays());
        }
    }

    void GameOver()
    {
        ClickLaser clickLaser = GetComponent<ClickLaser>();
        gameOver = true;
        clickLaser.laserOn = false;
    }

    IEnumerator SimonSays()
    {
        ClickLaser clickLaser = GetComponent<ClickLaser>();
        clickLaser.laserOn = false;

        rg = new System.Random("hakunamatata".GetHashCode());

        SetBleeps();

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < bleeps.Count; i++)
        {
            Bleep(bleeps[i]);

            yield return new WaitForSeconds(0.6f);
        }

        clickLaser.laserOn = true;

        yield return null;
    }

    void Bleep(int index)
    {
        //LeanTween.value(laserList[index], laserSettings[index].normalColor, laserSettings[index].highlightColor, 0.25f).setOnUpdate((Color color) => {
        //    laserList[index].GetComponent<Image>().color = color;
        //});

        //LeanTween.value(laserList[index], laserSettings[index].highlightColor, laserSettings[index].normalColor, 0.25f)
        //    .setDelay(0.5f)
        //    .setOnUpdate((Color color) => {
        //        laserList[index].GetComponent<Image>().color = color;
        //    });

        PlayAudio(index);
    }

    void SetBleeps()
    {
        bleeps = new List<int>();
        playerBleeps = new List<int>();

        for (int i = 0; i < bleepCount; i++)
        {
            bleeps.Add(rg.Next(0, laserList.Count));
        }

        bleepCount++;
    }
}