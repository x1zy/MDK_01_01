
namespace Laboratornaya_3_Fractions_WindowsForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            Fraction1NumeratorTextBox = new TextBox();
            Fraction1DenominatorTextBox = new TextBox();
            Fraction2NumeratorTextBox = new TextBox();
            Fraction2DenominatorTextBox = new TextBox();
            
            ResultTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // Fraction1NumeratorTextBox
            // 
            Fraction1NumeratorTextBox.Location = new Point(26, 74);
            Fraction1NumeratorTextBox.Margin = new Padding(6, 7, 6, 7);
            Fraction1NumeratorTextBox.Name = "Fraction1NumeratorTextBox";
            Fraction1NumeratorTextBox.Size = new Size(104, 39);
            Fraction1NumeratorTextBox.TabIndex = 0;
            Fraction1NumeratorTextBox.TextChanged += Fraction1NumeratorTextBox_TextChanged;
            // 
            // Fraction2NumeratorTextBox
            // 
            Fraction2NumeratorTextBox.Location = new Point(26, 172);
            Fraction2NumeratorTextBox.Margin = new Padding(6, 7, 6, 7);
            Fraction2NumeratorTextBox.Name = "Fraction2NumeratorTextBox";
            Fraction2NumeratorTextBox.Size = new Size(104, 39);
            Fraction2NumeratorTextBox.TabIndex = 2;
            Fraction2NumeratorTextBox.TextChanged += Fraction2NumeratorTextBox_TextChanged;
            // 
            // Fraction1DenominatorTextBox
            // 
            Fraction1DenominatorTextBox.Location = new Point(188, 74);
            Fraction1DenominatorTextBox.Margin = new Padding(6, 7, 6, 7);
            Fraction1DenominatorTextBox.Name = "Fraction1DenominatorTextBox";
            Fraction1DenominatorTextBox.Size = new Size(104, 39);
            Fraction1DenominatorTextBox.TabIndex = 1;
            Fraction1DenominatorTextBox.TextChanged += Fraction1DenominatorTextBox_TextChanged;
            // 
            // Fraction2DenominatorTextBox
            // 
            Fraction2DenominatorTextBox.Location = new Point(188, 172);
            Fraction2DenominatorTextBox.Margin = new Padding(6, 7, 6, 7);
            Fraction2DenominatorTextBox.Name = "Fraction2DenominatorTextBox";
            Fraction2DenominatorTextBox.Size = new Size(104, 39);
            Fraction2DenominatorTextBox.TabIndex = 3;
            Fraction2DenominatorTextBox.TextChanged += Fraction2DenominatorTextBox_TextChanged;
            // 
            // ResultTextBox
            // 
            ResultTextBox.AcceptsTab = true;
            ResultTextBox.Location = new Point(26, 369);
            ResultTextBox.Margin = new Padding(6, 7, 6, 7);
            ResultTextBox.Multiline = true;
            ResultTextBox.Name = "ResultTextBox";
            ResultTextBox.ReadOnly = true;
            ResultTextBox.Size = new Size(574, 257);
            ResultTextBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 34);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(174, 32);
            label1.TabIndex = 5;
            label1.Text = "Первая дробь:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 133);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(169, 32);
            label2.TabIndex = 6;
            label2.Text = "Вторая дробь:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(147, 74);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(23, 32);
            label3.TabIndex = 7;
            label3.Text = "/";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(147, 175);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(23, 32);
            label4.TabIndex = 8;
            label4.Text = "/";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 642);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ResultTextBox);
            Controls.Add(Fraction2DenominatorTextBox);
            Controls.Add(Fraction2NumeratorTextBox);
            Controls.Add(Fraction1DenominatorTextBox);
            Controls.Add(Fraction1NumeratorTextBox);
            Margin = new Padding(6, 7, 6, 7);
            Name = "Form1";
            Text = "Калькулятор дробей";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox Fraction1NumeratorTextBox;
        private System.Windows.Forms.TextBox Fraction1DenominatorTextBox;
        private System.Windows.Forms.TextBox Fraction2NumeratorTextBox;
        private System.Windows.Forms.TextBox Fraction2DenominatorTextBox;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}