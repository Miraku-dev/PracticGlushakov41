Console.WriteLine("Введите уровень громкости (0-100):");
int volume = int.Parse(Console.ReadLine() ?? "0");

VolumeControl volumeControl = new VolumeControl();
Display display = new Display();
SpeakerSystem speakerSystem = new SpeakerSystem();

volumeControl.VolumeChanged += display.OnVolumeChanged;
volumeControl.VolumeChanged += speakerSystem.OnVolumeChanged;

volumeControl.SetVolume(volume);

class VolumeControl
{
    public delegate void VolumeChangedHandler(int volume);
    public event VolumeChangedHandler VolumeChanged;

    public void SetVolume(int volume)
    {
        VolumeChanged?.Invoke(volume);
    }
}

class Display
{
    public void OnVolumeChanged(int volume)
    {
        Console.WriteLine($"Текущий уровень громкости: {volume}");
    }
}

class SpeakerSystem
{
    public void OnVolumeChanged(int volume)
    {
        Console.WriteLine($"Громкость изменена на {volume}%");
    }
}