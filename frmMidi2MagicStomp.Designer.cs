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
            this.comboInput = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(0, 32);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(384, 129);
            this.txtInfo.TabIndex = 0;
            // 
            // comboInput
            // 
            this.comboInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInput.FormattingEnabled = true;
            this.comboInput.Location = new System.Drawing.Point(0, 3);
            this.comboInput.Name = "comboInput";
            this.comboInput.Size = new System.Drawing.Size(384, 23);
            this.comboInput.TabIndex = 0;
            this.comboInput.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // frmMidi2MagicStomp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.comboInput);
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
    private ComboBox comboInput;
}
