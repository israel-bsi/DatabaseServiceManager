namespace DatabaseServiceManager;

partial class FrmMain
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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
        btnMySql = new Button();
        btnFirebird = new Button();
        btnPostgreSql = new Button();
        btnSqlServer = new Button();
        pictureBox1 = new PictureBox();
        pictureBox2 = new PictureBox();
        pictureBox3 = new PictureBox();
        pictureBox4 = new PictureBox();
        notIcon = new NotifyIcon(components);
        menuStrip = new ContextMenuStrip(components);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
        SuspendLayout();
        // 
        // btnMySql
        // 
        btnMySql.Location = new Point(63, 12);
        btnMySql.Name = "btnMySql";
        btnMySql.Size = new Size(167, 44);
        btnMySql.TabIndex = 0;
        btnMySql.Text = "Iniciar serviço MySQL";
        btnMySql.UseVisualStyleBackColor = true;
        btnMySql.Click += BtnMySql_Click;
        // 
        // btnFirebird
        // 
        btnFirebird.Location = new Point(63, 80);
        btnFirebird.Name = "btnFirebird";
        btnFirebird.Size = new Size(167, 44);
        btnFirebird.TabIndex = 1;
        btnFirebird.Text = "Iniciar serviço Firebird";
        btnFirebird.UseVisualStyleBackColor = true;
        btnFirebird.Click += BtnFirebird_Click;
        // 
        // btnPostgreSql
        // 
        btnPostgreSql.Location = new Point(63, 147);
        btnPostgreSql.Name = "btnPostgreSql";
        btnPostgreSql.Size = new Size(167, 44);
        btnPostgreSql.TabIndex = 2;
        btnPostgreSql.Text = "Iniciar serviço PostgreSQL";
        btnPostgreSql.UseVisualStyleBackColor = true;
        btnPostgreSql.Click += BtnPostgreSql_Click;
        // 
        // btnSqlServer
        // 
        btnSqlServer.Location = new Point(63, 215);
        btnSqlServer.Name = "btnSqlServer";
        btnSqlServer.Size = new Size(167, 44);
        btnSqlServer.TabIndex = 3;
        btnSqlServer.Text = "Iniciar serviço SqlServer";
        btnSqlServer.UseVisualStyleBackColor = true;
        btnSqlServer.Click += BtnSqlServer_Click;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(9, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(48, 44);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 4;
        pictureBox1.TabStop = false;
        // 
        // pictureBox2
        // 
        pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
        pictureBox2.Location = new Point(9, 215);
        pictureBox2.Name = "pictureBox2";
        pictureBox2.Size = new Size(48, 44);
        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox2.TabIndex = 5;
        pictureBox2.TabStop = false;
        // 
        // pictureBox3
        // 
        pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
        pictureBox3.Location = new Point(9, 147);
        pictureBox3.Name = "pictureBox3";
        pictureBox3.Size = new Size(48, 44);
        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox3.TabIndex = 6;
        pictureBox3.TabStop = false;
        // 
        // pictureBox4
        // 
        pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
        pictureBox4.Location = new Point(9, 80);
        pictureBox4.Name = "pictureBox4";
        pictureBox4.Size = new Size(48, 44);
        pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox4.TabIndex = 7;
        pictureBox4.TabStop = false;
        // 
        // notIcon
        // 
        notIcon.Text = "notifyIcon1";
        notIcon.Visible = true;
        notIcon.MouseDoubleClick += NotIcon_MouseDoubleClick;
        // 
        // menuStrip
        // 
        menuStrip.Name = "contextMenuStrip1";
        menuStrip.Size = new Size(61, 4);
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(239, 265);
        Controls.Add(pictureBox4);
        Controls.Add(pictureBox3);
        Controls.Add(pictureBox2);
        Controls.Add(pictureBox1);
        Controls.Add(btnSqlServer);
        Controls.Add(btnPostgreSql);
        Controls.Add(btnFirebird);
        Controls.Add(btnMySql);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "FrmMain";
        Text = "DatabaseServiceManager";
        Load += FrmMain_Load;
        Resize += FrmMain_Resize;
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Button btnMySql;
    private Button btnFirebird;
    private Button btnPostgreSql;
    private Button btnSqlServer;
    private PictureBox pictureBox1;
    private PictureBox pictureBox2;
    private PictureBox pictureBox3;
    private PictureBox pictureBox4;
    private NotifyIcon notIcon;
    private ContextMenuStrip menuStrip;
}
