namespace Dr_Edit
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button combineButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox durationTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox startTimeTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fileLabel1;
        private System.Windows.Forms.Button trimButton1;
        private System.Windows.Forms.Button openFile1Button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox durationTextBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox startTimeTextBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label fileLabel2;
        private System.Windows.Forms.Button trimButton2;
        private System.Windows.Forms.Button openFile2Button;
        private System.Windows.Forms.ErrorProvider errorProvider1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            statusLabel = new System.Windows.Forms.Label();
            combineButton = new System.Windows.Forms.Button();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            progressLabel = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            durationTextBox1 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            startTimeTextBox1 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            fileLabel1 = new System.Windows.Forms.Label();
            trimButton1 = new System.Windows.Forms.Button();
            openFile1Button = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            durationTextBox2 = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            startTimeTextBox2 = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            fileLabel2 = new System.Windows.Forms.Label();
            trimButton2 = new System.Windows.Forms.Button();
            openFile2Button = new System.Windows.Forms.Button();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(errorProvider1)).BeginInit();
            SuspendLayout();
            // 
            // statusLabel
            // 
            statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            statusLabel.Location = new System.Drawing.Point(12, 420);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(460, 23);
            statusLabel.TabIndex = 11;
            statusLabel.Text = "Ready";
            // 
            // combineButton
            // 
            combineButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            combineButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            combineButton.FlatAppearance.BorderSize = 0;
            combineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            combineButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            combineButton.ForeColor = System.Drawing.Color.White;
            combineButton.Location = new System.Drawing.Point(15, 318);
            combineButton.Name = "combineButton";
            combineButton.Size = new System.Drawing.Size(457, 40);
            combineButton.TabIndex = 10;
            combineButton.Text = "Combine Files";
            combineButton.UseVisualStyleBackColor = false;
            combineButton.Click += new System.EventHandler(CombineButton_Click);
            // 
            // progressBar1
            // 
            progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            progressBar1.Location = new System.Drawing.Point(12, 385);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(460, 23);
            progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 13;
            // 
            // progressLabel
            // 
            progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            progressLabel.AutoSize = true;
            progressLabel.Location = new System.Drawing.Point(12, 365);
            progressLabel.Name = "progressLabel";
            progressLabel.Size = new System.Drawing.Size(0, 16);
            progressLabel.TabIndex = 12;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox1.Controls.Add(durationTextBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(startTimeTextBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(fileLabel1);
            groupBox1.Controls.Add(trimButton1);
            groupBox1.Controls.Add(openFile1Button);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            groupBox1.Location = new System.Drawing.Point(15, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(457, 140);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Audio File 1";
            // 
            // durationTextBox1
            // 
            durationTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            durationTextBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            durationTextBox1.Location = new System.Drawing.Point(245, 95);
            durationTextBox1.Name = "durationTextBox1";
            durationTextBox1.Size = new System.Drawing.Size(85, 27);
            durationTextBox1.TabIndex = 6;
            durationTextBox1.Text = "00:00:00";
            durationTextBox1.Validating += new System.ComponentModel.CancelEventHandler(ValidateTimeInput);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(175, 98);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(70, 20);
            label2.TabIndex = 5;
            label2.Text = "Duration:";
            // 
            // startTimeTextBox1
            // 
            startTimeTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            startTimeTextBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            startTimeTextBox1.Location = new System.Drawing.Point(85, 95);
            startTimeTextBox1.Name = "startTimeTextBox1";
            startTimeTextBox1.Size = new System.Drawing.Size(85, 27);
            startTimeTextBox1.TabIndex = 4;
            startTimeTextBox1.Text = "00:00:00";
            startTimeTextBox1.Validating += new System.ComponentModel.CancelEventHandler(ValidateTimeInput);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 98);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(80, 20);
            label1.TabIndex = 3;
            label1.Text = "Start Time:";
            // 
            // fileLabel1
            // 
            fileLabel1.AutoEllipsis = true;
            fileLabel1.Location = new System.Drawing.Point(10, 65);
            fileLabel1.Name = "fileLabel1";
            fileLabel1.Size = new System.Drawing.Size(441, 23);
            fileLabel1.TabIndex = 2;
            fileLabel1.Text = "No file selected.";
            // 
            // trimButton1
            // 
            trimButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            trimButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            trimButton1.FlatAppearance.BorderSize = 0;
            trimButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            trimButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            trimButton1.Location = new System.Drawing.Point(341, 93);
            trimButton1.Name = "trimButton1";
            trimButton1.Size = new System.Drawing.Size(110, 30);
            trimButton1.TabIndex = 1;
            trimButton1.Text = "Trim";
            trimButton1.UseVisualStyleBackColor = false;
            trimButton1.Click += new System.EventHandler(TrimButton1_Click);
            // 
            // openFile1Button
            // 
            openFile1Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            openFile1Button.FlatAppearance.BorderSize = 0;
            openFile1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            openFile1Button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            openFile1Button.Location = new System.Drawing.Point(10, 25);
            openFile1Button.Name = "openFile1Button";
            openFile1Button.Size = new System.Drawing.Size(130, 30);
            openFile1Button.TabIndex = 0;
            openFile1Button.Text = "Open File 1...";
            openFile1Button.UseVisualStyleBackColor = false;
            openFile1Button.Click += new System.EventHandler(OpenFile1Button_Click);
            // 
            // groupBox2
            // 
            groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox2.Controls.Add(durationTextBox2);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(startTimeTextBox2);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(fileLabel2);
            groupBox2.Controls.Add(trimButton2);
            groupBox2.Controls.Add(openFile2Button);
            groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            groupBox2.Location = new System.Drawing.Point(15, 165);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(457, 140);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Audio File 2";
            // 
            // durationTextBox2
            // 
            durationTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            durationTextBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            durationTextBox2.Location = new System.Drawing.Point(245, 95);
            durationTextBox2.Name = "durationTextBox2";
            durationTextBox2.Size = new System.Drawing.Size(85, 27);
            durationTextBox2.TabIndex = 6;
            durationTextBox2.Text = "00:00:00";
            durationTextBox2.Validating += new System.ComponentModel.CancelEventHandler(ValidateTimeInput);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(175, 98);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(70, 20);
            label3.TabIndex = 5;
            label3.Text = "Duration:";
            // 
            // startTimeTextBox2
            // 
            startTimeTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            startTimeTextBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            startTimeTextBox2.Location = new System.Drawing.Point(85, 95);
            startTimeTextBox2.Name = "startTimeTextBox2";
            startTimeTextBox2.Size = new System.Drawing.Size(85, 27);
            startTimeTextBox2.TabIndex = 4;
            startTimeTextBox2.Text = "00:00:00";
            startTimeTextBox2.Validating += new System.ComponentModel.CancelEventHandler(ValidateTimeInput);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 98);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(80, 20);
            label4.TabIndex = 3;
            label4.Text = "Start Time:";
            // 
            // fileLabel2
            // 
            fileLabel2.AutoEllipsis = true;
            fileLabel2.Location = new System.Drawing.Point(10, 65);
            fileLabel2.Name = "fileLabel2";
            fileLabel2.Size = new System.Drawing.Size(441, 23);
            fileLabel2.TabIndex = 2;
            fileLabel2.Text = "No file selected.";
            // 
            // trimButton2
            // 
            trimButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            trimButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            trimButton2.FlatAppearance.BorderSize = 0;
            trimButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            trimButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            trimButton2.Location = new System.Drawing.Point(341, 93);
            trimButton2.Name = "trimButton2";
            trimButton2.Size = new System.Drawing.Size(110, 30);
            trimButton2.TabIndex = 1;
            trimButton2.Text = "Trim";
            trimButton2.UseVisualStyleBackColor = false;
            trimButton2.Click += new System.EventHandler(TrimButton2_Click);
            // 
            // openFile2Button
            // 
            openFile2Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            openFile2Button.FlatAppearance.BorderSize = 0;
            openFile2Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            openFile2Button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            openFile2Button.Location = new System.Drawing.Point(10, 25);
            openFile2Button.Name = "openFile2Button";
            openFile2Button.Size = new System.Drawing.Size(130, 30);
            openFile2Button.TabIndex = 0;
            openFile2Button.Text = "Open File 2...";
            openFile2Button.UseVisualStyleBackColor = false;
            openFile2Button.Click += new System.EventHandler(OpenFile2Button_Click);
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            ClientSize = new System.Drawing.Size(484, 461);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(progressBar1);
            Controls.Add(progressLabel);
            Controls.Add(combineButton);
            Controls.Add(statusLabel);
            ForeColor = System.Drawing.Color.WhiteSmoke;
            Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            MinimumSize = new System.Drawing.Size(500, 500);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Dr. Edit";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(errorProvider1)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
    }
}