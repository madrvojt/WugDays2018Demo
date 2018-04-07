using Android.App;
using Android.Content;
using Android.Speech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WugDays2018Demo.Android.Providers;
using WugDays2018Demo.Providers;
using Xamarin.Forms;

[assembly: Dependency(typeof(SpeechToTextProvider))]
namespace WugDays2018Demo.Android.Providers
{
    public class SpeechToTextProvider : ISpeechToTextProvider
	{
        public static AutoResetEvent autoEvent = new AutoResetEvent(false);
        public static string SpeechText;
        const int VOICE = 10;

        public async Task<string> SpeechToTextAsync()
        {
            var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
            voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Poslouchám");
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
            voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
            voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
            voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);

            SpeechText = "Ano";
            autoEvent.Reset();
            ((Activity)Forms.Context).StartActivityForResult(voiceIntent, VOICE);
            await Task.Run(() => { autoEvent.WaitOne(new TimeSpan(0, 0, 15)); });
            return SpeechText;
        }
    }
}
