/**
 * Copyright 2017 d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections;
using System.Globalization;
using System.Speech.Recognition;
using Link.CS.Example.VoiceRecognition.Properties;

namespace VoiceRecognition
{
    public class SpeechManager
    {
        public event EventHandler<SpeechRecognizedEventArgs> CommandRecognized;
        private readonly SpeechRecognitionEngine speechRecognitionEngine;

        public SpeechManager()
        {
            speechRecognitionEngine = new SpeechRecognitionEngine();

            speechRecognitionEngine.LoadGrammar(GetGrammar());
            speechRecognitionEngine.SpeechRecognized += RaiseCommandRecognizedEvent;
            speechRecognitionEngine.SetInputToDefaultAudioDevice();
            speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private Grammar GetGrammar()
        {
            var choices = new Choices();
            var resourceSet = Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, createIfNotExists:true, tryParents:true);
            foreach (DictionaryEntry resource in resourceSet)
            {
                var resourceValue = resource.Value as string;
                choices.Add(resourceValue);
            }

            var grammarBuilder = new GrammarBuilder(choices);
            return new Grammar(grammarBuilder);
        }

        private void RaiseCommandRecognizedEvent(object sender, SpeechRecognizedEventArgs args)
        {
            if (null == CommandRecognized)
            {
                return;
            }

            CommandRecognized.Invoke(sender, args);
        }
    }

}
