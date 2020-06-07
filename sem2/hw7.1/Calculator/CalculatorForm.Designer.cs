namespace Calculator
{
    partial class CalculatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculatorForm));
            this.TextBox = new System.Windows.Forms.TextBox();
            this.Label = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonNum7 = new System.Windows.Forms.Button();
            this.ButtonNum8 = new System.Windows.Forms.Button();
            this.ButtonNum9 = new System.Windows.Forms.Button();
            this.ButtonCE = new System.Windows.Forms.Button();
            this.ButtonC = new System.Windows.Forms.Button();
            this.ButtonBack = new System.Windows.Forms.Button();
            this.ButtonDivision = new System.Windows.Forms.Button();
            this.ButtonMultiply = new System.Windows.Forms.Button();
            this.ButtonSubtraction = new System.Windows.Forms.Button();
            this.ButtonPlus = new System.Windows.Forms.Button();
            this.ButtonEquality = new System.Windows.Forms.Button();
            this.ButtonNum4 = new System.Windows.Forms.Button();
            this.ButtonNum5 = new System.Windows.Forms.Button();
            this.ButtonNum6 = new System.Windows.Forms.Button();
            this.ButtonNum1 = new System.Windows.Forms.Button();
            this.ButtonNum2 = new System.Windows.Forms.Button();
            this.ButtonNum3 = new System.Windows.Forms.Button();
            this.ButtonNegate = new System.Windows.Forms.Button();
            this.ButtonNum0 = new System.Windows.Forms.Button();
            this.ButtonPoint = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.TextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.TextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TextBox.Location = new System.Drawing.Point(0, 68);
            this.TextBox.MaxLength = 20;
            this.TextBox.Multiline = true;
            this.TextBox.Name = "TextBox";
            this.TextBox.ReadOnly = true;
            this.TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.TextBox.Size = new System.Drawing.Size(457, 118);
            this.TextBox.TabIndex = 2;
            this.TextBox.Text = "0";
            this.TextBox.WordWrap = false;
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Label.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label.Font = new System.Drawing.Font("Microsoft JhengHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label.Location = new System.Drawing.Point(0, 0);
            this.Label.Margin = new System.Windows.Forms.Padding(0);
            this.Label.Name = "Label";
            this.Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label.Size = new System.Drawing.Size(0, 25);
            this.Label.TabIndex = 3;
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.ButtonNum7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ButtonNum8, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ButtonNum9, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ButtonCE, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonC, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonBack, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonDivision, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonMultiply, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.ButtonSubtraction, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.ButtonPlus, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.ButtonEquality, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.ButtonNum4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ButtonNum5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ButtonNum6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ButtonNum1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ButtonNum2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ButtonNum3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.ButtonNegate, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ButtonNum0, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ButtonPoint, 2, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 192);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.67F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.67F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.67F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.67F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.67F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.65F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(458, 490);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // ButtonNum7
            // 
            this.ButtonNum7.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNum7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonNum7.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonNum7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonNum7.Location = new System.Drawing.Point(3, 101);
            this.ButtonNum7.Name = "ButtonNum7";
            this.ButtonNum7.Size = new System.Drawing.Size(108, 92);
            this.ButtonNum7.TabIndex = 27;
            this.ButtonNum7.Text = "7";
            this.ButtonNum7.UseVisualStyleBackColor = false;
            this.ButtonNum7.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // ButtonNum8
            // 
            this.ButtonNum8.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNum8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonNum8.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonNum8.Location = new System.Drawing.Point(117, 101);
            this.ButtonNum8.Name = "ButtonNum8";
            this.ButtonNum8.Size = new System.Drawing.Size(108, 92);
            this.ButtonNum8.TabIndex = 26;
            this.ButtonNum8.Text = "8";
            this.ButtonNum8.UseVisualStyleBackColor = false;
            this.ButtonNum8.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // ButtonNum9
            // 
            this.ButtonNum9.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNum9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonNum9.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonNum9.Location = new System.Drawing.Point(231, 101);
            this.ButtonNum9.Name = "ButtonNum9";
            this.ButtonNum9.Size = new System.Drawing.Size(108, 92);
            this.ButtonNum9.TabIndex = 25;
            this.ButtonNum9.Text = "9";
            this.ButtonNum9.UseVisualStyleBackColor = false;
            this.ButtonNum9.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // ButtonCE
            // 
            this.ButtonCE.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCE.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonCE.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonCE.Location = new System.Drawing.Point(3, 3);
            this.ButtonCE.Name = "ButtonCE";
            this.ButtonCE.Size = new System.Drawing.Size(108, 92);
            this.ButtonCE.TabIndex = 6;
            this.ButtonCE.Text = "CE";
            this.ButtonCE.UseVisualStyleBackColor = false;
            this.ButtonCE.Click += new System.EventHandler(this.ButtonCE_Click);
            // 
            // ButtonC
            // 
            this.ButtonC.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonC.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonC.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonC.Location = new System.Drawing.Point(117, 3);
            this.ButtonC.Name = "ButtonC";
            this.ButtonC.Size = new System.Drawing.Size(108, 92);
            this.ButtonC.TabIndex = 7;
            this.ButtonC.Text = "C";
            this.ButtonC.UseVisualStyleBackColor = false;
            this.ButtonC.Click += new System.EventHandler(this.ButtonC_Click);
            // 
            // ButtonBack
            // 
            this.ButtonBack.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonBack.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonBack.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonBack.Location = new System.Drawing.Point(231, 3);
            this.ButtonBack.Name = "ButtonBack";
            this.ButtonBack.Size = new System.Drawing.Size(108, 92);
            this.ButtonBack.TabIndex = 8;
            this.ButtonBack.Text = "<=";
            this.ButtonBack.UseVisualStyleBackColor = false;
            this.ButtonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // ButtonDivision
            // 
            this.ButtonDivision.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDivision.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonDivision.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonDivision.Location = new System.Drawing.Point(345, 3);
            this.ButtonDivision.Name = "ButtonDivision";
            this.ButtonDivision.Size = new System.Drawing.Size(110, 92);
            this.ButtonDivision.TabIndex = 11;
            this.ButtonDivision.Text = "/";
            this.ButtonDivision.UseVisualStyleBackColor = false;
            this.ButtonDivision.Click += new System.EventHandler(this.ButtonDivision_Click);
            // 
            // ButtonMultiply
            // 
            this.ButtonMultiply.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMultiply.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonMultiply.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonMultiply.Location = new System.Drawing.Point(345, 101);
            this.ButtonMultiply.Name = "ButtonMultiply";
            this.ButtonMultiply.Size = new System.Drawing.Size(110, 92);
            this.ButtonMultiply.TabIndex = 12;
            this.ButtonMultiply.Text = "*";
            this.ButtonMultiply.UseVisualStyleBackColor = false;
            this.ButtonMultiply.Click += new System.EventHandler(this.ButtonMultiply_Click);
            // 
            // ButtonSubtraction
            // 
            this.ButtonSubtraction.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSubtraction.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonSubtraction.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonSubtraction.Location = new System.Drawing.Point(345, 199);
            this.ButtonSubtraction.Name = "ButtonSubtraction";
            this.ButtonSubtraction.Size = new System.Drawing.Size(110, 92);
            this.ButtonSubtraction.TabIndex = 13;
            this.ButtonSubtraction.Text = "-";
            this.ButtonSubtraction.UseVisualStyleBackColor = false;
            this.ButtonSubtraction.Click += new System.EventHandler(this.ButtonSubtraction_Click);
            // 
            // ButtonPlus
            // 
            this.ButtonPlus.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonPlus.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonPlus.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonPlus.Location = new System.Drawing.Point(345, 297);
            this.ButtonPlus.Name = "ButtonPlus";
            this.ButtonPlus.Size = new System.Drawing.Size(110, 92);
            this.ButtonPlus.TabIndex = 14;
            this.ButtonPlus.Text = "+";
            this.ButtonPlus.UseVisualStyleBackColor = false;
            this.ButtonPlus.Click += new System.EventHandler(this.ButtonPlus_Click);
            // 
            // ButtonEquality
            // 
            this.ButtonEquality.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonEquality.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ButtonEquality.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonEquality.Location = new System.Drawing.Point(345, 395);
            this.ButtonEquality.Name = "ButtonEquality";
            this.ButtonEquality.Size = new System.Drawing.Size(110, 92);
            this.ButtonEquality.TabIndex = 15;
            this.ButtonEquality.Text = "=";
            this.ButtonEquality.UseVisualStyleBackColor = false;
            this.ButtonEquality.Click += new System.EventHandler(this.ButtonEquality_Click);
            // 
            // ButtonNum4
            // 
            this.ButtonNum4.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNum4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonNum4.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonNum4.Location = new System.Drawing.Point(3, 199);
            this.ButtonNum4.Name = "ButtonNum4";
            this.ButtonNum4.Size = new System.Drawing.Size(108, 92);
            this.ButtonNum4.TabIndex = 22;
            this.ButtonNum4.Text = "4";
            this.ButtonNum4.UseVisualStyleBackColor = false;
            this.ButtonNum4.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // ButtonNum5
            // 
            this.ButtonNum5.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNum5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonNum5.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonNum5.Location = new System.Drawing.Point(117, 199);
            this.ButtonNum5.Name = "ButtonNum5";
            this.ButtonNum5.Size = new System.Drawing.Size(108, 92);
            this.ButtonNum5.TabIndex = 23;
            this.ButtonNum5.Text = "5";
            this.ButtonNum5.UseVisualStyleBackColor = false;
            this.ButtonNum5.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // ButtonNum6
            // 
            this.ButtonNum6.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNum6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonNum6.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonNum6.Location = new System.Drawing.Point(231, 199);
            this.ButtonNum6.Name = "ButtonNum6";
            this.ButtonNum6.Size = new System.Drawing.Size(108, 92);
            this.ButtonNum6.TabIndex = 24;
            this.ButtonNum6.Text = "6";
            this.ButtonNum6.UseVisualStyleBackColor = false;
            this.ButtonNum6.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // ButtonNum1
            // 
            this.ButtonNum1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNum1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonNum1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonNum1.Location = new System.Drawing.Point(3, 297);
            this.ButtonNum1.Name = "ButtonNum1";
            this.ButtonNum1.Size = new System.Drawing.Size(108, 92);
            this.ButtonNum1.TabIndex = 19;
            this.ButtonNum1.Text = "1";
            this.ButtonNum1.UseVisualStyleBackColor = false;
            this.ButtonNum1.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // ButtonNum2
            // 
            this.ButtonNum2.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNum2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ButtonNum2.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonNum2.Location = new System.Drawing.Point(117, 297);
            this.ButtonNum2.Name = "ButtonNum2";
            this.ButtonNum2.Size = new System.Drawing.Size(108, 92);
            this.ButtonNum2.TabIndex = 20;
            this.ButtonNum2.Text = "2";
            this.ButtonNum2.UseVisualStyleBackColor = false;
            this.ButtonNum2.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // ButtonNum3
            // 
            this.ButtonNum3.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNum3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ButtonNum3.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonNum3.Location = new System.Drawing.Point(231, 297);
            this.ButtonNum3.Name = "ButtonNum3";
            this.ButtonNum3.Size = new System.Drawing.Size(108, 92);
            this.ButtonNum3.TabIndex = 21;
            this.ButtonNum3.Text = "3";
            this.ButtonNum3.UseVisualStyleBackColor = false;
            this.ButtonNum3.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // ButtonNegate
            // 
            this.ButtonNegate.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNegate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonNegate.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonNegate.Location = new System.Drawing.Point(3, 395);
            this.ButtonNegate.Name = "ButtonNegate";
            this.ButtonNegate.Size = new System.Drawing.Size(108, 92);
            this.ButtonNegate.TabIndex = 16;
            this.ButtonNegate.Text = "+/-";
            this.ButtonNegate.UseVisualStyleBackColor = false;
            this.ButtonNegate.Click += new System.EventHandler(this.ButtonNegate_Click);
            // 
            // ButtonNum0
            // 
            this.ButtonNum0.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonNum0.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonNum0.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonNum0.Location = new System.Drawing.Point(117, 395);
            this.ButtonNum0.Name = "ButtonNum0";
            this.ButtonNum0.Size = new System.Drawing.Size(108, 92);
            this.ButtonNum0.TabIndex = 18;
            this.ButtonNum0.Text = "0";
            this.ButtonNum0.UseVisualStyleBackColor = false;
            this.ButtonNum0.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // ButtonPoint
            // 
            this.ButtonPoint.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonPoint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonPoint.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ButtonPoint.Location = new System.Drawing.Point(231, 395);
            this.ButtonPoint.Name = "ButtonPoint";
            this.ButtonPoint.Size = new System.Drawing.Size(108, 92);
            this.ButtonPoint.TabIndex = 17;
            this.ButtonPoint.Text = ",";
            this.ButtonPoint.UseVisualStyleBackColor = false;
            this.ButtonPoint.Click += new System.EventHandler(this.ButtonPoint_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 62);
            this.panel1.TabIndex = 7;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(458, 694);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.TextBox);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(480, 750);
            this.Name = "CalculatorForm";
            this.Text = "Calculator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button ButtonBack;
        private System.Windows.Forms.Button ButtonC;
        private System.Windows.Forms.Button ButtonCE;
        private System.Windows.Forms.Button ButtonDivision;
        private System.Windows.Forms.Button ButtonEquality;
        private System.Windows.Forms.Button ButtonMultiply;
        private System.Windows.Forms.Button ButtonNegate;
        private System.Windows.Forms.Button ButtonNum0;
        private System.Windows.Forms.Button ButtonNum1;
        private System.Windows.Forms.Button ButtonNum2;
        private System.Windows.Forms.Button ButtonNum3;
        private System.Windows.Forms.Button ButtonNum4;
        private System.Windows.Forms.Button ButtonNum5;
        private System.Windows.Forms.Button ButtonNum6;
        private System.Windows.Forms.Button ButtonNum7;
        private System.Windows.Forms.Button ButtonNum8;
        private System.Windows.Forms.Button ButtonNum9;
        private System.Windows.Forms.Button ButtonPlus;
        private System.Windows.Forms.Button ButtonPoint;
        private System.Windows.Forms.Button ButtonSubtraction;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TextBox;

        #endregion
    }
}

