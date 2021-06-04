namespace GaussianEliminationCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.resetButton_matrixInput = new System.Windows.Forms.Button();
            this.solveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vectorOutput_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vectorInput_TextBox = new System.Windows.Forms.TextBox();
            this.outputMatrix = new System.Windows.Forms.Label();
            this.inputMatrix_Label = new System.Windows.Forms.Label();
            this.matrixOutput_Textbox = new System.Windows.Forms.TextBox();
            this.matrixInput_Textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // resetButton_matrixInput
            // 
            this.resetButton_matrixInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(23)))));
            this.resetButton_matrixInput.FlatAppearance.BorderSize = 0;
            this.resetButton_matrixInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton_matrixInput.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.resetButton_matrixInput.ForeColor = System.Drawing.Color.White;
            this.resetButton_matrixInput.Location = new System.Drawing.Point(480, 482);
            this.resetButton_matrixInput.Name = "resetButton_matrixInput";
            this.resetButton_matrixInput.Size = new System.Drawing.Size(75, 33);
            this.resetButton_matrixInput.TabIndex = 21;
            this.resetButton_matrixInput.Text = "Reset";
            this.resetButton_matrixInput.UseVisualStyleBackColor = false;
            this.resetButton_matrixInput.Click += new System.EventHandler(this.resetButton_matrixInput_Click_1);
            // 
            // solveButton
            // 
            this.solveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(23)))));
            this.solveButton.FlatAppearance.BorderSize = 0;
            this.solveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.solveButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.solveButton.ForeColor = System.Drawing.Color.White;
            this.solveButton.Location = new System.Drawing.Point(480, 429);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(75, 33);
            this.solveButton.TabIndex = 16;
            this.solveButton.Text = "Solve";
            this.solveButton.UseVisualStyleBackColor = false;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(28, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(372, 225);
            this.label3.TabIndex = 26;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(600, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 21);
            this.label2.TabIndex = 25;
            this.label2.Text = "Solution to Vector x";
            // 
            // vectorOutput_textbox
            // 
            this.vectorOutput_textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.vectorOutput_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vectorOutput_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.vectorOutput_textbox.ForeColor = System.Drawing.Color.White;
            this.vectorOutput_textbox.Location = new System.Drawing.Point(603, 271);
            this.vectorOutput_textbox.Multiline = true;
            this.vectorOutput_textbox.Name = "vectorOutput_textbox";
            this.vectorOutput_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.vectorOutput_textbox.Size = new System.Drawing.Size(385, 102);
            this.vectorOutput_textbox.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 21);
            this.label1.TabIndex = 23;
            this.label1.Text = "Input Vector b";
            // 
            // vectorInput_TextBox
            // 
            this.vectorInput_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.vectorInput_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vectorInput_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.vectorInput_TextBox.ForeColor = System.Drawing.Color.White;
            this.vectorInput_TextBox.Location = new System.Drawing.Point(31, 271);
            this.vectorInput_TextBox.Multiline = true;
            this.vectorInput_TextBox.Name = "vectorInput_TextBox";
            this.vectorInput_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.vectorInput_TextBox.Size = new System.Drawing.Size(385, 102);
            this.vectorInput_TextBox.TabIndex = 22;
            this.vectorInput_TextBox.Text = "5\r\n2/3\r\n2";
            // 
            // outputMatrix
            // 
            this.outputMatrix.AutoSize = true;
            this.outputMatrix.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.outputMatrix.ForeColor = System.Drawing.Color.White;
            this.outputMatrix.Location = new System.Drawing.Point(599, 34);
            this.outputMatrix.Name = "outputMatrix";
            this.outputMatrix.Size = new System.Drawing.Size(299, 21);
            this.outputMatrix.TabIndex = 20;
            this.outputMatrix.Text = "Output Matrix (\"Frankenstein\" L\\U Matrix)";
            // 
            // inputMatrix_Label
            // 
            this.inputMatrix_Label.AutoSize = true;
            this.inputMatrix_Label.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.inputMatrix_Label.ForeColor = System.Drawing.Color.White;
            this.inputMatrix_Label.Location = new System.Drawing.Point(27, 34);
            this.inputMatrix_Label.Name = "inputMatrix_Label";
            this.inputMatrix_Label.Size = new System.Drawing.Size(277, 21);
            this.inputMatrix_Label.TabIndex = 19;
            this.inputMatrix_Label.Text = "Input Matrix A (Must be square matrix)";
            // 
            // matrixOutput_Textbox
            // 
            this.matrixOutput_Textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.matrixOutput_Textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matrixOutput_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.matrixOutput_Textbox.ForeColor = System.Drawing.Color.White;
            this.matrixOutput_Textbox.Location = new System.Drawing.Point(603, 58);
            this.matrixOutput_Textbox.Multiline = true;
            this.matrixOutput_Textbox.Name = "matrixOutput_Textbox";
            this.matrixOutput_Textbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.matrixOutput_Textbox.Size = new System.Drawing.Size(385, 178);
            this.matrixOutput_Textbox.TabIndex = 18;
            // 
            // matrixInput_Textbox
            // 
            this.matrixInput_Textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.matrixInput_Textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matrixInput_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.matrixInput_Textbox.ForeColor = System.Drawing.Color.White;
            this.matrixInput_Textbox.Location = new System.Drawing.Point(31, 58);
            this.matrixInput_Textbox.Multiline = true;
            this.matrixInput_Textbox.Name = "matrixInput_Textbox";
            this.matrixInput_Textbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.matrixInput_Textbox.Size = new System.Drawing.Size(385, 178);
            this.matrixInput_Textbox.TabIndex = 17;
            this.matrixInput_Textbox.Text = "1,2,3\r\n4,2,5\r\n6,7,8";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1014, 648);
            this.Controls.Add(this.resetButton_matrixInput);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vectorOutput_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vectorInput_TextBox);
            this.Controls.Add(this.outputMatrix);
            this.Controls.Add(this.inputMatrix_Label);
            this.Controls.Add(this.matrixOutput_Textbox);
            this.Controls.Add(this.matrixInput_Textbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gaussian Elimination";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button resetButton_matrixInput;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox vectorOutput_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox vectorInput_TextBox;
        private System.Windows.Forms.Label outputMatrix;
        private System.Windows.Forms.Label inputMatrix_Label;
        private System.Windows.Forms.TextBox matrixOutput_Textbox;
        private System.Windows.Forms.TextBox matrixInput_Textbox;
    }
}

