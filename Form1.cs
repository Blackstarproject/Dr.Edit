// 🎧 Dr.Edit 🎧 
// 🎙️ Created by: Justin Linwood Ross 🎙️
// 🎙️ Creation Date: 8-22-2025 ** Last Modified: 8-26-2025 🎙️
using System;
using System.ComponentModel;
using System.IO; 
using System.Threading.Tasks; 
using System.Windows.Forms; 
using NAudio.Wave; 

namespace Dr_Edit
{
    /// <summary>
    /// The main window for the Dr. Edit application.
    /// It handles all user interactions and orchestrates audio processing tasks.
    /// </summary>
    public partial class Form1 : Form
    {
        #region Fields & Properties

        // Stores the full path to the first selected audio file.
        private string audioFile1Path;
        // Stores the full path to the second selected audio file.
        private string audioFile2Path;
        // A single instance of our AudioProcessor class to handle all backend audio logic.
        // 'readonly' means it can only be assigned in the constructor.
        private readonly AudioProcessor audioProcessor;

        #endregion

        #region Constructor & Initialization

        /// <summary>
        /// The constructor for the main form. This is the first method called when the application starts.
        /// </summary>
        public Form1()
        {
            // This is a required method for WinForms designer support. It sets up all the controls placed on the form.
            InitializeComponent();
            // Creates a new instance of our audio processing class.
            audioProcessor = new AudioProcessor();
            // Sets the user interface to its default starting state.
            InitializeUIState();
        }

        /// <summary>
        /// Resets the user interface elements to their initial state.
        /// </summary>
        private void InitializeUIState()
        {
            // Set the main status label text.
            statusLabel.Text = "Ready. Please select an audio file to begin.";
            // Clear the labels that show the selected file names.
            fileLabel1.Text = "No file selected.";
            fileLabel2.Text = "No file selected.";
            // Hide the progress bar until an operation starts.
            progressBar1.Visible = false;
            // Clear the label associated with the progress bar.
            progressLabel.Text = "";
            // Ensure the entire form is enabled and responsive to user input.
            Enabled = true;
        }

        #endregion

        #region UI Event Handlers

        /// <summary>
        /// Handles the 'Click' event for the "Open File 1" button.
        /// </summary>
        private void OpenFile1Button_Click(object sender, EventArgs e)
        {
            // Calls the helper method to open a file dialog for the first audio file.
            SelectAudioFile(ref audioFile1Path, fileLabel1, "File 1");
        }

        /// <summary>
        /// Handles the 'Click' event for the "Open File 2" button.
        /// </summary>
        private void OpenFile2Button_Click(object sender, EventArgs e)
        {
            // Calls the helper method to open a file dialog for the second audio file.
            SelectAudioFile(ref audioFile2Path, fileLabel2, "File 2");
        }

        /// <summary>
        /// Handles the 'Click' event for the first "Trim" button.
        /// 'async void' is used for event handlers that need to perform 'await' operations.
        /// </summary>
        private async void TrimButton1_Click(object sender, EventArgs e)
        {
            // Calls the main trimming logic, passing the controls and data for the first file.
            await HandleTrimRequest(audioFile1Path, startTimeTextBox1, durationTextBox1, "File 1");
        }

        /// <summary>
        /// Handles the 'Click' event for the second "Trim" button.
        /// </summary>
        private async void TrimButton2_Click(object sender, EventArgs e)
        {
            // Calls the main trimming logic, passing the controls and data for the second file.
            await HandleTrimRequest(audioFile2Path, startTimeTextBox2, durationTextBox2, "File 2");
        }

        /// <summary>
        /// Handles the 'Click' event for the "Combine Files" button.
        /// </summary>
        private async void CombineButton_Click(object sender, EventArgs e)
        {
            // --- Input Validation ---
            // Check if both audio files have been selected by the user.
            if (string.IsNullOrEmpty(audioFile1Path) || string.IsNullOrEmpty(audioFile2Path))
            {
                // If not, show an error message and stop the operation.
                MessageBox.Show("Please select both audio files before combining.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // The 'return' keyword exits the method early.
            }

            // The 'using' statement ensures the SaveFileDialog is properly disposed of after use.
            using (var saveFileDialog = new SaveFileDialog())
            {
                // Configure the save dialog properties.
                saveFileDialog.Filter = "WAV File|*.wav";
                saveFileDialog.Title = "Save Combined File";
                saveFileDialog.FileName = "combined_output.wav"; // Default suggested file name.

                // Show the dialog to the user and proceed only if they click "OK".
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // --- Overwrite Prevention ---
                    // Check if the user is trying to save the output over one of the original input files.
                    if (saveFileDialog.FileName.Equals(audioFile1Path, StringComparison.OrdinalIgnoreCase) ||
                        saveFileDialog.FileName.Equals(audioFile2Path, StringComparison.OrdinalIgnoreCase))
                    {
                        // If so, show a warning and prevent the operation.
                        MessageBox.Show("The output file cannot be the same as one of the input files.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Disable the UI and show the progress bar.
                    SetBusyState(true, "Combining files...");
                    // Create a progress reporter that updates the progress bar's value.
                    var progress = new Progress<int>(p => progressBar1.Value = p);

                    // The 'try...catch...finally' block handles potential errors during the operation.
                    try
                    {
                        // 'await' the asynchronous combine operation from the AudioProcessor.
                        await audioProcessor.CombineAudioAsync(new[] { audioFile1Path, audioFile2Path }, saveFileDialog.FileName, progress);
                        // If successful, update the status label and show a success message.
                        statusLabel.Text = $"Combine complete. Saved to {Path.GetFileName(saveFileDialog.FileName)}";
                        MessageBox.Show("Files combined successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // If an error occurs, show an informative error message.
                        MessageBox.Show($"An error occurred during combining: {ex.Message}", "Combine Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        statusLabel.Text = "An error occurred during combine.";
                    }
                    finally
                    {
                        // The 'finally' block *always* runs, whether an error occurred or not.
                        // This ensures the UI is always re-enabled after the operation finishes.
                        SetBusyState(false);
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for real-time validation of time format TextBoxes.
        /// This event fires when the user tries to leave the textbox.
        /// </summary>
        private void ValidateTimeInput(object sender, CancelEventArgs e)
        {
            // Check if the control that triggered the event is a TextBox.
            if (sender is TextBox textBox)
            {
                // Use our helper method to check if the text is a valid time format.
                if (!IsTimeInputValid(textBox))
                {
                    // If the input is not valid, set e.Cancel to true.
                    // This prevents the user from changing focus to another control, forcing them to fix the error.
                    e.Cancel = true;
                }
            }
        }

        #endregion      

        #region Core Logic & Helper Methods

        /// <summary>
        /// Opens a file dialog to allow the user to select an audio file.
        /// </summary>
        /// <param name="filePath">A reference to the string variable that will store the selected file's path.</param>
        /// <param name="fileLabel">The label control to update with the file's information.</param>
        /// <param name="fileIdentifier">A friendly name for the file (e.g., "File 1") for use in messages.</param>
        private void SelectAudioFile(ref string filePath, Label fileLabel, string fileIdentifier)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                // Set the file types that appear in the dialog's dropdown.
                openFileDialog.Filter = "Audio Files|*.wav;*.mp3;*.aac;*.wma|All files (*.*)|*.*";
                openFileDialog.Title = $"Select {fileIdentifier}";

                // Show the dialog and proceed only if the user clicks "OK".
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Store the chosen file path.
                    filePath = openFileDialog.FileName;
                    try
                    {
                        // Attempt to open the file with NAudio to verify it's a valid audio file.
                        // The 'using' block ensures the file reader is closed immediately after.
                        using (var reader = new AudioFileReader(filePath))
                        {
                            // If successful, display the file's name, duration, and sample rate in the UI.
                            fileLabel.Text = $"{Path.GetFileName(filePath)} ({reader.TotalTime:mm\\:ss}, {reader.WaveFormat.SampleRate} Hz)";
                            statusLabel.Text = $"{fileIdentifier} loaded successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // If NAudio fails to open the file (e.g., it's corrupted or not a supported format), show an error.
                        MessageBox.Show($"Could not open or read audio file: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Reset the state since the file is invalid.
                        filePath = null;
                        fileLabel.Text = "No file selected.";
                    }
                }
            }
        }

        /// <summary>
        /// A generic handler that contains all the logic for validating and executing a trim operation.
        /// </summary>
        private async Task HandleTrimRequest(string filePath, TextBox startBox, TextBox durationBox, string fileIdentifier)
        {
            // --- Input Validation ---
            // 1. Check if a file has been selected.
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show($"Please select {fileIdentifier} first.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Check if the time formats in the textboxes are valid.
            if (!IsTimeInputValid(startBox) || !IsTimeInputValid(durationBox))
            {
                MessageBox.Show("Please correct the invalid time format(s) before trimming.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convert the textbox text into TimeSpan objects for calculation.
            TimeSpan.TryParse(startBox.Text, out var startTime);
            TimeSpan.TryParse(durationBox.Text, out var trimDuration);

            // 3. Ensure the trim duration is greater than zero.
            if (trimDuration <= TimeSpan.Zero)
            {
                MessageBox.Show("Duration must be a positive time value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- Enhanced time validation ---
            try
            {
                // 4. Open the audio file to check its total length.
                using (var reader = new AudioFileReader(filePath))
                {
                    // Ensure the user's requested start time is actually within the file's duration.
                    if (startTime >= reader.TotalTime)
                    {
                        MessageBox.Show($"Start time cannot be greater than or equal to the file's total duration ({reader.TotalTime:mm\\:ss}).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                // This catches errors if the file can no longer be accessed (e.g., deleted or on a disconnected drive).
                MessageBox.Show($"Could not read audio file to validate trim times: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- Execute Trim ---
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "WAV File|*.wav";
                saveFileDialog.Title = $"Save Trimmed {fileIdentifier}";
                saveFileDialog.FileName = $"{Path.GetFileNameWithoutExtension(filePath)}_trimmed.wav";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // --- Overwrite Prevention ---
                    if (saveFileDialog.FileName.Equals(filePath, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("The output file cannot be the same as the input file.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Set the UI to a busy state.
                    SetBusyState(true, $"Trimming {fileIdentifier}...");
                    var progress = new Progress<int>(p => progressBar1.Value = p);

                    try
                    {
                        // Call the asynchronous trim method in the AudioProcessor.
                        await audioProcessor.TrimAudioAsync(filePath, saveFileDialog.FileName, startTime, trimDuration, progress);
                        statusLabel.Text = $"Trim complete. Saved to {Path.GetFileName(saveFileDialog.FileName)}";
                        MessageBox.Show($"{fileIdentifier} trimmed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Display any errors that occurred during the trimming process.
                        MessageBox.Show($"An error occurred during trimming: {ex.Message}", "Trim Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        statusLabel.Text = "An error occurred during trim.";
                    }
                    finally
                    {
                        // Always re-enable the UI when the operation is complete.
                        SetBusyState(false);
                    }
                }
            }
        }

        /// <summary>
        /// Centralizes the logic for enabling or disabling the UI during a long operation.
        /// </summary>
        /// <param name="isBusy">True to disable the form and show progress, false to re-enable it.</param>
        /// <param name="message">The message to display next to the progress bar.</param>
        private void SetBusyState(bool isBusy, string message = "")
        {
            // 'Enabled = false' makes the entire form non-interactive.
            Enabled = !isBusy;
            // Show or hide the progress bar.
            progressBar1.Visible = isBusy;
            // Update the progress message.
            progressLabel.Text = message;

            // If we are no longer busy, reset the progress bar's value to 0.
            if (!isBusy)
            {
                progressBar1.Value = 0;
            }
        }

        /// <summary>
        /// Checks if the text in a given TextBox represents a valid TimeSpan.
        /// </summary>
        /// <param name="textBox">The TextBox control to validate.</param>
        /// <returns>True if the format is valid, otherwise false.</returns>
        private bool IsTimeInputValid(TextBox textBox)
        {
            // Check if the input is empty or if TimeSpan.TryParse fails.
            if (string.IsNullOrWhiteSpace(textBox.Text) || !TimeSpan.TryParse(textBox.Text, out _))
            {
                // If invalid, use the ErrorProvider to show an icon and tooltip next to the textbox.
                errorProvider1.SetError(textBox, "Invalid time format. Use hh:mm:ss or mm:ss.");
                return false;
            }

            // If the format is valid, clear any existing error message from the ErrorProvider.
            errorProvider1.SetError(textBox, "");
            return true;
        }

        #endregion
    }
}