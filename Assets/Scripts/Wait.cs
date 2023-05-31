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
    // ������� ���������� ������ ���� ������ ���������� ������� (CycleTime)
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
    // ������� ������������� ������ �������
    public void Stop()
    {
        isStop = true;
    }
    // ������� ������������ ������ �������
    public void Play()
    {
        isStop = false;
    }
    // ������� ������������ � �������� �������
    public void Reset()
    {
        CurrentCycleTime = CycleTime;
        isStop = false;
    }
    // ������� ���������� ���������� ����� � �������� ������
    public override string ToString()
    {
        return CurrentCycleTime.ToString();
    }
}
