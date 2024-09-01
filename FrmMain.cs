using DatabaseServiceManager.Common;
using System.Reflection;

namespace DatabaseServiceManager;

public partial class FrmMain : Form
{
    private readonly IService _service;
    public FrmMain(
        IService service)
    {
        _service = service;
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
        notIcon.MouseDoubleClick += NotIcon_MouseDoubleClick;
        notIcon.Visible = true;
    }
    private void ConfigureMenuStrip()
    {
        menuStrip = new ContextMenuStrip();

        foreach (EDatabase db in Enum.GetValues(typeof(EDatabase)))
        {
            var menuItem = new ToolStripMenuItem(db.ToString());
            menuItem.Click += (_, _) => DatabaseMenuItem_Click(db);
            menuStrip.Items.Add(menuItem);
        }

        var exitMenuItem = new ToolStripMenuItem("Sair");
        exitMenuItem.Click += (_, _) => Application.Exit();
        menuStrip.Items.Add(exitMenuItem);
        notIcon.ContextMenuStrip = menuStrip;
    }
    private void CheckCurrentServicesStates()
    {
        foreach (EDatabase db in Enum.GetValues(typeof(EDatabase)))
        {
            var button = GetButtonByDatabase(db);
            var menuItem = GetMenuItemByDatabase(db);
            CheckButton(_service.SetServiceName(db), button);
            CheckMenuStrip(_service.SetServiceName(db), menuItem);
        }
    }
    private void DatabaseMenuItem_Click(EDatabase database)
    {
        _service.SetServiceName(database);
        ExecuteHandler();
    }
    private Button GetButtonByDatabase(EDatabase database)
    {
        return database switch
        {
            EDatabase.Firebird => btnFirebird,
            EDatabase.MySql => btnMySql,
            EDatabase.PostgreSql => btnPostgreSql,
            EDatabase.SqlServer => btnSqlServer,
            _ => throw new ArgumentOutOfRangeException(nameof(database), database, null)
        };
    }
    private ToolStripMenuItem GetMenuItemByDatabase(EDatabase database)
    {
        return menuStrip.Items
            .OfType<ToolStripMenuItem>()
            .First(x => x
                .Text!
                .Contains(database.ToString()));
    }
    private void BtnMySql_Click(object? sender, EventArgs e)
    {
        _service.SetServiceName(EDatabase.MySql);
        ExecuteHandler();
    }
    private void BtnFirebird_Click(object? sender, EventArgs e)
    {
        _service.SetServiceName(EDatabase.Firebird);
        ExecuteHandler();
    }
    private void BtnPostgreSql_Click(object? sender, EventArgs e)
    {
        _service.SetServiceName(EDatabase.PostgreSql);
        ExecuteHandler();
    }
    private void BtnSqlServer_Click(object? sender, EventArgs e)
    {
        _service.SetServiceName(EDatabase.SqlServer);
        ExecuteHandler();
    }
    private void ExecuteHandler()
    {
        var result = _service.ExecuteCommand();
        CheckCurrentServicesStates();
        if (!result.Success)
            MessageBox.Show(result.Error, "Erro", MessageBoxButtons.OK);
    }
    private void CheckButton(IService service, Button btn)
    {
        var result = service.IsServiceRunning();
        btn.Text = result.IsRunning
            ? $"Parar serviço {service.GetServiceName()}"
            : $"Iniciar serviço {service.GetServiceName()}";
    }
    private void CheckMenuStrip(IService service, ToolStripMenuItem menuItem)
    {
        var result = service.IsServiceRunning();
        menuItem.Text = result.IsRunning
            ? $"Parar serviço {service.GetServiceName()}"
            : $"Iniciar serviço {service.GetServiceName()}";
    }
    private void FrmMain_Load(object sender, EventArgs e) => MinimizeToTray();
    private void NotIcon_MouseDoubleClick(object? sender, MouseEventArgs e) => RestoreFromTray();
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