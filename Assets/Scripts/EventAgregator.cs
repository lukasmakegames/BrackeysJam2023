using UnityEngine.Events;

public class EventAgregator
{
    public static UnityEvent<float> editVolumeMusic = new UnityEvent<float>();
    public static UnityEvent<float> editVolumeSound = new UnityEvent<float>();
}
