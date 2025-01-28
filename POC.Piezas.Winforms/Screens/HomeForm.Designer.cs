namespace POC.Piezas.Winforms.Screens
{
    partial class HomeForm
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
            treeViewAssembly = new TreeView();
            textBoxFilePath = new TextBox();
            buttonTest = new Button();
            SuspendLayout();
            // 
            // treeViewAssembly
            // 
            treeViewAssembly.Location = new Point(12, 47);
            treeViewAssembly.Name = "treeViewAssembly";
            treeViewAssembly.Size = new Size(661, 369);
            treeViewAssembly.TabIndex = 0;
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Location = new Point(12, 12);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.Size = new Size(353, 23);
            textBoxFilePath.TabIndex = 1;
            // 
            // buttonTest
            // 
            buttonTest.Location = new Point(397, 12);
            buttonTest.Name = "buttonTest";
            buttonTest.Size = new Size(75, 23);
            buttonTest.TabIndex = 2;
            buttonTest.Text = "TEST";
            buttonTest.UseVisualStyleBackColor = true;
            buttonTest.Click += ButtonTest_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonTest);
            Controls.Add(textBoxFilePath);
            Controls.Add(treeViewAssembly);
            Name = "HomeForm";
            Text = "POCg";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeViewAssembly;
        private TextBox textBoxFilePath;
        private Button buttonTest;
    }
}