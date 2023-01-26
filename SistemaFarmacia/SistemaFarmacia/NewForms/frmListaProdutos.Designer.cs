namespace SistemaFarmacia.NewForms
{
    partial class frmListaProdutos
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            BunifuAnimatorNS.Animation animation4 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaProdutos));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lbl_quantExpirados = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label34 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.dgvProdutosExpirados = new System.Windows.Forms.DataGridView();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuTransition1 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.groupBox3.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosExpirados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCancelar);
            this.groupBox3.Controls.Add(this.lbl_quantExpirados);
            this.groupBox3.Controls.Add(this.panel8);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.panel9);
            this.groupBox3.Controls.Add(this.panel10);
            this.groupBox3.Controls.Add(this.dgvProdutosExpirados);
            this.bunifuTransition1.SetDecoration(this.groupBox3, BunifuAnimatorNS.DecorationType.None);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(59, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(591, 433);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Produtos Expirados";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(188)))));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(188)))));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.BorderRadius = 6;
            this.btnCancelar.ButtonText = "FECHAR";
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuTransition1.SetDecoration(this.btnCancelar, BunifuAnimatorNS.DecorationType.None);
            this.btnCancelar.DisabledColor = System.Drawing.Color.Gray;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.LightGreen;
            this.btnCancelar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCancelar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Iconimage")));
            this.btnCancelar.Iconimage_right = null;
            this.btnCancelar.Iconimage_right_Selected = null;
            this.btnCancelar.Iconimage_Selected = null;
            this.btnCancelar.IconMarginLeft = 0;
            this.btnCancelar.IconMarginRight = 0;
            this.btnCancelar.IconRightVisible = false;
            this.btnCancelar.IconRightZoom = 0D;
            this.btnCancelar.IconVisible = false;
            this.btnCancelar.IconZoom = 50D;
            this.btnCancelar.IsTab = false;
            this.btnCancelar.Location = new System.Drawing.Point(434, 378);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(188)))));
            this.btnCancelar.OnHovercolor = System.Drawing.Color.Lime;
            this.btnCancelar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCancelar.selected = false;
            this.btnCancelar.Size = new System.Drawing.Size(135, 30);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "FECHAR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancelar.Textcolor = System.Drawing.Color.LightGreen;
            this.btnCancelar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lbl_quantExpirados
            // 
            this.lbl_quantExpirados.AutoSize = true;
            this.lbl_quantExpirados.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.lbl_quantExpirados, BunifuAnimatorNS.DecorationType.None);
            this.lbl_quantExpirados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_quantExpirados.ForeColor = System.Drawing.Color.Red;
            this.lbl_quantExpirados.Location = new System.Drawing.Point(21, 349);
            this.lbl_quantExpirados.Name = "lbl_quantExpirados";
            this.lbl_quantExpirados.Size = new System.Drawing.Size(153, 20);
            this.lbl_quantExpirados.TabIndex = 23;
            this.lbl_quantExpirados.Text = "*Produtos Expirados";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.RoyalBlue;
            this.bunifuTransition1.SetDecoration(this.panel8, BunifuAnimatorNS.DecorationType.None);
            this.panel8.Location = new System.Drawing.Point(7, 87);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(562, 5);
            this.panel8.TabIndex = 22;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.label28, BunifuAnimatorNS.DecorationType.None);
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(117, 373);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(131, 16);
            this.label28.TabIndex = 15;
            this.label28.Text = "*Produtos Expirados";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Red;
            this.bunifuTransition1.SetDecoration(this.panel9, BunifuAnimatorNS.DecorationType.None);
            this.panel9.Location = new System.Drawing.Point(12, 378);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(105, 10);
            this.panel9.TabIndex = 14;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(115)))), ((int)(((byte)(189)))));
            this.panel10.Controls.Add(this.label34);
            this.panel10.Controls.Add(this.label30);
            this.panel10.Controls.Add(this.label31);
            this.panel10.Controls.Add(this.label32);
            this.panel10.Controls.Add(this.label33);
            this.bunifuTransition1.SetDecoration(this.panel10, BunifuAnimatorNS.DecorationType.None);
            this.panel10.Location = new System.Drawing.Point(8, 57);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(561, 28);
            this.panel10.TabIndex = 11;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.label34, BunifuAnimatorNS.DecorationType.None);
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.White;
            this.label34.Location = new System.Drawing.Point(468, 6);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(60, 16);
            this.label34.TabIndex = 13;
            this.label34.Text = "Unidade";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.label30, BunifuAnimatorNS.DecorationType.None);
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(231, 4);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(114, 16);
            this.label30.TabIndex = 12;
            this.label30.Text = "Data de Validade";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.label31, BunifuAnimatorNS.DecorationType.None);
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.White;
            this.label31.Location = new System.Drawing.Point(124, 4);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(78, 16);
            this.label31.TabIndex = 11;
            this.label31.Text = "Quantidade";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.label32, BunifuAnimatorNS.DecorationType.None);
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(374, 3);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(44, 16);
            this.label32.TabIndex = 10;
            this.label32.Text = "Preço";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTransition1.SetDecoration(this.label33, BunifuAnimatorNS.DecorationType.None);
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(13, 4);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(55, 16);
            this.label33.TabIndex = 1;
            this.label33.Text = "Produto";
            // 
            // dgvProdutosExpirados
            // 
            this.dgvProdutosExpirados.AllowUserToAddRows = false;
            this.dgvProdutosExpirados.AllowUserToDeleteRows = false;
            this.dgvProdutosExpirados.AllowUserToOrderColumns = true;
            this.dgvProdutosExpirados.AllowUserToResizeColumns = false;
            this.dgvProdutosExpirados.AllowUserToResizeRows = false;
            this.dgvProdutosExpirados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdutosExpirados.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgvProdutosExpirados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProdutosExpirados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutosExpirados.ColumnHeadersVisible = false;
            this.bunifuTransition1.SetDecoration(this.dgvProdutosExpirados, BunifuAnimatorNS.DecorationType.None);
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProdutosExpirados.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvProdutosExpirados.GridColor = System.Drawing.Color.Lavender;
            this.dgvProdutosExpirados.Location = new System.Drawing.Point(8, 94);
            this.dgvProdutosExpirados.Name = "dgvProdutosExpirados";
            this.dgvProdutosExpirados.ReadOnly = true;
            this.dgvProdutosExpirados.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProdutosExpirados.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProdutosExpirados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutosExpirados.ShowRowErrors = false;
            this.dgvProdutosExpirados.Size = new System.Drawing.Size(561, 248);
            this.dgvProdutosExpirados.TabIndex = 3;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuTransition1
            // 
            this.bunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
            this.bunifuTransition1.Cursor = null;
            animation4.AnimateOnlyDifferences = true;
            animation4.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.BlindCoeff")));
            animation4.LeafCoeff = 0F;
            animation4.MaxTime = 1F;
            animation4.MinTime = 0F;
            animation4.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicCoeff")));
            animation4.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicShift")));
            animation4.MosaicSize = 0;
            animation4.Padding = new System.Windows.Forms.Padding(0);
            animation4.RotateCoeff = 0F;
            animation4.RotateLimit = 0F;
            animation4.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.ScaleCoeff")));
            animation4.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.SlideCoeff")));
            animation4.TimeCoeff = 0F;
            animation4.TransparencyCoeff = 0F;
            this.bunifuTransition1.DefaultAnimation = animation4;
            // 
            // frmListaProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(660, 487);
            this.Controls.Add(this.groupBox3);
            this.bunifuTransition1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListaProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListaProdutos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmListaProdutos_Load);
            this.MouseEnter += new System.EventHandler(this.frmListaProdutos_MouseEnter);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosExpirados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_quantExpirados;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.DataGridView dgvProdutosExpirados;
        private Bunifu.Framework.UI.BunifuFlatButton btnCancelar;
        private BunifuAnimatorNS.BunifuTransition bunifuTransition1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}