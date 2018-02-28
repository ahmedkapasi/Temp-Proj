namespace RPN_Coder
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
            this.txt_cols = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_gen_flds = new System.Windows.Forms.Button();
            this.grd_col_dtls = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Module_Name = new System.Windows.Forms.TextBox();
            this.chk_grd_actions = new System.Windows.Forms.CheckBox();
            this.grd_actions = new System.Windows.Forms.DataGridView();
            this.btn_add_actions = new System.Windows.Forms.Button();
            this.btn_clr_actions = new System.Windows.Forms.Button();
            this.pnl_grd_actions = new System.Windows.Forms.Panel();
            this.btn_gen_code = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_com_module = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_appFolderPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grd_col_dtls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_actions)).BeginInit();
            this.pnl_grd_actions.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_cols
            // 
            this.txt_cols.Location = new System.Drawing.Point(155, 24);
            this.txt_cols.Name = "txt_cols";
            this.txt_cols.Size = new System.Drawing.Size(240, 20);
            this.txt_cols.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Columns(comma separated)";
            // 
            // btn_gen_flds
            // 
            this.btn_gen_flds.Location = new System.Drawing.Point(412, 22);
            this.btn_gen_flds.Name = "btn_gen_flds";
            this.btn_gen_flds.Size = new System.Drawing.Size(123, 23);
            this.btn_gen_flds.TabIndex = 2;
            this.btn_gen_flds.Text = "Generate Columns";
            this.btn_gen_flds.UseVisualStyleBackColor = true;
            this.btn_gen_flds.Click += new System.EventHandler(this.btn_gen_flds_Click);
            // 
            // grd_col_dtls
            // 
            this.grd_col_dtls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_col_dtls.Location = new System.Drawing.Point(15, 51);
            this.grd_col_dtls.Name = "grd_col_dtls";
            this.grd_col_dtls.Size = new System.Drawing.Size(523, 162);
            this.grd_col_dtls.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Module Name";
            // 
            // txt_Module_Name
            // 
            this.txt_Module_Name.Location = new System.Drawing.Point(106, 230);
            this.txt_Module_Name.Name = "txt_Module_Name";
            this.txt_Module_Name.Size = new System.Drawing.Size(162, 20);
            this.txt_Module_Name.TabIndex = 4;
            // 
            // chk_grd_actions
            // 
            this.chk_grd_actions.AutoSize = true;
            this.chk_grd_actions.Location = new System.Drawing.Point(15, 294);
            this.chk_grd_actions.Name = "chk_grd_actions";
            this.chk_grd_actions.Size = new System.Drawing.Size(83, 17);
            this.chk_grd_actions.TabIndex = 6;
            this.chk_grd_actions.Text = "Grid Actions";
            this.chk_grd_actions.UseVisualStyleBackColor = true;
            this.chk_grd_actions.CheckedChanged += new System.EventHandler(this.chk_grd_actions_CheckedChanged);
            // 
            // grd_actions
            // 
            this.grd_actions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_actions.Location = new System.Drawing.Point(123, 7);
            this.grd_actions.Name = "grd_actions";
            this.grd_actions.Size = new System.Drawing.Size(314, 86);
            this.grd_actions.TabIndex = 7;
            // 
            // btn_add_actions
            // 
            this.btn_add_actions.Location = new System.Drawing.Point(2, 8);
            this.btn_add_actions.Name = "btn_add_actions";
            this.btn_add_actions.Size = new System.Drawing.Size(117, 23);
            this.btn_add_actions.TabIndex = 8;
            this.btn_add_actions.Text = "+Add Action";
            this.btn_add_actions.UseVisualStyleBackColor = true;
            this.btn_add_actions.Click += new System.EventHandler(this.btn_add_actions_Click);
            // 
            // btn_clr_actions
            // 
            this.btn_clr_actions.Location = new System.Drawing.Point(0, 70);
            this.btn_clr_actions.Name = "btn_clr_actions";
            this.btn_clr_actions.Size = new System.Drawing.Size(117, 23);
            this.btn_clr_actions.TabIndex = 9;
            this.btn_clr_actions.Text = "Clear Actions";
            this.btn_clr_actions.UseVisualStyleBackColor = true;
            this.btn_clr_actions.Click += new System.EventHandler(this.btn_clr_actions_Click);
            // 
            // pnl_grd_actions
            // 
            this.pnl_grd_actions.Controls.Add(this.btn_add_actions);
            this.pnl_grd_actions.Controls.Add(this.btn_clr_actions);
            this.pnl_grd_actions.Controls.Add(this.grd_actions);
            this.pnl_grd_actions.Enabled = false;
            this.pnl_grd_actions.Location = new System.Drawing.Point(95, 287);
            this.pnl_grd_actions.Name = "pnl_grd_actions";
            this.pnl_grd_actions.Size = new System.Drawing.Size(443, 96);
            this.pnl_grd_actions.TabIndex = 10;
            // 
            // btn_gen_code
            // 
            this.btn_gen_code.Location = new System.Drawing.Point(175, 417);
            this.btn_gen_code.Name = "btn_gen_code";
            this.btn_gen_code.Size = new System.Drawing.Size(123, 23);
            this.btn_gen_code.TabIndex = 11;
            this.btn_gen_code.Text = "Generate Code";
            this.btn_gen_code.UseVisualStyleBackColor = true;
            this.btn_gen_code.Click += new System.EventHandler(this.btn_gen_code_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Parent Module Name";
            // 
            // txt_com_module
            // 
            this.txt_com_module.Location = new System.Drawing.Point(391, 230);
            this.txt_com_module.Name = "txt_com_module";
            this.txt_com_module.Size = new System.Drawing.Size(141, 20);
            this.txt_com_module.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "_app Folder Path";
            // 
            // txt_appFolderPath
            // 
            this.txt_appFolderPath.Location = new System.Drawing.Point(106, 257);
            this.txt_appFolderPath.Name = "txt_appFolderPath";
            this.txt_appFolderPath.Size = new System.Drawing.Size(429, 20);
            this.txt_appFolderPath.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 480);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_appFolderPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_com_module);
            this.Controls.Add(this.btn_gen_code);
            this.Controls.Add(this.pnl_grd_actions);
            this.Controls.Add(this.chk_grd_actions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Module_Name);
            this.Controls.Add(this.grd_col_dtls);
            this.Controls.Add(this.btn_gen_flds);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_cols);
            this.Name = "Form1";
            this.Text = "RPN Coder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_col_dtls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_actions)).EndInit();
            this.pnl_grd_actions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_cols;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_gen_flds;
        private System.Windows.Forms.DataGridView grd_col_dtls;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Module_Name;
        private System.Windows.Forms.CheckBox chk_grd_actions;
        private System.Windows.Forms.DataGridView grd_actions;
        private System.Windows.Forms.Button btn_add_actions;
        private System.Windows.Forms.Button btn_clr_actions;
        private System.Windows.Forms.Panel pnl_grd_actions;
        private System.Windows.Forms.Button btn_gen_code;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_com_module;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_appFolderPath;
    }
}

