using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace JBAddons.Speech
{
    public class JBSpeak
    {
        private static SpeechSynthesizer synth = new SpeechSynthesizer();
        /// <summary>
        /// The Gender of the TTS(text-to-speech)
        /// </summary>
        public static VoiceGender Gender { get; set; }
        /// <summary>
        /// The Age of the TTS(text-to-speech)
        /// </summary>
        public static VoiceAge Age { get; set; }

        /// <summary>
        /// Sets or Gets the rate of TTS(text-to-speech)
        /// </summary>
        public static int Rate { get; set; }

        /// <summary>
        /// Set or Gets the volume of the TTS(text-to-speech)
        /// </summary>
        public static int Vol { get; set; }

        /// <summary>
        /// Simple TTS, read a text and speaks it
        /// </summary>
        /// <param name="file">The file that you want to be read</param>
        public static void SpeakFromFile(string file, Encoding encoding)
        {
            string fileContents = File.ReadAllText(file, encoding);
            if (Vol != 0 && Rate != 0 && Age != VoiceAge.NotSet && Gender != VoiceGender.NotSet)
            {
                synth.Volume = Vol;
                synth.Rate = Rate;
                synth.SelectVoiceByHints(Gender, Age);
            }

            synth.SetOutputToDefaultAudioDevice();
            synth.Speak(fileContents);
        }
    }
}
