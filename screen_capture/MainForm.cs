/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 12/7/2011
 * Time: 5:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;


using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Diagnostics;

namespace screen_capture
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}


		int fx,fy,width,height;
		bool started=false;
		System.Drawing.Point startpoint = new System.Drawing.Point();

		Pen MyPen = new Pen(Color.Black, 1);

		void public_key_press(System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == 27)
				this.Close();
		}
		void MainFormKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			public_key_press(e);
		}

		void MainFormMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			started=true;
			this.groupBox1.Visible = false;
			startpoint.X = e.X;
			startpoint.Y = e.Y;
		}

		void MainFormMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(started==true)
			{
				DrawSelection(e.X,e.Y);
				this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			}
		}

		void MainFormMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			started = false;
			mainProc();
			this.Close();
		}

		Bitmap bitmap;
		Graphics g;
		//string TEMPFILENAME="D:\\111.jpg";
		string TEMPFILENAME = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\111.jpg";

		void editWithMsPaint(string FilePath)
		{
			System.Diagnostics.Process edit = new System.Diagnostics.Process();
			edit.StartInfo.Arguments = "\"" + FilePath.ToString() + "\"";
			edit.StartInfo.FileName = "mspaint.exe";
			edit.Start();
			//edit.WaitForExit();
		}

		void showInExplorer(string FilePath)
		{
			System.Diagnostics.Process proc = new System.Diagnostics.Process();
			//proc.StartInfo.Arguments = "\"/select, \"" + "\"" + FilePath.ToString() + "\"";
			proc.StartInfo.Arguments = "/select, \"" + FilePath.ToString() +"\"";
			//proc.StartInfo.Arguments = "/select, c:\\111.jpg\"";
			proc.StartInfo.FileName = "explorer.exe";
			//MessageBox.Show(proc.StartInfo.Arguments.ToString());
			//MessageBox.Show(FilePath.ToString());
			proc.Start();
		}



		void CaptureImage(Point SourcePoint, Point DestinationPoint, Rectangle SelectionRectangle, string FilePath, string extension)
		{
			switch (extension)
			{
				case ".bmp":
					bitmap.Save(FilePath, System.Drawing.Imaging.ImageFormat.Bmp);
					break;
				case ".jpg":
					bitmap.Save(FilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
					break;
				case ".gif":
					bitmap.Save(FilePath, System.Drawing.Imaging.ImageFormat.Gif);
					break;
				case ".tiff":
					bitmap.Save(FilePath, System.Drawing.Imaging.ImageFormat.Tiff);
					break;
				case ".png":
					bitmap.Save(FilePath, System.Drawing.Imaging.ImageFormat.Png);
					break;
				default:
					bitmap.Save(FilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
					break;
			}

		}


		public void mainProc()
		{
			string fName;
			FileInfo fInfo;

			Point StartPoint = new Point(fx,fy);
			Rectangle bounds = new Rectangle(fx,fy,width,height);

			bitmap = new Bitmap(bounds.Width, bounds.Height);
			g = Graphics.FromImage(bitmap);
			g.CopyFromScreen(StartPoint, Point.Empty, bounds.Size);

			if(radioButton1.Checked == true)  // copy to clipboard and exit
			{
				Clipboard.Clear();
				Image img;
				img = (Image)bitmap;
				Clipboard.SetImage(bitmap);
				return;
			}

			if (radioButton2.Checked == true) // save to file
			{
				saveFileDialog1.DefaultExt = "bmp";
				saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg|gif files (*.gif)|*.gif|tiff files (*.tiff)|*.tiff|png files (*.png)|*.png";
				saveFileDialog1.Title = "Save screenshot to...";
				saveFileDialog1.ShowDialog();
				fName = saveFileDialog1.FileName;

				this.Hide();

				if ("" != fName)
				{
					fInfo = new FileInfo(fName);
				}
				else
				{
					MessageBox.Show("Couldnt save file. Exiting");
					return;
				}
			}
			else
			{
				fName = TEMPFILENAME;
				fInfo= new FileInfo(fName);
			}

			//Allow 250 milliseconds for the screen to repaint itself (we don't want to include this form in the capture)
			System.Threading.Thread.Sleep(150);

			CaptureImage(StartPoint, Point.Empty, bounds, fName, fInfo.Extension);

			if (radioButton2.Checked == true) // save to file
			{
				System.Windows.Forms.DialogResult ans;
				ans=MessageBox.Show("Do u want to edit with PAINT..?","Screen Capture",MessageBoxButtons.YesNo);
				if(ans==DialogResult.Yes)
				{
					editWithMsPaint(fName);
				}
			}
			
			if (radioButton5.Checked == true) // open in explorer
			{
				showInExplorer(fName);
			}
		}

		private void DrawSelection(int cx,int cy)
		{
			this.Cursor = Cursors.Cross;
			bool flag=false;
			if(cx>startpoint.X)
			{
				fx=startpoint.X;
				width=cx-fx;
			}
			else
			{
				fx=cx;
				width=startpoint.X-fx;
			}

			if(cy>startpoint.Y)
			{
				fy=startpoint.Y;
				height=cy-fy;
			}
			else
			{
				flag=true;
				fy=startpoint.Y;
				height=fy-cy;
			}
			this.Refresh();
			if(flag==true)
			{
				fx=startpoint.X;
				fy=cy;
				if(cx<startpoint.X)
				{
					fx=cx;
				}
			}
			System.Drawing.Rectangle bx = new Rectangle(fx,fy,width,height);
			Graphics drawRect = this.CreateGraphics();
			drawRect.DrawRectangle(MyPen,bx);
		}

		void RadioButton2KeyPress(object sender, KeyPressEventArgs e)
		{
			public_key_press(e);
		}

		void RadioButton1KeyPress(object sender, KeyPressEventArgs e)
		{
			public_key_press(e);
		}
		
		private void radioButton5_KeyPress(object sender, KeyPressEventArgs e)
		{
			public_key_press(e);
		}

		
		
		
		void RadioButton1MouseDown(object sender, MouseEventArgs e)
		{
			

		}
		
		void RadioButton5MouseDown(object sender, MouseEventArgs e)
		{

		}
		
		void RadioButton2MouseDown(object sender, MouseEventArgs e)
		{

		}
	}
}
