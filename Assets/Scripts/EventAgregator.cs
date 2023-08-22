using UnityEngine.Events;

public class EventAgregator
{
    public static UnityEvent<float> editVolumeMusic = new UnityEvent<float>();
    public static UnityEvent<float> editVolumeSound = new UnityEvent<float>();
    public static UnityEvent updateUI = new UnityEvent();
    public static UnityEvent<float> playerLostHP = new UnityEvent<float>();
    public static UnityEvent playerDoShot = new UnityEvent();
    public static UnityEvent updateBullet = new UnityEvent();
    public static UnityEvent<int> updateScore = new UnityEvent<int>();
}
