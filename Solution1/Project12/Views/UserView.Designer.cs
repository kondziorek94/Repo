namespace Project10.Views
{
    partial class UserView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.oldPasswordPlaceHolderTextBox = new Project10.PlaceHolderTextBox();
            this.userNameTextBox = new Project10.PlaceHolderTextBox();
            this.newPasswordPlaceHolderTextBox1 = new Project10.PlaceHolderTextBox();
            this.newPasswordPlaceHolderTextBox2 = new Project10.PlaceHolderTextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.oldPasswordPlaceHolderTextBox, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.userNameTextBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.newPasswordPlaceHolderTextBox1, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.newPasswordPlaceHolderTextBox2, 0, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(458, 266);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // oldPasswordPlaceHolderTextBox
            // 
            this.oldPasswordPlaceHolderTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oldPasswordPlaceHolderTextBox.Location = new System.Drawing.Point(3, 69);
            this.oldPasswordPlaceHolderTextBox.Name = "oldPasswordPlaceHolderTextBox";
            this.oldPasswordPlaceHolderTextBox.PlaceHolderText = "old password";
            this.oldPasswordPlaceHolderTextBox.Size = new System.Drawing.Size(452, 31);
            this.oldPasswordPlaceHolderTextBox.TabIndex = 4;
            this.oldPasswordPlaceHolderTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.oldPasswordPlaceHolderTextBox_MouseClick);
            this.oldPasswordPlaceHolderTextBox.Enter += new System.EventHandler(this.oldPasswordPlaceHolderTextBox_Enter);
            this.oldPasswordPlaceHolderTextBox.Leave += new System.EventHandler(this.oldPasswordPlaceHolderTextBox_Leave);
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userNameTextBox.Location = new System.Drawing.Point(3, 3);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.PlaceHolderText = "Username";
            this.userNameTextBox.Size = new System.Drawing.Size(452, 31);
            this.userNameTextBox.TabIndex = 0;
            this.userNameTextBox.Text = "Username";
            // 
            // newPasswordPlaceHolderTextBox1
            // 
            this.newPasswordPlaceHolderTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newPasswordPlaceHolderTextBox1.Location = new System.Drawing.Point(3, 135);
            this.newPasswordPlaceHolderTextBox1.Name = "newPasswordPlaceHolderTextBox1";
            this.newPasswordPlaceHolderTextBox1.PlaceHolderText = "new password";
            this.newPasswordPlaceHolderTextBox1.Size = new System.Drawing.Size(452, 31);
            this.newPasswordPlaceHolderTextBox1.TabIndex = 2;
            this.newPasswordPlaceHolderTextBox1.Enter += new System.EventHandler(this.newPasswordPlaceHolderTextBox1_Enter);
            this.newPasswordPlaceHolderTextBox1.Leave += new System.EventHandler(this.newPasswordPlaceHolderTextBox1_Leave);
            // 
            // newPasswordPlaceHolderTextBox2
            // 
            this.newPasswordPlaceHolderTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newPasswordPlaceHolderTextBox2.Location = new System.Drawing.Point(3, 201);
            this.newPasswordPlaceHolderTextBox2.Name = "newPasswordPlaceHolderTextBox2";
            this.newPasswordPlaceHolderTextBox2.PlaceHolderText = "repeat new password";
            this.newPasswordPlaceHolderTextBox2.Size = new System.Drawing.Size(452, 31);
            this.newPasswordPlaceHolderTextBox2.TabIndex = 3;
            this.newPasswordPlaceHolderTextBox2.Enter += new System.EventHandler(this.newPasswordPlaceHolderTextBox2_Enter);
            this.newPasswordPlaceHolderTextBox2.Leave += new System.EventHandler(this.newPasswordPlaceHolderTextBox2_Leave);
            // 
            // UserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "UserView";
            this.Size = new System.Drawing.Size(458, 266);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private PlaceHolderTextBox userNameTextBox;
        private PlaceHolderTextBox oldPasswordPlaceHolderTextBox;
        private PlaceHolderTextBox newPasswordPlaceHolderTextBox1;
        private PlaceHolderTextBox newPasswordPlaceHolderTextBox2;
    }
}
