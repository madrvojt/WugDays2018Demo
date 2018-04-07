using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WugDays2018Demo.Providers
{
    public interface ISpeechToTextProvider
    {
        Task<string> SpeechToTextAsync();

    }
}
