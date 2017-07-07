using IBM.WatsonDeveloperCloud.SpeechToText.v1;
using IBM.WatsonDeveloperCloud.SpeechToText.v1.Model;
using IBM.WatsonDeveloperCloud.SpeechToText.v1.Util;
using System;
using System.IO;

namespace wdc_stt_example
{
    class Program
    {
        static void Main(string[] args)
        {
            ISpeechToTextService _speechToText = new SpeechToTextService("<username>", "<password>");

            using (FileStream fs = File.OpenRead("test-audio.wav"))
            {
                Console.WriteLine("\nCalling RecognizeBody...");
                var speechEvent = _speechToText.Recognize(fs.GetMediaTypeFromFile(),
                                                          fs);

                Console.WriteLine("speechEvent received...");
                if (speechEvent.Results != null || speechEvent.Results.Count > 0)
                {
                    foreach (SpeechRecognitionResult result in speechEvent.Results)
                    {
                        if (result.Alternatives != null && result.Alternatives.Count > 0)
                        {
                            foreach (SpeechRecognitionAlternative alternative in result.Alternatives)
                            {
                                Console.WriteLine(string.Format("{0}, {1}", alternative.Transcript, alternative.Confidence));
                            }
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
