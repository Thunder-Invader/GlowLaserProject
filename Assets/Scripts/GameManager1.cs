using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class GameManager1 : MonoBehaviour
{


    public List<ButtonSetting> laserSettings;

    List<int> laserList;
    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
    public GameObject laser4;
    public GameObject laser5;
    public GameObject laser6;
    public GameObject laser7;
    public GameObject laser8;

    int onInList = 0;
    Random rand = new Random();
    bool playingBack = false;

    //void Start()
    //{

    //    laserList = new List<int>();
    //    laserList.Add(laser1);
    //    laserList.Add(laser2);
    //    laserList.Add(laser3);
    //    laserList.Add(laser4);
    //    laserList.Add(laser5);
    //    laserList.Add(laser6);
    //    laserList.Add(laser7);
    //    laserList.Add(laser8);

    //    laserList.Add(rand.Next(0, 6));
    //    new Thread(playback).Start();
    //}

    //void testCorrect(int laser)
    //{
    //    if (playingBack)
    //        return;
    //    if (laserList[onInList] == laser)
    //    {
    //        onInList++;
    //    }
    //    else
    //    {
           
    //        onInList = 0;
    //        laserList = new List<int>();
    //        new Thread(playback).Start();
    //    }
    //    if (onInList >= laserList.Count)
    //    {
    //        laserList.Add(rand.Next(0, 8));
    //        onInList = 0;
    //        new Thread(playback).Start();
    //    }
    //}

    //void playback()
    //{
    //    playingBack = true;
    //    foreach (int laser in laserList)
    //    {
    //        switch (laser)
    //        {
    //            case 0:
    //                Red.Backlaser = laser.Red;
    //                Thread.Sleep(200);
    //                Red.Backlaser = laser.Transparent;
    //                break;

    //            case 1:
    //                Blue.Backlaser = laser.Blue;
    //                Thread.Sleep(200);
    //                Blue.Backlaser = laser.Transparent;
    //                break;

    //            case 2:
    //                Yellow.Backlaser = laser.Yellow;
    //                Thread.Sleep(200);
    //                Yellow.Backlaser = laser.Transparent;
    //                break;

    //            case 3:
    //                Green.Backlaser = laser.Green;
    //                Thread.Sleep(200);
    //                Green.Backlaser = laser.Transparent;
    //                break;

    //            case 4:
    //                Purple.Backlaser = laser.Purple;
    //                Thread.Sleep(200);
    //                Purple.Backlaser = laser.Transparent;
    //                break;

    //            case 5:
    //                Pink.Backlaser = laser.Pink;
    //                Thread.Sleep(200);
    //                Pink.Backlaser = laser.Transparent;
    //                break;
    //        }
    //        Thread.Sleep(200);
    //    }
    //    playingBack = false;
    //}

}