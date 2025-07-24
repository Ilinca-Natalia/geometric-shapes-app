namespace GeometricShapes.UI
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
            drawingPanel = new Panel();
            shapeTypeComboBox = new ComboBox();
            colorPanel = new Panel();
            btnColor = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            btnClear = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // drawingPanel
            // 
            drawingPanel.Location = new Point(36, 20);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(702, 417);
            drawingPanel.TabIndex = 0;
            // 
            // shapeTypeComboBox
            // 
            shapeTypeComboBox.FormattingEnabled = true;
            shapeTypeComboBox.Location = new Point(36, 481);
            shapeTypeComboBox.Name = "shapeTypeComboBox";
            shapeTypeComboBox.Size = new Size(250, 28);
            shapeTypeComboBox.TabIndex = 1;
            // 
            // colorPanel
            // 
            colorPanel.Location = new Point(1092, 20);
            colorPanel.Name = "colorPanel";
            colorPanel.Size = new Size(203, 57);
            colorPanel.TabIndex = 2;
            // 
            // btnColor
            // 
            btnColor.Location = new Point(789, 20);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(220, 65);
            btnColor.TabIndex = 3;
            btnColor.Text = "SELECT COLOR";
            btnColor.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(789, 135);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(220, 65);
            btnSave.TabIndex = 4;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(789, 251);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(220, 65);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "LOAD";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(789, 372);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(220, 65);
            btnClear.TabIndex = 6;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1046, 28);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1467, 555);
            Controls.Add(label1);
            Controls.Add(btnClear);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(btnColor);
            Controls.Add(colorPanel);
            Controls.Add(shapeTypeComboBox);
            Controls.Add(drawingPanel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel drawingPanel;
        private ComboBox shapeTypeComboBox;
        private Panel colorPanel;
        private Button btnColor;
        private Button btnSave;
        private Button btnLoad;
        private Button btnClear;
        private Label label1;
    }
}