namespace Sistema_De_Facturacion_Ventas.Formularios {
    partial class FormMenuPrincipal {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.msFacturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.msProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.msClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.msHistorial = new System.Windows.Forms.ToolStripMenuItem();
            this.msSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlCardProductos = new System.Windows.Forms.Panel();
            this.txtProductos = new System.Windows.Forms.TextBox();
            this.pnlCardClientes = new System.Windows.Forms.Panel();
            this.txtClientes = new System.Windows.Forms.TextBox();
            this.pnlCardVentas = new System.Windows.Forms.Panel();
            this.txtVentas = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.tmrReloj = new System.Windows.Forms.Timer(this.components);
            this.lblDashboard = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblClientes = new System.Windows.Forms.Label();
            this.lblVentas = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnlCardProductos.SuspendLayout();
            this.pnlCardClientes.SuspendLayout();
            this.pnlCardVentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFacturacion,
            this.msProductos,
            this.msClientes,
            this.msHistorial,
            this.msSalir});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1152, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // msFacturacion
            // 
            this.msFacturacion.Name = "msFacturacion";
            this.msFacturacion.Size = new System.Drawing.Size(93, 23);
            this.msFacturacion.Text = "Facturación";
            this.msFacturacion.Click += new System.EventHandler(this.msFacturacion_Click);
            // 
            // msProductos
            // 
            this.msProductos.Name = "msProductos";
            this.msProductos.Size = new System.Drawing.Size(85, 23);
            this.msProductos.Text = "Inventario";
            this.msProductos.Click += new System.EventHandler(this.msProductos_Click);
            // 
            // msClientes
            // 
            this.msClientes.Name = "msClientes";
            this.msClientes.Size = new System.Drawing.Size(71, 23);
            this.msClientes.Text = "Clientes";
            this.msClientes.Click += new System.EventHandler(this.msClientes_Click);
            // 
            // msHistorial
            // 
            this.msHistorial.Name = "msHistorial";
            this.msHistorial.Size = new System.Drawing.Size(73, 23);
            this.msHistorial.Text = "Historial";
            this.msHistorial.Click += new System.EventHandler(this.msHistorial_Click);
            // 
            // msSalir
            // 
            this.msSalir.Name = "msSalir";
            this.msSalir.Size = new System.Drawing.Size(48, 23);
            this.msSalir.Text = "Salir";
            this.msSalir.Click += new System.EventHandler(this.msSalir_Click);
            // 
            // pnlCardProductos
            // 
            this.pnlCardProductos.AutoSize = true;
            this.pnlCardProductos.BackColor = System.Drawing.Color.White;
            this.pnlCardProductos.Controls.Add(this.txtProductos);
            this.pnlCardProductos.Controls.Add(this.lblProductos);
            this.pnlCardProductos.Location = new System.Drawing.Point(120, 302);
            this.pnlCardProductos.Name = "pnlCardProductos";
            this.pnlCardProductos.Size = new System.Drawing.Size(219, 114);
            this.pnlCardProductos.TabIndex = 2;
            // 
            // txtProductos
            // 
            this.txtProductos.BackColor = System.Drawing.Color.White;
            this.txtProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductos.Location = new System.Drawing.Point(28, 49);
            this.txtProductos.Multiline = true;
            this.txtProductos.Name = "txtProductos";
            this.txtProductos.ReadOnly = true;
            this.txtProductos.Size = new System.Drawing.Size(163, 42);
            this.txtProductos.TabIndex = 6;
            this.txtProductos.TabStop = false;
            this.txtProductos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlCardClientes
            // 
            this.pnlCardClientes.BackColor = System.Drawing.Color.White;
            this.pnlCardClientes.Controls.Add(this.lblClientes);
            this.pnlCardClientes.Controls.Add(this.txtClientes);
            this.pnlCardClientes.Controls.Add(this.label2);
            this.pnlCardClientes.Location = new System.Drawing.Point(477, 307);
            this.pnlCardClientes.Name = "pnlCardClientes";
            this.pnlCardClientes.Size = new System.Drawing.Size(219, 110);
            this.pnlCardClientes.TabIndex = 3;
            // 
            // txtClientes
            // 
            this.txtClientes.BackColor = System.Drawing.Color.White;
            this.txtClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientes.Location = new System.Drawing.Point(28, 42);
            this.txtClientes.Multiline = true;
            this.txtClientes.Name = "txtClientes";
            this.txtClientes.ReadOnly = true;
            this.txtClientes.Size = new System.Drawing.Size(163, 42);
            this.txtClientes.TabIndex = 7;
            this.txtClientes.TabStop = false;
            this.txtClientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlCardVentas
            // 
            this.pnlCardVentas.AutoScroll = true;
            this.pnlCardVentas.AutoSize = true;
            this.pnlCardVentas.BackColor = System.Drawing.Color.White;
            this.pnlCardVentas.Controls.Add(this.lblVentas);
            this.pnlCardVentas.Controls.Add(this.txtVentas);
            this.pnlCardVentas.Location = new System.Drawing.Point(860, 309);
            this.pnlCardVentas.Name = "pnlCardVentas";
            this.pnlCardVentas.Size = new System.Drawing.Size(219, 110);
            this.pnlCardVentas.TabIndex = 4;
            this.pnlCardVentas.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardVentas_Paint);
            // 
            // txtVentas
            // 
            this.txtVentas.BackColor = System.Drawing.Color.White;
            this.txtVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVentas.Location = new System.Drawing.Point(30, 38);
            this.txtVentas.Multiline = true;
            this.txtVentas.Name = "txtVentas";
            this.txtVentas.ReadOnly = true;
            this.txtVentas.Size = new System.Drawing.Size(163, 42);
            this.txtVentas.TabIndex = 8;
            this.txtVentas.TabStop = false;
            this.txtVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVentas.TextChanged += new System.EventHandler(this.txtVentas_TextChanged);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.Font = new System.Drawing.Font("Cascadia Code SemiBold", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(41, 536);
            this.txtUsuario.Multiline = true;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(298, 28);
            this.txtUsuario.TabIndex = 5;
            this.txtUsuario.TabStop = false;
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // txtRol
            // 
            this.txtRol.BackColor = System.Drawing.Color.White;
            this.txtRol.Font = new System.Drawing.Font("Cascadia Code SemiBold", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRol.Location = new System.Drawing.Point(437, 536);
            this.txtRol.Multiline = true;
            this.txtRol.Name = "txtRol";
            this.txtRol.ReadOnly = true;
            this.txtRol.Size = new System.Drawing.Size(238, 28);
            this.txtRol.TabIndex = 7;
            this.txtRol.TabStop = false;
            this.txtRol.TextChanged += new System.EventHandler(this.txtRol_TextChanged);
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.Color.White;
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFecha.Font = new System.Drawing.Font("Cascadia Code SemiBold", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(834, 536);
            this.txtFecha.Multiline = true;
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(268, 28);
            this.txtFecha.TabIndex = 10;
            this.txtFecha.TabStop = false;
            this.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFecha.TextChanged += new System.EventHandler(this.txtFecha_TextChanged);
            // 
            // tmrReloj
            // 
            this.tmrReloj.Interval = 1000;
            this.tmrReloj.Tick += new System.EventHandler(this.tmrReloj_Tick);
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Cascadia Code SemiBold", 26.18182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.Location = new System.Drawing.Point(467, 105);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(229, 52);
            this.lblDashboard.TabIndex = 1;
            this.lblDashboard.Text = "Dashboard";
            this.lblDashboard.Click += new System.EventHandler(this.lblDashboard_Click);
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13.74545F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.Location = new System.Drawing.Point(49, 10);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(120, 28);
            this.lblProductos.TabIndex = 5;
            this.lblProductos.Text = "Productos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13.74545F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, -34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "Clientes";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13.74545F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(926, 505);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(84, 28);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.Click += new System.EventHandler(this.lblFecha_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13.74545F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(127, 492);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(108, 28);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13.74545F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRol.Location = new System.Drawing.Point(481, 498);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(60, 28);
            this.lblRol.TabIndex = 8;
            this.lblRol.Text = "Rol:";
            // 
            // lblClientes
            // 
            this.lblClientes.AutoSize = true;
            this.lblClientes.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13.74545F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientes.Location = new System.Drawing.Point(46, 11);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(108, 28);
            this.lblClientes.TabIndex = 12;
            this.lblClientes.Text = "Clientes";
            this.lblClientes.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblVentas
            // 
            this.lblVentas.AutoSize = true;
            this.lblVentas.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13.74545F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentas.Location = new System.Drawing.Point(66, 11);
            this.lblVentas.Name = "lblVentas";
            this.lblVentas.Size = new System.Drawing.Size(84, 28);
            this.lblVentas.TabIndex = 13;
            this.lblVentas.Text = "Ventas";
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1152, 799);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.txtRol);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.pnlCardVentas);
            this.Controls.Add(this.pnlCardClientes);
            this.Controls.Add(this.pnlCardProductos);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Facturación y Ventas";
            this.Load += new System.EventHandler(this.FormMenuPrincipal_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlCardProductos.ResumeLayout(false);
            this.pnlCardProductos.PerformLayout();
            this.pnlCardClientes.ResumeLayout(false);
            this.pnlCardClientes.PerformLayout();
            this.pnlCardVentas.ResumeLayout(false);
            this.pnlCardVentas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem msFacturacion;
        private System.Windows.Forms.ToolStripMenuItem msProductos;
        private System.Windows.Forms.ToolStripMenuItem msClientes;
        private System.Windows.Forms.ToolStripMenuItem msHistorial;
        private System.Windows.Forms.ToolStripMenuItem msSalir;
        private System.Windows.Forms.Panel pnlCardProductos;
        private System.Windows.Forms.Panel pnlCardClientes;
        private System.Windows.Forms.Panel pnlCardVentas;
        private System.Windows.Forms.TextBox txtProductos;
        private System.Windows.Forms.TextBox txtClientes;
        private System.Windows.Forms.TextBox txtVentas;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Timer tmrReloj;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label lblVentas;
    }
}
