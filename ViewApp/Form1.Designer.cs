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
            this.dgv_TeamsList = new System.Windows.Forms.DataGridView();
            this.TeamsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PersonList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RacesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TeamsList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_PersonList
            // 
            this.dgv_PersonList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_PersonList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_PersonList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_PersonList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PersonList.Location = new System.Drawing.Point(589, 84);
            this.dgv_PersonList.Name = "dgv_PersonList";
            this.dgv_PersonList.RowTemplate.Height = 25;
            this.dgv_PersonList.Size = new System.Drawing.Size(689, 393);
            this.dgv_PersonList.TabIndex = 0;
            // 
            // btn_LoadFile
            // 
            this.btn_LoadFile.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_LoadFile.Location = new System.Drawing.Point(19, 32);
            this.btn_LoadFile.Name = "btn_LoadFile";
            this.btn_LoadFile.Size = new System.Drawing.Size(202, 32);
            this.btn_LoadFile.TabIndex = 1;
            this.btn_LoadFile.Text = "Загрузить файл";
            this.btn_LoadFile.UseVisualStyleBackColor = false;
            this.btn_LoadFile.Click += new System.EventHandler(this.btn_LoadFile_Click);
            // 
            // btn_СheckErrors
            // 
            this.btn_СheckErrors.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_СheckErrors.Location = new System.Drawing.Point(825, 483);
            this.btn_СheckErrors.Name = "btn_СheckErrors";
            this.btn_СheckErrors.Size = new System.Drawing.Size(241, 55);
            this.btn_СheckErrors.TabIndex = 2;
            this.btn_СheckErrors.Text = "Проверить на ошибки";
            this.btn_СheckErrors.UseVisualStyleBackColor = false;
            this.btn_СheckErrors.Click += new System.EventHandler(this.btn_СheckErrors_Click);
            // 
            // dgv_RacesList
            // 
            this.dgv_RacesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_RacesList.BackgroundColor = System.Drawing.SystemColors.Control;
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
            this.PersonsLabel.Location = new System.Drawing.Point(898, 67);
            this.PersonsLabel.Name = "PersonsLabel";
            this.PersonsLabel.Size = new System.Drawing.Size(65, 15);
            this.PersonsLabel.TabIndex = 4;
            this.PersonsLabel.Text = "Участники";
            // 
            // dgv_TeamsList
            // 
            this.dgv_TeamsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_TeamsList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_TeamsList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_TeamsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TeamsList.Location = new System.Drawing.Point(302, 84);
            this.dgv_TeamsList.Name = "dgv_TeamsList";
            this.dgv_TeamsList.RowTemplate.Height = 25;
            this.dgv_TeamsList.Size = new System.Drawing.Size(281, 393);
            this.dgv_TeamsList.TabIndex = 5;
            // 
            // TeamsLabel
            // 
            this.TeamsLabel.AutoSize = true;
            this.TeamsLabel.Location = new System.Drawing.Point(412, 67);
            this.TeamsLabel.Name = "TeamsLabel";
            this.TeamsLabel.Size = new System.Drawing.Size(58, 15);
            this.TeamsLabel.TabIndex = 6;
            this.TeamsLabel.Text = "Команды";
            this.TeamsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1282, 590);
            this.Controls.Add(this.TeamsLabel);
            this.Controls.Add(this.dgv_TeamsList);
            this.Controls.Add(this.PersonsLabel);
            this.Controls.Add(this.RacesLabel);
            this.Controls.Add(this.dgv_RacesList);
            this.Controls.Add(this.btn_СheckErrors);
            this.Controls.Add(this.btn_LoadFile);
            this.Controls.Add(this.dgv_PersonList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PenaltyShootingControl v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PersonList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RacesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TeamsList)).EndInit();
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
        private System.Windows.Forms.DataGridView dgv_TeamsList;
        private System.Windows.Forms.Label TeamsLabel;
    }
}
