namespace Midi2MagicStomp;

partial class frmMidi2MagicStomp
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
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.checkSoundEditor = new System.Windows.Forms.CheckBox();
            this.comboOutput = new System.Windows.Forms.ComboBox();
            this.comboInput = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(0, 86);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(378, 75);
            this.txtInfo.TabIndex = 4;
            // 
            // checkSoundEditor
            // 
            this.checkSoundEditor.AutoSize = true;
            this.checkSoundEditor.Location = new System.Drawing.Point(12, 32);
            this.checkSoundEditor.Name = "checkSoundEditor";
            this.checkSoundEditor.Size = new System.Drawing.Size(202, 19);
            this.checkSoundEditor.TabIndex = 1;
            this.checkSoundEditor.Text = "Use Sound Editor for MAGICSTOP";
            this.checkSoundEditor.UseVisualStyleBackColor = true;
            // 
            // comboOutput
            // 
            this.comboOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOutput.FormattingEnabled = true;
            this.comboOutput.Location = new System.Drawing.Point(192, 57);
            this.comboOutput.Name = "comboOutput";
            this.comboOutput.Size = new System.Drawing.Size(186, 23);
            this.comboOutput.TabIndex = 3;
            this.comboOutput.SelectedIndexChanged += new System.EventHandler(this.comboOutput_SelectedIndexChanged);
            // 
            // comboInput
            // 
            this.comboInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInput.FormattingEnabled = true;
            this.comboInput.Location = new System.Drawing.Point(0, 57);
            this.comboInput.Name = "comboInput";
            this.comboInput.Size = new System.Drawing.Size(186, 23);
            this.comboInput.TabIndex = 2;
            this.comboInput.SelectedIndexChanged += new System.EventHandler(this.comboInput_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(378, 23);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(311, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmMidi2MagicStomp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.comboOutput);
            this.Controls.Add(this.comboInput);
            this.Controls.Add(this.checkSoundEditor);
            this.Controls.Add(this.txtInfo);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "frmMidi2MagicStomp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Midi2MagicStomp";
            this.Load += new System.EventHandler(this.frmMidi2MagicStomp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private TextBox txtInfo;
    private CheckBox checkSoundEditor;
    private ComboBox comboOutput;
    private ComboBox comboInput;
    private ComboBox comboBox1;
    private Button button1;
    private Button button2;
}
