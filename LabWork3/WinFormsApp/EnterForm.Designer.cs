namespace WinFormsApp
{
    partial class EnterForm
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
            this.ElementTypesComboBox = new System.Windows.Forms.ComboBox();
            this.AddRandomElementButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SelectElementGroupBox = new System.Windows.Forms.GroupBox();
            this.ParametersGgroupBox = new System.Windows.Forms.GroupBox();
            this.resistorUserControl1 = new WinFormsApp.ResistorUserControl();
            this.capacitorUserControl1 = new WinFormsApp.CapacitorUserControl();
            this.inductorCoilUserControl1 = new WinFormsApp.InductorCoilUserControl();
            this.SelectElementGroupBox.SuspendLayout();
            this.ParametersGgroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ElementTypesComboBox
            // 
            this.ElementTypesComboBox.FormattingEnabled = true;
            this.ElementTypesComboBox.Location = new System.Drawing.Point(13, 26);
            this.ElementTypesComboBox.Name = "ElementTypesComboBox";
            this.ElementTypesComboBox.Size = new System.Drawing.Size(218, 28);
            this.ElementTypesComboBox.TabIndex = 0;
            // 
            // AddRandomElementButton
            // 
            this.AddRandomElementButton.Location = new System.Drawing.Point(25, 348);
            this.AddRandomElementButton.Name = "AddRandomElementButton";
            this.AddRandomElementButton.Size = new System.Drawing.Size(218, 29);
            this.AddRandomElementButton.TabIndex = 1;
            this.AddRandomElementButton.Text = "Random Element";
            this.AddRandomElementButton.UseVisualStyleBackColor = true;
            this.AddRandomElementButton.Click += new System.EventHandler(this.AddRandomElementButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(25, 246);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(218, 29);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(25, 294);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(218, 29);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SelectElementGroupBox
            // 
            this.SelectElementGroupBox.Controls.Add(this.ElementTypesComboBox);
            this.SelectElementGroupBox.Location = new System.Drawing.Point(12, 12);
            this.SelectElementGroupBox.Name = "SelectElementGroupBox";
            this.SelectElementGroupBox.Size = new System.Drawing.Size(247, 76);
            this.SelectElementGroupBox.TabIndex = 4;
            this.SelectElementGroupBox.TabStop = false;
            this.SelectElementGroupBox.Text = "Select element";
            // 
            // ParametersGgroupBox
            // 
            this.ParametersGgroupBox.Controls.Add(this.resistorUserControl1);
            this.ParametersGgroupBox.Controls.Add(this.capacitorUserControl1);
            this.ParametersGgroupBox.Controls.Add(this.inductorCoilUserControl1);
            this.ParametersGgroupBox.Location = new System.Drawing.Point(12, 107);
            this.ParametersGgroupBox.Name = "ParametersGgroupBox";
            this.ParametersGgroupBox.Size = new System.Drawing.Size(247, 114);
            this.ParametersGgroupBox.TabIndex = 5;
            this.ParametersGgroupBox.TabStop = false;
            this.ParametersGgroupBox.Text = "Parameters";
            // 
            // resistorUserControl1
            // 
            this.resistorUserControl1.Location = new System.Drawing.Point(6, 40);
            this.resistorUserControl1.Name = "resistorUserControl1";
            this.resistorUserControl1.Size = new System.Drawing.Size(228, 58);
            this.resistorUserControl1.TabIndex = 1;
            // 
            // capacitorUserControl1
            // 
            this.capacitorUserControl1.Location = new System.Drawing.Point(19, 26);
            this.capacitorUserControl1.Name = "capacitorUserControl1";
            this.capacitorUserControl1.Size = new System.Drawing.Size(212, 82);
            this.capacitorUserControl1.TabIndex = 0;
            // 
            // inductorCoilUserControl1
            // 
            this.inductorCoilUserControl1.Location = new System.Drawing.Point(6, 23);
            this.inductorCoilUserControl1.Name = "inductorCoilUserControl1";
            this.inductorCoilUserControl1.Size = new System.Drawing.Size(228, 85);
            this.inductorCoilUserControl1.TabIndex = 2;
            // 
            // EnterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 394);
            this.Controls.Add(this.ParametersGgroupBox);
            this.Controls.Add(this.SelectElementGroupBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.AddRandomElementButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "EnterForm";
            this.Text = "EnterForm";
            this.Load += new System.EventHandler(this.EnterForm_Load);
            this.SelectElementGroupBox.ResumeLayout(false);
            this.ParametersGgroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox ElementTypesComboBox;
        private Button AddRandomElementButton;
        private Button OKButton;
        private Button CancelButton;
        private GroupBox SelectElementGroupBox;
        private GroupBox ParametersGgroupBox;
        private CapacitorUserControl capacitorUserControl1;
        private ResistorUserControl resistorUserControl1;
        private InductorCoilUserControl inductorCoilUserControl1;
    }
}