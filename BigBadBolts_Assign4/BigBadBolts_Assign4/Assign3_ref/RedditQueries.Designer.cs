namespace BigBadBolts_Assign3
{
    partial class RedditQueries
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.subbredditAwardComboBox = new System.Windows.Forms.ComboBox();
            this.silverCheckBox = new System.Windows.Forms.CheckBox();
            this.platinumCheckBox = new System.Windows.Forms.CheckBox();
            this.goldCheckBox = new System.Windows.Forms.CheckBox();
            this.subAwardBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.userSubbredditBtn = new System.Windows.Forms.Button();
            this.lessThanRadioButton = new System.Windows.Forms.RadioButton();
            this.greaterThanRadioButton = new System.Windows.Forms.RadioButton();
            this.threshholdGroupbox = new System.Windows.Forms.GroupBox();
            this.thresholdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.thresholdBtn = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateBtn = new System.Windows.Forms.Button();
            this.subGroupBox = new System.Windows.Forms.GroupBox();
            this.avgRadio = new System.Windows.Forms.RadioButton();
            this.highRadio = new System.Windows.Forms.RadioButton();
            this.lowRadio = new System.Windows.Forms.RadioButton();
            this.postSubBtn = new System.Windows.Forms.Button();
            this.userGroupBox = new System.Windows.Forms.GroupBox();
            this.avgRadioU = new System.Windows.Forms.RadioButton();
            this.highRadioU = new System.Windows.Forms.RadioButton();
            this.lowRadioU = new System.Windows.Forms.RadioButton();
            this.postUserBtn = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.threshholdGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumericUpDown)).BeginInit();
            this.subGroupBox.SuspendLayout();
            this.userGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputBox
            // 
            this.OutputBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.OutputBox.Font = new System.Drawing.Font("Source Code Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputBox.Location = new System.Drawing.Point(557, 54);
            this.OutputBox.Margin = new System.Windows.Forms.Padding(4);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(883, 706);
            this.OutputBox.TabIndex = 1;
            this.OutputBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Posts from a specific date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(16, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Posts per Subreddit:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(16, 246);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Posts per User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(16, 353);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(356, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Total awards within a Subreddit:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(16, 500);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(388, 29);
            this.label5.TabIndex = 6;
            this.label5.Text = "List of Subreddits posted by a user:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(16, 614);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(415, 29);
            this.label6.TabIndex = 7;
            this.label6.Text = "Points threshold for Posts/Comments:";
            // 
            // subbredditAwardComboBox
            // 
            this.subbredditAwardComboBox.FormattingEnabled = true;
            this.subbredditAwardComboBox.Location = new System.Drawing.Point(135, 442);
            this.subbredditAwardComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.subbredditAwardComboBox.Name = "subbredditAwardComboBox";
            this.subbredditAwardComboBox.Size = new System.Drawing.Size(237, 24);
            this.subbredditAwardComboBox.TabIndex = 8;
            // 
            // silverCheckBox
            // 
            this.silverCheckBox.AutoSize = true;
            this.silverCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.silverCheckBox.Location = new System.Drawing.Point(21, 414);
            this.silverCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.silverCheckBox.Name = "silverCheckBox";
            this.silverCheckBox.Size = new System.Drawing.Size(65, 21);
            this.silverCheckBox.TabIndex = 9;
            this.silverCheckBox.Text = "Silver";
            this.silverCheckBox.UseVisualStyleBackColor = true;
            // 
            // platinumCheckBox
            // 
            this.platinumCheckBox.AutoSize = true;
            this.platinumCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.platinumCheckBox.Location = new System.Drawing.Point(21, 470);
            this.platinumCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.platinumCheckBox.Name = "platinumCheckBox";
            this.platinumCheckBox.Size = new System.Drawing.Size(84, 21);
            this.platinumCheckBox.TabIndex = 10;
            this.platinumCheckBox.Text = "Platinum";
            this.platinumCheckBox.UseVisualStyleBackColor = true;
            // 
            // goldCheckBox
            // 
            this.goldCheckBox.AutoSize = true;
            this.goldCheckBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.goldCheckBox.Location = new System.Drawing.Point(21, 442);
            this.goldCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.goldCheckBox.Name = "goldCheckBox";
            this.goldCheckBox.Size = new System.Drawing.Size(60, 21);
            this.goldCheckBox.TabIndex = 11;
            this.goldCheckBox.Text = "Gold";
            this.goldCheckBox.UseVisualStyleBackColor = true;
            // 
            // subAwardBtn
            // 
            this.subAwardBtn.Location = new System.Drawing.Point(422, 409);
            this.subAwardBtn.Margin = new System.Windows.Forms.Padding(4);
            this.subAwardBtn.Name = "subAwardBtn";
            this.subAwardBtn.Size = new System.Drawing.Size(100, 28);
            this.subAwardBtn.TabIndex = 12;
            this.subAwardBtn.Text = "Query";
            this.subAwardBtn.UseVisualStyleBackColor = true;
            this.subAwardBtn.Click += new System.EventHandler(this.SubAwardBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(16, 572);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "User:";
            // 
            // userComboBox
            // 
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Location = new System.Drawing.Point(72, 571);
            this.userComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(192, 24);
            this.userComboBox.TabIndex = 14;
            // 
            // userSubbredditBtn
            // 
            this.userSubbredditBtn.Location = new System.Drawing.Point(422, 562);
            this.userSubbredditBtn.Margin = new System.Windows.Forms.Padding(4);
            this.userSubbredditBtn.Name = "userSubbredditBtn";
            this.userSubbredditBtn.Size = new System.Drawing.Size(100, 28);
            this.userSubbredditBtn.TabIndex = 15;
            this.userSubbredditBtn.Text = "Query";
            this.userSubbredditBtn.UseVisualStyleBackColor = true;
            this.userSubbredditBtn.Click += new System.EventHandler(this.UserSubbredditBtn_Click);
            // 
            // lessThanRadioButton
            // 
            this.lessThanRadioButton.AutoSize = true;
            this.lessThanRadioButton.Checked = true;
            this.lessThanRadioButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lessThanRadioButton.Location = new System.Drawing.Point(4, 14);
            this.lessThanRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.lessThanRadioButton.Name = "lessThanRadioButton";
            this.lessThanRadioButton.Size = new System.Drawing.Size(195, 21);
            this.lessThanRadioButton.TabIndex = 16;
            this.lessThanRadioButton.TabStop = true;
            this.lessThanRadioButton.Text = "Less than or equal to zero";
            this.lessThanRadioButton.UseVisualStyleBackColor = true;
            // 
            // greaterThanRadioButton
            // 
            this.greaterThanRadioButton.AutoSize = true;
            this.greaterThanRadioButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.greaterThanRadioButton.Location = new System.Drawing.Point(4, 42);
            this.greaterThanRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.greaterThanRadioButton.Name = "greaterThanRadioButton";
            this.greaterThanRadioButton.Size = new System.Drawing.Size(214, 21);
            this.greaterThanRadioButton.TabIndex = 17;
            this.greaterThanRadioButton.Text = "Greater than or equal to zero";
            this.greaterThanRadioButton.UseVisualStyleBackColor = true;
            // 
            // threshholdGroupbox
            // 
            this.threshholdGroupbox.Controls.Add(this.greaterThanRadioButton);
            this.threshholdGroupbox.Controls.Add(this.lessThanRadioButton);
            this.threshholdGroupbox.Location = new System.Drawing.Point(5, 660);
            this.threshholdGroupbox.Margin = new System.Windows.Forms.Padding(4);
            this.threshholdGroupbox.Name = "threshholdGroupbox";
            this.threshholdGroupbox.Padding = new System.Windows.Forms.Padding(4);
            this.threshholdGroupbox.Size = new System.Drawing.Size(223, 75);
            this.threshholdGroupbox.TabIndex = 18;
            this.threshholdGroupbox.TabStop = false;
            // 
            // thresholdNumericUpDown
            // 
            this.thresholdNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.thresholdNumericUpDown.Location = new System.Drawing.Point(236, 686);
            this.thresholdNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.thresholdNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.thresholdNumericUpDown.Name = "thresholdNumericUpDown";
            this.thresholdNumericUpDown.Size = new System.Drawing.Size(81, 22);
            this.thresholdNumericUpDown.TabIndex = 19;
            this.thresholdNumericUpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // thresholdBtn
            // 
            this.thresholdBtn.Location = new System.Drawing.Point(422, 680);
            this.thresholdBtn.Margin = new System.Windows.Forms.Padding(4);
            this.thresholdBtn.Name = "thresholdBtn";
            this.thresholdBtn.Size = new System.Drawing.Size(100, 28);
            this.thresholdBtn.TabIndex = 20;
            this.thresholdBtn.Text = "Query";
            this.thresholdBtn.UseVisualStyleBackColor = true;
            this.thresholdBtn.Click += new System.EventHandler(this.ThresholdBtn_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(21, 85);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(256, 22);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // dateBtn
            // 
            this.dateBtn.Location = new System.Drawing.Point(422, 84);
            this.dateBtn.Margin = new System.Windows.Forms.Padding(4);
            this.dateBtn.Name = "dateBtn";
            this.dateBtn.Size = new System.Drawing.Size(100, 28);
            this.dateBtn.TabIndex = 22;
            this.dateBtn.Text = "Query";
            this.dateBtn.UseVisualStyleBackColor = true;
            this.dateBtn.Click += new System.EventHandler(this.DateBtn_Click);
            // 
            // subGroupBox
            // 
            this.subGroupBox.Controls.Add(this.avgRadio);
            this.subGroupBox.Controls.Add(this.highRadio);
            this.subGroupBox.Controls.Add(this.lowRadio);
            this.subGroupBox.Location = new System.Drawing.Point(19, 178);
            this.subGroupBox.Name = "subGroupBox";
            this.subGroupBox.Size = new System.Drawing.Size(258, 65);
            this.subGroupBox.TabIndex = 23;
            this.subGroupBox.TabStop = false;
            // 
            // avgRadio
            // 
            this.avgRadio.AutoSize = true;
            this.avgRadio.ForeColor = System.Drawing.Color.White;
            this.avgRadio.Location = new System.Drawing.Point(175, 21);
            this.avgRadio.Name = "avgRadio";
            this.avgRadio.Size = new System.Drawing.Size(82, 21);
            this.avgRadio.TabIndex = 2;
            this.avgRadio.TabStop = true;
            this.avgRadio.Text = "Average";
            this.avgRadio.UseVisualStyleBackColor = true;
            // 
            // highRadio
            // 
            this.highRadio.AutoSize = true;
            this.highRadio.ForeColor = System.Drawing.Color.White;
            this.highRadio.Location = new System.Drawing.Point(86, 22);
            this.highRadio.Name = "highRadio";
            this.highRadio.Size = new System.Drawing.Size(77, 21);
            this.highRadio.TabIndex = 1;
            this.highRadio.TabStop = true;
            this.highRadio.Text = "Highest";
            this.highRadio.UseVisualStyleBackColor = true;
            // 
            // lowRadio
            // 
            this.lowRadio.AutoSize = true;
            this.lowRadio.ForeColor = System.Drawing.Color.White;
            this.lowRadio.Location = new System.Drawing.Point(7, 22);
            this.lowRadio.Name = "lowRadio";
            this.lowRadio.Size = new System.Drawing.Size(73, 21);
            this.lowRadio.TabIndex = 0;
            this.lowRadio.TabStop = true;
            this.lowRadio.Text = "Lowest";
            this.lowRadio.UseVisualStyleBackColor = true;
            // 
            // postSubBtn
            // 
            this.postSubBtn.Location = new System.Drawing.Point(422, 195);
            this.postSubBtn.Margin = new System.Windows.Forms.Padding(4);
            this.postSubBtn.Name = "postSubBtn";
            this.postSubBtn.Size = new System.Drawing.Size(100, 28);
            this.postSubBtn.TabIndex = 24;
            this.postSubBtn.Text = "Query";
            this.postSubBtn.UseVisualStyleBackColor = true;
            this.postSubBtn.Click += new System.EventHandler(this.PostSubBtn_Click);
            // 
            // userGroupBox
            // 
            this.userGroupBox.Controls.Add(this.avgRadioU);
            this.userGroupBox.Controls.Add(this.highRadioU);
            this.userGroupBox.Controls.Add(this.lowRadioU);
            this.userGroupBox.Location = new System.Drawing.Point(19, 278);
            this.userGroupBox.Name = "userGroupBox";
            this.userGroupBox.Size = new System.Drawing.Size(258, 65);
            this.userGroupBox.TabIndex = 25;
            this.userGroupBox.TabStop = false;
            // 
            // avgRadioU
            // 
            this.avgRadioU.AutoSize = true;
            this.avgRadioU.ForeColor = System.Drawing.Color.White;
            this.avgRadioU.Location = new System.Drawing.Point(175, 21);
            this.avgRadioU.Name = "avgRadioU";
            this.avgRadioU.Size = new System.Drawing.Size(82, 21);
            this.avgRadioU.TabIndex = 2;
            this.avgRadioU.TabStop = true;
            this.avgRadioU.Text = "Average";
            this.avgRadioU.UseVisualStyleBackColor = true;
            // 
            // highRadioU
            // 
            this.highRadioU.AutoSize = true;
            this.highRadioU.ForeColor = System.Drawing.Color.White;
            this.highRadioU.Location = new System.Drawing.Point(86, 22);
            this.highRadioU.Name = "highRadioU";
            this.highRadioU.Size = new System.Drawing.Size(77, 21);
            this.highRadioU.TabIndex = 1;
            this.highRadioU.TabStop = true;
            this.highRadioU.Text = "Highest";
            this.highRadioU.UseVisualStyleBackColor = true;
            // 
            // lowRadioU
            // 
            this.lowRadioU.AutoSize = true;
            this.lowRadioU.ForeColor = System.Drawing.Color.White;
            this.lowRadioU.Location = new System.Drawing.Point(7, 22);
            this.lowRadioU.Name = "lowRadioU";
            this.lowRadioU.Size = new System.Drawing.Size(73, 21);
            this.lowRadioU.TabIndex = 0;
            this.lowRadioU.TabStop = true;
            this.lowRadioU.Text = "Lowest";
            this.lowRadioU.UseVisualStyleBackColor = true;
            // 
            // postUserBtn
            // 
            this.postUserBtn.Location = new System.Drawing.Point(422, 292);
            this.postUserBtn.Margin = new System.Windows.Forms.Padding(4);
            this.postUserBtn.Name = "postUserBtn";
            this.postUserBtn.Size = new System.Drawing.Size(100, 28);
            this.postUserBtn.TabIndex = 26;
            this.postUserBtn.Text = "Query";
            this.postUserBtn.UseVisualStyleBackColor = true;
            this.postUserBtn.Click += new System.EventHandler(this.PostUserBtn_Click);
            // 
            // Output
            // 
            this.Output.AutoSize = true;
            this.Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Output.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Output.Location = new System.Drawing.Point(557, 13);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(84, 29);
            this.Output.TabIndex = 27;
            this.Output.Text = "Output";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(132, 409);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 18);
            this.label8.TabIndex = 28;
            this.label8.Text = "Subreddit:";
            // 
            // RedditQueries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1475, 777);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.postUserBtn);
            this.Controls.Add(this.userGroupBox);
            this.Controls.Add(this.postSubBtn);
            this.Controls.Add(this.subGroupBox);
            this.Controls.Add(this.dateBtn);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.thresholdBtn);
            this.Controls.Add(this.thresholdNumericUpDown);
            this.Controls.Add(this.threshholdGroupbox);
            this.Controls.Add(this.userSubbredditBtn);
            this.Controls.Add(this.userComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.subAwardBtn);
            this.Controls.Add(this.goldCheckBox);
            this.Controls.Add(this.platinumCheckBox);
            this.Controls.Add(this.silverCheckBox);
            this.Controls.Add(this.subbredditAwardComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RedditQueries";
            this.Text = "Reddit Queries";
            this.threshholdGroupbox.ResumeLayout(false);
            this.threshholdGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdNumericUpDown)).EndInit();
            this.subGroupBox.ResumeLayout(false);
            this.subGroupBox.PerformLayout();
            this.userGroupBox.ResumeLayout(false);
            this.userGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox OutputBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox subbredditAwardComboBox;
        private System.Windows.Forms.CheckBox silverCheckBox;
        private System.Windows.Forms.CheckBox platinumCheckBox;
        private System.Windows.Forms.CheckBox goldCheckBox;
        private System.Windows.Forms.Button subAwardBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox userComboBox;
        private System.Windows.Forms.Button userSubbredditBtn;
        private System.Windows.Forms.RadioButton lessThanRadioButton;
        private System.Windows.Forms.RadioButton greaterThanRadioButton;
        private System.Windows.Forms.GroupBox threshholdGroupbox;
        private System.Windows.Forms.NumericUpDown thresholdNumericUpDown;
        private System.Windows.Forms.Button thresholdBtn;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button dateBtn;
        private System.Windows.Forms.GroupBox subGroupBox;
        private System.Windows.Forms.RadioButton avgRadio;
        private System.Windows.Forms.RadioButton highRadio;
        private System.Windows.Forms.RadioButton lowRadio;
        private System.Windows.Forms.Button postSubBtn;
        private System.Windows.Forms.GroupBox userGroupBox;
        private System.Windows.Forms.RadioButton avgRadioU;
        private System.Windows.Forms.RadioButton highRadioU;
        private System.Windows.Forms.RadioButton lowRadioU;
        private System.Windows.Forms.Button postUserBtn;
        private System.Windows.Forms.Label Output;
        private System.Windows.Forms.Label label8;
    }
}

