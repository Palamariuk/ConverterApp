using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;

namespace ConverterApp
{
	public partial class Form1 : Form
	{

		public int selectedButton;
		public List<Button> numButtons = new List<Button>();
		public List<char> nums = new List<char>();
		public List<Button> notationButtons = new List<Button>();

		private void selectButton(int select)
		{
			foreach(Button bt in notationButtons)
			{
				bt.BackColor = Color.FromArgb(224, 224, 224);
			}

			notationButtons[select].BackColor = Color.FromArgb(128, 128, 255);

		}

		public Form1()
		{
			InitializeComponent();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void pictureBox1_MouseEnter(object sender, EventArgs e)
		{
			btClose.Left -= 3;
			btClose.Top -= 3;
			btClose.Size = new Size(26, 26);
		}

		private void btClose_MouseLeave(object sender, EventArgs e)
		{
			btClose.Left += 3;
			btClose.Top += 3;
			btClose.Size = new Size(20, 20);
		}

		private void initLabels()
		{
			lbBin.Text = "";
			lbOct.Text = "";
			lbDec.Text = "";
			lbHex.Text = "";
			lbMain.Text = "";
		}

		private void initNumButtons()
		{
			numButtons.Add(bt0);
			numButtons.Add(bt1);
			numButtons.Add(bt2);
			numButtons.Add(bt3);
			numButtons.Add(bt4);
			numButtons.Add(bt5);
			numButtons.Add(bt6);
			numButtons.Add(bt7);
			numButtons.Add(bt8);
			numButtons.Add(bt9);
			numButtons.Add(btA);
			numButtons.Add(btB);
			numButtons.Add(btC);
			numButtons.Add(btD);
			numButtons.Add(btE);
			numButtons.Add(btF);
			nums.Add('0');
			nums.Add('1');
			nums.Add('2');
			nums.Add('3');
			nums.Add('4');
			nums.Add('5');
			nums.Add('6');
			nums.Add('7');
			nums.Add('8');
			nums.Add('9');
			nums.Add('A');
			nums.Add('B');
			nums.Add('C');
			nums.Add('D');
			nums.Add('E');
			nums.Add('F');
		}

		private void initNotationButtons()
		{
			notationButtons.Add(btBin);
			notationButtons.Add(btOct);
			notationButtons.Add(btDec);
			notationButtons.Add(btHex);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			initLabels();
			btClose.Size = new Size(20, 20);
			initNotationButtons();
			initNumButtons();
			selectedButton = 2;
			selectButton(selectedButton);
			UpdateButtons();
		}

		private void button18_Click(object sender, EventArgs e)
		{
			lbMain.Text = "";
			UpdateLabels();
		}

		private void button17_Click(object sender, EventArgs e)
		{
			try 
			{ 
				lbMain.Text = lbMain.Text.Remove(lbMain.Text.Length - 1);
				UpdateLabels();
			}
			catch { return; }
			
		}

		private void bt0_Click(object sender, EventArgs e)
		{
			lbMain.Text += 0;
			UpdateLabels();
		}

		private void bt1_Click(object sender, EventArgs e)
		{
			lbMain.Text += 1;
			UpdateLabels();
		}

		private void bt2_Click(object sender, EventArgs e)
		{
			lbMain.Text += 2;
			UpdateLabels();
		}

		private void bt3_Click(object sender, EventArgs e)
		{
			lbMain.Text += 3;
			UpdateLabels();
		}

		private void bt4_Click(object sender, EventArgs e)
		{
			lbMain.Text += 4;
			UpdateLabels();
		}

		private void bt5_Click(object sender, EventArgs e)
		{
			lbMain.Text += 5;
			UpdateLabels();
		}

		private void bt6_Click(object sender, EventArgs e)
		{
			lbMain.Text += 6;
			UpdateLabels();
		}

		private void bt7_Click(object sender, EventArgs e)
		{
			lbMain.Text += 7;
			UpdateLabels();
		}

		private void bt8_Click(object sender, EventArgs e)
		{
			lbMain.Text += 8;
			UpdateLabels();
		}

		private void bt9_Click(object sender, EventArgs e)
		{
			lbMain.Text += 9;
			UpdateLabels();
		}

		private void btA_Click(object sender, EventArgs e)
		{
			lbMain.Text += "A";
			UpdateLabels();
		}

		private void btB_Click(object sender, EventArgs e)
		{
			lbMain.Text += "B";
			UpdateLabels();
		}

		private void btC_Click(object sender, EventArgs e)
		{
			lbMain.Text += "C";
			UpdateLabels();
		}

		private void btD_Click(object sender, EventArgs e)
		{
			lbMain.Text += "D";
			UpdateLabels();
		}

		private void btE_Click(object sender, EventArgs e)
		{
			lbMain.Text += "E";
			UpdateLabels();
		}

		private void btF_Click(object sender, EventArgs e)
		{
			lbMain.Text += "F";
			UpdateLabels();
		}

		private void button19_Click(object sender, EventArgs e)
		{
			selectedButton = 2;
			Random random = new Random(300);
			lbMain.Text = Convert.ToString(random);
			selectButton(selectedButton);
			UpdateLabels();
		}

		private void UpdateLabels()
		{
			int notation = 0; 

			switch (selectedButton)
			{
				case 0: notation = 2; break;
				case 1: notation = 8; break;
				case 2: notation = 10; break;
				case 3: notation = 16; break;
				default: notation = 10; break;
			}

			if (lbMain.Text == "")
			{
				lbBin.Text = "";
				lbOct.Text = "";
				lbDec.Text = "";
				lbHex.Text = "";
				return;
			}

			lbBin.Text = ConvertValues(notation, 2);
			lbOct.Text = ConvertValues(notation, 8);
			lbDec.Text = ConvertValues(notation, 10);
			lbHex.Text = ConvertValues(notation, 16);
		}

		private string ConvertValues(int from, int to)
		{
			string returnValue = "";
			string numText = lbMain.Text;
			Int64 num = 0;

			if (from == 10) num = Convert.ToInt64(numText); else
			{
				Int64 power = 1;
				while(numText.Length != 0)
				{
					num += nums.IndexOf(numText[numText.Length - 1]) * power;
					numText = numText.Remove(numText.Length - 1);
					power *= from;
				}
			}
			
			while(num != 0)
			{
				returnValue = nums[Convert.ToInt32(num % to)] + returnValue;
				num /= to;
			}
			return returnValue;
		}

		private void btBin_Click(object sender, EventArgs e)
		{
			selectedButton = 0;
			lbMain.Text = "";
			selectButton(selectedButton);
			UpdateLabels();
			UpdateButtons();
		}

		private void btOct_Click(object sender, EventArgs e)
		{
			selectedButton = 1;
			lbMain.Text = "";
			selectButton(selectedButton);
			UpdateLabels();
			UpdateButtons();
		}

		private void btDec_Click(object sender, EventArgs e)
		{
			selectedButton = 2;
			lbMain.Text = "";
			selectButton(selectedButton);
			UpdateLabels();
			UpdateButtons();
		}

		private void btHex_Click(object sender, EventArgs e)
		{
			selectedButton = 3;
			lbMain.Text = "";
			selectButton(selectedButton);
			UpdateLabels();
			UpdateButtons();
		}

		private void EnableButtons()
		{
			foreach(Button button in numButtons)
			{
				button.Enabled = true;
			}
		}

		private void DisableButtons() {

			int notation = 0;

			switch (selectedButton)
			{
				case 0: notation = 2; break;
				case 1: notation = 8; break;
				case 2: notation = 10; break;
				case 3: notation = 16; break;
				default: notation = 10; break;
			}

			for (int i = notation; i < 16; i++)
			{
				numButtons[i].Enabled = false;
			}
		}

		private void UpdateButtons()
		{
			EnableButtons();
			DisableButtons();
		}

		Point lastPoint;
		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				this.Left += e.X - lastPoint.X;
				this.Top += e.Y - lastPoint.Y;
			}
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			lastPoint = new Point(e.X, e.Y);
		}
	}
}
