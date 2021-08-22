
namespace Mini_Spotify
{
    partial class FrmMain
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
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvPlayList = new System.Windows.Forms.ListView();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(24, 77);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(260, 20);
            this.txtQuery.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Location = new System.Drawing.Point(209, 112);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // lvPlayList
            // 
            this.lvPlayList.HideSelection = false;
            this.lvPlayList.Location = new System.Drawing.Point(24, 161);
            this.lvPlayList.Name = "lvPlayList";
            this.lvPlayList.Size = new System.Drawing.Size(260, 231);
            this.lvPlayList.TabIndex = 2;
            this.lvPlayList.UseCompatibleStateImageBehavior = false;
            this.lvPlayList.Visible = false;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(24, 406);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Visible = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(209, 406);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search for your favorite Artist/Song";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(296, 476);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lvPlayList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtQuery);
            this.ForeColor = System.Drawing.Color.Navy;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mini Spotify";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvPlayList;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
    }
}

