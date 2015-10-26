using System;

namespace BroadcastorClient
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.btnRegisterClient = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEventMessage = new System.Windows.Forms.TextBox();
            this.btnSendEvent = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEventMessages = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ClientName";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(35, 48);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(189, 20);
            this.txtClientName.TabIndex = 1;
            // 
            // btnRegisterClient
            // 
            this.btnRegisterClient.Location = new System.Drawing.Point(73, 84);
            this.btnRegisterClient.Name = "btnRegisterClient";
            this.btnRegisterClient.Size = new System.Drawing.Size(100, 23);
            this.btnRegisterClient.TabIndex = 2;
            this.btnRegisterClient.Text = "RegisterClient";
            this.btnRegisterClient.UseVisualStyleBackColor = true;
            this.btnRegisterClient.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "EventMessage";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtEventMessage
            // 
            this.txtEventMessage.Location = new System.Drawing.Point(35, 160);
            this.txtEventMessage.Name = "txtEventMessage";
            this.txtEventMessage.Size = new System.Drawing.Size(189, 20);
            this.txtEventMessage.TabIndex = 4;
            // 
            // btnSendEvent
            // 
            this.btnSendEvent.Location = new System.Drawing.Point(73, 195);
            this.btnSendEvent.Name = "btnSendEvent";
            this.btnSendEvent.Size = new System.Drawing.Size(100, 23);
            this.btnSendEvent.TabIndex = 5;
            this.btnSendEvent.Text = "SendMessage";
            this.btnSendEvent.UseVisualStyleBackColor = true;
            this.btnSendEvent.Click += new System.EventHandler(this.btnSendEvent_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "MessageFromOtherClient";
            // 
            // txtEventMessages
            // 
            this.txtEventMessages.Location = new System.Drawing.Point(35, 288);
            this.txtEventMessages.Multiline = true;
            this.txtEventMessages.Name = "txtEventMessages";
            this.txtEventMessages.Size = new System.Drawing.Size(189, 135);
            this.txtEventMessages.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 463);
            this.Controls.Add(this.txtEventMessages);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSendEvent);
            this.Controls.Add(this.txtEventMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRegisterClient);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Button btnRegisterClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEventMessage;
        private System.Windows.Forms.Button btnSendEvent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEventMessages;
        private System.Windows.Forms.FontDialog fontDialog1;

    }
}

