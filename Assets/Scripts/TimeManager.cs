using UnityEngine;
using TMPro;
public class TimeManager : MonoBehaviour
{
    public const int hoursInDay = 24;
    public const int minutesInHour = 60;
    public const int secondsInMinute = 60;

    public float dayDuration = 30f;

    public TMP_Text buttonText;

    float totalTime = 0;
    float currentTime = 0;

    bool isIrlTime = false;

    public bool IRLClock => isIrlTime;

    // Update is called once per frame
    void Update()
    {
        if (dayDuration > 0)
        {
            totalTime += Time.deltaTime;
            currentTime = totalTime % dayDuration;
        }
        else
        {
            Debug.LogWarning("Must have a positive value for dayDuration in TimeManager script");
        }
    }

    public float GetHour()
    {
        return currentTime * hoursInDay / dayDuration;
    }

    public float GetMinutes()
    {
        return (currentTime * hoursInDay * minutesInHour / dayDuration) % minutesInHour;
    }

    public float GetSeconds()
    {
        return (currentTime * hoursInDay * minutesInHour * secondsInMinute / dayDuration) % secondsInMinute;
    }

    public string Clock24Hour()
    {
        return Mathf.FloorToInt(GetHour()).ToString("00") + 
            ":" + Mathf.FloorToInt(GetMinutes()).ToString("00") + 
            ":" + Mathf.FloorToInt(GetSeconds()).ToString("00");
    }

    public string Clock12Hour()
    {
        int hour = Mathf.FloorToInt(GetHour());
        string abbreviation = "AM";

        if (hour >= 12)
        {
            abbreviation = "PM";
            hour -= 12;
        }

        if (hour == 0)
        {
            hour = 12;
        }

        return hour.ToString("00") + 
            ":" + Mathf.FloorToInt(GetMinutes()).ToString("00") +
            ":" + Mathf.FloorToInt(GetSeconds()).ToString("00") +
            " " + abbreviation;
    }

    public int GetIRLHour()
    {
        return System.DateTime.Now.Hour;
    }

    public int GetIRLMinutes()
    {
        return System.DateTime.Now.Minute;
    }

    public int GetIRLSeconds()
    {
        return System.DateTime.Now.Second;
    }

    public string IRLClock24Hour()
    {
        return Mathf.FloorToInt(GetIRLHour()).ToString("00") +
            ":" + Mathf.FloorToInt(GetIRLMinutes()).ToString("00") +
            ":" + Mathf.FloorToInt(GetIRLSeconds()).ToString("00");
    }

    public string IRLClock12Hour()
    {
        int hour = Mathf.FloorToInt(GetIRLHour());
        string abbreviation = "AM";

        if (hour >= 12)
        {
            abbreviation = "PM";
            hour -= 12;
        }

        if (hour == 0)
        {
            hour = 12;
        }

        return hour.ToString("00") +
            ":" + Mathf.FloorToInt(GetIRLMinutes()).ToString("00") +
            ":" + Mathf.FloorToInt(GetIRLSeconds()).ToString("00") +
            " " + abbreviation;
    }

    public void setClockType()
    {
        if (isIrlTime)
        {
            isIrlTime = false;
            buttonText.text = "Use local time?";
        }
        else
        {
            isIrlTime = true;
            buttonText.text = "Use in-game time?";
        }
    }
}
