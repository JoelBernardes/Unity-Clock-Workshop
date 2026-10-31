using UnityEngine;

public class AnalogClock : MonoBehaviour
{
    public TimeManager tm;

    public RectTransform secondHand;
    public RectTransform minuteHand;
    public RectTransform houreHand;

    const float hourToDegrees = 360 / 12;
    const float minutesToDegrees = 360 / 60;
    const float secondsToDegrees = 360 / 60;


    // Update is called once per frame
    void Update()
    {
        if (tm != null)
        {
            if (tm.IRLClock)
            {
                houreHand.rotation = Quaternion.Euler(0, 0, -tm.GetIRLHour() * hourToDegrees);
                minuteHand.rotation = Quaternion.Euler(0, 0, -tm.GetIRLMinutes() * minutesToDegrees);
                secondHand.rotation = Quaternion.Euler(0, 0, -tm.GetIRLSeconds() * secondsToDegrees);
            }
            else
            {
                houreHand.rotation = Quaternion.Euler(0, 0, -tm.GetHour() * hourToDegrees);
                minuteHand.rotation = Quaternion.Euler(0, 0, -tm.GetMinutes() * minutesToDegrees);
                secondHand.rotation = Quaternion.Euler(0, 0, -tm.GetSeconds() * secondsToDegrees);
            }
        }
    }
}
