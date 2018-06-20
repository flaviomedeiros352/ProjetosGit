namespace VerificaBase
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
            this.txtCfg = new System.Windows.Forms.TextBox();
            this.btnSelecionarCfg = new System.Windows.Forms.Button();
            this.btnProcessar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCfg
            // 
            this.txtCfg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCfg.Enabled = false;
            this.txtCfg.Location = new System.Drawing.Point(13, 13);
            this.txtCfg.Name = "txtCfg";
            this.txtCfg.Size = new System.Drawing.Size(635, 20);
            this.txtCfg.TabIndex = 0;
            // 
            // btnSelecionarCfg
            // 
            this.btnSelecionarCfg.Location = new System.Drawing.Point(654, 13);
            this.btnSelecionarCfg.Name = "btnSelecionarCfg";
            this.btnSelecionarCfg.Size = new System.Drawing.Size(20, 20);
            this.btnSelecionarCfg.TabIndex = 1;
            this.btnSelecionarCfg.UseVisualStyleBackColor = true;
            this.btnSelecionarCfg.Click += new System.EventHandler(this.btnSelecionarCfg_Click);
            // 
            // btnProcessar
            // 
            this.btnProcessar.Location = new System.Drawing.Point(13, 40);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(75, 23);
            this.btnProcessar.TabIndex = 2;
            this.btnProcessar.Text = "Processar";
            this.btnProcessar.UseVisualStyleBackColor = true;
            this.btnProcessar.Click += new System.EventHandler(this.btnProcessar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 252);
            this.Controls.Add(this.btnProcessar);
            this.Controls.Add(this.btnSelecionarCfg);
            this.Controls.Add(this.txtCfg);
            this.Name = "Form1";
            this.Text = "Verifica Base";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCfg;
        private System.Windows.Forms.Button btnSelecionarCfg;
        private System.Windows.Forms.Button btnProcessar;
    }
}

