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
            this.btn_СheckErrors = new System.Windows.Forms.Button();
            this.dgv_RacesList = new System.Windows.Forms.DataGridView();
            this.RacesLabel = new System.Windows.Forms.Label();
            this.PersonsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PersonList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RacesList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_PersonList
            // 
            this.dgv_PersonList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_PersonList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_PersonList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PersonList.Location = new System.Drawing.Point(302, 84);
            this.dgv_PersonList.Name = "dgv_PersonList";
            this.dgv_PersonList.RowTemplate.Height = 25;
            this.dgv_PersonList.Size = new System.Drawing.Size(866, 393);
            this.dgv_PersonList.TabIndex = 0;
            // 
            // btn_LoadFile
            // 
            this.btn_LoadFile.Location = new System.Drawing.Point(19, 32);
            this.btn_LoadFile.Name = "btn_LoadFile";
            this.btn_LoadFile.Size = new System.Drawing.Size(202, 32);
            this.btn_LoadFile.TabIndex = 1;
            this.btn_LoadFile.Text = "Загрузить файл";
            this.btn_LoadFile.UseVisualStyleBackColor = true;
            this.btn_LoadFile.Click += new System.EventHandler(this.btn_LoadFile_Click);
            // 
            // btn_СheckErrors
            // 
            this.btn_СheckErrors.Location = new System.Drawing.Point(589, 483);
            this.btn_СheckErrors.Name = "btn_СheckErrors";
            this.btn_СheckErrors.Size = new System.Drawing.Size(241, 55);
            this.btn_СheckErrors.TabIndex = 2;
            this.btn_СheckErrors.Text = "Проверить на ошибки";
            this.btn_СheckErrors.UseVisualStyleBackColor = true;
            this.btn_СheckErrors.Click += new System.EventHandler(this.btn_СheckErrors_Click);
            // 
            // dgv_RacesList
            // 
            this.dgv_RacesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_RacesList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_RacesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RacesList.Location = new System.Drawing.Point(19, 84);
            this.dgv_RacesList.Name = "dgv_RacesList";
            this.dgv_RacesList.RowTemplate.Height = 25;
            this.dgv_RacesList.Size = new System.Drawing.Size(277, 393);
            this.dgv_RacesList.TabIndex = 3;
            // 
            // RacesLabel
            // 
            this.RacesLabel.AutoSize = true;
            this.RacesLabel.Location = new System.Drawing.Point(130, 67);
            this.RacesLabel.Name = "RacesLabel";
            this.RacesLabel.Size = new System.Drawing.Size(40, 15);
            this.RacesLabel.TabIndex = 4;
            this.RacesLabel.Text = "Гонки";
            // 
            // PersonsLabel
            // 
            this.PersonsLabel.AutoSize = true;
            this.PersonsLabel.Location = new System.Drawing.Point(687, 67);
            this.PersonsLabel.Name = "PersonsLabel";
            this.PersonsLabel.Size = new System.Drawing.Size(65, 15);
            this.PersonsLabel.TabIndex = 4;
            this.PersonsLabel.Text = "Участники";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1180, 590);
            this.Controls.Add(this.PersonsLabel);
            this.Controls.Add(this.RacesLabel);
            this.Controls.Add(this.dgv_RacesList);
            this.Controls.Add(this.btn_СheckErrors);
            this.Controls.Add(this.btn_LoadFile);
            this.Controls.Add(this.dgv_PersonList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PersonList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RacesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_PersonList;
        private System.Windows.Forms.Button btn_LoadFile;
        private System.Windows.Forms.Button btn_СheckErrors;
        private System.Windows.Forms.DataGridView dgv_RacesList;
        private System.Windows.Forms.Label RacesLabel;
        private System.Windows.Forms.Label PersonsLabel;
    }
}
