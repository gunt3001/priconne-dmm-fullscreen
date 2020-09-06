namespace Hwnd
{
    partial class PrinconneFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrinconneFrm));
            this.fullscreenBtn = new System.Windows.Forms.Button();
            this.restoreBtn = new System.Windows.Forms.Button();
            this.linkBtn = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.resolutionComboBox = new System.Windows.Forms.ComboBox();
            this.applyResolutionBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fullscreenBtn
            // 
            this.fullscreenBtn.Location = new System.Drawing.Point(10, 12);
            this.fullscreenBtn.Name = "fullscreenBtn";
            this.fullscreenBtn.Size = new System.Drawing.Size(163, 35);
            this.fullscreenBtn.TabIndex = 0;
            this.fullscreenBtn.Text = "Go FullScreen";
            this.fullscreenBtn.UseVisualStyleBackColor = true;
            this.fullscreenBtn.Click += new System.EventHandler(this.fullscreenBtn_Click);
            // 
            // restoreBtn
            // 
            this.restoreBtn.Location = new System.Drawing.Point(179, 12);
            this.restoreBtn.Name = "restoreBtn";
            this.restoreBtn.Size = new System.Drawing.Size(163, 35);
            this.restoreBtn.TabIndex = 1;
            this.restoreBtn.Text = "Restore Window";
            this.restoreBtn.UseVisualStyleBackColor = true;
            this.restoreBtn.Click += new System.EventHandler(this.restoreBtn_Click);
            // 
            // linkBtn
            // 
            this.linkBtn.AutoSize = true;
            this.linkBtn.Location = new System.Drawing.Point(7, 105);
            this.linkBtn.Name = "linkBtn";
            this.linkBtn.Size = new System.Drawing.Size(341, 13);
            this.linkBtn.TabIndex = 2;
            this.linkBtn.TabStop = true;
            this.linkBtn.Text = "Princess Connect Re:Dive (DMM) Full Screen tool by Takumi Producer";
            this.linkBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBtn_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Set Resolution";
            // 
            // resolutionComboBox
            // 
            this.resolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resolutionComboBox.FormattingEnabled = true;
            this.resolutionComboBox.Location = new System.Drawing.Point(94, 65);
            this.resolutionComboBox.Name = "resolutionComboBox";
            this.resolutionComboBox.Size = new System.Drawing.Size(167, 21);
            this.resolutionComboBox.TabIndex = 4;
            // 
            // applyResolutionBtn
            // 
            this.applyResolutionBtn.Location = new System.Drawing.Point(267, 57);
            this.applyResolutionBtn.Name = "applyResolutionBtn";
            this.applyResolutionBtn.Size = new System.Drawing.Size(75, 35);
            this.applyResolutionBtn.TabIndex = 5;
            this.applyResolutionBtn.Text = "Apply";
            this.applyResolutionBtn.UseVisualStyleBackColor = true;
            this.applyResolutionBtn.Click += new System.EventHandler(this.applyResolutionBtn_Click);
            // 
            // PrinconneFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 134);
            this.Controls.Add(this.applyResolutionBtn);
            this.Controls.Add(this.resolutionComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkBtn);
            this.Controls.Add(this.restoreBtn);
            this.Controls.Add(this.fullscreenBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrinconneFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Priconne (DMM) Fullscreen v1.2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fullscreenBtn;
        private System.Windows.Forms.Button restoreBtn;
        private System.Windows.Forms.LinkLabel linkBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox resolutionComboBox;
        private System.Windows.Forms.Button applyResolutionBtn;
    }
}

