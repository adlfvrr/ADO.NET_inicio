namespace ModalProductos
{
    partial class Form1
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
            groupBox1 = new GroupBox();
            btnListarS = new Button();
            btnAgregarS = new Button();
            lsbS = new ListBox();
            tbSerie = new TextBox();
            tbStockS = new TextBox();
            tbPrecioS = new TextBox();
            tbModeloS = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnListarI = new Button();
            btnAgregarI = new Button();
            lsbI = new ListBox();
            tbBateria = new TextBox();
            label8 = new Label();
            tbStockI = new TextBox();
            label7 = new Label();
            tbPrecioI = new TextBox();
            label6 = new Label();
            tbModeloI = new TextBox();
            label5 = new Label();
            groupBox3 = new GroupBox();
            lvwCelulares = new ListView();
            groupBox4 = new GroupBox();
            rdbtnIphone = new RadioButton();
            rdbtnSamsung = new RadioButton();
            btnActualizar = new Button();
            btnEliminar = new Button();
            label9 = new Label();
            tbId = new TextBox();
            button1 = new Button();
            btnListar = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnListarS);
            groupBox1.Controls.Add(btnAgregarS);
            groupBox1.Controls.Add(lsbS);
            groupBox1.Controls.Add(tbSerie);
            groupBox1.Controls.Add(tbStockS);
            groupBox1.Controls.Add(tbPrecioS);
            groupBox1.Controls.Add(tbModeloS);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(426, 350);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Celulares Samsung";
            // 
            // btnListarS
            // 
            btnListarS.Location = new Point(282, 156);
            btnListarS.Name = "btnListarS";
            btnListarS.Size = new Size(114, 33);
            btnListarS.TabIndex = 22;
            btnListarS.Text = "Listar";
            btnListarS.UseVisualStyleBackColor = true;
            btnListarS.Click += btnListarS_Click;
            // 
            // btnAgregarS
            // 
            btnAgregarS.Location = new Point(282, 117);
            btnAgregarS.Name = "btnAgregarS";
            btnAgregarS.Size = new Size(114, 33);
            btnAgregarS.TabIndex = 21;
            btnAgregarS.Text = "Agregar";
            btnAgregarS.UseVisualStyleBackColor = true;
            btnAgregarS.Click += btnAgregarS_Click;
            // 
            // lsbS
            // 
            lsbS.FormattingEnabled = true;
            lsbS.Location = new Point(6, 200);
            lsbS.Name = "lsbS";
            lsbS.Size = new Size(405, 144);
            lsbS.TabIndex = 8;
            lsbS.SelectedIndexChanged += lsbS_SelectedIndexChanged;
            // 
            // tbSerie
            // 
            tbSerie.Location = new Point(73, 117);
            tbSerie.Multiline = true;
            tbSerie.Name = "tbSerie";
            tbSerie.Size = new Size(203, 59);
            tbSerie.TabIndex = 7;
            // 
            // tbStockS
            // 
            tbStockS.Location = new Point(297, 36);
            tbStockS.Name = "tbStockS";
            tbStockS.Size = new Size(57, 27);
            tbStockS.TabIndex = 6;
            // 
            // tbPrecioS
            // 
            tbPrecioS.Location = new Point(73, 76);
            tbPrecioS.Name = "tbPrecioS";
            tbPrecioS.Size = new Size(139, 27);
            tbPrecioS.TabIndex = 5;
            // 
            // tbModeloS
            // 
            tbModeloS.Location = new Point(73, 36);
            tbModeloS.Name = "tbModeloS";
            tbModeloS.Size = new Size(139, 27);
            tbModeloS.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(218, 39);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 3;
            label4.Text = "Existencias";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 120);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 2;
            label3.Text = "Serie";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 79);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 1;
            label2.Text = "Precio $";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 39);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 0;
            label1.Text = "Modelo";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnListarI);
            groupBox2.Controls.Add(btnAgregarI);
            groupBox2.Controls.Add(lsbI);
            groupBox2.Controls.Add(tbBateria);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(tbStockI);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(tbPrecioI);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(tbModeloI);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(444, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(458, 350);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Celulares Iphone";
            // 
            // btnListarI
            // 
            btnListarI.Location = new Point(324, 156);
            btnListarI.Name = "btnListarI";
            btnListarI.Size = new Size(114, 33);
            btnListarI.TabIndex = 23;
            btnListarI.Text = "Listar";
            btnListarI.UseVisualStyleBackColor = true;
            btnListarI.Click += btnListarI_Click;
            // 
            // btnAgregarI
            // 
            btnAgregarI.Location = new Point(324, 117);
            btnAgregarI.Name = "btnAgregarI";
            btnAgregarI.Size = new Size(114, 33);
            btnAgregarI.TabIndex = 22;
            btnAgregarI.Text = "Agregar";
            btnAgregarI.UseVisualStyleBackColor = true;
            btnAgregarI.Click += btnAgregarI_Click;
            // 
            // lsbI
            // 
            lsbI.FormattingEnabled = true;
            lsbI.Location = new Point(6, 200);
            lsbI.Name = "lsbI";
            lsbI.Size = new Size(424, 144);
            lsbI.TabIndex = 17;
            lsbI.SelectedIndexChanged += lsbI_SelectedIndexChanged;
            // 
            // tbBateria
            // 
            tbBateria.Location = new Point(110, 117);
            tbBateria.Multiline = true;
            tbBateria.Name = "tbBateria";
            tbBateria.Size = new Size(203, 59);
            tbBateria.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 39);
            label8.Name = "label8";
            label8.Size = new Size(61, 20);
            label8.TabIndex = 9;
            label8.Text = "Modelo";
            // 
            // tbStockI
            // 
            tbStockI.Location = new Point(297, 36);
            tbStockI.Name = "tbStockI";
            tbStockI.Size = new Size(57, 27);
            tbStockI.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 79);
            label7.Name = "label7";
            label7.Size = new Size(62, 20);
            label7.TabIndex = 10;
            label7.Text = "Precio $";
            // 
            // tbPrecioI
            // 
            tbPrecioI.Location = new Point(73, 76);
            tbPrecioI.Name = "tbPrecioI";
            tbPrecioI.Size = new Size(139, 27);
            tbPrecioI.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 120);
            label6.Name = "label6";
            label6.Size = new Size(98, 20);
            label6.TabIndex = 11;
            label6.Text = "Cond. Batería";
            // 
            // tbModeloI
            // 
            tbModeloI.Location = new Point(73, 36);
            tbModeloI.Name = "tbModeloI";
            tbModeloI.Size = new Size(139, 27);
            tbModeloI.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(218, 39);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 12;
            label5.Text = "Existencias";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lvwCelulares);
            groupBox3.Location = new Point(12, 368);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(572, 379);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Celulares";
            // 
            // lvwCelulares
            // 
            lvwCelulares.Font = new Font("Segoe UI", 8F);
            lvwCelulares.Location = new Point(6, 26);
            lvwCelulares.Name = "lvwCelulares";
            lvwCelulares.Size = new Size(554, 347);
            lvwCelulares.TabIndex = 0;
            lvwCelulares.UseCompatibleStateImageBehavior = false;
            lvwCelulares.SelectedIndexChanged += lvwCelulares_SelectedIndexChanged_1;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(rdbtnIphone);
            groupBox4.Controls.Add(rdbtnSamsung);
            groupBox4.Controls.Add(btnActualizar);
            groupBox4.Controls.Add(btnEliminar);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(tbId);
            groupBox4.Controls.Add(button1);
            groupBox4.Controls.Add(btnListar);
            groupBox4.Location = new Point(590, 368);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(312, 373);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Acciones";
            // 
            // rdbtnIphone
            // 
            rdbtnIphone.AutoSize = true;
            rdbtnIphone.Location = new Point(150, 89);
            rdbtnIphone.Name = "rdbtnIphone";
            rdbtnIphone.Size = new Size(73, 24);
            rdbtnIphone.TabIndex = 22;
            rdbtnIphone.TabStop = true;
            rdbtnIphone.Text = "Iphone";
            rdbtnIphone.UseVisualStyleBackColor = true;
            // 
            // rdbtnSamsung
            // 
            rdbtnSamsung.AutoSize = true;
            rdbtnSamsung.Location = new Point(151, 59);
            rdbtnSamsung.Name = "rdbtnSamsung";
            rdbtnSamsung.Size = new Size(87, 24);
            rdbtnSamsung.TabIndex = 21;
            rdbtnSamsung.TabStop = true;
            rdbtnSamsung.Text = "Samsung";
            rdbtnSamsung.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(6, 121);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(129, 53);
            btnActualizar.TabIndex = 20;
            btnActualizar.Text = "Actualizar celular";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(178, 121);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(129, 53);
            btnEliminar.TabIndex = 19;
            btnEliminar.Text = "Eliminar celular";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(150, 29);
            label9.Name = "label9";
            label9.Size = new Size(22, 20);
            label9.TabIndex = 18;
            label9.Text = "Id";
            // 
            // tbId
            // 
            tbId.Location = new Point(178, 26);
            tbId.Name = "tbId";
            tbId.Size = new Size(78, 27);
            tbId.TabIndex = 18;
            // 
            // button1
            // 
            button1.Location = new Point(6, 26);
            button1.Name = "button1";
            button1.Size = new Size(129, 53);
            button1.TabIndex = 1;
            button1.Text = "Listar por (id)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(72, 229);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(177, 84);
            btnListar.TabIndex = 0;
            btnListar.Text = "Listar celulares";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 759);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 11F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Modal Celulares";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListBox lsbS;
        private TextBox tbSerie;
        private TextBox tbStockS;
        private TextBox tbPrecioS;
        private TextBox tbModeloS;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ListBox lsbI;
        private TextBox tbBateria;
        private Label label8;
        private TextBox tbStockI;
        private Label label7;
        private TextBox tbPrecioI;
        private Label label6;
        private TextBox tbModeloI;
        private Label label5;
        private GroupBox groupBox3;
        private ListView lvwCelulares;
        private GroupBox groupBox4;
        private Button btnEliminar;
        private Label label9;
        private TextBox tbId;
        private Button button1;
        private Button btnListar;
        private Button btnActualizar;
        private Button btnAgregarS;
        private Button btnAgregarI;
        private Button btnListarS;
        private Button btnListarI;
        private RadioButton rdbtnIphone;
        private RadioButton rdbtnSamsung;
    }
}