using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MobilePhone
{
    public delegate void RingEventHandler();
    public event RingEventHandler OnRing;

    public void ReceiveCall()
    {
        OnRing();
    }
}
class RingtonePlayer
{
    public void ringtone()
    {
        Console.WriteLine("Playing ringtone...");
    }
}
class ScreenDisplay
{
    public void display()
    {
        Console.WriteLine("Displaying caller information...");
    }
}

class VibrationMotor
{
    public void Vibrate()
    {
        Console.WriteLine("Phone is vibrating...");
    }
}

internal class Prgm3
{
  public  static void phn()
    {
        MobilePhone phone = new MobilePhone();

        RingtonePlayer ringtone = new RingtonePlayer();
        ScreenDisplay screen = new ScreenDisplay();
        VibrationMotor vibration = new VibrationMotor();

        phone.OnRing += ringtone.ringtone;
        phone.OnRing += screen.display;
        phone.OnRing += vibration.Vibrate;
        phone.ReceiveCall();
    }

    
}