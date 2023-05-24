namespace WinFormsApp
{
    partial class ImpedanceUserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.RealTextBox = new System.Windows.Forms.TextBox();
            this.ImaginaryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RealTextBox
            // 
            this.RealTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RealTextBox.Location = new System.Drawing.Point(3, 3);
            this.RealTextBox.Name = "RealTextBox";
            this.RealTextBox.Size = new System.Drawing.Size(57, 30);
            this.RealTextBox.TabIndex = 0;
            // 
            // ImaginaryTextBox
            // 
            this.ImaginaryTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ImaginaryTextBox.Location = new System.Drawing.Point(99, 3);
            this.ImaginaryTextBox.Name = "ImaginaryTextBox";
            this.ImaginaryTextBox.Size = new System.Drawing.Size(62, 30);
            this.ImaginaryTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(66, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "+  (                  )j,  Ohm";
            // 
            // ImpedanceUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ImaginaryTextBox);
            this.Controls.Add(this.RealTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ImpedanceUserControl";
            this.Size = new System.Drawing.Size(257, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox RealTextBox;
        private TextBox ImaginaryTextBox;
        private Label label1;
    }
}
