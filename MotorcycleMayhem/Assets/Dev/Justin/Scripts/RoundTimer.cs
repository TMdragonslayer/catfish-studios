using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class RoundTimer : MonoBehaviour
{
    [Serializable] public class TimerEndsEvent : UnityEvent { }
    [SerializeField] private TimerEndsEvent onTimerEnd = new TimerEndsEvent();

    [SerializeField] private float timerLength;
    private float timer;
    public int displayTime;
    private bool timerGoing = false;

    public void StartTimer()
    {
        timer = timerLength;
        timerGoing = true;
    }

    public void StopTimer()
    {
        timer = 0;
        timerGoing = false;
    }
    
    private void Update()
    {
        
        if (timerGoing)
        {
            if (timer <= 0)
            {
                timerGoing = false;
                TimerEnd();
            }
            timer -= Time.deltaTime;
            displayTime = Mathf.RoundToInt(timer - 0.5f);
        }
    }

    private void TimerEnd()
    {
        onTimerEnd.Invoke();
    }
}
