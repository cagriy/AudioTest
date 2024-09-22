using Plugin.Maui.Audio;

namespace AudioTest;

public partial class MainPage : ContentPage
{
    private readonly IAudioPlayer _audioPlayer;
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
    public static async void PlayAudio(string fileName)
    {
        var audioPlayer =
            AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync($"Sounds/{fileName}"),
                new AudioPlayerOptions
                {
#if IOS || MACCATALYST
                    CategoryOptions = AVFoundation.AVAudioSessionCategoryOptions.MixWithOthers
#endif
                });
        audioPlayer.Play();
    }
    
}