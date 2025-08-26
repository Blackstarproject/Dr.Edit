// 🎧 Dr.Edit 🎧 
// 🎙️ Created by: Justin Linwood Ross 🎙️
// 🎙️ Creation Date: 8-22-2025 ** Last Modified: 8-26-2025 🎙️
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dr_Edit
{
    /// <summary>
    /// A class dedicated to handling all backend audio processing tasks.
    /// This separation of concerns keeps the UI code (Form1.cs) clean and focused on user interaction,
    /// while this class manages the complex audio manipulation logic.
    /// </summary>
    public class AudioProcessor
    {
        /// <summary>
        /// Asynchronously trims an audio file to a specified duration, starting from a given time.
        /// </summary>
        /// <param name="inPath">The full path to the input audio file to be trimmed.</param>
        /// <param name="outPath">The full path where the new, trimmed audio file will be saved.</param>
        /// <param name="startTime">A TimeSpan object representing the point in the audio to start trimming from.</param>
        /// <param name="duration">A TimeSpan object representing how long the trimmed audio segment should be.</param>
        /// <param name="progress">An interface for reporting progress back to the UI thread.</param>
        /// <exception cref="ArgumentException">Thrown if the trim range (startTime + duration) is outside the bounds of the original audio file.</exception>
        public async Task TrimAudioAsync(string inPath, string outPath, TimeSpan startTime, TimeSpan duration, IProgress<int> progress)
        {
            // Task.Run offloads the audio processing work to a background thread.
            // This is crucial for keeping the user interface (UI) responsive and preventing it from freezing during the operation.
            // 'await' pauses the execution of this method until the background task is complete.
            await Task.Run(() =>
            {
                // The 'using' statement ensures that the AudioFileReader is properly closed and disposed of,
                // releasing its lock on the input file, even if an error occurs.
                using (var reader = new AudioFileReader(inPath))
                {
                    // *** Validation ***
                    // Before proceeding, check if the requested trim operation is valid.
                    if (startTime + duration > reader.TotalTime)
                    {
                        // If the end point of the trim is beyond the total length of the file, it's an invalid request.
                        // We throw an exception that will be caught by the UI layer and shown to the user.
                        throw new ArgumentException("The specified start time and duration exceed the total length of the audio file.");
                    }

                    // *** Trimming Logic ***
                    // The OffsetSampleProvider is a powerful NAudio tool that acts as a wrapper around another audio source.
                    // It allows you to skip a certain amount of audio and then take a specific duration.
                    var trimmedProvider = new OffsetSampleProvider(reader)
                    {
                        // SkipOver tells the provider to ignore all audio data up to the specified startTime.
                        SkipOver = startTime,
                        // Take tells the provider to read audio data for the specified duration and then stop.
                        Take = duration
                    };

                    // *** Writing the Output File ***
                    // WaveFileWriter.CreateWaveFile16 is a helper method that takes any sample provider
                    // and writes its output to a standard 16-bit PCM WAV file. This format is widely compatible.
                    WaveFileWriter.CreateWaveFile16(outPath, trimmedProvider);

                    // Report that the process is 100% complete. This will update the progress bar in the UI.
                    progress.Report(100);
                }
            });
        }

        /// <summary>
        /// Asynchronously mixes multiple audio files together so they play simultaneously.
        /// </summary>
        /// <param name="inFiles">An array of strings, where each string is a full path to an input audio file.</param>
        /// <param name="outFile">The full path where the new, mixed audio file will be saved.</param>
        /// <param name="progress">An interface for reporting progress back to the UI thread.</param>
        public async Task CombineAudioAsync(string[] inFiles, string outFile, IProgress<int> progress)
        {
            await Task.Run(() =>
            {
                // This list will hold all our file readers. We need to keep them open until writing is finished,
                // so we can't use a simple 'using' block inside the loop.
                var readers = new List<AudioFileReader>();
                // The 'try...finally' block is essential here. It ensures that no matter what happens (even if an error occurs),
                // the 'finally' block will run and dispose of all our file readers, releasing their file locks.
                try
                {
                    // 1. Create Readers and Determine the Output Format
                    // We need all audio streams to have the same format (sample rate, channels) to be mixed.
                    // A simple strategy is to use the format of the first file as the target for all others.
                    var firstReader = new AudioFileReader(inFiles[0]);
                    readers.Add(firstReader); // Add the first reader to our list for later cleanup.
                    var outputFormat = firstReader.WaveFormat;

                    // This list will hold the final 'sample providers' that will be fed into the mixer.
                    // A sample provider is an object that provides audio samples in a standard format.
                    var sampleProviders = new List<ISampleProvider>
                    {
                        // Add the first file's sample provider to the list.
                        firstReader.ToSampleProvider()
                    };

                    // 2. Open Other Files and Resample if Necessary 
                    // Loop through the rest of the input files (starting from the second one, index 1).
                    for (int i = 1; i < inFiles.Length; i++)
                    {
                        var reader = new AudioFileReader(inFiles[i]);
                        readers.Add(reader); // Add to list for later disposal.
                        ISampleProvider provider = reader.ToSampleProvider();

                        // *** Resampling Logic ***
                        // Check if the current file's format matches our target output format.
                        if (!provider.WaveFormat.Equals(outputFormat))
                        {
                            // If they don't match, we must resample the audio.
                            // WdlResamplingSampleProvider is a high-quality resampler that converts the audio
                            // from its original sample rate to the target sample rate on the fly.
                            provider = new WdlResamplingSampleProvider(provider, outputFormat.SampleRate);
                        }
                        // Add the (potentially resampled) provider to our list.
                        sampleProviders.Add(provider);
                    }

                    // 3. Create the Mixer and Write to the Output File 
                    // The MixingSampleProvider is the core of this operation.
                    // It takes a collection of sample providers and, when read from, it reads from all of them
                    // simultaneously and sums their samples together to create a mixed audio stream.
                    var mixer = new MixingSampleProvider(sampleProviders);

                    // Write the output of the mixer to a 16-bit WAV file.
                    WaveFileWriter.CreateWaveFile16(outFile, mixer);

                    // Report completion to the UI.
                    progress.Report(100);
                }
                finally
                {
                    // 4. IMPORTANT: Dispose All File Readers
                    // This block is guaranteed to execute. We loop through every reader we opened
                    // and call Dispose() on it. This is critical for releasing the locks on the input files.
                    foreach (var reader in readers)
                    {
                        reader.Dispose();
                    }
                }
            });
        }
    }
}