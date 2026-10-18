using System;
using System.Windows.Forms;
using System.Drawing;

namespace Sistema_De_Facturacion_Ventas.Formularios
{
    partial class FormFacturacion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            txtTelefono = new TextBox();
            label8 = new Label();
            txtDireccion = new TextBox();
            label7 = new Label();
            textNombres = new TextBox();
            label6 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label5 = new Label();
            grpProducto = new GroupBox();
            button2 = new Button();
            btnAgregar = new Button();
            label12 = new Label();
            nudCantidad = new NumericUpDown();
            label11 = new Label();
            lblStock = new Label();
            lblPrecio = new Label();
            label10 = new Label();
            btnBuscarProducto = new Button();
            cboProductos = new ComboBox();
            label9 = new Label();
            dgvDetalles = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            ColDescripcion = new DataGridViewTextBoxColumn();
            ColCantidad = new DataGridViewTextBoxColumn();
            ColPrecio = new DataGridViewTextBoxColumn();
            colSubtotal = new DataGridViewTextBoxColumn();
            btnLimpiar = new Button();
            btnEmitir = new Button();
            lblsubtotal2 = new Label();
            lblIVA = new Label();
            lblTotalIVA = new Label();
            lblTOTAL = new Label();
            lblTotalFinal = new Label();
            label13 = new Label();
            groupBox1.SuspendLayout();
            grpProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(134, 30);
            label1.TabIndex = 0;
            label1.Text = "Factura Nro:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(152, 28);
            label2.Name = "label2";
            label2.Size = new Size(107, 30);
            label2.TabIndex = 1;
            label2.Text = "FAC-0001";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(642, 28);
            label3.Name = "label3";
            label3.Size = new Size(81, 30);
            label3.TabIndex = 2;
            label3.Text = "Fecha: ";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(729, 28);
            label4.Name = "label4";
            label4.Size = new Size(127, 30);
            label4.TabIndex = 3;
            label4.Text = "15/10/2026";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtDireccion);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(textNombres);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(12, 64);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(826, 141);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "DATOS DEL CLIENTE";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(109, 107);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(427, 23);
            txtTelefono.TabIndex = 12;
            txtTelefono.TextChanged += txtTelefono_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(10, 106);
            label8.Name = "label8";
            label8.Size = new Size(74, 20);
            label8.TabIndex = 11;
            label8.Text = "Teléfono:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(109, 78);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(427, 23);
            txtDireccion.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(6, 77);
            label7.Name = "label7";
            label7.Size = new Size(78, 20);
            label7.TabIndex = 9;
            label7.Text = "Dirección:";
            // 
            // textNombres
            // 
            textNombres.Location = new Point(109, 49);
            textNombres.Name = "textNombres";
            textNombres.Size = new Size(427, 23);
            textNombres.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(9, 48);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 7;
            label6.Text = "Nombre: ";
            label6.Click += label6_Click;
            // 
            // button1
            // 
            button1.Location = new Point(300, 19);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(109, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(171, 23);
            textBox1.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(6, 19);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 5;
            label5.Text = "Cedúla/RUC:";
            // 
            // grpProducto
            // 
            grpProducto.Controls.Add(button2);
            grpProducto.Controls.Add(btnAgregar);
            grpProducto.Controls.Add(label12);
            grpProducto.Controls.Add(nudCantidad);
            grpProducto.Controls.Add(label11);
            grpProducto.Controls.Add(lblStock);
            grpProducto.Controls.Add(lblPrecio);
            grpProducto.Controls.Add(label10);
            grpProducto.Controls.Add(btnBuscarProducto);
            grpProducto.Controls.Add(cboProductos);
            grpProducto.Controls.Add(label9);
            grpProducto.Location = new Point(12, 221);
            grpProducto.Name = "grpProducto";
            grpProducto.Size = new Size(826, 136);
            grpProducto.TabIndex = 5;
            grpProducto.TabStop = false;
            grpProducto.Text = "PRODUCTO";
            // 
            // button2
            // 
            button2.Location = new Point(362, 92);
            button2.Name = "button2";
            button2.Size = new Size(122, 38);
            button2.TabIndex = 23;
            button2.Text = "Eliminar Reglón";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(67, 92);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(122, 38);
            btnAgregar.TabIndex = 22;
            btnAgregar.Text = "Añadir a Factura";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(271, 54);
            label12.Name = "label12";
            label12.Size = new Size(18, 20);
            label12.TabIndex = 21;
            label12.Text = "0";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(443, 54);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(69, 23);
            nudCantidad.TabIndex = 20;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(362, 54);
            label11.Name = "label11";
            label11.Size = new Size(75, 20);
            label11.TabIndex = 19;
            label11.Text = "Cantidad:";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStock.Location = new Point(198, 54);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(52, 20);
            lblStock.TabIndex = 18;
            lblStock.Text = "Stock:";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecio.Location = new Point(101, 54);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(53, 20);
            lblPrecio.TabIndex = 17;
            lblPrecio.Text = "$ 0.00";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(6, 54);
            label10.Name = "label10";
            label10.Size = new Size(56, 20);
            label10.TabIndex = 16;
            label10.Text = "Precio:";
            // 
            // btnBuscarProducto
            // 
            btnBuscarProducto.Location = new Point(362, 19);
            btnBuscarProducto.Name = "btnBuscarProducto";
            btnBuscarProducto.Size = new Size(75, 23);
            btnBuscarProducto.TabIndex = 15;
            btnBuscarProducto.Text = "Buscar";
            btnBuscarProducto.UseVisualStyleBackColor = true;
            // 
            // cboProductos
            // 
            cboProductos.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProductos.FormattingEnabled = true;
            cboProductos.Location = new Point(101, 20);
            cboProductos.Name = "cboProductos";
            cboProductos.Size = new Size(244, 23);
            cboProductos.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(6, 19);
            label9.Name = "label9";
            label9.Size = new Size(77, 20);
            label9.TabIndex = 13;
            label9.Text = "Producto:";
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Columns.AddRange(new DataGridViewColumn[] { colCodigo, ColDescripcion, ColCantidad, ColPrecio, colSubtotal });
            dgvDetalles.Location = new Point(12, 363);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(826, 193);
            dgvDetalles.TabIndex = 6;
            // 
            // colCodigo
            // 
            colCodigo.HeaderText = "Código";
            colCodigo.Name = "colCodigo";
            colCodigo.ReadOnly = true;
            // 
            // ColDescripcion
            // 
            ColDescripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColDescripcion.HeaderText = "Descripción";
            ColDescripcion.Name = "ColDescripcion";
            ColDescripcion.ReadOnly = true;
            // 
            // ColCantidad
            // 
            ColCantidad.HeaderText = "Cantidad";
            ColCantidad.Name = "ColCantidad";
            ColCantidad.ReadOnly = true;
            // 
            // ColPrecio
            // 
            ColPrecio.HeaderText = "Precio";
            ColPrecio.Name = "ColPrecio";
            ColPrecio.ReadOnly = true;
            // 
            // colSubtotal
            // 
            colSubtotal.HeaderText = "SubTotal";
            colSubtotal.Name = "colSubtotal";
            colSubtotal.ReadOnly = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(12, 572);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(165, 35);
            btnLimpiar.TabIndex = 24;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnEmitir
            // 
            btnEmitir.Location = new Point(12, 613);
            btnEmitir.Name = "btnEmitir";
            btnEmitir.Size = new Size(165, 35);
            btnEmitir.TabIndex = 25;
            btnEmitir.Text = "Registrar y Emitir";
            btnEmitir.UseVisualStyleBackColor = true;
            // 
            // lblsubtotal2
            // 
            lblsubtotal2.AutoSize = true;
            lblsubtotal2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblsubtotal2.Location = new Point(743, 572);
            lblsubtotal2.Name = "lblsubtotal2";
            lblsubtotal2.Size = new Size(53, 20);
            lblsubtotal2.TabIndex = 24;
            lblsubtotal2.Text = "$ 0.00";
            // 
            // lblIVA
            // 
            lblIVA.AutoSize = true;
            lblIVA.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIVA.Location = new Point(650, 601);
            lblIVA.Name = "lblIVA";
            lblIVA.Size = new Size(73, 20);
            lblIVA.TabIndex = 26;
            lblIVA.Text = "IVA(15%):";
            // 
            // lblTotalIVA
            // 
            lblTotalIVA.AutoSize = true;
            lblTotalIVA.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalIVA.Location = new Point(743, 601);
            lblTotalIVA.Name = "lblTotalIVA";
            lblTotalIVA.Size = new Size(53, 20);
            lblTotalIVA.TabIndex = 27;
            lblTotalIVA.Text = "$ 0.00";
            // 
            // lblTOTAL
            // 
            lblTOTAL.AutoSize = true;
            lblTOTAL.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTOTAL.Location = new Point(650, 632);
            lblTOTAL.Name = "lblTOTAL";
            lblTOTAL.Size = new Size(73, 25);
            lblTOTAL.TabIndex = 28;
            lblTOTAL.Text = "TOTAL:";
            // 
            // lblTotalFinal
            // 
            lblTotalFinal.AutoSize = true;
            lblTotalFinal.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalFinal.Location = new Point(743, 628);
            lblTotalFinal.Name = "lblTotalFinal";
            lblTotalFinal.Size = new Size(73, 30);
            lblTotalFinal.TabIndex = 29;
            lblTotalFinal.Text = "$ 0.00";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(650, 572);
            label13.Name = "label13";
            label13.Size = new Size(70, 20);
            label13.TabIndex = 30;
            label13.Text = "Subtotal:";
            // 
            // Facturacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(984, 661);
            Controls.Add(label13);
            Controls.Add(lblTotalFinal);
            Controls.Add(lblTOTAL);
            Controls.Add(lblTotalIVA);
            Controls.Add(lblIVA);
            Controls.Add(lblsubtotal2);
            Controls.Add(btnEmitir);
            Controls.Add(btnLimpiar);
            Controls.Add(dgvDetalles);
            Controls.Add(grpProducto);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            Name = "Facturacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "0";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grpProducto.ResumeLayout(false);
            grpProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private TextBox textNombres;
        private Label label6;
        private Button button1;
        private TextBox textBox1;
        private Label label5;
        private Label label7;
        private TextBox txtTelefono;
        private Label label8;
        private TextBox txtDireccion;
        private GroupBox grpProducto;
        private Label label10;
        private Button btnBuscarProducto;
        private ComboBox cboProductos;
        private Label label9;
        private Label label12;
        private NumericUpDown nudCantidad;
        private Label label11;
        private Label lblStock;
        private Label lblPrecio;
        private Button button2;
        private Button btnAgregar;
        private DataGridView dgvDetalles;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn ColDescripcion;
        private DataGridViewTextBoxColumn ColCantidad;
        private DataGridViewTextBoxColumn ColPrecio;
        private DataGridViewTextBoxColumn colSubtotal;
        private Button btnLimpiar;
        private Button btnEmitir;
        private Label lblsubtotal2;
        private Label lblIVA;
        private Label lblTotalIVA;
        private Label lblTOTAL;
        private Label lblTotalFinal;
        private Label label13;
    }
}
