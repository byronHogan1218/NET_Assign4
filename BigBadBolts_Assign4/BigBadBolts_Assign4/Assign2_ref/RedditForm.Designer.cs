namespace BigBadBolts_Assign2
{
    partial class RedditForm
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
            this.subredditListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userListBox = new System.Windows.Forms.ListBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.systemOutListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.postListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addReplyTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addReplyBtn = new System.Windows.Forms.Button();
            this.commentListBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.membersTileLabel = new System.Windows.Forms.Label();
            this.activeTitleLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.membersNumberLabel = new System.Windows.Forms.Label();
            this.activeNumberLabel = new System.Windows.Forms.Label();
            this.deletePostBtn = new System.Windows.Forms.Button();
            this.deleteCommentBtn = new System.Windows.Forms.Button();
            this.lockPostBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // subredditListBox
            // 
            this.subredditListBox.BackColor = System.Drawing.Color.Black;
            this.subredditListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subredditListBox.ForeColor = System.Drawing.Color.White;
            this.subredditListBox.FormattingEnabled = true;
            this.subredditListBox.ItemHeight = 16;
            this.subredditListBox.Location = new System.Drawing.Point(239, 31);
            this.subredditListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.subredditListBox.Name = "subredditListBox";
            this.subredditListBox.Size = new System.Drawing.Size(155, 164);
            this.subredditListBox.TabIndex = 0;
            this.subredditListBox.SelectedIndexChanged += new System.EventHandler(this.SubredditListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(233, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subreddits";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(1, -7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Users";
            // 
            // userListBox
            // 
            this.userListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userListBox.FormattingEnabled = true;
            this.userListBox.ItemHeight = 16;
            this.userListBox.Location = new System.Drawing.Point(8, 21);
            this.userListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(181, 116);
            this.userListBox.TabIndex = 3;
            this.userListBox.Click += new System.EventHandler(this.UserListBox_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Location = new System.Drawing.Point(41, 190);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(100, 28);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // systemOutListBox
            // 
            this.systemOutListBox.BackColor = System.Drawing.Color.LightGray;
            this.systemOutListBox.FormattingEnabled = true;
            this.systemOutListBox.ItemHeight = 16;
            this.systemOutListBox.Location = new System.Drawing.Point(19, 469);
            this.systemOutListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.systemOutListBox.Name = "systemOutListBox";
            this.systemOutListBox.Size = new System.Drawing.Size(1011, 132);
            this.systemOutListBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(15, 441);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "System Output";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(403, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Posts";
            // 
            // postListBox
            // 
            this.postListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.postListBox.FormattingEnabled = true;
            this.postListBox.ItemHeight = 16;
            this.postListBox.Location = new System.Drawing.Point(403, 31);
            this.postListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.postListBox.Name = "postListBox";
            this.postListBox.Size = new System.Drawing.Size(625, 164);
            this.postListBox.TabIndex = 8;
            this.postListBox.SelectedIndexChanged += new System.EventHandler(this.PostListBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.OrangeRed;
            this.label5.Location = new System.Drawing.Point(13, 255);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Comments";
            // 
            // addReplyTextBox
            // 
            this.addReplyTextBox.Enabled = false;
            this.addReplyTextBox.Location = new System.Drawing.Point(599, 283);
            this.addReplyTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addReplyTextBox.Multiline = true;
            this.addReplyTextBox.Name = "addReplyTextBox";
            this.addReplyTextBox.Size = new System.Drawing.Size(431, 114);
            this.addReplyTextBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(595, 254);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Add Reply";
            // 
            // addReplyBtn
            // 
            this.addReplyBtn.Enabled = false;
            this.addReplyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addReplyBtn.ForeColor = System.Drawing.Color.Black;
            this.addReplyBtn.Location = new System.Drawing.Point(928, 404);
            this.addReplyBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addReplyBtn.Name = "addReplyBtn";
            this.addReplyBtn.Size = new System.Drawing.Size(100, 28);
            this.addReplyBtn.TabIndex = 14;
            this.addReplyBtn.Text = "Add Reply";
            this.addReplyBtn.UseVisualStyleBackColor = true;
            this.addReplyBtn.Click += new System.EventHandler(this.AddReplyBtn_Click);
            // 
            // commentListBox
            // 
            this.commentListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commentListBox.FormattingEnabled = true;
            this.commentListBox.ItemHeight = 16;
            this.commentListBox.Location = new System.Drawing.Point(16, 284);
            this.commentListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.commentListBox.Name = "commentListBox";
            this.commentListBox.Size = new System.Drawing.Size(573, 148);
            this.commentListBox.TabIndex = 15;
            this.commentListBox.SelectedIndexChanged += new System.EventHandler(this.CommentListBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(3, 142);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(8, 159);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(137, 20);
            this.passwordTextBox.Size = new System.Drawing.Size(181, 22);
            this.passwordTextBox.TabIndex = 18;
            // 
            // membersTileLabel
            // 
            this.membersTileLabel.AutoSize = true;
            this.membersTileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.membersTileLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.membersTileLabel.Location = new System.Drawing.Point(235, 199);
            this.membersTileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.membersTileLabel.Name = "membersTileLabel";
            this.membersTileLabel.Size = new System.Drawing.Size(84, 17);
            this.membersTileLabel.TabIndex = 21;
            this.membersTileLabel.Text = "Members -";
            // 
            // activeTitleLabel
            // 
            this.activeTitleLabel.AutoSize = true;
            this.activeTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeTitleLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.activeTitleLabel.Location = new System.Drawing.Point(380, 199);
            this.activeTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.activeTitleLabel.Name = "activeTitleLabel";
            this.activeTitleLabel.Size = new System.Drawing.Size(63, 17);
            this.activeTitleLabel.TabIndex = 22;
            this.activeTitleLabel.Text = "Active -";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.passwordTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.loginBtn);
            this.groupBox1.Controls.Add(this.userListBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(199, 228);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // membersNumberLabel
            // 
            this.membersNumberLabel.AutoSize = true;
            this.membersNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.membersNumberLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.membersNumberLabel.Location = new System.Drawing.Point(317, 199);
            this.membersNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.membersNumberLabel.Name = "membersNumberLabel";
            this.membersNumberLabel.Size = new System.Drawing.Size(35, 17);
            this.membersNumberLabel.TabIndex = 24;
            this.membersNumberLabel.Text = "###";
            // 
            // activeNumberLabel
            // 
            this.activeNumberLabel.AutoSize = true;
            this.activeNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeNumberLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.activeNumberLabel.Location = new System.Drawing.Point(437, 199);
            this.activeNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.activeNumberLabel.Name = "activeNumberLabel";
            this.activeNumberLabel.Size = new System.Drawing.Size(35, 17);
            this.activeNumberLabel.TabIndex = 25;
            this.activeNumberLabel.Text = "###";
            // 
            // deletePostBtn
            // 
            this.deletePostBtn.Enabled = false;
            this.deletePostBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletePostBtn.ForeColor = System.Drawing.Color.OrangeRed;
            this.deletePostBtn.Location = new System.Drawing.Point(929, 199);
            this.deletePostBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deletePostBtn.Name = "deletePostBtn";
            this.deletePostBtn.Size = new System.Drawing.Size(100, 28);
            this.deletePostBtn.TabIndex = 26;
            this.deletePostBtn.Text = "Delete Post";
            this.deletePostBtn.UseVisualStyleBackColor = true;
            this.deletePostBtn.Click += new System.EventHandler(this.DeletePostBtn_Click);
            // 
            // deleteCommentBtn
            // 
            this.deleteCommentBtn.Enabled = false;
            this.deleteCommentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteCommentBtn.ForeColor = System.Drawing.Color.OrangeRed;
            this.deleteCommentBtn.Location = new System.Drawing.Point(599, 405);
            this.deleteCommentBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteCommentBtn.Name = "deleteCommentBtn";
            this.deleteCommentBtn.Size = new System.Drawing.Size(145, 28);
            this.deleteCommentBtn.TabIndex = 27;
            this.deleteCommentBtn.Text = "Delete Comment";
            this.deleteCommentBtn.UseVisualStyleBackColor = true;
            this.deleteCommentBtn.Click += new System.EventHandler(this.DeleteCommentBtn_Click);
            // 
            // lockPostBtn
            // 
            this.lockPostBtn.Enabled = false;
            this.lockPostBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lockPostBtn.ForeColor = System.Drawing.Color.OrangeRed;
            this.lockPostBtn.Location = new System.Drawing.Point(821, 199);
            this.lockPostBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lockPostBtn.Name = "lockPostBtn";
            this.lockPostBtn.Size = new System.Drawing.Size(100, 28);
            this.lockPostBtn.TabIndex = 28;
            this.lockPostBtn.Text = "Lock Post";
            this.lockPostBtn.UseVisualStyleBackColor = true;
            this.lockPostBtn.Visible = false;
            this.lockPostBtn.Click += new System.EventHandler(this.LockPostBtn_Click);
            // 
            // RedditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1067, 604);
            this.Controls.Add(this.lockPostBtn);
            this.Controls.Add(this.deleteCommentBtn);
            this.Controls.Add(this.deletePostBtn);
            this.Controls.Add(this.activeNumberLabel);
            this.Controls.Add(this.membersNumberLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.activeTitleLabel);
            this.Controls.Add(this.membersTileLabel);
            this.Controls.Add(this.commentListBox);
            this.Controls.Add(this.addReplyBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.addReplyTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.postListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.systemOutListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subredditListBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RedditForm";
            this.Text = "Subreddit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox subredditListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox userListBox;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.ListBox systemOutListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox postListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addReplyTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addReplyBtn;
        private System.Windows.Forms.ListBox commentListBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label membersTileLabel;
        private System.Windows.Forms.Label activeTitleLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label membersNumberLabel;
        private System.Windows.Forms.Label activeNumberLabel;
        private System.Windows.Forms.Button deletePostBtn;
        private System.Windows.Forms.Button deleteCommentBtn;
        private System.Windows.Forms.Button lockPostBtn;
    }
}
