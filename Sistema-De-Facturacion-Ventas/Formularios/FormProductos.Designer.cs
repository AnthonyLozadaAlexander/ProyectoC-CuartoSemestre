namespace Sistema_De_Facturacion_Ventas.Formularios {
    partial class FormProductos {
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpProducto = new System.Windows.Forms.GroupBox();
            this.dvgProductos = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.grpProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Cascadia Code SemiBold", 15.70909F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(154, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(490, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Inventario y Catalogo De Productos";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Cascadia Code SemiBold", 15.70909F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(536, 2);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inventario y Catalogo De Productos";
            // 
            // grpProducto
            // 
            this.grpProducto.Controls.Add(this.button3);
            this.grpProducto.Controls.Add(this.button2);
            this.grpProducto.Controls.Add(this.button1);
            this.grpProducto.Controls.Add(this.btnGuardar);
            this.grpProducto.Controls.Add(this.dvgProductos);
            this.grpProducto.Font = new System.Drawing.Font("Cascadia Code SemiBold", 11.78182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProducto.Location = new System.Drawing.Point(30, 93);
            this.grpProducto.Name = "grpProducto";
            this.grpProducto.Size = new System.Drawing.Size(764, 525);
            this.grpProducto.TabIndex = 2;
            this.grpProducto.TabStop = false;
            this.grpProducto.Text = "DATOS DEL PRODUCTO";
            // 
            // dvgProductos
            // 
            this.dvgProductos.BackgroundColor = System.Drawing.Color.White;
            this.dvgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgProductos.Location = new System.Drawing.Point(40, 299);
            this.dvgProductos.Name = "dvgProductos";
            this.dvgProductos.RowHeadersWidth = 47;
            this.dvgProductos.Size = new System.Drawing.Size(685, 200);
            this.dvgProductos.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(56, 152);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 40);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "[ Guardar ]";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "[ Actualizar ]";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(382, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "[ Eliminar ]";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(544, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 40);
            this.button3.TabIndex = 4;
            this.button3.Text = "[ Limpiar ]";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // FormProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(806, 648);
            this.Controls.Add(this.grpProducto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormProductos";
            this.Text = "[ Eliminar ]";
            this.grpProducto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpProducto;
        private System.Windows.Forms.DataGridView dvgProductos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}