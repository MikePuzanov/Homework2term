
namespace Hw7CalculatorWinForms
{
    partial class CalculatorForms
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPlusMinus = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.buttonDot = new System.Windows.Forms.Button();
            this.buttonEqual = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonText = new System.Windows.Forms.Button();
            this.buttonResetAll = new System.Windows.Forms.Button();
            this.buttonResetString = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonMultiplication = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonDivide = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPlusMinus
            // 
            this.buttonPlusMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlusMinus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonPlusMinus.Location = new System.Drawing.Point(3, 298);
            this.buttonPlusMinus.Name = "buttonPlusMinus";
            this.buttonPlusMinus.Size = new System.Drawing.Size(101, 54);
            this.buttonPlusMinus.TabIndex = 10;
            this.buttonPlusMinus.Text = "+/-";
            this.buttonPlusMinus.UseVisualStyleBackColor = true;
            this.buttonPlusMinus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonPlusMinus_MouseClick);
            // 
            // button0
            // 
            this.button0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button0.Location = new System.Drawing.Point(110, 298);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(101, 54);
            this.button0.TabIndex = 9;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // buttonDot
            // 
            this.buttonDot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDot.Location = new System.Drawing.Point(217, 298);
            this.buttonDot.Name = "buttonDot";
            this.buttonDot.Size = new System.Drawing.Size(101, 54);
            this.buttonDot.TabIndex = 11;
            this.buttonDot.Text = ".";
            this.buttonDot.UseVisualStyleBackColor = true;
            this.buttonDot.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // buttonEqual
            // 
            this.buttonEqual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEqual.Location = new System.Drawing.Point(324, 298);
            this.buttonEqual.Name = "buttonEqual";
            this.buttonEqual.Size = new System.Drawing.Size(101, 54);
            this.buttonEqual.TabIndex = 16;
            this.buttonEqual.Text = "=";
            this.buttonEqual.UseVisualStyleBackColor = true;
            this.buttonEqual.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonEqual_MouseClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.buttonPlusMinus, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetAll, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonResetString, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonDelete, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonMultiplication, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button6, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonDivide, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonMinus, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonPlus, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonEqual, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonDot, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button0, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(428, 355);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // buttonText
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonText, 4);
            this.buttonText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonText.Location = new System.Drawing.Point(3, 23);
            this.buttonText.Name = "buttonText";
            this.buttonText.Size = new System.Drawing.Size(422, 49);
            this.buttonText.TabIndex = 20;
            this.buttonText.Text = "0";
            this.buttonText.UseVisualStyleBackColor = true;
            // 
            // buttonResetAll
            // 
            this.buttonResetAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetAll.Location = new System.Drawing.Point(110, 78);
            this.buttonResetAll.Name = "buttonResetAll";
            this.buttonResetAll.Size = new System.Drawing.Size(101, 49);
            this.buttonResetAll.TabIndex = 17;
            this.buttonResetAll.Text = "c";
            this.buttonResetAll.UseVisualStyleBackColor = true;
            this.buttonResetAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonResetAll_MouseClick);
            // 
            // buttonResetString
            // 
            this.buttonResetString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonResetString.Location = new System.Drawing.Point(3, 78);
            this.buttonResetString.Name = "buttonResetString";
            this.buttonResetString.Size = new System.Drawing.Size(101, 49);
            this.buttonResetString.TabIndex = 18;
            this.buttonResetString.Text = "ce";
            this.buttonResetString.UseVisualStyleBackColor = true;
            this.buttonResetString.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonResetString_MouseClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelete.Location = new System.Drawing.Point(217, 78);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(101, 49);
            this.buttonDelete.TabIndex = 19;
            this.buttonDelete.Text = "delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonDelete_MouseClick);
            // 
            // buttonMultiplication
            // 
            this.buttonMultiplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMultiplication.Location = new System.Drawing.Point(324, 78);
            this.buttonMultiplication.Name = "buttonMultiplication";
            this.buttonMultiplication.Size = new System.Drawing.Size(101, 49);
            this.buttonMultiplication.TabIndex = 14;
            this.buttonMultiplication.Text = "*";
            this.buttonMultiplication.UseVisualStyleBackColor = true;
            this.buttonMultiplication.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonSign_MouseClick);
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.Location = new System.Drawing.Point(217, 133);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(101, 49);
            this.button9.TabIndex = 8;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Location = new System.Drawing.Point(110, 133);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(101, 49);
            this.button8.TabIndex = 7;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Location = new System.Drawing.Point(3, 133);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(101, 49);
            this.button7.TabIndex = 6;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(3, 188);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 49);
            this.button4.TabIndex = 3;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(110, 188);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(101, 49);
            this.button5.TabIndex = 4;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Location = new System.Drawing.Point(217, 188);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(101, 49);
            this.button6.TabIndex = 5;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // buttonDivide
            // 
            this.buttonDivide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDivide.Location = new System.Drawing.Point(324, 133);
            this.buttonDivide.Name = "buttonDivide";
            this.buttonDivide.Size = new System.Drawing.Size(101, 49);
            this.buttonDivide.TabIndex = 15;
            this.buttonDivide.Text = "/";
            this.buttonDivide.UseVisualStyleBackColor = true;
            this.buttonDivide.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonSign_MouseClick);
            // 
            // buttonMinus
            // 
            this.buttonMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMinus.Location = new System.Drawing.Point(324, 188);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(101, 49);
            this.buttonMinus.TabIndex = 13;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonSign_MouseClick);
            // 
            // buttonPlus
            // 
            this.buttonPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlus.Location = new System.Drawing.Point(324, 243);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(101, 49);
            this.buttonPlus.TabIndex = 12;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonSign_MouseClick);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(217, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 49);
            this.button3.TabIndex = 2;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(110, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 49);
            this.button2.TabIndex = 1;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // CalculatorForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 355);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "CalculatorForms";
            this.Text = "Calculator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonPlusMinus;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button buttonDot;
        private System.Windows.Forms.Button buttonEqual;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonResetAll;
        private System.Windows.Forms.Button buttonResetString;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonMultiplication;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buttonDivide;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonText;
    }
}