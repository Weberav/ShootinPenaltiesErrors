namespace ViewApp
{
    partial class Form1
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
            this.dgv_PersonList = new System.Windows.Forms.DataGridView();
            this.btn_LoadFile = new System.Windows.Forms.Button();
            this.btn_OneTwoThree = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PersonList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_PersonList
            // 
            this.dgv_PersonList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_PersonList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PersonList.Location = new System.Drawing.Point(19, 78);
            this.dgv_PersonList.Name = "dgv_PersonList";
            this.dgv_PersonList.RowTemplate.Height = 25;
            this.dgv_PersonList.Size = new System.Drawing.Size(726, 393);
            this.dgv_PersonList.TabIndex = 0;
            // 
            // btn_LoadFile
            // 
            this.btn_LoadFile.Location = new System.Drawing.Point(19, 12);
            this.btn_LoadFile.Name = "btn_LoadFile";
            this.btn_LoadFile.Size = new System.Drawing.Size(212, 58);
            this.btn_LoadFile.TabIndex = 1;
            this.btn_LoadFile.Text = "Загрузить файл";
            this.btn_LoadFile.UseVisualStyleBackColor = true;
            this.btn_LoadFile.Click += new System.EventHandler(this.btn_LoadFile_Click);
            // 
            // btn_OneTwoThree
            // 
            this.btn_OneTwoThree.Location = new System.Drawing.Point(286, 15);
            this.btn_OneTwoThree.Name = "btn_OneTwoThree";
            this.btn_OneTwoThree.Size = new System.Drawing.Size(241, 55);
            this.btn_OneTwoThree.TabIndex = 2;
            this.btn_OneTwoThree.Text = "123";
            this.btn_OneTwoThree.UseVisualStyleBackColor = true;
            this.btn_OneTwoThree.Click += new System.EventHandler(this.btn_OneTwoThree_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 590);
            this.Controls.Add(this.btn_OneTwoThree);
            this.Controls.Add(this.btn_LoadFile);
            this.Controls.Add(this.dgv_PersonList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PersonList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_PersonList;
        private System.Windows.Forms.Button btn_LoadFile;
        private System.Windows.Forms.Button btn_OneTwoThree;
    }
}
