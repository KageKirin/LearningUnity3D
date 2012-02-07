using UnityEngine;
using System;

struct ClockArmAnimator
{
	float degreeDivider;
	
	public ClockArmAnimator(float degreeDiv)
	{
		degreeDivider = degreeDiv;
	}
	
	float convertToDegrees(float unit)
	{
		return -unit * 360f / degreeDivider;
	}
	
	public Quaternion getRotation(float unit)
	{
		return Quaternion.Euler(0f, 0f, convertToDegrees(unit));
	}
}

public class ClockAnimator : MonoBehaviour
{
	public Transform hoursArm;
	public Transform minutesArm;
	public Transform secondsArm;
	
	ClockArmAnimator hoursArmAnm;
	ClockArmAnimator minutesArmAnm;
	ClockArmAnimator secondsArmAnm;
	
	public bool analog;
	
	void Start()
	{
		hoursArmAnm = new ClockArmAnimator(12f);
		minutesArmAnm = new ClockArmAnimator(60f);
		secondsArmAnm = new ClockArmAnimator(60f);
	}

	// Update is called once per frame
	void Update ()
	{
		DateTime time = DateTime.Now;
		TimeSpan timespan = DateTime.Now.TimeOfDay;
		
		float hours = analog ? (float)timespan.TotalHours : time.Hour;
		float minutes = analog ? (float)timespan.TotalMinutes : time.Minute;
		float seconds = analog ? (float)timespan.TotalSeconds : time.Second;
		
		
		hoursArm.localRotation = hoursArmAnm.getRotation(hours);
		minutesArm.localRotation = minutesArmAnm.getRotation(minutes);
		secondsArm.localRotation = secondsArmAnm.getRotation(seconds);
	}

}
