using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait
{
    public float CycleTime, CurrentCycleTime;
    public bool isStop;


    public Wait(float cycletime)
    {
        CycleTime = cycletime;
        CurrentCycleTime = CycleTime;
        isStop = false;
    }
    // Функция возвращает истину если прошло достаточно времени (CycleTime)
    public bool Cycle()
    {
        if (isStop) return false;
        CurrentCycleTime -= Time.deltaTime;
        if (CurrentCycleTime <= 0)
        {
            CurrentCycleTime = CycleTime;
            return true;
        }
        return false;
    }
    // Функция останавливает отсчёт времени
    public void Stop()
    {
        isStop = true;
    }
    // Функция возобновляет отсчёт времени
    public void Play()
    {
        isStop = false;
    }
    // Функция сбрасывается и начинает сначала
    public void Reset()
    {
        CurrentCycleTime = CycleTime;
        isStop = false;
    }
    // Функция возвращает оставшееся время в качестве строки
    public override string ToString()
    {
        return CurrentCycleTime.ToString();
    }
}
