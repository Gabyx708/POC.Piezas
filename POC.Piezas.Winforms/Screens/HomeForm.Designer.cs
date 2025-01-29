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
            buttonExportarBom = new Button();
            pictureBoxThumbnail = new PictureBox();
            labelPartNumber = new Label();
            textBoxPartNumber = new TextBox();
            textBoxQuantity = new TextBox();
            textBoxMaterial = new TextBox();
            textBoxDestiny = new TextBox();
            labelQuantity = new Label();
            labelMaterial = new Label();
            labelDestiny = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxThumbnail).BeginInit();
            SuspendLayout();
            // 
            // treeViewAssembly
            // 
            treeViewAssembly.Location = new Point(12, 47);
            treeViewAssembly.Name = "treeViewAssembly";
            treeViewAssembly.Size = new Size(622, 494);
            treeViewAssembly.TabIndex = 0;
            treeViewAssembly.AfterSelect += SelectAssembly;
            // 
            // buttonExportarBom
            // 
            buttonExportarBom.Location = new Point(12, 12);
            buttonExportarBom.Name = "buttonExportarBom";
            buttonExportarBom.Size = new Size(134, 23);
            buttonExportarBom.TabIndex = 2;
            buttonExportarBom.Text = "EXPORTAR BOM ";
            buttonExportarBom.UseVisualStyleBackColor = true;
            buttonExportarBom.Click += ButtonExportarBom_Click;
            // 
            // pictureBoxThumbnail
            // 
            pictureBoxThumbnail.BackColor = SystemColors.ButtonHighlight;
            pictureBoxThumbnail.Location = new Point(651, 47);
            pictureBoxThumbnail.Name = "pictureBoxThumbnail";
            pictureBoxThumbnail.Size = new Size(349, 194);
            pictureBoxThumbnail.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxThumbnail.TabIndex = 3;
            pictureBoxThumbnail.TabStop = false;
            // 
            // labelPartNumber
            // 
            labelPartNumber.AutoSize = true;
            labelPartNumber.Location = new Point(651, 268);
            labelPartNumber.Name = "labelPartNumber";
            labelPartNumber.Size = new Size(87, 15);
            labelPartNumber.TabIndex = 4;
            labelPartNumber.Text = "PART NUMBER:";
            // 
            // textBoxPartNumber
            // 
            textBoxPartNumber.Location = new Point(744, 265);
            textBoxPartNumber.Name = "textBoxPartNumber";
            textBoxPartNumber.Size = new Size(256, 23);
            textBoxPartNumber.TabIndex = 5;
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(744, 321);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(256, 23);
            textBoxQuantity.TabIndex = 6;
            // 
            // textBoxMaterial
            // 
            textBoxMaterial.Location = new Point(744, 389);
            textBoxMaterial.Name = "textBoxMaterial";
            textBoxMaterial.Size = new Size(256, 23);
            textBoxMaterial.TabIndex = 7;
            // 
            // textBoxDestiny
            // 
            textBoxDestiny.Location = new Point(744, 455);
            textBoxDestiny.Name = "textBoxDestiny";
            textBoxDestiny.Size = new Size(256, 23);
            textBoxDestiny.TabIndex = 8;
            // 
            // labelQuantity
            // 
            labelQuantity.AutoSize = true;
            labelQuantity.Location = new Point(670, 325);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(68, 15);
            labelQuantity.TabIndex = 9;
            labelQuantity.Text = "CANTIDAD:";
            // 
            // labelMaterial
            // 
            labelMaterial.AutoSize = true;
            labelMaterial.Location = new Point(674, 393);
            labelMaterial.Name = "labelMaterial";
            labelMaterial.Size = new Size(64, 15);
            labelMaterial.TabIndex = 10;
            labelMaterial.Text = "MATERIAL:";
            // 
            // labelDestiny
            // 
            labelDestiny.AutoSize = true;
            labelDestiny.Location = new Point(683, 459);
            labelDestiny.Name = "labelDestiny";
            labelDestiny.Size = new Size(57, 15);
            labelDestiny.TabIndex = 11;
            labelDestiny.Text = "DESTINO:";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 553);
            Controls.Add(labelDestiny);
            Controls.Add(labelMaterial);
            Controls.Add(labelQuantity);
            Controls.Add(textBoxDestiny);
            Controls.Add(textBoxMaterial);
            Controls.Add(textBoxQuantity);
            Controls.Add(textBoxPartNumber);
            Controls.Add(labelPartNumber);
            Controls.Add(pictureBoxThumbnail);
            Controls.Add(buttonExportarBom);
            Controls.Add(treeViewAssembly);
            Name = "HomeForm";
            Text = "POCg";
            ((System.ComponentModel.ISupportInitialize)pictureBoxThumbnail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeViewAssembly;
        private Button buttonExportarBom;
        private PictureBox pictureBoxThumbnail;
        private Label labelPartNumber;
        private TextBox textBoxPartNumber;
        private TextBox textBoxQuantity;
        private TextBox textBoxMaterial;
        private TextBox textBoxDestiny;
        private Label labelQuantity;
        private Label labelMaterial;
        private Label labelDestiny;
    }
}