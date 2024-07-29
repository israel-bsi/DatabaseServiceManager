using DatabaseServiceManager.Common;
using DatabaseServiceManager.Services;
using System.Reflection;

namespace DatabaseServiceManager;

public partial class FrmMain : Form
{
    public FrmMain()
    {
        InitializeComponent();
        ConfigureNotifyIcon();
        ConfigureMenuStrip();
        CheckCurrentServicesStates();
    }
    private void ConfigureNotifyIcon()
    {
        notIcon = new NotifyIcon();
        var exePath = Assembly.GetExecutingAssembly().Location;
        notIcon.Icon = Icon.ExtractAssociatedIcon(exePath);
        notIcon.Text = Assembly.GetExecutingAssembly().GetName().Name;
        notIcon.MouseDoubleClick += notIcon_MouseDoubleClick;
        notIcon.Visible = true;
    }
    private void ConfigureMenuStrip()
    {
        menuStrip = new ContextMenuStrip();

        var mysql = new ToolStripMenuItem(EDatabase.MySql.ToString());
        mysql.Click += BtnMySql_Click;
        menuStrip.Items.Add(mysql);

        var firebird = new ToolStripMenuItem(EDatabase.Firebird.ToString());
        firebird.Click += BtnFirebird_Click;
        menuStrip.Items.Add(firebird);

        var postgre = new ToolStripMenuItem(EDatabase.PostgreSql.ToString());
        postgre.Click += BtnPostgreSql_Click;
        menuStrip.Items.Add(postgre);

        var sqlServer = new ToolStripMenuItem(EDatabase.SqlServer.ToString());
        sqlServer.Click += BtnSqlServer_Click;
        menuStrip.Items.Add(sqlServer);

        notIcon.ContextMenuStrip = menuStrip;
    }
    private void BtnMySql_Click(object? sender, EventArgs e)
    {
        ExecuteHandler(new MySqlService(), btnMySql, EDatabase.MySql);
    }
    private void BtnFirebird_Click(object? sender, EventArgs e)
    {
        ExecuteHandler(new FirebirdService(), btnFirebird, EDatabase.Firebird);
    }
    private void BtnPostgreSql_Click(object? sender, EventArgs e)
    {
        ExecuteHandler(new PostgreSqlService(), btnPostgreSql, EDatabase.PostgreSql);
    }
    private void BtnSqlServer_Click(object? sender, EventArgs e)
    {
        ExecuteHandler(new SqlServerService(), btnSqlServer, EDatabase.SqlServer);
    }
    private void ExecuteHandler(IServiceCommand handler, Button button, EDatabase database)
    {
        var result = handler.ExecuteCommand();
        var service = new ServiceInfo(handler, button, database.ToString());
        ServiceInfo.UpdateServiceButton(service);
        if (!result.Success)
            MessageBox.Show(result.Error, "Erro", MessageBoxButtons.OK);
    }
    private void CheckCurrentServicesStates()
    {
        var services = new List<ServiceInfo>
        {
            new(new MySqlService(), btnMySql, "MySQL"),
            new(new FirebirdService(), btnFirebird, "Firebird"),
            new(new SqlServerService(), btnSqlServer, "SqlServer"),
            new(new PostgreSqlService(), btnPostgreSql, "PostgreSQL")
        };

        foreach (var service in services)
        {
            ServiceInfo.UpdateServiceButton(service);
        }
    }
    private void FrmMain_Load(object sender, EventArgs e)
    {
        MinimizeToTray();
    }
    private void notIcon_MouseDoubleClick(object? sender, MouseEventArgs e)
    {
        RestoreFromTray();
    }
    private void FrmMain_Resize(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized)
        {
            MinimizeToTray();
        }
    }
    private void RestoreFromTray()
    {
        Show();
        WindowState = FormWindowState.Normal;
        ShowInTaskbar = true;
        Activate();
    }
    private void MinimizeToTray()
    {
        WindowState = FormWindowState.Minimized;
        ShowInTaskbar = false;
        Hide();
    }
}