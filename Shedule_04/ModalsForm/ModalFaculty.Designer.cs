namespace Shedule_04.ModalsForm
{
    partial class ModalFaculty
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAddFaculty = new System.Windows.Forms.TextBox();
            this.addNewFaculty = new System.Windows.Forms.Button();
            this.cancelNewFaculty = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(174, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название факультета";
            // 
            // textBoxAddFaculty
            // 
            this.textBoxAddFaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAddFaculty.Location = new System.Drawing.Point(68, 87);
            this.textBoxAddFaculty.Name = "textBoxAddFaculty";
            this.textBoxAddFaculty.Size = new System.Drawing.Size(408, 26);
            this.textBoxAddFaculty.TabIndex = 1;
            this.textBoxAddFaculty.TextChanged += new System.EventHandler(this.textBoxAddFaculty_TextChanged);
            // 
            // addNewFaculty
            // 
            this.addNewFaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addNewFaculty.Location = new System.Drawing.Point(143, 143);
            this.addNewFaculty.Name = "addNewFaculty";
            this.addNewFaculty.Size = new System.Drawing.Size(118, 34);
            this.addNewFaculty.TabIndex = 2;
            this.addNewFaculty.Text = "Сохранить";
            this.addNewFaculty.UseVisualStyleBackColor = true;
            this.addNewFaculty.Click += new System.EventHandler(this.addNewFaculty_Click);
            // 
            // cancelNewFaculty
            // 
            this.cancelNewFaculty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelNewFaculty.Location = new System.Drawing.Point(286, 143);
            this.cancelNewFaculty.Name = "cancelNewFaculty";
            this.cancelNewFaculty.Size = new System.Drawing.Size(118, 34);
            this.cancelNewFaculty.TabIndex = 3;
            this.cancelNewFaculty.Text = "Отмена";
            this.cancelNewFaculty.UseVisualStyleBackColor = true;
            this.cancelNewFaculty.Click += new System.EventHandler(this.cancelNewFaculty_Click);
            // 
            // ModalFaculty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 233);
            this.ControlBox = false;
            this.Controls.Add(this.cancelNewFaculty);
            this.Controls.Add(this.addNewFaculty);
            this.Controls.Add(this.textBoxAddFaculty);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModalFaculty";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование";
            this.Load += new System.EventHandler(this.ModalFaculty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAddFaculty;
        private System.Windows.Forms.Button addNewFaculty;
        private System.Windows.Forms.Button cancelNewFaculty;
    }
}