namespace PhanMemQuanLyShop_00.View
{
    partial class ConThongKeHangNam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConThongKeHangNam));
            this.grChucNang = new DevExpress.XtraEditors.GroupControl();
            this.txtnam = new DevExpress.XtraEditors.SpinEdit();
            this.btnInThongKe = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThongKe = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.grChucNang)).BeginInit();
            this.grChucNang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtnam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grChucNang
            // 
            this.grChucNang.Controls.Add(this.txtnam);
            this.grChucNang.Controls.Add(this.btnInThongKe);
            this.grChucNang.Controls.Add(this.label2);
            this.grChucNang.Controls.Add(this.btnThongKe);
            this.grChucNang.Dock = System.Windows.Forms.DockStyle.Top;
            this.grChucNang.Location = new System.Drawing.Point(0, 0);
            this.grChucNang.Name = "grChucNang";
            this.grChucNang.ShowCaption = false;
            this.grChucNang.Size = new System.Drawing.Size(1182, 130);
            this.grChucNang.TabIndex = 2;
            this.grChucNang.Text = "groupControl1";
            // 
            // txtnam
            // 
            this.txtnam.EditValue = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.txtnam.Location = new System.Drawing.Point(207, 73);
            this.txtnam.Name = "txtnam";
            this.txtnam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtnam.Properties.Mask.EditMask = "d0";
            this.txtnam.Size = new System.Drawing.Size(225, 20);
            this.txtnam.TabIndex = 7;
            // 
            // btnInThongKe
            // 
            this.btnInThongKe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnInThongKe.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInThongKe.Appearance.Options.UseFont = true;
            this.btnInThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnInThongKe.Image")));
            this.btnInThongKe.Location = new System.Drawing.Point(716, 36);
            this.btnInThongKe.Name = "btnInThongKe";
            this.btnInThongKe.Size = new System.Drawing.Size(197, 57);
            this.btnInThongKe.TabIndex = 5;
            this.btnInThongKe.Text = "IN THỐNG KÊ";
            this.btnInThongKe.Click += new System.EventHandler(this.btnInThongKe_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(211, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nhập năm cần thống kê";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThongKe.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Appearance.Options.UseFont = true;
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.Location = new System.Drawing.Point(491, 36);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(197, 57);
            this.btnThongKe.TabIndex = 0;
            this.btnThongKe.Text = "THỐNG KÊ";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click_1);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 20);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1178, 403);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Location = new System.Drawing.Point(0, 136);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1182, 425);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Danh sách thống hàng nhập";
            // 
            // ConThongKeHangNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 561);
            this.Controls.Add(this.grChucNang);
            this.Controls.Add(this.groupControl2);
            this.Name = "ConThongKeHangNam";
            this.Text = "Thống kê hàng nhập theo năm";
            ((System.ComponentModel.ISupportInitialize)(this.grChucNang)).EndInit();
            this.grChucNang.ResumeLayout(false);
            this.grChucNang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtnam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grChucNang;
        private DevExpress.XtraEditors.SpinEdit txtnam;
        private DevExpress.XtraEditors.SimpleButton btnInThongKe;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnThongKe;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}