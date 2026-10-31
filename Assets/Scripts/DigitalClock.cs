using TMPro;
using UnityEngine;

public class DigitalClock : MonoBehaviour
{
    public TimeManager tm;
    public bool is24HourClock = true;

    TMP_Text display;
    void Start()
    {
        display = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tm != null)
        {
            if (tm.IRLClock)
            {
                if (is24HourClock)
                {
                    display.text = tm.IRLClock24Hour();
                }
                else
                {
                    display.text = tm.IRLClock12Hour();
                }
            }
            else
            {
                if (is24HourClock)
                {
                    display.text = tm.Clock24Hour();
                }
                else
                {
                    display.text = tm.Clock12Hour();
                }
            }
        }
    }
}
