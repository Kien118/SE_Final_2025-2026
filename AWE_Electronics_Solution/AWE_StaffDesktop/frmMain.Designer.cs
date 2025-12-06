namespace AWE_StaffDesktop
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importWarehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliveryShippingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnDelivery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.managementToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit ";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // managementToolStripMenuItem
            // 
            this.managementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsToolStripMenuItem,
            this.importWarehouseToolStripMenuItem,
            this.deliveryShippingToolStripMenuItem,
            this.statisticalToolStripMenuItem});
            this.managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            this.managementToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.managementToolStripMenuItem.Text = "Management";
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.productsToolStripMenuItem.Text = "Products Management";
            this.productsToolStripMenuItem.Click += new System.EventHandler(this.productsToolStripMenuItem_Click);
            // 
            // importWarehouseToolStripMenuItem
            // 
            this.importWarehouseToolStripMenuItem.Name = "importWarehouseToolStripMenuItem";
            this.importWarehouseToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.importWarehouseToolStripMenuItem.Text = "Import Goods";
            this.importWarehouseToolStripMenuItem.Click += new System.EventHandler(this.importWarehouseToolStripMenuItem_Click);
            // 
            // deliveryShippingToolStripMenuItem
            // 
            this.deliveryShippingToolStripMenuItem.Name = "deliveryShippingToolStripMenuItem";
            this.deliveryShippingToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.deliveryShippingToolStripMenuItem.Text = "Delivery / Shipping";
            this.deliveryShippingToolStripMenuItem.Click += new System.EventHandler(this.deliveryShippingToolStripMenuItem_Click);
            // 
            // statisticalToolStripMenuItem
            // 
            this.statisticalToolStripMenuItem.Name = "statisticalToolStripMenuItem";
            this.statisticalToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.statisticalToolStripMenuItem.Text = "Statistical Report";
            this.statisticalToolStripMenuItem.Click += new System.EventHandler(this.statisticsReportToolStripMenuItem_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Location = new System.Drawing.Point(28, 283);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(164, 54);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "Product Management";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(219, 283);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(156, 54);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import GoodsReceipt";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDelivery
            // 
            this.btnDelivery.Location = new System.Drawing.Point(409, 283);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(159, 54);
            this.btnDelivery.TabIndex = 3;
            this.btnDelivery.Text = "Management Delivery Note (Ship)";
            this.btnDelivery.UseVisualStyleBackColor = true;
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(194, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "AWE ELECTRONICS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(253, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "STAFF DESKTOP";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(606, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 54);
            this.button1.TabIndex = 6;
            this.button1.Text = "Statistics Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelivery);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importWarehouseToolStripMenuItem;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnDelivery;
        private System.Windows.Forms.ToolStripMenuItem deliveryShippingToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem statisticalToolStripMenuItem;
    }
}