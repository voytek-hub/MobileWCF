﻿namespace MobileWCF.WinClient
{
    partial class MainForm
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
            this.tbNum1 = new System.Windows.Forms.TextBox();
            this.tbNum2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lResult = new System.Windows.Forms.Label();
            this.bAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbNum1
            // 
            this.tbNum1.Location = new System.Drawing.Point(163, 66);
            this.tbNum1.Name = "tbNum1";
            this.tbNum1.Size = new System.Drawing.Size(300, 31);
            this.tbNum1.TabIndex = 1;
            this.tbNum1.Text = "22";
            // 
            // tbNum2
            // 
            this.tbNum2.Location = new System.Drawing.Point(163, 119);
            this.tbNum2.Name = "tbNum2";
            this.tbNum2.Size = new System.Drawing.Size(300, 31);
            this.tbNum2.TabIndex = 2;
            this.tbNum2.Text = "33";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "+";
            // 
            // lResult
            // 
            this.lResult.Location = new System.Drawing.Point(263, 262);
            this.lResult.Name = "lResult";
            this.lResult.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lResult.Size = new System.Drawing.Size(200, 25);
            this.lResult.TabIndex = 4;
            this.lResult.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(268, 176);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(195, 49);
            this.bAdd.TabIndex = 5;
            this.bAdd.Text = "Add";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAddAsyncTAP_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 569);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.lResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNum2);
            this.Controls.Add(this.tbNum1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbNum1;
        private System.Windows.Forms.TextBox tbNum2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lResult;
        private System.Windows.Forms.Button bAdd;
    }
}

