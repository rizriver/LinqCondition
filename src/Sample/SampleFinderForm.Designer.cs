namespace Sample
{
    partial class SampleFinderForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAgeTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAgeFrom = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbGenderBoth = new System.Windows.Forms.RadioButton();
            this.rdbGenderFemale = new System.Windows.Forms.RadioButton();
            this.rdbGenderMale = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.rdbPartialMatch = new System.Windows.Forms.RadioButton();
            this.rdbExactMatch = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstBloodType = new System.Windows.Forms.ListBox();
            this.txtExpression = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 235);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(548, 132);
            this.dataGridView1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstBloodType);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAgeTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAgeFrom);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 188);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Condition";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(386, 154);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "BloodType(Multiple Selection)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "-";
            // 
            // txtAgeTo
            // 
            this.txtAgeTo.Location = new System.Drawing.Point(125, 110);
            this.txtAgeTo.Name = "txtAgeTo";
            this.txtAgeTo.Size = new System.Drawing.Size(40, 19);
            this.txtAgeTo.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Age";
            // 
            // txtAgeFrom
            // 
            this.txtAgeFrom.Location = new System.Drawing.Point(56, 110);
            this.txtAgeFrom.Name = "txtAgeFrom";
            this.txtAgeFrom.Size = new System.Drawing.Size(40, 19);
            this.txtAgeFrom.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbGenderBoth);
            this.groupBox2.Controls.Add(this.rdbGenderFemale);
            this.groupBox2.Controls.Add(this.rdbGenderMale);
            this.groupBox2.Location = new System.Drawing.Point(248, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 77);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gender";
            // 
            // rdbGenderBoth
            // 
            this.rdbGenderBoth.AutoSize = true;
            this.rdbGenderBoth.Location = new System.Drawing.Point(181, 32);
            this.rdbGenderBoth.Name = "rdbGenderBoth";
            this.rdbGenderBoth.Size = new System.Drawing.Size(47, 16);
            this.rdbGenderBoth.TabIndex = 7;
            this.rdbGenderBoth.TabStop = true;
            this.rdbGenderBoth.Text = "Both";
            this.rdbGenderBoth.UseVisualStyleBackColor = true;
            // 
            // rdbGenderFemale
            // 
            this.rdbGenderFemale.AutoSize = true;
            this.rdbGenderFemale.Location = new System.Drawing.Point(95, 32);
            this.rdbGenderFemale.Name = "rdbGenderFemale";
            this.rdbGenderFemale.Size = new System.Drawing.Size(60, 16);
            this.rdbGenderFemale.TabIndex = 6;
            this.rdbGenderFemale.TabStop = true;
            this.rdbGenderFemale.Text = "Female";
            this.rdbGenderFemale.UseVisualStyleBackColor = true;
            // 
            // rdbGenderMale
            // 
            this.rdbGenderMale.AutoSize = true;
            this.rdbGenderMale.Location = new System.Drawing.Point(23, 32);
            this.rdbGenderMale.Name = "rdbGenderMale";
            this.rdbGenderMale.Size = new System.Drawing.Size(47, 16);
            this.rdbGenderMale.TabIndex = 5;
            this.rdbGenderMale.TabStop = true;
            this.rdbGenderMale.Text = "Male";
            this.rdbGenderMale.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(467, 154);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(8, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(168, 19);
            this.txtName.TabIndex = 15;
            // 
            // rdbPartialMatch
            // 
            this.rdbPartialMatch.AutoSize = true;
            this.rdbPartialMatch.Location = new System.Drawing.Point(99, 48);
            this.rdbPartialMatch.Name = "rdbPartialMatch";
            this.rdbPartialMatch.Size = new System.Drawing.Size(91, 16);
            this.rdbPartialMatch.TabIndex = 16;
            this.rdbPartialMatch.TabStop = true;
            this.rdbPartialMatch.Text = "Partial Match";
            this.rdbPartialMatch.UseVisualStyleBackColor = true;
            // 
            // rdbExactMatch
            // 
            this.rdbExactMatch.AutoSize = true;
            this.rdbExactMatch.Location = new System.Drawing.Point(6, 48);
            this.rdbExactMatch.Name = "rdbExactMatch";
            this.rdbExactMatch.Size = new System.Drawing.Size(87, 16);
            this.rdbExactMatch.TabIndex = 17;
            this.rdbExactMatch.TabStop = true;
            this.rdbExactMatch.Text = "Exact Match";
            this.rdbExactMatch.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.rdbExactMatch);
            this.groupBox3.Controls.Add(this.rdbPartialMatch);
            this.groupBox3.Location = new System.Drawing.Point(23, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 77);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Name";
            // 
            // lstBloodType
            // 
            this.lstBloodType.FormattingEnabled = true;
            this.lstBloodType.ItemHeight = 12;
            this.lstBloodType.Items.AddRange(new object[] {
            "A",
            "B",
            "O",
            "AB"});
            this.lstBloodType.Location = new System.Drawing.Point(248, 125);
            this.lstBloodType.Name = "lstBloodType";
            this.lstBloodType.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBloodType.Size = new System.Drawing.Size(123, 52);
            this.lstBloodType.TabIndex = 19;
            // 
            // txtExpression
            // 
            this.txtExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpression.Location = new System.Drawing.Point(78, 210);
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.ReadOnly = true;
            this.txtExpression.Size = new System.Drawing.Size(482, 19);
            this.txtExpression.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "Debug Info";
            // 
            // SampleFinderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 379);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtExpression);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SampleFinderForm";
            this.Text = "SampleFinder";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbGenderMale;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rdbGenderFemale;
        private System.Windows.Forms.RadioButton rdbGenderBoth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAgeTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAgeFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RadioButton rdbPartialMatch;
        private System.Windows.Forms.RadioButton rdbExactMatch;
        private System.Windows.Forms.ListBox lstBloodType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtExpression;
        private System.Windows.Forms.Label label1;
    }
}

