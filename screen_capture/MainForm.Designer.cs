/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 12/7/2011
 * Time: 5:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Diagnostics;

namespace screen_capture
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        	this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.radioButton5 = new System.Windows.Forms.RadioButton();
        	this.radioButton1 = new System.Windows.Forms.RadioButton();
        	this.radioButton2 = new System.Windows.Forms.RadioButton();
        	this.groupBox1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        	this.groupBox1.Controls.Add(this.radioButton5);
        	this.groupBox1.Controls.Add(this.radioButton1);
        	this.groupBox1.Controls.Add(this.radioButton2);
        	this.groupBox1.Location = new System.Drawing.Point(176, 117);
        	this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
        	this.groupBox1.Size = new System.Drawing.Size(600, 80);
        	this.groupBox1.TabIndex = 1;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Image";
        	// 
        	// radioButton5
        	// 
        	this.radioButton5.BackColor = System.Drawing.Color.Cyan;
        	this.radioButton5.Location = new System.Drawing.Point(199, 29);
        	this.radioButton5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        	this.radioButton5.Name = "radioButton5";
        	this.radioButton5.Size = new System.Drawing.Size(208, 31);
        	this.radioButton5.TabIndex = 4;
        	this.radioButton5.Text = "Open In &Explorer";
        	this.radioButton5.UseVisualStyleBackColor = false;
        	this.radioButton5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.radioButton5_KeyPress);
        	this.radioButton5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RadioButton5MouseDown);
        	// 
        	// radioButton1
        	// 
        	this.radioButton1.BackColor = System.Drawing.Color.Cyan;
        	this.radioButton1.Checked = true;
        	this.radioButton1.Location = new System.Drawing.Point(9, 29);
        	this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        	this.radioButton1.Name = "radioButton1";
        	this.radioButton1.Size = new System.Drawing.Size(182, 31);
        	this.radioButton1.TabIndex = 2;
        	this.radioButton1.TabStop = true;
        	this.radioButton1.Text = "&Copy to Clipboard";
        	this.radioButton1.UseVisualStyleBackColor = false;
        	this.radioButton1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RadioButton1KeyPress);
        	this.radioButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RadioButton1MouseDown);
        	// 
        	// radioButton2
        	// 
        	this.radioButton2.BackColor = System.Drawing.Color.Cyan;
        	this.radioButton2.Location = new System.Drawing.Point(418, 29);
        	this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        	this.radioButton2.Name = "radioButton2";
        	this.radioButton2.Size = new System.Drawing.Size(162, 31);
        	this.radioButton2.TabIndex = 1;
        	this.radioButton2.Text = "&Save to file";
        	this.radioButton2.UseVisualStyleBackColor = false;
        	this.radioButton2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RadioButton2KeyPress);
        	this.radioButton2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RadioButton2MouseDown);
        	// 
        	// MainForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        	this.ClientSize = new System.Drawing.Size(1438, 426);
        	this.ControlBox = false;
        	this.Controls.Add(this.groupBox1);
        	this.Cursor = System.Windows.Forms.Cursors.Cross;
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        	this.Name = "MainForm";
        	this.Opacity = 0.5D;
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.Text = "ScreenCapture";
        	this.TransparencyKey = System.Drawing.Color.White;
        	this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        	this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainFormKeyPress);
        	this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseDown);
        	this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseMove);
        	this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseUp);
        	this.groupBox1.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

    }
}
