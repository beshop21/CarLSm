namespace FirstProject
{
    partial class FrmFIndPerson
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
            this.ctrWithFillter1 = new FirstProject.CTRWithFillter();
            this.SuspendLayout();
            // 
            // ctrWithFillter1
            // 
            this.ctrWithFillter1.Location = new System.Drawing.Point(-5, 12);
            this.ctrWithFillter1.Name = "ctrWithFillter1";
            this.ctrWithFillter1.Size = new System.Drawing.Size(886, 430);
            this.ctrWithFillter1.TabIndex = 0;
            this.ctrWithFillter1.Load += new System.EventHandler(this.ctrWithFillter1_Load);
            // 
            // FrmFIndPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 450);
            this.Controls.Add(this.ctrWithFillter1);
            this.Name = "FrmFIndPerson";
            this.Text = "FrmFIndPerson";
            this.Load += new System.EventHandler(this.FrmFIndPerson_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CTRWithFillter ctrWithFillter1;
    }
}